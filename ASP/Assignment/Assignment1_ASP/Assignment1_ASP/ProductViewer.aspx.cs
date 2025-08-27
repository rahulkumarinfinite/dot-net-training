using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment1_ASP;

namespace Assignment1_ASP
{
    
        public partial class ProductViewer : System.Web.UI.Page
        {

            Dictionary<string, (string imageUrl, decimal price)> products = new Dictionary<string, (string, decimal)>
        {
            { "Laptop", ("~/Image/Laptop.jpg", 75000) },
            { "SmartPhones", ("~/Image/SmartPhones.jpg", 45000) },
            { "HeadPhones", ("~/Image/HeadPhones.jpg", 3000) },
            { "Camera", ("~/Image/Camera.jpg", 55000) }
        };

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ddlProducts.DataSource = products.Keys;
                    ddlProducts.DataBind();
                }
            }

            protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selected = ddlProducts.SelectedValue;
                imgProduct.ImageUrl = products[selected].imageUrl;
                lblPrice.Text = ""; 
            }

            protected void btnGetPrice_Click(object sender, EventArgs e)
            {
                string selected = ddlProducts.SelectedValue;
                lblPrice.Text = $"Price: ₹{products[selected].price}";
            }
        }
    }

