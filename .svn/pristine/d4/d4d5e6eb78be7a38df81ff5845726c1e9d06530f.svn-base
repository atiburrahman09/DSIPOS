using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.ChartOfAccount
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
                    idLabel.Text = chartOfAccountIdForUpdateHiddenField.Value = LumexSessionManager.Get("ChartOfAccountIdForUpdate").ToString().Trim();
                    if (idLabel.Text == "A0" || idLabel.Text == "L0" || idLabel.Text == "I0" || idLabel.Text == "E0")
                    {
                        updateButton.Enabled = false;
                    }
                    GetChartOfAccountById(chartOfAccountIdForUpdateHiddenField.Value.Trim());

                    accountNameTextBox.Focus();
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

        protected void GetChartOfAccountById(string accountId)
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetChartOfAccountById(accountId);

                if (dt.Rows.Count > 0)
                {
                    chartOfAccountNameForUpdateHiddenField.Value = accountNameTextBox.Text = dt.Rows[0]["AccountName"].ToString();
                    accountTypeDropDownList.SelectedValue = dt.Rows[0]["AccountType"].ToString();
                    postedDropDownList.SelectedValue = dt.Rows[0]["IsPosted"].ToString();
                    totallingAccountNumberTextBox.Text = dt.Rows[0]["TotallingAccountNumber"].ToString();
                    useAsDropDownList.SelectedValue = dt.Rows[0]["UseAs"].ToString();
                    bankAccountNumberTextBox.Text = dt.Rows[0]["BankAccountNumber"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["Description"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Chart Of Account Data Not Found!!!"; msgDetailLabel.Text = "";
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
                chartOfAccount = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                if (accountNameTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Account Name field is required.";
                }
                else if (totallingAccountNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Totalling Account Number field is required.";
                }
                else
                {
                    chartOfAccount.AccountId = idLabel.Text.Trim();
                    chartOfAccount.AccountName = accountNameTextBox.Text.Trim();
                    chartOfAccount.AccountType = accountTypeDropDownList.SelectedValue.Trim();
                    chartOfAccount.TotallingAccountNumber = totallingAccountNumberTextBox.Text.Trim();
                    chartOfAccount.IsPosted = postedDropDownList.SelectedValue.Trim();
                    chartOfAccount.UseAs = useAsDropDownList.SelectedValue.Trim();
                    chartOfAccount.BankAccountNumber = bankAccountNumberTextBox.Text.Trim();
                    chartOfAccount.Description = descriptionTextBox.Text.Trim();

                    if (!chartOfAccount.CheckDuplicateChartOfAccount())
                    {
                        chartOfAccount.UpdateChartOfAccount();

                        chartOfAccountNameForUpdateHiddenField.Value = "";
                        chartOfAccountIdForUpdateHiddenField.Value = "";

                        string message = "Chart Of Account <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/ChartOfAccount/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (chartOfAccountNameForUpdateHiddenField.Value == accountNameTextBox.Text.Trim())
                        {
                            chartOfAccount.AccountName = "WithOut";
                            chartOfAccount.UpdateChartOfAccount();

                            chartOfAccountNameForUpdateHiddenField.Value = "";
                            chartOfAccountIdForUpdateHiddenField.Value = "";

                            string message = "Chart Of Account <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/ChartOfAccount/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message2 = "This Chart Of Account <span class='actionTopic'>already exist</span>, try another one.";
                            MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message2 + "\");");
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
                chartOfAccount = null;
            }
        }
    }
}