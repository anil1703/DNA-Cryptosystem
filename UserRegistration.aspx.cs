using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class UserRegistration : System.Web.UI.Page
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
            TextBox7.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!IsPostBack)
            {
                autonumber();
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void autonumber()
    {
        try 
        {
            cmd = new SqlCommand("select isnull (max(uid),100)+1 from regtable", con);
            TextBox1.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
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
            Image1.ImageUrl = "";
            if (FileUpload1.HasFile)
            {
                string fname = FileUpload1.FileName;
                string ext = fname.Substring(fname.LastIndexOf(".")).ToLower();
                if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".gif") || ext.Equals(".jpeg") || ext.Equals(".bmp"))
                {
                    string fname1 = DateTime.Now.Ticks + "_" + fname;
                    FileUpload1.SaveAs(Server.MapPath("Photo\\" + fname1));
                    Image1.ImageUrl = "~\\Photo\\" + fname1;
                    HiddenField1.Value = fname1;
                }
                else
                    Label1.Text = "Select Only .jpg Or .png Or .gif or .bmp Files.....";

            }
            else
                Label1.Text = "Select File Name....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try 
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Security Question......";
                return;
            }
            if (HiddenField1.Value == "")
            {
                Label1.Text = "File Not Selected....";
                return;
            }

            if (TextBox9.Text == "" || TextBox10.Text == "")
            {
                Label1.Text = "Type Password And Confirm Password Again.....";
                return;
            }

            cmd = new SqlCommand("select uid from regtable where uid=@uid", con);
            cmd.Parameters.AddWithValue("uid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "UserID Already Found.....";
                return ;
            }

            cmd = new SqlCommand("select uname from regtable where uname=@uname", con);
            cmd.Parameters.AddWithValue("uname", TextBox8.Text);
            rs = cmd.ExecuteReader();
             b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "UserName Already Found.....";
                return;
            }

            cmd = new SqlCommand("select mno from regtable where mno=@mno", con);
            cmd.Parameters.AddWithValue("mno", TextBox3.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "MobileNumber Already Found.....";
                return;
            }

            cmd = new SqlCommand("select emailid from regtable where emailid=@emailid", con);
            cmd.Parameters.AddWithValue("emailid", TextBox4.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "EMailID Already Found.....";
                return;
            }
            ArrayList a = new ArrayList();
            a.Add(TextBox1.Text);
            a.Add(TextBox2.Text);
            a.Add(TextBox3.Text);
            a.Add(TextBox4.Text);
            a.Add(DropDownList1.SelectedItem.Text);
            a.Add(TextBox5.Text);
            a.Add(TextBox6.Text);
            a.Add(TextBox7.Text);
            a.Add(HiddenField1.Value);
            a.Add(TextBox8.Text);
            a.Add(TextBox9.Text);
          
            Session.Add("UserDetails", a);
            Response.Redirect("SKeyOption.aspx");

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        DropDownList1.SelectedIndex = 0;
        HiddenField1.Value = "";
        Image1.ImageUrl = "";
        autonumber();
        TextBox7.Text = DateTime.Now.ToString("dd-MMM-yyyy");
    }
}