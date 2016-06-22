using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class ChequeBookPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    numberLabel.Text = chequeBookAutoRefNoForViewHiddenField.Value = LumexSessionManager.Get("ChequeBookAutoRefNoForView").ToString().Trim();
                    GetBankChequeBookEntryByAutoRefNo(chequeBookAutoRefNoForViewHiddenField.Value.Trim());
                    GetBankChequeBookPagesByAutoRefNo(chequeBookAutoRefNoForViewHiddenField.Value.Trim());
                }

                if (chequeBookPageListGridView.Rows.Count > 0)
                {
                    chequeBookPageListGridView.UseAccessibleHeader = true;
                    chequeBookPageListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetBankChequeBookEntryByAutoRefNo(string autoRefNo)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                DataTable dt = bankChequeBook.GetBankChequeBookEntryByAutoRefNo(autoRefNo);

                if (dt.Rows.Count > 0)
                {
                    bankAccountHeadLabel.Text = dt.Rows[0]["AccountHead"].ToString();
                    chequeBookRefNoLabel.Text = dt.Rows[0]["ChequeBookRefNo"].ToString();
                    startPageNoLabel.Text = dt.Rows[0]["StartPageNo"].ToString();
                    endPageNoLabel.Text = dt.Rows[0]["EndPageNo"].ToString();
                    entryDateLabel.Text = dt.Rows[0]["EntryDate"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                }
                else
                {
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

            try
            {
                DataTable dt = bankChequeBook.GetBankChequeBookPagesByAutoRefNo(autoRefNo);

                if (dt.Rows.Count > 0)
                {
                    chequeBookPageListGridView.DataSource = dt;
                    chequeBookPageListGridView.DataBind();

                    if (chequeBookPageListGridView.Rows.Count > 0)
                    {
                        chequeBookPageListGridView.UseAccessibleHeader = true;
                        chequeBookPageListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    //msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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