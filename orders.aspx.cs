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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        void getorders()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_getorders", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        void getexpirymed()
         {
            /* SqlCommand cmd = new SqlCommand("proc_getexpiry", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@a", DateTime.Now.ToString());
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             da.Fill(ds);
             GridView2.DataSource = ds;
             GridView2.DataBind();*/
            SqlDataAdapter da = new SqlDataAdapter("proc_getexpiry", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        void getReports()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_dailyreport", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView3.DataSource = ds;
            GridView3.DataBind();
        }
       /* void cal()
        {
            double total = 0;
            foreach(GridViewRow row in GridView3.Rows)
            {
                total = total + Convert.ToDouble(row.Cells[4].Text.ToString());
            }
            Label6.Text = total.ToString();
        }*/
       void getTotal()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_day_total", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object p = cmd.ExecuteScalar();
            con.Close();
           // double tot = (Convert.ToDouble(p) * 18 / 100) + Convert.ToDouble(p);
            Label6.Text = p.ToString();
        }
        void getReportTotal()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_prev_total", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", TextBox6.Text);
            cmd.Parameters.AddWithValue("@b", TextBox7.Text);
            object p = cmd.ExecuteScalar();
            con.Close();
            Label6.Text = p.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getorders();
                getexpirymed();
                getReports();
                if ((int)Session["a"] == 0)
                { MultiView1.ActiveViewIndex = 0; }
                else 
                {   MultiView1.ActiveViewIndex = 2;  }
                // cal();
                getTotal();
                Label7.Text = DateTime.Now.ToString();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("proc_getreports", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", TextBox6.Text);
            cmd.Parameters.AddWithValue("@b", TextBox7.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView3.DataSource = ds;
            GridView3.DataBind();
            getReportTotal();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.HeaderRow;
            CheckBox ch = (CheckBox)row.FindControl("CheckBox2");
            if(ch.Checked==true)
            {
                foreach(GridViewRow row1 in GridView1.Rows)
                {
                    CheckBox ck = (CheckBox)row1.FindControl("CheckBox1");
                    ck.Checked = ch.Checked;
                }
            }
            else
            {
                foreach (GridViewRow row1 in GridView1.Rows)
                {
                    CheckBox ck = (CheckBox)row1.FindControl("CheckBox1");
                    ck.Checked = ch.Checked;
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            List<medpurch> set = new List<medpurch>();
            foreach(GridViewRow row1 in GridView1.Rows)
            {
                CheckBox ck = (CheckBox)row1.FindControl("CheckBox1");
                medpurch m = new medpurch();
                m.mid = ((Label)row1.FindControl("Label1")).Text;
                m.mname = ((Label)row1.FindControl("Label2")).Text;
                m.qty = ((Label)row1.FindControl("Label3")).Text;
                if (ck.Checked)
                {
                    set.Add(m);
                }
            }
            Session["order"] = set;
            Server.Transfer("medpurchase.aspx");
        }
    }
}