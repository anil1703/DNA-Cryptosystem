using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewMessage : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
                if (Session["UserName"] != null)
                    TextBox1.Text = Session["UserName"].ToString();


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
            int no = int.Parse (Request.QueryString.Get("mno"));
            string mtype = Request.QueryString.Get("MType");
            if (mtype.Equals("Message"))
            {
                cmd = new SqlCommand("select * from mtable where msgno=@msgno and mkey=@mkey ", con);
                cmd.Parameters.AddWithValue("msgno", no);
                cmd.Parameters.AddWithValue("mkey", TextBox2.Text);
                // cmd.Parameters.AddWithValue("mvcode", TextBox3.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b == false)
                {
                    Label1.Text = "Your Decryption Key  is Invalid.....";
                    return;
                }
                else
                {
                    Response.Redirect("MessageWindow.aspx?mno=" + no + "&MType=" + Request.QueryString.Get("MType"));
                }

            }
            else
            {

                cmd = new SqlCommand("select * from msgtable where msgno=@msgno and mkey=@mkey ", con);
                cmd.Parameters.AddWithValue("msgno", no);
                cmd.Parameters.AddWithValue("mkey", TextBox2.Text);
                // cmd.Parameters.AddWithValue("mvcode", TextBox3.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b == false)
                {
                    Label1.Text = "Your Decryption Key  is Invalid.....";
                    return;
                }
                else
                {
                    Response.Redirect("MessageWindow.aspx?mno=" + no + "&MType=" + Request.QueryString.Get("MType"));
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}