using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesPerson
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
                    salesPersonNameTextBox.Focus();
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

                workingSalesCenterDropDownList.DataSource = dt;
                workingSalesCenterDropDownList.DataValueField = "SalesCenterId";
                workingSalesCenterDropDownList.DataTextField = "SalesCenterName";
                workingSalesCenterDropDownList.DataBind();
                workingSalesCenterDropDownList.Items.Insert(0, "");
                workingSalesCenterDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining & Working Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
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
            SalesPersonBLL salesPerson = new SalesPersonBLL();

            try
            {
                if (salesPersonNameTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Sales Person Name field is required.";
                }
                else if (emailTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Email field is required.";
                }
                else if (addressTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                }
                else if (joinDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(joinDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Join Date field is required.";
                }
                else if (joiningSalesCenterDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Joining Sales Center field is required.";
                }
                else if (workingSalesCenterDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Working Sales Center field is required.";
                }
                else
                {
                    salesPerson.SalesPersonName = salesPersonNameTextBox.Text.Trim();
                    salesPerson.ContactNumber = contactNumberTextBox.Text.Trim();
                    salesPerson.Email = emailTextBox.Text.Trim();
                    salesPerson.Country = countryTextBox.Text.Trim();
                    salesPerson.City = cityTextBox.Text.Trim();
                    salesPerson.District = districtTextBox.Text.Trim();
                    salesPerson.PostalCode = postalCodeTextBox.Text.Trim();
                    salesPerson.Address = addressTextBox.Text.Trim();
                    salesPerson.NationalId = nationalIdTextBox.Text.Trim();
                    salesPerson.PassportNumber = passportNumberTextBox.Text.Trim();
                    salesPerson.JoinDate = LumexLibraryManager.ParseAppDate(joinDateTextBox.Text.Trim());
                    salesPerson.JoiningSalesCenterId = joiningSalesCenterDropDownList.SelectedValue.Trim();
                    salesPerson.WorkingSalesCenterId = workingSalesCenterDropDownList.SelectedValue.Trim();

                    DataTable dt = salesPerson.SaveSalesPerson();

                    if (dt.Rows.Count > 0)
                    {
                        string message = "Sales Person <span class='actionTopic'>Created</span> Successfully with Sales Person ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesPerson/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        string message = "<span class='actionTopic'>Failed</span> to Create Sales Person.";
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
                salesPerson = null;
            }
        }
    }
}