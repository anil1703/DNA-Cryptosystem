using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class DeleteAllRecords : System.Web.UI.Page
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

            cmd = new SqlCommand("delete from msgtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from mtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from regtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("Photo"));
            FileInfo []f1=d1.GetFiles ();
            foreach (FileInfo f2 in f1 )
                f2.Delete ();


            d1 = new DirectoryInfo(Server.MapPath("temp"));
            f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

           d1 = new DirectoryInfo(Server.MapPath("temp1"));
             f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            d1 = new DirectoryInfo(Server.MapPath("TempFile"));
            f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            Label1.Text = "All Table Records are Deleted......";



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
}