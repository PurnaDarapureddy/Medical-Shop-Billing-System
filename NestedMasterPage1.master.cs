using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicines1
{
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
          //  Response.Redirect("Billing.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["a"] = 1;
            Server.Transfer("orders.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
             Server.Transfer("search.aspx");
        }
    }
}