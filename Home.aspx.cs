using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicines1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Insert.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("search.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Billing.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["a"] = 0;
            Server.Transfer("orders.aspx");
        }
    }
}