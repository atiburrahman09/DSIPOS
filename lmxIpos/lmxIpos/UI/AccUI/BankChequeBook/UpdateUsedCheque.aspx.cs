using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class UpdateUsedCheque : System.Web.UI.Page
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

                if (chequeBookPageListGridView.Rows.Count > 0)
                {
                    chequeBookPageListGridView.UseAccessibleHeader = true;
                    chequeBookPageListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    chequeBookEntry.Visible = true;
                }
                else
                {
                    chequeBookEntry.Visible = false;
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

        protected void updateLinkButton_Click(object sender, EventArgs e)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                TextBox usedDateTextBox = (TextBox)chequeBookPageListGridView.Rows[row.RowIndex].Cells[3].FindControl("usedDateTextBox");
                string usedDate = usedDateTextBox.Text.Trim();

                TextBox usedVoucherNoTextBox = (TextBox)chequeBookPageListGridView.Rows[row.RowIndex].Cells[4].FindControl("usedVoucherNoTextBox");
                string usedVoucherNo = usedVoucherNoTextBox.Text.Trim();

                TextBox usedJournalNoTextBox = (TextBox)chequeBookPageListGridView.Rows[row.RowIndex].Cells[5].FindControl("usedJournalNoTextBox");
                string usedJournalNo = usedJournalNoTextBox.Text.Trim();

                TextBox usedNarrationTextBox = (TextBox)chequeBookPageListGridView.Rows[row.RowIndex].Cells[6].FindControl("usedNarrationTextBox");
                string usedNarration = usedNarrationTextBox.Text.Trim();

                string chequeNo = chequeBookPageListGridView.Rows[row.RowIndex].Cells[1].Text.Trim();
                string autoRefNo = numberLabel.Text.Trim();

                if (string.IsNullOrEmpty(usedDate) || LumexLibraryManager.ParseAppDate(usedDate) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Used Date field is required at Cheque No. [" + chequeNo + "]";
                }
                else if (string.IsNullOrEmpty(usedVoucherNo))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Used Voucher No. field is required at Cheque No. [" + chequeNo + "]";
                }
                else if (string.IsNullOrEmpty(usedJournalNo))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Used Journal No. field is required at Cheque No. [" + chequeNo + "]";
                }
                else if (string.IsNullOrEmpty(usedNarration))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Used Narration field is required at Cheque No. [" + chequeNo + "]";
                }
                else
                {
                    bankChequeBook.ChequeUsedByAutoRefNoAndChequeNo(autoRefNo, chequeNo, LumexLibraryManager.ParseAppDate(usedDate), usedVoucherNo, usedJournalNo, usedNarration);

                    GetBankChequeBookPagesByAutoRefNo(numberLabel.Text.Trim());
                    string message = "Cheque <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void GetBankChequeBookEntryByAutoRefNo(string autoRefNo)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                DataTable dt = bankChequeBook.GetBankChequeBookEntryByAutoRefNo(autoRefNo);

                if (dt.Rows.Count > 0 && dt.Rows[0]["AccountId"].ToString() == bankAccountHeadDropDownList.SelectedValue.Trim())
                {
                    numberLabel.Text = autoRefNo.Trim();
                    bankAccountHeadLabel.Text = dt.Rows[0]["AccountHead"].ToString();
                    chequeBookRefNoLabel.Text = dt.Rows[0]["ChequeBookRefNo"].ToString();
                    startPageNoLabel.Text = dt.Rows[0]["StartPageNo"].ToString();
                    endPageNoLabel.Text = dt.Rows[0]["EndPageNo"].ToString();
                    entryDateLabel.Text = dt.Rows[0]["EntryDate"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();

                    GetBankChequeBookPagesByAutoRefNo(autoRefNo);
                }
                else
                {
                    chequeBookEntry.Visible = false;
                    msgbox.Visible = true; msgTitleLabel.Text = "Cheque Book Entry Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bankChequeBook = null;
            }
        }

        protected void GetBankChequeBookPagesByAutoRefNo(string autoRefNo)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();
            TextBox usedDateTextBox;
            TextBox usedVoucherNoTextBox;
            TextBox usedJournalNoTextBox;
            TextBox usedNarrationTextBox;
            LinkButton updateLinkButton;

            try
            {
                DataTable dt = bankChequeBook.GetBankChequeBookPagesByAutoRefNo(autoRefNo);

                if (dt.Rows.Count > 0)
                {
                    chequeBookPageListGridView.DataSource = dt;
                    chequeBookPageListGridView.DataBind();

                    for (int i = 0; i < chequeBookPageListGridView.Rows.Count; i++)
                    {
                        usedDateTextBox = (TextBox)chequeBookPageListGridView.Rows[i].Cells[3].FindControl("usedDateTextBox");
                        if (!string.IsNullOrEmpty(dt.Rows[i]["UsedDate"].ToString()))
                        {
                            usedDateTextBox.Text = LumexLibraryManager.GetAppDateView(dt.Rows[i]["UsedDate"].ToString());
                        }
                        else
                        {
                            usedDateTextBox.Text = "";
                        }

                        usedVoucherNoTextBox = (TextBox)chequeBookPageListGridView.Rows[i].Cells[4].FindControl("usedVoucherNoTextBox");
                        usedVoucherNoTextBox.Text = dt.Rows[i]["UsedVoucherNo"].ToString();

                        usedJournalNoTextBox = (TextBox)chequeBookPageListGridView.Rows[i].Cells[5].FindControl("usedJournalNoTextBox");
                        usedJournalNoTextBox.Text = dt.Rows[i]["UsedJournalNo"].ToString();

                        usedNarrationTextBox = (TextBox)chequeBookPageListGridView.Rows[i].Cells[6].FindControl("usedNarrationTextBox");
                        usedNarrationTextBox.Text = dt.Rows[i]["UsedNarration"].ToString();

                        if (chequeBookPageListGridView.Rows[i].Cells[2].Text.ToString() != "Used")
                        {
                            updateLinkButton = (LinkButton)chequeBookPageListGridView.Rows[i].Cells[7].FindControl("updateLinkButton");
                            updateLinkButton.Visible = false;

                            usedDateTextBox.Enabled = false;
                            usedVoucherNoTextBox.ReadOnly = true;
                            usedJournalNoTextBox.ReadOnly = true;
                            usedNarrationTextBox.ReadOnly = true;
                        }
                    }

                    if (chequeBookPageListGridView.Rows.Count > 0)
                    {
                        chequeBookPageListGridView.UseAccessibleHeader = true;
                        chequeBookPageListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        chequeBookEntry.Visible = true;
                    }
                    else
                    {
                        chequeBookEntry.Visible = false;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Cheque Book Page List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bankChequeBook = null;
            }
        }

        protected void chequeBookEntryButton_Click(object sender, EventArgs e)
        {
            GetBankChequeBookEntryByAutoRefNo(autoRefNoTextBox.Text.Trim());
            MyAlertBox("MyOverlayStop();");
        }
    }
}