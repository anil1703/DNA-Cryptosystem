using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Net.Mail;

public partial class SendAudioVideo : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    Random r = new Random();
    /*void passwordcreation()
    {
        char[] c = { 'A', 'T', 'G', 'C' };
        string s = "";
        Random x = new Random();
        for (int i = 1; i <= 20; i++)
        {

            int y = x.Next(4);
            if (i ==6 || i == 13)
                s += " ";
            else 
            s += c[y];
        }
        TextBox2.Text = s;

    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();

            TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss.ms tt");
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    // TextBox1.Text = Session["UserName"].ToString();
                   // passwordcreation();
                    //TextBox3.Text = r.Next(1, 9).ToString();

                    cmd = new SqlCommand("select emailid from regtable where uname=@uname", con);
                    cmd.Parameters.AddWithValue("uname", Session["UserName"].ToString());
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox1.Text = rs["emailid"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }

                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "UserName is Invalid .Check RegTable....";
                        return;
                    }

                    cmd = new SqlCommand("select emailid from regtable where emailid<>@emailid", con);
                    cmd.Parameters.AddWithValue("emailid", TextBox1.Text);
                    rs = cmd.ExecuteReader();
                    while (rs.Read())
                        CheckBoxList1.Items.Add(rs["emailid"].ToString());
                    rs.Close();
                    cmd.Dispose();

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    string imagefilepath, datafilepath;

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Text = "Select Option.....";
                return;
            }
            int t=0 ;
            if (RadioButtonList1.SelectedIndex == 0)
                t = 2;
            else if (RadioButtonList1.SelectedIndex == 1)
                t = 3;


            int j;
           // imagefilepath = FileUpload1.PostedFile.FileName;

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("TempFile"));
            FileInfo[] ff1 = d1.GetFiles();
            foreach (FileInfo f2 in ff1)
                f2.Delete();

            imagefilepath = DateTime.Now.Ticks + "_1_" + FileUpload1.FileName;

            FileUpload1.PostedFile.SaveAs(Server.MapPath("TempFile\\") + imagefilepath);
           // datafilepath = FileUpload2.PostedFile.FileName;

            datafilepath = DateTime.Now.Ticks + "_2_" + FileUpload2.FileName;

            FileUpload2.PostedFile.SaveAs(Server.MapPath("TempFile\\") + datafilepath);


            //int n = int.Parse(TextBox3.Text);
            int n = r.Next(1, 5);
            byte rno = (byte)n;

            if (imagefilepath != null)
            {

                FileStream fs = new FileStream(Server.MapPath("TempFile\\") + imagefilepath, FileMode.Open, FileAccess.Read);
                FileInfo f = new FileInfo(imagefilepath);
                byte[] source = new byte[fs.Length];
                fs.Read(source, 0, source.Length);
                fs.Close();

                if (datafilepath != "")
                {
                    fs = new FileStream(Server.MapPath("TempFile\\") + datafilepath, FileMode.Open, FileAccess.Read);
                    byte[] b1 = new byte[fs.Length];
                    fs.Read(b1, 0, b1.Length);
                    for (j = 0; j < fs.Length; j++)
                        b1[j] += rno;       //Encryption
                    fs.Close();

                    MsgEncrypt(source, b1, t, rno, n);
                    //                Label4.Text = "Data Has Been Encrypted ";// and Stored in..." + des;
                }

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void MsgEncrypt(byte[] s, byte[] d, int t, byte rno, int n)
    {
        int i;
        string dna = d.Length.ToString();
        byte[] a = new byte[s.Length + d.Length + dna.Length + 3];
        s.CopyTo(a, 0);
        d.CopyTo(a, s.Length);
        int k = s.Length + d.Length;
        a[k] = rno;   // Key
        k++;
        char[] c = new char[dna.Length];
        dna.CopyTo(0, c, 0, c.Length);
        for (i = 0; i < c.Length; i++)
            a[k++] = (byte)c[i];   // file length

        a[k] = (byte)dna.Length; // file len - in no.of digits
        k++;
        a[k] = (byte)(t);   // type
        StoreData(a, n);

    }

    void mailcoding(string semailid, string spassword, string remailid, string message)
    {
        MailMessage m = new MailMessage();
        m.From = new MailAddress(semailid);
        m.To.Add(remailid);
        m.IsBodyHtml = true;
        m.Subject = "Content Decryption Key";
        m.Body = m.From + "<br>Sending Date :" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "<br>" + message + "<br>Using this Key to Decrypt the Content";
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Credentials = new System.Net.NetworkCredential(semailid, spassword);
        smtp.EnableSsl = true;
        smtp.Send(m);
    }
    void StoreData(byte[] Fb, int n )
    {
        foreach (ListItem litem in CheckBoxList1.Items)
        {
            if (litem.Selected)
            {
                string toid = litem.Text;
                cmd = new SqlCommand("select isnull(max(msgno),0)+1 from msgtable", con);
                int msgno = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into msgtable values(@msgno,@fromid,@toid,@msg,@msgdate,@mkey,@mvcode)", con);
                cmd.Parameters.AddWithValue("msgno", msgno);
                cmd.Parameters.AddWithValue("fromid", TextBox1.Text);
                cmd.Parameters.AddWithValue("toid", toid);
                cmd.Parameters.AddWithValue("msg", Fb);
                cmd.Parameters.AddWithValue("msgdate", DateTime.Now);
                cmd.Parameters.AddWithValue("mkey", TextBox2.Text);
                //cmd.Parameters.AddWithValue("mvcode", TextBox3.Text);
                cmd.Parameters.AddWithValue("mvcode", n);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        Label1.Text = "Data Has Been Encrypted ";

        string message = "Content Decryption is :" + TextBox2.Text;
        foreach (ListItem litem in CheckBoxList1.Items)
        {
            if (litem.Selected)
            {
                string toid = litem.Text;

                mailcoding("customerproject404nf@gmail.com", "nowdlnospvmgsoth", toid, message);
            }
        }

    }
}