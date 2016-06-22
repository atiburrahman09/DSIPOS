using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Customer
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadSalesCenters();

                    idLabel.Text = customerIdForUpdateHiddenField.Value = LumexSessionManager.Get("CustomerIdForUpdate").ToString().Trim();
                    GetCustomerById(customerIdForUpdateHiddenField.Value.Trim());

                    customerNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                updateButton.Enabled = false;

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

        protected void GetCustomerById(string customerId)
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                DataTable dt = customer.GetCustomerById(customerId);

                if (dt.Rows.Count > 0)
                {
                    customerNameTextBox.Text = dt.Rows[0]["CustomerName"].ToString();
                    //countryTextBox.Text = dt.Rows[0]["Country"].ToString();
                    //cityTextBox.Text = dt.Rows[0]["City"].ToString();
                    //districtTextBox.Text = dt.Rows[0]["District"].ToString();
                    //postalCodeTextBox.Text = dt.Rows[0]["PostalCode"].ToString();
                    //nationalIdTextBox.Text = dt.Rows[0]["NationalId"].ToString();
                    //passportNumberTextBox.Text = dt.Rows[0]["PassportNumber"].ToString();
                    contactNumberTextBox.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailTextBox.Text = dt.Rows[0]["Email"].ToString();
                    addressTextBox.Text = dt.Rows[0]["Address"].ToString();

                    joiningSalesCenterDropDownList.SelectedValue = dt.Rows[0]["JoiningSalesCenterId"].ToString();
                    if (joiningSalesCenterDropDownList.SelectedValue != dt.Rows[0]["JoiningSalesCenterId"].ToString())
                    {
                        joiningSalesCenterDropDownList.Items.Insert(1, new ListItem(dt.Rows[0]["JoiningSalesCenterName"].ToString(), dt.Rows[0]["JoiningSalesCenterId"].ToString()));
                        joiningSalesCenterDropDownList.SelectedIndex = 1;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Customer Data Not Found!!!"; msgDetailLabel.Text = "";
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
                customer = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                if (customerIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Customer not found to update.";
                }
                else if (customerNameTextBox.Text == "")
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
                    customer.CustomerId = customerIdForUpdateHiddenField.Value.Trim();
                    customer.CustomerName = customerNameTextBox.Text.Trim();
                    customer.ContactNumber = contactNumberTextBox.Text.Trim();
                    customer.Email = emailTextBox.Text.Trim();
                    customer.Country = ""; //countryTextBox.Text.Trim();
                    customer.City = ""; //cityTextBox.Text.Trim();
                    customer.District = ""; // districtTextBox.Text.Trim();
                    customer.PostalCode = ""; //postalCodeTextBox.Text.Trim();
                    customer.Address = addressTextBox.Text.Trim();
                    customer.NationalId = "";//nationalIdTextBox.Text.Trim();
                    customer.PassportNumber = "";//passportNumberTextBox.Text.Trim();
                    customer.JoiningSalesCenterId = joiningSalesCenterDropDownList.SelectedValue.Trim();

                    customer.UpdateCustomer();

                    customerIdForUpdateHiddenField.Value = "";

                    string message = "Customer <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Customer/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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