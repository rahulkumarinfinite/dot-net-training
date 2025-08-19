using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspProj
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Admin"] = "true";
            Response.Redirect("NumberOfCust.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Admin"] = "true";
            Response.Redirect("ViewBills.aspx");
        }
    }
}