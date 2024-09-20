using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class Login : System.Web.UI.Page
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            
           
                cmd = new SqlCommand("select * from regtable where uname=@uname and pword=@pword  ", con);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                cmd.Parameters.AddWithValue("pword", TextBox2.Text);
                rs = cmd.ExecuteReader();
                string status = "";
                if (rs.Read())
                {
                   
                    status = rs["status"].ToString().ToLower ();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Invalid Username Or Password.....";
                }
                if (status.Equals("register"))
                {
                    Label1.Text = "Status is Register.Process is Going On.Please Wait......";
                    return;
                }
                else if (status.Equals("notactivated"))
                {
                    Label1.Text = "Your Status is Not Activated......";
                    return;
                }
                else if (status.Equals("activated"))
                {
                    Session.Add("UserName", TextBox1.Text);
                    Response.Redirect("KeyChecking.aspx");
                   // Response.Redirect("SendImage.aspx");
                  //  Response.Redirect("SendMessage.aspx");
                   // Response.Redirect("SendAudioVideo.aspx");
                    //Response.Redirect("Inbox.aspx");
                }
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }

    }
}
