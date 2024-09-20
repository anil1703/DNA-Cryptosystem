using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Text;
using System.Net.Mail;

public partial class SendMessage1 : System.Web.UI.Page
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
            if (i == 3 || i==11)
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
                   // TextBox3.Text = r.Next(1, 9).ToString();
                   // passwordcreation();

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

    void EncryptedContent()
    {

        System.Collections.SortedList s = new System.Collections.SortedList();
        s.Add('a', "aaa");
        s.Add('b', "aac");
        s.Add('c', "aag");
        s.Add('d', "aat");
        s.Add('e', "aca");
        s.Add('f', "acc");
        s.Add('g', "acg");
        s.Add('h', "act");
        s.Add('i', "aga");
        s.Add('j', "agc");
        s.Add('k', "agg");
        s.Add('l', "agt");
        s.Add('m', "ata");
        s.Add('n', "atc");
        s.Add('o', "atg");
        s.Add('p', "att");
        s.Add('q', "caa");
        s.Add('r', "cac");
        s.Add('s', "cag");
        s.Add('t', "cat");
        s.Add('u', "cca");
        s.Add('v', "ccc");
        s.Add('w', "ccg");
        s.Add('x', "cct");
        s.Add('y', "cga");
        s.Add('z', "cgc");


        s.Add('A', "AAA");
        s.Add('B', "AAC");
        s.Add('C', "AAG");
        s.Add('D', "AAT");
        s.Add('E', "ACA");
        s.Add('F', "ACC");
        s.Add('G', "ACG");
        s.Add('H', "ACT");
        s.Add('I', "AGA");
        s.Add('J', "AGC");
        s.Add('K', "AGG");
        s.Add('L', "AGT");
        s.Add('M', "ATA");
        s.Add('N', "ATC");
        s.Add('O', "ATG");
        s.Add('P', "ATT");
        s.Add('Q', "CAA");
        s.Add('R', "CAC");
        s.Add('S', "CAG");
        s.Add('T', "CAT");
        s.Add('U', "CCA");
        s.Add('V', "CCC");
        s.Add('W', "CCG");
        s.Add('X', "CCT");
        s.Add('Y', "CGA");
        s.Add('Z', "CGC");


        s.Add('0', "cgg");
        s.Add('1', "cgt");
        s.Add('2', "cta");
        s.Add('3', "ctc");
        s.Add('4', "ctg");
        s.Add('5', "ctt");
        s.Add('6', "gaa");
        s.Add('7', "gac");
        s.Add('8', "gag");
        s.Add('9', "gat");
        s.Add('~', "gca");
        s.Add('!', "gcc");
        s.Add('@', "gcg");
        s.Add('#', "gct");
        s.Add('$', "gga");
        s.Add('%', "ggc");
        s.Add('/', "ggg");
        s.Add('&', "ggt");
        s.Add('*', "gta");
        s.Add('(', "gtc");
        s.Add(')', "gtg");
        s.Add('_', "gtt");
        s.Add('+', "taa");
        s.Add('?', "tac");
        s.Add('-', "tag");
        s.Add('=', "tat");
        s.Add('{', "tca");
        s.Add('}', "tcc");
        s.Add('[', "tcg");
        s.Add(']', "tct");
        s.Add('|', "tga");
        s.Add(':', "tgc");
        s.Add(';', "tgg");
        s.Add('"', "tgt");
        s.Add('<', "tta");
        s.Add('>', "ttc");
        s.Add(',', "ttg");
        s.Add('.', "ttt");
        string data = TextBox5.Text;
        //char[] c = data.ToLower().ToCharArray();
        char[] c = data.ToCharArray();
        string x = "";
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] != ' ')
            {
                if (s.Contains(c[i]))
                {
                    int ind = s.IndexOfKey(c[i]);
                    string y = s.GetByIndex(ind).ToString();
                    x = x + y;

                }

            }
            else
            {
                x = x + " ";
            }

        }

        TextBox6.Text = x;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

                 EncryptedContent();
             

          }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void MsgEncrypt( byte[] d, int t, byte rno, int n )
    {
        int i;
        byte[] d1 = d;
        string dna = d.Length.ToString();
        byte[] a = new byte[ d.Length + dna.Length + 3];
       
       
        int k =  d.Length;
        a[k] = rno;   // Key
        k++;
        char[] c = new char[dna.Length];
        dna.CopyTo(0, c, 0, c.Length);
        for (i = 0; i < c.Length; i++)
            a[k++] = (byte)c[i];   // file length

        a[k] = (byte)dna.Length; // file len - in no.of digits
        k++;
        a[k] = (byte)(t);   // type
        StoreData(d1, n);
    }

    void mailcoding(string semailid, string spassword, string remailid, string message)
    {
        MailMessage m = new MailMessage();
        m.From = new MailAddress(semailid);
        m.To.Add(remailid);
        m.IsBodyHtml = true;
        m.Subject = "Content Decryption Key";
        m.Body = m.From + "<br>Sending Date :" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "<br>" + message +"<br>Using this Key to Decrypt the Content";
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
                cmd = new SqlCommand("select isnull(max(msgno),0)+1 from mtable", con);
                int msgno = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                string msg = Encoding.ASCII.GetString(Fb);

                cmd = new SqlCommand("insert into mtable values(@msgno,@fromid,@toid,@msg,@msgdate,@mkey,@mvcode)", con);
                cmd.Parameters.AddWithValue("msgno", msgno);
                cmd.Parameters.AddWithValue("fromid", TextBox1.Text);
                cmd.Parameters.AddWithValue("toid", toid);
               // cmd.Parameters.AddWithValue("msg", Fb);
                cmd.Parameters.AddWithValue("msg", msg);
                cmd.Parameters.AddWithValue("msgdate", DateTime.Now);
                cmd.Parameters.AddWithValue("mkey", TextBox2.Text);
                cmd.Parameters.AddWithValue("mvcode", n );
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {

            int j;

             int n = r.Next(1, 5);
             byte rno = (byte)n;     



                /* byte[] b1 = Encoding.ASCII.GetBytes(TextBox5.Text);

                 for (j = 0; j < b1.Length; j++)
                     b1[j] += rno;   //Encryption*/

             byte[] b1 = Encoding.ASCII.GetBytes(TextBox6.Text);

                 MsgEncrypt(b1, 0, rno, n);           


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}