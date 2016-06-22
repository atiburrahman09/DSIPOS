using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using System.Web.UI.WebControls;
using Lumex.Tech;

namespace lmxIpos.UI.Customer
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadSalesCenters();
                    customerNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadSalesCenters()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                joiningSalesCenterDropDownList.DataSource = dt;
                joiningSalesCenterDropDownList.DataValueField = "SalesCenterId";
                joiningSalesCenterDropDownList.DataTextField = "SalesCenterName";
                joiningSalesCenterDropDownList.DataBind();
                joiningSalesCenterDropDownList.Items.Insert(0, "");
                joiningSalesCenterDropDownList.SelectedIndex = 0;

                joiningSalesCenterDropDownList.SelectedValue = LumexSessionManager.Get("SalesCenterId").ToString();


                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                salesCenter = null;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            CustomerBLL customer = new CustomerBLL();

            Button btn = (Button)sender;

            try
            {
                if (customerNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Customer Name field is required.";
                }
                else if (addressTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                }
                else if (joiningSalesCenterDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Joining Sales Center field is required.";
                }
                else
                {
                    customer.CustomerName = customerNameTextBox.Text.Trim();
                    customer.ContactNumber = contactNumberTextBox.Text.Trim();
                    customer.Email = emailTextBox.Text.Trim();
                    customer.Country = countryTextBox.Text.Trim();
                    customer.City = cityTextBox.Text.Trim();
                    customer.District = districtTextBox.Text.Trim();
                    customer.PostalCode = postalCodeTextBox.Text.Trim();
                    customer.Address = addressTextBox.Text.Trim();
                    customer.NationalId = nationalIdTextBox.Text.Trim();
                    customer.PassportNumber = passportNumberTextBox.Text.Trim();
                    customer.JoiningSalesCenterId = joiningSalesCenterDropDownList.SelectedValue.Trim();

                    DataTable dt = customer.SaveCustomer();

                    if (dt.Rows.Count > 0)
                    {
                        if (btn.CommandArgument == "1")
                        {
                            string message = "Customer <span class='actionTopic'>Created</span> Successfully with Customer ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Customer/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "Customer <span class='actionTopic'>Created</span> Successfully with Customer ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Customer/Create.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                        }
                    }
                    else
                    {
                        string message = "<span class='actionTopic'>Failed</span> to Create Customer.";
                        MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                customer = null;
            }
        }
    }
}