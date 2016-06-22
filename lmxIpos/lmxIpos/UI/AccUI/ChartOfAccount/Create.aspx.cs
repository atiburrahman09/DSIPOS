using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.ChartOfAccount
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
                    GetTotallingAccountList();
                    accountTypeDropDownList.Focus();
                }

                if (totallingAccountListGridView.Rows.Count > 0)
                {
                    totallingAccountListGridView.UseAccessibleHeader = true;
                    totallingAccountListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetTotallingAccountList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetTotallingAccountList(accountTypeDropDownList.SelectedValue.Trim());
                totallingAccountListGridView.DataSource = dt;
                totallingAccountListGridView.DataBind();

                if (totallingAccountListGridView.Rows.Count > 0)
                {
                    totallingAccountListGridView.UseAccessibleHeader = true;
                    totallingAccountListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Totalling Account List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void accountTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTotallingAccountList();
            totallingAccountNumberTextBox.Text = "";
            //MyAlertBox("MyOverlayStop();");
        }

        protected void saveButton_Click(object sender, EventArgs e)
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
                    chartOfAccount.AccountName = accountNameTextBox.Text.Trim();
                    chartOfAccount.AccountType = accountTypeDropDownList.SelectedValue.Trim();
                    chartOfAccount.TotallingAccountNumber = totallingAccountNumberTextBox.Text.Trim();
                    chartOfAccount.IsPosted = postedDropDownList.SelectedValue.Trim();
                    chartOfAccount.UseAs = useAsDropDownList.SelectedValue.Trim();
                    chartOfAccount.BankAccountNumber = bankAccountNumberTextBox.Text.Trim();
                    chartOfAccount.Description = descriptionTextBox.Text.Trim();

                    if (!chartOfAccount.CheckDuplicateChartOfAccount())
                    {
                        DataTable dt = chartOfAccount.SaveChartOfAccount();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "Chart Of Account <span class='actionTopic'>Created</span> Successfully with Account ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/ChartOfAccount/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Create Chart Of Account.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Chart Of Account <span class='actionTopic'>already exist</span>, try another one.";
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
                chartOfAccount = null;
            }
        }
    }
}