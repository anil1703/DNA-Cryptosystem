using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class GetOfflineSecretKey : System.Web.UI.Page
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
          

            if (!IsPostBack)
                if (Session["UserName"] != null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                }
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

            cmd = new SqlCommand("Select skoption from regtable where uname=@uname ", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            
            rs = cmd.ExecuteReader();
            string skeyoption = "";
            if (rs.Read())
            {
                skeyoption = rs["skoption"].ToString().ToLower() ;
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "UserName Is Invalid.....";
                return;
            }

            if (skeyoption.Equals("online"))
            {
                Label1.Text = "Your Secret Key Option Is OnLine.So View To Your Inbox......";
                return;
            }

            else if (skeyoption.Equals("offline"))
            {

                cmd = new SqlCommand("select skey from regtable where uname=@uname  and emailid=@emailid", con);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
             
                cmd.Parameters.AddWithValue("emailid", TextBox2.Text);
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    Label1.Text = "Secret Key :" + rs["skey"].ToString();
                    rs.Close();
                    cmd.Dispose();


                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Your UserName Or EMailID Is Invalid.....";
                }

            }




        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.Message;
        }

    }
}