using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspProj
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
       
            protected void btnLogin_Click(object sender, EventArgs e)
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
                {
                    Session["Admin"] = "true";
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password!";
                }
            }

        }
    }
