using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Medicines1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void clear()
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = TextBox6.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_insertmed", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", TextBox1.Text);
            cmd.Parameters.AddWithValue("@b", TextBox2.Text);
            cmd.Parameters.AddWithValue("@c", TextBox3.Text);
            cmd.Parameters.AddWithValue("@d", TextBox4.Text);
            cmd.Parameters.AddWithValue("@e", TextBox5.Text);
            cmd.Parameters.AddWithValue("@f", TextBox6.Text);
            int p = cmd.ExecuteNonQuery();
            if(p!=0)
            {
                clear();
                Label1.Visible = true;
                Label1.Text = "Record inserted";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Record not inserted";
            }    
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}