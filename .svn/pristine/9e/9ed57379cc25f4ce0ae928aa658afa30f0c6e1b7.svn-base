using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class ChequeBookEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadChartOfAccountsBankHeadList();
                    bankAccountHeadDropDownList.Focus();
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

        protected void LoadChartOfAccountsBankHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsBankHeadList();

                bankAccountHeadDropDownList.DataSource = dt;
                bankAccountHeadDropDownList.DataValueField = "AccountId";
                bankAccountHeadDropDownList.DataTextField = "AccountHead";
                bankAccountHeadDropDownList.DataBind();
                bankAccountHeadDropDownList.Items.Insert(0, "");
                bankAccountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                if (bankAccountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Account Head field is required.";
                }
                else if (chequeBookReferenceNoTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Cheque Book Reference Number field is required.";
                }
                else if (startPageNoTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Start Page Number field is required.";
                }
                else if (endPageNoTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "End Page Number field is required.";
                }
                else
                {
                    bankChequeBook.AccountId = bankAccountHeadDropDownList.SelectedValue.Trim();
                    bankChequeBook.ChequeBookRefNo = chequeBookReferenceNoTextBox.Text.Trim();
                    bankChequeBook.StartPageNo = startPageNoTextBox.Text.Trim();
                    bankChequeBook.EndPageNo = endPageNoTextBox.Text.Trim();

                    if (!bankChequeBook.CheckDuplicateBankChequeBook())
                    {
                        DataTable dt = bankChequeBook.SaveBankChequeBook();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "Cheque Book Entry <span class='actionTopic'>Created</span> Successfully with Reference Number: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/BankChequeBook/ChequeBookEntryList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Cheque Book Entry.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Cheque Book Page(s) <span class='actionTopic'>already exist</span>, check the cheque numbers.";
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
                bankChequeBook = null;
            }
        }
    }
}