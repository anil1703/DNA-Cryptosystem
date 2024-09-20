using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

public partial class Inbox : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
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
            {
                TextBox1.Text = Session["UserName"].ToString();
                bindgrid();
                bindgrid1 ();


            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid()
    {

        DirectoryInfo di = new DirectoryInfo(Server.MapPath("temp"));
        FileInfo[] f1 = di.GetFiles();
        foreach (FileInfo f2 in f1)
            f2.Delete();
        
        adp = new SqlDataAdapter("select * from msgtable where toid=(select emailid from regtable where uname=@uname)", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        int c = 1;
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("msgno", typeof(int));
        dt1.Columns.Add("fromid");
        dt1.Columns.Add("toid");
        dt1.Columns.Add("msg");
        dt1.Columns.Add("msgdate", typeof(DateTime));
        dt1.Columns.Add("mkey");


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            byte[] a = (byte[])dt.Rows [i]["msg"];

            //string fname = @"c:\img" + c.ToString();
            string fn="img"+c .ToString ()+".jpg";
            string fname = Server.MapPath("temp\\" + fn);
            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(a, 0, a.Length);
            fs.Close();
            c++;

            DataRow dr = dt1.NewRow();
            dr[0] = dt.Rows[i]["msgno"].ToString();
            dr[1] = dt.Rows[i]["fromid"].ToString();
            dr[2] = dt.Rows[i]["toid"].ToString();
            //dr[3] = fname;
            dr[3] = fn;
            dr[4] = dt.Rows[i]["msgdate"].ToString();
            dr[5] = dt.Rows[i]["mkey"].ToString();
            dt1.Rows.Add(dr);

        }
        GridView1.DataSource = dt1;
        GridView1.DataBind();


        
    }

    void bindgrid1()
    {

     

        adp = new SqlDataAdapter("select * from mtable where toid=(select emailid from regtable where uname=@uname)", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
    //    int c = 1;
    //    DataTable dt1 = new DataTable();
    //    dt1.Columns.Add("msgno", typeof(int));
    //    dt1.Columns.Add("fromid");
    //    dt1.Columns.Add("toid");
      
    //    dt1.Columns.Add("msgdate", typeof(DateTime));


    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        byte[] a = (byte[])dt.Rows[i]["msg"];

    //        //string fname = @"c:\img" + c.ToString();
    //        string fn = "img" + c.ToString() + ".jpg";
    //        string fname = Server.MapPath("temp\\" + fn);
    //        FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write);
    //        fs.Write(a, 0, a.Length);
    //        fs.Close();
    //        c++;

    //        DataRow dr = dt1.NewRow();
    //        dr[0] = dt.Rows[i]["msgno"].ToString();
    //        dr[1] = dt.Rows[i]["fromid"].ToString();
    //        dr[2] = dt.Rows[i]["toid"].ToString();
    //        //dr[3] = fname;
    //        dr[3] = fn;
    //        dr[4] = dt.Rows[i]["msgdate"].ToString();
    //        dt1.Rows.Add(dr);

    //    }
    //    GridView1.DataSource = dt1;
    //    GridView1.DataBind();

       GridView2.DataSource = dt;
       GridView2.DataBind();

   }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "gk")
            {
                string mkey = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
                Label1.Text = "Key is :" + mkey;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "gk")
            {
                string mkey = GridView2.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
                Label1.Text = "Key is :" + mkey;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}