using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace aspProj
{
    public partial class NumberOfCust : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            
            
                if (IsPostBack && ViewState["CustomerCount"] != null)
                {
                    int count = (int)ViewState["CustomerCount"];
                    RecreateDynamicControls(count);
                }
            

            //
        }
        private const string TextBoxPrefix = "txt";

        //
        private void RecreateDynamicControls(int count)
        {
            phDynamicForm.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Literal header = new Literal { Text = $"<h4>Customer {i + 1}</h4>" };
                phDynamicForm.Controls.Add(header);

                // Consumer Number
                phDynamicForm.Controls.Add(new Literal { Text = "Consumer Number: " });
                phDynamicForm.Controls.Add(new TextBox { ID = $"{TextBoxPrefix}ConsumerNumber{i}" });
                phDynamicForm.Controls.Add(new Literal { Text = "<br/>" });

                // Consumer Name
                phDynamicForm.Controls.Add(new Literal { Text = "Consumer Name: " });
                phDynamicForm.Controls.Add(new TextBox { ID = $"{TextBoxPrefix}ConsumerName{i}" });
                phDynamicForm.Controls.Add(new Literal { Text = "<br/>" });

                // Units Consumed
                phDynamicForm.Controls.Add(new Literal { Text = "Units Consumed: " });
                phDynamicForm.Controls.Add(new TextBox { ID = $"{TextBoxPrefix}Units{i}" });
                phDynamicForm.Controls.Add(new Literal { Text = "<br/><br/>" });
            }
        }

        //

        protected void btnGenerateForm_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(txtBillCount.Text, out count) || count <= 0)
            {
                lblMessage.Text = "Enter a valid number of customers.";
                return;
            }

            phDynamicForm.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Literal header = new Literal { Text = $"<h4>Customer {i + 1}</h4>" };
                phDynamicForm.Controls.Add(header);

                // Consumer Number
                phDynamicForm.Controls.Add(new Literal { Text = "Consumer Number: " });
                phDynamicForm.Controls.Add(new TextBox { ID = $"{TextBoxPrefix}ConsumerNumber{i}" });
                phDynamicForm.Controls.Add(new Literal { Text = "<br/>" });

                // Consumer Name
                phDynamicForm.Controls.Add(new Literal { Text = "Consumer Name: " });
                phDynamicForm.Controls.Add(new TextBox { ID = $"{TextBoxPrefix}ConsumerName{i}" });
                phDynamicForm.Controls.Add(new Literal { Text = "<br/>" });

                // Units Consumed
                phDynamicForm.Controls.Add(new Literal { Text = "Units Consumed: " });
                phDynamicForm.Controls.Add(new TextBox { ID = $"{TextBoxPrefix}Units{i}" });
                phDynamicForm.Controls.Add(new Literal { Text = "<br/><br/>" });
            }

            ViewState["CustomerCount"] = count;
            lblMessage.Text = "";
            btnSubmitBills.Visible = true;
        }
       
        protected void btnSubmitBills_Click(object sender, EventArgs e)
        {
           
            lblMessage.Text = ""; // Clear previous messages

            int count = (int)ViewState["CustomerCount"];
            ElectricityBoard board = new ElectricityBoard();
            BillValidator validator = new BillValidator();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    // Safely find and cast TextBoxes
                    TextBox txtCno = phDynamicForm.FindControl($"{TextBoxPrefix}ConsumerNumber{i}") as TextBox;
                    TextBox txtCname = phDynamicForm.FindControl($"{TextBoxPrefix}ConsumerName{i}") as TextBox;
                    TextBox txtUnits = phDynamicForm.FindControl($"{TextBoxPrefix}Units{i}") as TextBox;

                    // Check if any textbox is null
                    if (txtCno == null || txtCname == null || txtUnits == null)
                    {
                        lblMessage.Text += $"Customer {i + 1}: Could not find all controls.<br/>";
                        continue;
                    }

                    string cno = txtCno.Text.Trim();
                    string cname = txtCname.Text.Trim();

                    if (!int.TryParse(txtUnits.Text.Trim(), out int units))
                    {
                        lblMessage.Text += $"Customer {i + 1}: Units must be a number.<br/>";
                        continue;
                    }

                    string validationResult = validator.ValidateUnitsConsumed(units);
                    if (validationResult != "Valid")
                    {
                        lblMessage.Text += $"Customer {i + 1}: {validationResult}<br/>";
                        continue;
                    }

                    ElectricityBill eb = new ElectricityBill
                    {
                        ConsumerNumber = cno,
                        ConsumerName = cname,
                        UnitsConsumed = units
                    };

                    board.CalculateBill(eb);
                    board.AddBill(eb);

                    lblMessage.Text += $"Customer {i + 1}: Bill Added Successfully - Amount: ₹{eb.BillAmount}<br/>";
                }
                catch (FormatException ex)
                {
                    lblMessage.Text += $"Customer {i + 1}: {ex.Message}<br/>";
                }
                catch (Exception ex)
                {
                    lblMessage.Text += $"Customer {i + 1}: Error - {ex.Message}<br/>";
                }
            }

            phDynamicForm.Controls.Clear();
            btnSubmitBills.Visible = false;
            pnlCount.Visible = false;
        }


    }
}