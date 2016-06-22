using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.PayToFromCompany
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
                    companyNameTextBox.Focus();
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                if (companyNameTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Company Name field is required.";
                }
                else if (descriptionTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    payToFromCompany.CompanyName = companyNameTextBox.Text.Trim();
                    payToFromCompany.Description = descriptionTextBox.Text.Trim();

                    if (!payToFromCompany.CheckDuplicatePayToFromCompany(payToFromCompany.CompanyName.Trim()))
                    {
                        DataTable dt = payToFromCompany.SavePayToFromCompany();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "Company <span class='actionTopic'>Created</span> Successfully with Company ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/PayToFromCompany/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Company.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Company Name <span class='actionTopic'>already exist</span>, try another one.";
                        MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
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