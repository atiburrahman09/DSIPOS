using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesPerson
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

                    idLabel.Text = salesPersonIdForUpdateHiddenField.Value = LumexSessionManager.Get("SalesPersonIdForUpdate").ToString().Trim();
                    GetSalesPersonById(salesPersonIdForUpdateHiddenField.Value.Trim());
                    salesPersonNameTextBox.Focus();
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

        protected void GetSalesPersonById(string salesPersonId)
        {
            SalesPersonBLL salesPerson = new SalesPersonBLL();

            try
            {
                DataTable dt = salesPerson.GetSalesPersonById(salesPersonId);

                if (dt.Rows.Count > 0)
                {
                    salesPersonNameTextBox.Text = dt.Rows[0]["SalesPersonName"].ToString();
                    countryTextBox.Text = dt.Rows[0]["Country"].ToString();
                    cityTextBox.Text = dt.Rows[0]["City"].ToString();
                    districtTextBox.Text = dt.Rows[0]["District"].ToString();
                    postalCodeTextBox.Text = dt.Rows[0]["PostalCode"].ToString();
                    nationalIdTextBox.Text = dt.Rows[0]["NationalId"].ToString();
                    passportNumberTextBox.Text = dt.Rows[0]["PassportNumber"].ToString();
                    contactNumberTextBox.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailTextBox.Text = dt.Rows[0]["Email"].ToString();
                    addressTextBox.Text = dt.Rows[0]["Address"].ToString();
                    joinDateTextBox.Text = LumexLibraryManager.GetAppDateView(dt.Rows[0]["joinDate"].ToString());

                    joiningSalesCenterDropDownList.SelectedValue = dt.Rows[0]["JoiningSalesCenterId"].ToString();
                    if (joiningSalesCenterDropDownList.SelectedValue != dt.Rows[0]["JoiningSalesCenterId"].ToString())
                    {
                        joiningSalesCenterDropDownList.Items.Insert(1, new ListItem(dt.Rows[0]["JoiningSalesCenterName"].ToString(), dt.Rows[0]["JoiningSalesCenterId"].ToString()));
                        joiningSalesCenterDropDownList.SelectedIndex = 1;
                    }

                    workingSalesCenterDropDownList.SelectedValue = dt.Rows[0]["WorkingSalesCenterId"].ToString();
                    if (workingSalesCenterDropDownList.SelectedValue != dt.Rows[0]["WorkingSalesCenterId"].ToString())
                    {
                        workingSalesCenterDropDownList.Items.Insert(1, new ListItem(dt.Rows[0]["WorkingSalesCenterName"].ToString(), dt.Rows[0]["WorkingSalesCenterId"].ToString()));
                        workingSalesCenterDropDownList.SelectedIndex = 1;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Sales Person Data Not Found!!!"; msgDetailLabel.Text = "";
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
                salesPerson = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            SalesPersonBLL salesPerson = new SalesPersonBLL();

            try
            {
                if (salesPersonIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Sales Person not found to update.";
                }
                else if (salesPersonNameTextBox.Text.Trim() == "")
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
                    salesPerson.SalesPersonId = salesPersonIdForUpdateHiddenField.Value.Trim();
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

                    salesPerson.UpdateSalesPerson();

                    salesPersonIdForUpdateHiddenField.Value = "";

                    string message = "Sales Person <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesPerson/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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