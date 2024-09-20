using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class KeyChecking : System.Web.UI.Page
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


            cmd = new SqlCommand("select * from regtable where uname=@uname and skey=@skey", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("skey", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Response.Redirect("SendImage.aspx");

            }
            else
            {
                Label1.Text = "Invalid UserName or Secret Key.....";
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}