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
    public partial class ViewJournalVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    numberLabel.Text = journalNumberForViewHiddenField.Value = LumexSessionManager.Get("JournalNumberForView").ToString().Trim();
                    GetJournalVoucherEntryListByJournalNumber(journalNumberForViewHiddenField.Value.Trim());
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
    }
}