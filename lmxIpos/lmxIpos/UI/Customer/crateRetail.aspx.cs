using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;
using Lumex.Project.BLL;
using System.Data;
namespace lmxIpos.UI.Customer
{
    public partial class crateRetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    Page.Title = "Customar Add";
                    LoadSalesCenters();
                    customerNameTextBox.Focus();

                }
                msgbox.Visible = false;
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
                //joiningSalesCenterDropDownList.Items.Insert(0, "");
                //joiningSalesCenterDropDownList.SelectedIndex = 0;
                joiningSalesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

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
            Button btn = (Button)sender;

            CustomerBLL customer = new CustomerBLL();

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
                //else if (joiningSalesCenterDropDownList.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Joining Sales Center field is required.";
                //}
                else
                {
                    customer.CustomerName = customerNameTextBox.Text.Trim();
                    customer.ContactNumber = contactNumberTextBox.Text.Trim();
                    customer.Email = emailTextBox.Text.Trim();
                    customer.Country = "";
                    customer.City = "";
                    customer.District = "";
                    customer.PostalCode = "";
                    customer.Address = addressTextBox.Text.Trim();
                    customer.NationalId = ""; //nationalIdTextBox.Text.Trim();
                    customer.PassportNumber = "";//passportNumberTextBox.Text.Trim();
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
                            msgbox.Visible = true;
                            msgTitleLabel.Text = "Process Succeed";
                            msgDetailLabel.Text = "Created Successfully with Customer ID: " + dt.Rows[0][0].ToString();
                            msgbox.Attributes.Add("class", "alert alert-success");

                            customerNameTextBox.Text = "";
                            contactNumberTextBox.Text = "";
                            emailTextBox.Text = "";
                            addressTextBox.Text = "";
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