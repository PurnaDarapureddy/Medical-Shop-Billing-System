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
    public partial class Billing : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        void getdata()
        {

            SqlDataAdapter da = new SqlDataAdapter("proc_viewbag", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        void gettotal()
        {
            con.Open();
            SqlCommand cmd= new SqlCommand("proc_total", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object p=cmd.ExecuteScalar();
            if(p!= DBNull.Value)
            {
                GridViewRow row = GridView1.FooterRow;
                Label l1 = (Label)row.FindControl("Label8");
                l1.Text = p.ToString();
            }
            con.Close();
        }
        void delete()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_purchesed", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void update()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_update_med_qty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@b", Session["qty"].ToString());
            cmd.Parameters.AddWithValue("@a", Session["mname"].ToString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getdata(); 
                gettotal();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Label l1 = (Label)row.FindControl("Label2");
            Label l2 = (Label)row.FindControl("Label3");
            Label l3 = (Label)row.FindControl("Label4");
            Label l4 = (Label)row.FindControl("Label5");
            Label l5 = (Label)row.FindControl("Label6");
            Label l6 = (Label)row.FindControl("Label7");
            ImageButton i1 = (ImageButton)row.FindControl("ImageButton1");
            ImageButton i2 = (ImageButton)row.FindControl("ImageButton2");
            GridViewRow row1 = GridView1.FooterRow;
            Label total = (Label)row1.FindControl("Label8");
            Session["mname"] = l1.Text;
            Session["qty"] = l5.Text;
            if (TextBox1.Text !="" && TextBox2.Text !="" &&  TextBox3.Text != "" && TextBox4.Text != "")
            {
                if (e.CommandName == "iCheck")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("proc_insertReporta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", l1.Text);
                    cmd.Parameters.AddWithValue("@b", l2.Text);
                    cmd.Parameters.AddWithValue("@c", l3.Text);
                    cmd.Parameters.AddWithValue("@d", l4.Text);
                    cmd.Parameters.AddWithValue("@e", l5.Text);
                    cmd.Parameters.AddWithValue("@f", l6.Text);
                    //cmd.Parameters.AddWithValue("@g", total.Text);
                    cmd.Parameters.AddWithValue("@g", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@h", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@i", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@j", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@k", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@l", DateTime.Now.TimeOfDay);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    i1.Enabled = false;
                    i2.Visible = false;
                    Label9.Visible = false;
                    update();
                    List<billclass> b1 = new List<billclass>();
                    double tot = 0, dtot = 0; int disc = 0; double gst = 0, grandtot = 0;
                    foreach (GridViewRow row2 in GridView1.Rows)
                    {
                       
                        billclass bc1 = new billclass();
                        bc1.mname = ((Label)row2.FindControl("Label2")).Text;
                        bc1.batchno = ((Label)row2.FindControl("Label3")).Text;
                        bc1.expirydate = ((Label)row2.FindControl("Label4")).Text;
                        bc1.mrp = Convert.ToDouble(((Label)row2.FindControl("Label5")).Text);
                        bc1.qty = Convert.ToInt32(((Label)row2.FindControl("Label6")).Text);
                        bc1.amount = Convert.ToDouble(((Label)row2.FindControl("Label7")).Text);
                        tot = tot + (bc1.mrp * bc1.qty);
                       
                        b1.Add(bc1);
                        
                    }
                    if (tot >= 999)
                    {
                        disc = 10;
                    }
                    dtot = (tot * disc / 100);
                    gst = tot * 18 / 100;
                    grandtot = (tot-dtot) + gst;
                    Session["bill"] = b1;
                    Session["tot"] = tot;
                    Session["dtot"] = dtot;
                    Session["gst"] = gst;
                    Session["grandtot"] = grandtot;
                }

                else if (e.CommandName == "iRemove")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("proc_remove", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", l1.Text);
                    cmd.Parameters.AddWithValue("@b", l5.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    getdata();
                    gettotal();
                }

            }
            else
            {
                Label9.Visible=true;
                Label9.Text="Enter Details";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["cname"] = TextBox1.Text;
            Session["phno"] = TextBox2.Text;
            Session["gender"] = TextBox3.Text;
            Session["age"] = TextBox4.Text;
            delete();
            Server.Transfer("purchase.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
    }
}