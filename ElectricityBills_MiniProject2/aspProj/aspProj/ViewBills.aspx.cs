using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspProj
{
    public partial class ViewBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(txtCount.Text);
            ElectricityBoard board = new ElectricityBoard();
            var bills = board.Generate_N_BillDetails(count);

            gvBills.DataSource = bills;
            gvBills.DataBind();
        }

    }
}