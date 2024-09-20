using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;

public partial class MessageWindow : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected static string avifile = "";
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
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
 //  protected  static string fname = "";

    void DecryptedContent(string data)
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

        string[] c = data.Split(new char[] { ' ' });
        string x = "";
        for (int i = 0; i < c.Length; i++)
        {
            string  z = c[i];
            int count = 0 ;           
            
                for (int j = 0; j < z.Length /3 ; j++)
                {
                    count = j*3 ;
                    string dd = z.Substring(count,  3);


                    if (s.ContainsValue (dd))
                    {
                        
                        int ind =s.IndexOfValue(dd);
                        string y = s.GetKey(ind).ToString();
                        
                        x = x + y;

                    }
                    //count = count + 3;

                }
                x = x + " ";



         
        }
        TextBox2.Visible = true;
        TextBox2.Text = x;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int i, j, p;
        try
        {
            int mno = int.Parse(Request.QueryString["mno"]);

            string mtype = Request.QueryString.Get("MType");
            if (mtype .Equals ("Message"))
            {
                Image2.Visible = false;
               
                e1.Visible = false;
                e2.Visible = false;

                cmd = new SqlCommand("select mvcode,msg from mtable where msgno=@msgno", con);
                cmd.Parameters.AddWithValue("msgno", mno);
                rs = cmd.ExecuteReader();

                string data1 = "";
                int mvcode = 0;
                if (rs.Read())
                {
                    mvcode = int.Parse(rs["mvcode"].ToString ());
                    data1 = rs["msg"].ToString();
                }

                rs.Close();
                cmd.Dispose();

               
                /*byte rno = (byte)mvcode;



                byte[] b1 = Encoding.ASCII.GetBytes(data1);

                for (j = 0; j < b1.Length; j++)
                    b1[j] -= rno;   //Encryption

                TextBox2.Visible = true;
                TextBox2.Text = Encoding.ASCII.GetString(b1);
                data1=Encoding.ASCII.GetString(b1);*/
                DecryptedContent(data1);
                return;


            }

            cmd = new SqlCommand("select msg from msgtable where msgno=@msgno", con);
            cmd.Parameters.AddWithValue("msgno", mno);
            rs = cmd.ExecuteReader();
           
            byte[] data = { 0 };
            if (rs.Read())
                data = (byte[])rs[0];

           rs.Close();
            cmd.Dispose();

            //Reading Message
            int t = (int)data[data.Length - 1]; // type
            int len = (int)data[data.Length - 2]; // no.of digits
            char b;
            string fna = "";
            for (i = data.Length - len - 2; i < data.Length - 2; i++)
            {
                b = (char)data[i];
                fna += b.ToString();
            }
            int mk = int.Parse(fna);
            byte[] s = new byte[data.Length - mk - len - 3];
            byte k = (byte)data[data.Length - fna.Length - 3];  // key
            for (i = 0; i < s.Length; i++)
                s[i] = data[i];

            byte[] d = new byte[mk];
            for (j = s.Length, p = 0; j < (s.Length + mk); j++, p++)
            {
                d[p] = data[j];
                d[p] -= k;
            }

            FileStream ff;

            ff = new FileStream(Server.MapPath ("temp1\\timg1.jpg"), FileMode.OpenOrCreate, FileAccess.Write);
            ff.Write(s, 0, s.Length);
            ff.Close();

           // Image1.ImageUrl = Server.MapPath("temp1\\timg1.jpg");

            Image1.Visible = true;
            Image1.ImageUrl ="~\\temp1\\timg1.jpg";
         
            Image2.Visible = false;
            TextBox2.Visible = false;
            e1.Visible = false;
            e2.Visible = false;
           
                if (t == 0)
                {
                    
                    TextBox2.Visible = true;
                    TextBox2.Text = Encoding.ASCII.GetString(d);
                }

                else if (t == 1)
                {
                
                    Image2.Visible = true;
                    ff = new FileStream(Server.MapPath ("temp1\\timg2.jpg"), FileMode.OpenOrCreate, FileAccess.Write);
                    ff.Write(d, 0, d.Length);
                    ff.Close();
                   // Image2.ImageUrl = Server.MapPath("temp1\\timg2.jpg");
                    Image2.ImageUrl ="~\\temp1\\timg2.jpg";
                }
                else if (t == 2)
                {
                  
                   
                    
                    ff = new FileStream(Server.MapPath("temp1\\myfile.wav"), FileMode.OpenOrCreate, FileAccess.Write);
               //     ff = new FileStream(@"c:\myfile.wav", FileMode.OpenOrCreate, FileAccess.Write);
                    ff.Write(d, 0, d.Length);
                    ff.Close();
                   // fname = Server.MapPath("temp1\\myfile.wav");
                 //   fname = "temp1\\myfile.wav";

                    //    Response.Write("<embed src='c:\\myfile.wav'></embed>");
                    e1.Visible = true;
                }
                else if (t == 3)
                {
                    ff = new FileStream(Server .MapPath ("temp1\\myfile.mp4"), FileMode.OpenOrCreate, FileAccess.Write);
                    ff.Write(d, 0, d.Length);
                    ff.Close();
                    avifile = "temp1/myfile.mp4";

                    //    Response.Write("<embed src='c:\\myfile.avi' ></embed>");
                  //  fname = Server.MapPath("temp1\\myfile.avi");
                 //   fname = "temp1\\myfile.avi";
                    e2.Visible = true;
                    e2.DataBind();
             
            }
        }
        catch (Exception ex)
        {
           Label1 .Text  = ex.Message + "<br>No Contents to Extract from that file";
        }

    }
}