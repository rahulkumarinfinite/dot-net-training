using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Assignment1_ASP
{
        public partial class Validator : System.Web.UI.Page
        {
            protected void btnCheck_Click(object sender, EventArgs e)
            {
                string errorMsg = "";

                if (txtName.Text == txtFamilyName.Text)
                    errorMsg += "Name must be different from Family Name.<br/>";

                if (txtAddress.Text.Length < 2)
                    errorMsg += "Address must be at least 2 letters.<br/>";

                if (txtCity.Text.Length < 2)
                    errorMsg += "City must be at least 2 letters.<br/>";

                if (!Regex.IsMatch(txtZip.Text, @"^\d{5}$"))
                    errorMsg += "Zip Code must be exactly 5 digits.<br/>";

                if (!Regex.IsMatch(txtPhone.Text, @"^\d{2,3}-\d{7}$"))
                    errorMsg += "Phone must match format XX-XXXXXXX or XXX-XXXXXXX.<br/>";

                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    errorMsg += "Email must be a valid email address.<br/>";

                lblResult.Text = string.IsNullOrEmpty(errorMsg) ? "All validations passed!" : errorMsg;
            }
        }
 }
