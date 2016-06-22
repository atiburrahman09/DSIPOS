using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class ChequeBookEntryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadChartOfAccountsBankHeadList();
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());

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

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ChequeBookAutoRefNoForView", chequeBookEntryListGridView.Rows[row.RowIndex].Cells[3].Text.ToString());
                Response.Redirect("~/UI/AccUI/BankChequeBook/ChequeBookPages.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void chequeBookEntryListButton_Click(object sender, EventArgs e)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                if (bankAccountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Account Head field is required.";
                }
                else if (fromDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date From field is required.";
                }
                else if (toDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date To field is required.";
                }
                else
                {
                    bankChequeBook.AccountId = bankAccountHeadDropDownList.SelectedValue.Trim();
                    bankChequeBook.FromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    bankChequeBook.ToDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    bankChequeBook.Status = statusDropDownList.SelectedValue.Trim();

                    DataTable dt = bankChequeBook.GetBankChequeBookEntryListByAccountIdDateRangeAndStatus();

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
                MyAlertBox("MyOverlayStop();");
            }
        }
    }
}