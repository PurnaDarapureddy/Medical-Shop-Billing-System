using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;

namespace Medicines1
{
    public partial class search : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        void getdata()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("proc_getdata", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getdata();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("proc_searchdata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", TextBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Label l1 = (Label)row.FindControl("Label2");
            Label l2 = (Label)row.FindControl("Label6");
            ImageButton b1 = (ImageButton)row.FindControl("ImageButton2");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("proc_insertbag", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", l2.Text);
                cmd.Parameters.AddWithValue("@b", TextBox2.Text);
                double rs = Convert.ToDouble(l2.Text) * Convert.ToDouble(TextBox2.Text);
                cmd.Parameters.AddWithValue("@c", rs);
                cmd.Parameters.AddWithValue("@d", l1.Text);
                cmd.ExecuteNonQuery();
            }
            catch(FormatException f)
            {
                Label8.Visible = true;
            }
            con.Close();
            if(TextBox2.Text!="")
            {
                Label8.Visible = false;
                b1.Visible = false;
            }
        }
    }
}