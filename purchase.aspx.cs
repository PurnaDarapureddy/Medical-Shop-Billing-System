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
    public partial class purchase : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        /*void getbill()
        {
            SqlCommand cmd = new SqlCommand("proc_getbill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", Label1.Text);
            cmd.Parameters.AddWithValue("@b", Label5.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }*/
        void getbill2()
        {
            
                 List<billclass> b1 = Session["bill"] as List<billclass>;
                 GridView1.DataSource = b1;
                 GridView1.DataBind();
  
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Session["cname"].ToString();
                Label2.Text = Session["phno"].ToString();
                Label3.Text = Session["gender"].ToString();
                Label4.Text = Session["age"].ToString();
                Label5.Text = DateTime.Now.ToString();
               // getbill();
                getbill2();
                Label7.Text = Session["tot"].ToString();
                Label8.Text = Session["dtot"].ToString();
                Label9.Text = Session["gst"].ToString();
                Label10.Text = Session["grandtot"].ToString();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                int serialNumber = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = serialNumber.ToString();
            }
        }
    }
}