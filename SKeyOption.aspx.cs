using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Collections;

public partial class SKeyOption : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
          

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();

        }

        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    private string GenerateRandomCode()
    {



        Random r = new Random();
        string s = "",s1="";
        s = ((char)r.Next(65, 90)).ToString();
        ArrayList aa = new ArrayList();
        s = s + ((char)r.Next(65, 90)).ToString();
        s = s + ((char)r.Next(65, 90)).ToString();
        s = s + ((char)r.Next(65, 90)).ToString();
        s1 = r.Next(1000, 9999).ToString();
        s = s + s1;
        s1 = "";
        char[] c = s.ToCharArray();
        while (s1.Length != c.Length)
        {
            int n = r.Next(0, c.Length);
            if (!aa.Contains(n))
            {
                s1 = s1 + c[n].ToString();
                aa.Add(n);
            }

        }

     

        /*string s = "";
        Random random = new Random();
        int length = 8;
        for (int i = 0; i < length; i++)
        {
            if (random.Next(0, 4) == 0) //if random.Next() == 0 then we generate a random character
            {
                s += ((char)random.Next(97, 122)).ToString();
            }
            else if (random.Next(0, 3) == 1) //if random.Next() == 0 then we generate a random digit
            {
                s += random.Next(0, 9);
            }
            else
            {
                s += ((char)random.Next(65, 90)).ToString();
            }

        }
        return s;*/
        return s1;
    }

    void mailcoding(string semailid, string spassword, string remailid, string message)
    {
        MailMessage m = new MailMessage();
        m.From = new MailAddress(semailid);
        m.To.Add(remailid);
        m.IsBodyHtml = true;
        m.Subject = "Secret Key :";
        m.Body = m.From + "<br>Sending Date :" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "<br>" + message;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Credentials = new System.Net.NetworkCredential(semailid, spassword);
        smtp.EnableSsl = true;
        smtp.Send(m);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
           try
        {
            
            if (Session["UserDetails"] != null)
            {
                if (RadioButtonList1.SelectedIndex == -1)
                {
                    Label1.Text = "Select Any One Option.....";
                    return;
                }
                string rcode = GenerateRandomCode();
                ArrayList a = (ArrayList)Session["UserDetails"];

                cmd = new SqlCommand("select uid from regtable where uid=@uid", con);
                cmd.Parameters.AddWithValue("uid", a[0].ToString ());
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "UserID Already Found.....";
                    return;
                }
     

                    cmd = new SqlCommand("insert into regtable values(@uid,@name,@mno,@emailid,@squestion,@sanswer,@designation,@rdate,@sphoto,@uname,@pword,@skoption,@skey,@status)", con);

                    cmd.Parameters.AddWithValue("uid", a[0].ToString());
                    cmd.Parameters.AddWithValue("name", a[1].ToString());
                    cmd.Parameters.AddWithValue("mno", a[2].ToString());
                    cmd.Parameters.AddWithValue("emailid", a[3].ToString());
                    cmd.Parameters.AddWithValue("squestion", a[4].ToString());
                    cmd.Parameters.AddWithValue("sanswer", a[5].ToString());
                    cmd.Parameters.AddWithValue("designation", a[6].ToString());
                    cmd.Parameters.AddWithValue("rdate", a[7].ToString());
                    cmd.Parameters.AddWithValue("sphoto", a[8].ToString());
                    cmd.Parameters.AddWithValue("uname", a[9].ToString());
                    cmd.Parameters.AddWithValue("pword", a[10].ToString());
                    cmd.Parameters.AddWithValue("skoption", RadioButtonList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("skey",rcode );
                    cmd.Parameters.AddWithValue("status", "Register");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Label1.Text = "Registration Details Inserted....";




                    if (RadioButtonList1.SelectedIndex == 1)
                    {
                        /*MailMessage mail = new MailMessage();

                        //mail.To.Add("aptech266goodshed@gmail.com");//receiver
                        mail.To.Add(a[4].ToString());//receiver
                        mail.From = new MailAddress("customerproject404nf@gmail.com");//sender
                        mail.Subject = "Secure Key:";

                        string Body = "<b>From:<b>" + mail.From + "<br/>" + "Your Secure Key <br/>" + rcode;
                        mail.Body = Body;

                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address//refer server

                        smtp.Credentials = new System.Net.NetworkCredential("customerproject404nf@gmail.com", "ssiaptech");//Or your Smtp Email ID and Password//security

                        smtp.EnableSsl = true;
                        smtp.Send(mail);*/

                        mailcoding("customerproject404nf@gmail.com", "nowdlnospvmgsoth", a[3].ToString(), "Your Secure Key <br/>" + rcode);

                      
                    }
                }
           
        }
        catch (Exception ex)
        {
           Label1 .Text = ex.Message;
        }
    }
}