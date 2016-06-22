using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;
using Newtonsoft.Json;

namespace lmxIpos.UI.AccUI.JournalVoucher
{
    public partial class UpdateJournalVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    numberLabel.Text = journalNumberForUpdateHiddenField.Value = LumexSessionManager.Get("JournalNumberForUpdate").ToString().Trim();
                    GetJournalVoucherEntryListByJournalNumber(journalNumberForUpdateHiddenField.Value.Trim());

                    LoadChartOfAccountsHeadList();
                    LoadPayToFromCompanyList();
                    LoadBankList();
                }

                if (journalEntryListGridView.Rows.Count > 0)
                {
                    journalEntryListGridView.UseAccessibleHeader = true;
                    journalEntryListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                saveChangesButton.Enabled = false;

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadChartOfAccountsHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsHeadList();

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountHead";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void LoadPayToFromCompanyList()
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                DataTable dt = payToFromCompany.GetActivePayToFromCompanyList();

                payToFromCompanyDropDownList.DataSource = dt;
                payToFromCompanyDropDownList.DataValueField = "CompanyId";
                payToFromCompanyDropDownList.DataTextField = "CompanyName";
                payToFromCompanyDropDownList.DataBind();
                payToFromCompanyDropDownList.Items.Insert(0, "");
                payToFromCompanyDropDownList.Items.Insert(1, "N/A");
                payToFromCompanyDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Pay To/From Company Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void LoadBankList()
        {
            BankBLL bank = new BankBLL();

            try
            {
                DataTable dt = bank.GetActiveBankList();

                bankDropDownList.DataSource = dt;
                bankDropDownList.DataValueField = "BankId";
                bankDropDownList.DataTextField = "BankName";
                bankDropDownList.DataBind();
                bankDropDownList.Items.Insert(0, "");
                bankDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bank = null;
            }
        }

        protected void GetJournalVoucherEntryListByJournalNumber(string journalNumber)
        {
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

            try
            {
                DataTable dt = journalVoucher.GetJournalVoucherEntryListByJournal(journalNumber);

                if (dt.Rows.Count > 0)
                {
                    transactionDateLabel.Text = dt.Rows[0]["TransactionDate"].ToString();
                    autoVoucherNumberLabel.Text = dt.Rows[0]["AutoVoucherNumber"].ToString() + " - T" + dt.Rows.Count.ToString();
                    voucherStatusLabel.Text = dt.Rows[0]["Status"].ToString();
                    totalEntryLabel.Text = dt.Rows.Count.ToString();

                    journalEntryListGridView.DataSource = dt;
                    journalEntryListGridView.DataBind();

                    if (journalEntryListGridView.Rows.Count > 0)
                    {
                        journalEntryListGridView.UseAccessibleHeader = true;
                        journalEntryListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                    CalculateTotalDebitCreditAmount(dt);
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Journal Voucher Entry List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                journalVoucher = null;
            }
        }

        protected void CalculateTotalDebitCreditAmount(DataTable dt)
        {
            try
            {
                decimal drAmt = 0, crAmt = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["DebitCredit"].ToString() == "Dr")
                    {
                        drAmt += decimal.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                    else
                    {
                        crAmt += decimal.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                }

                totalAmountLabel.Text = drAmtLabel.Text = drAmt.ToString();
                crAmtLabel.Text = crAmt.ToString();

                if (drAmt == crAmt && voucherStatusLabel.Text == "Update Pending")
                {
                    saveChangesButton.Enabled = true;
                }
                else
                {
                    saveChangesButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        [WebMethod]
        public static string GetJournalEntryViewByJournalAndTransactionNumber(string SN, string journalNumber)
        {
            try
            {
                JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

                DataTable dt = journalVoucher.GetJournalVoucherEntryByJournalAndTransactionNumber(journalNumber, SN);

                string json = JsonConvert.SerializeObject(dt);
                json = json.Substring(1, json.Length - 2);

                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

            try
            {
                if (accountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Account Head field is required.";
                }
                else if (voucherNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Voucher Number field is required.";
                }
                else if (payToFromCompanyDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Pay To/From Company field is required.";
                }
                else if (narrationTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Narration field is required.";
                }
                else
                {
                    journalVoucher.JournalNumber = journalNumberForUpdateHiddenField.Value.Trim();
                    journalVoucher.TransactionNumber = transactionNumberForUpdateHiddenField.Value.Trim();
                    journalVoucher.Description = descriptionForUpdateHiddenField.Value.Trim();
                    journalVoucher.ManualVoucherNumber = voucherNumberTextBox.Text.Trim();
                    journalVoucher.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                    journalVoucher.DebitCredit = debitCreditDropDownList.SelectedValue.Trim();
                    journalVoucher.Amount = amountTextBox.Text.Trim();
                    journalVoucher.Bank = bankDropDownList.SelectedValue.Trim();
                    journalVoucher.BankBranch = bankBranchTextBox.Text.Trim();
                    journalVoucher.ChequeNumber = chequeNumberTextBox.Text.Trim();
                    journalVoucher.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim());
                    journalVoucher.PayToFromCompany = payToFromCompanyDropDownList.SelectedValue.Trim();
                    journalVoucher.Narration = narrationTextBox.Text.Trim();

                    journalVoucher.UpdateJournalVoucherEntryByJournalAndTransactionNumber();

                    GetJournalVoucherEntryListByJournalNumber(numberLabel.Text.Trim());
                    string message = "Journal Voucher Entry <span class='actionTopic'>Updated</span> Successfully.";
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
                journalVoucher = null;
            }
        }

        protected void saveChangesButton_Click(object sender, EventArgs e)
        {
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

            try
            {
                if (drAmtLabel.Text == crAmtLabel.Text && voucherStatusLabel.Text == "Update Pending")
                {
                    journalVoucher.UpdateJournalVoucherUpdateStatusByJournal(numberLabel.Text.Trim());

                    string message = "Journal Voucher Changes <span class='actionTopic'>Saved</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/JournalVoucher/JournalVoucherList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                journalVoucher = null;
            }
        }
    }
}