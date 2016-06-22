using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class ApproveChequeBookEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadChartOfAccountsBankHeadList();
                    GetApprovalList();
                    bankAccountHeadDropDownList.Focus();
                }

                if (chequeBookEntryListGridView.Rows.Count > 0)
                {
                    chequeBookEntryListGridView.UseAccessibleHeader = true;
                    chequeBookEntryListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                bankAccountHeadDropDownList.Items.Insert(0, "All");
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

        protected void approveLinkButton_Click(object sender, EventArgs e)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                string[] accId = chequeBookEntryListGridView.Rows[row.RowIndex].Cells[1].Text.ToString().Split('-');

                bankChequeBook.AccountId = accId[0].ToString();
                bankChequeBook.ChequeBookRefNo = chequeBookEntryListGridView.Rows[row.RowIndex].Cells[2].Text.ToString();
                bankChequeBook.AutoRefNo = chequeBookEntryListGridView.Rows[row.RowIndex].Cells[3].Text.ToString();
                bankChequeBook.StartPageNo = chequeBookEntryListGridView.Rows[row.RowIndex].Cells[4].Text.ToString();
                bankChequeBook.EndPageNo = chequeBookEntryListGridView.Rows[row.RowIndex].Cells[5].Text.ToString();

                bankChequeBook.ApproveBankChequeBookEntryByAutoRefNo();

                GetApprovalList();
                string message = "Cheque Book Entry <span class='actionTopic'>Approved</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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

        protected void rejectLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();
                bankChequeBook.RejectBankChequeBookEntryByAutoRefNo(chequeBookEntryListGridView.Rows[row.RowIndex].Cells[3].Text.ToString());

                GetApprovalList();
                string message = "Cheque Book Entry <span class='actionTopic'>Rejected</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void GetApprovalList()
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                if (bankAccountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Account Head field is required.";
                }
                else
                {
                    DataTable dt = bankChequeBook.GetBankChequeBookEntryApprovalListByAccountIdAll(bankAccountHeadDropDownList.SelectedValue.Trim());

                    chequeBookEntryListGridView.DataSource = dt;
                    chequeBookEntryListGridView.DataBind();

                    if (chequeBookEntryListGridView.Rows.Count > 0)
                    {
                        chequeBookEntryListGridView.UseAccessibleHeader = true;
                        chequeBookEntryListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Cheque Book Entry List Data Not Found!!!"; msgDetailLabel.Text = "";
                        msgbox.Attributes.Add("class", "alert alert-info");
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

        protected void pendingEntryListButton_Click(object sender, EventArgs e)
        {
            GetApprovalList();
            MyAlertBox("MyOverlayStop();");
        }
    }
}