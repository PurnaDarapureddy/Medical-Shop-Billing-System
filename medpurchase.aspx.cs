using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicines1
{
    public partial class medpurchase : System.Web.UI.Page
    {
        void getorder()
        {


                List<medpurch> b1 = Session["order"] as List<medpurch>;
                GridView1.DataSource = b1;
                GridView1.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getorder();
                Label4.Text = DateTime.Now.ToString();
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}