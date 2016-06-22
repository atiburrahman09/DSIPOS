using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.PayToFromCompany
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
                    idLabel.Text = payToFromCompanyIdForUpdateHiddenField.Value = LumexSessionManager.Get("PayToFromCompanyIdForUpdate").ToString().Trim();
                    GetUserGroupById(payToFromCompanyIdForUpdateHiddenField.Value.Trim());

                    companyNameTextBox.Focus();
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

        protected void GetUserGroupById(string companyId)
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                DataTable dt = payToFromCompany.GetPayToFromCompanyById(companyId);

                if (dt.Rows.Count > 0)
                {
                    payToFromCompanyNameForUpdateHiddenField.Value = companyNameTextBox.Text = dt.Rows[0]["CompanyName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["Description"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Company Data Not Found!!!"; msgDetailLabel.Text = "";
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
                payToFromCompany = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                if (payToFromCompanyIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Company not found to update.";
                }
                else if (companyNameTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Company Name field is required.";
                }
                else if (descriptionTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    payToFromCompany.CompanyId = payToFromCompanyIdForUpdateHiddenField.Value.Trim();
                    payToFromCompany.CompanyName = companyNameTextBox.Text.Trim();
                    payToFromCompany.Description = descriptionTextBox.Text.Trim();

                    if (!payToFromCompany.CheckDuplicatePayToFromCompany(companyNameTextBox.Text.Trim()))
                    {
                        payToFromCompany.UpdatePayToFromCompany();

                        payToFromCompanyNameForUpdateHiddenField.Value = "";
                        payToFromCompanyIdForUpdateHiddenField.Value = "";

                        string message = "Company <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/PayToFromCompany/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (payToFromCompanyNameForUpdateHiddenField.Value == companyNameTextBox.Text.Trim())
                        {
                            payToFromCompany.CompanyName = "WithOut";
                            payToFromCompany.UpdatePayToFromCompany();

                            payToFromCompanyNameForUpdateHiddenField.Value = "";
                            payToFromCompanyIdForUpdateHiddenField.Value = "";

                            string message = "Company <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/PayToFromCompany/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "This Company Name <span class='actionTopic'>already exist</span>, try another one.";
                            MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                        }
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
                payToFromCompany = null;
            }
        }
    }
}