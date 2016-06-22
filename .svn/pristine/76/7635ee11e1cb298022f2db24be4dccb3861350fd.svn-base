using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class ChequeVoid : System.Web.UI.Page
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

        protected void voidLinkButton_Click(object sender, EventArgs e)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                TextBox voidNarrationTextBox = (TextBox)chequeBookPageListGridView.Rows[row.RowIndex].Cells[6].FindControl("voidNarrationTextBox");
                string voidNarration = voidNarrationTextBox.Text.Trim();
                string chequeNo = chequeBookPageListGridView.Rows[row.RowIndex].Cells[1].Text.Trim();
                string autoRefNo = numberLabel.Text.Trim();

                if (string.IsNullOrEmpty(voidNarration))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Void Narration field is required at Cheque No. [" + chequeNo + "]";
                }
                else
                {
                    bankChequeBook.ChequeVoidByAutoRefNoAndChequeNo(autoRefNo, chequeNo, voidNarration);

                    GetBankChequeBookPagesByAutoRefNo(numberLabel.Text.Trim());
                    string message = "Cheque <span class='actionTopic'>Void</span> Successfully.";
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
            TextBox voidNarrationTextBox;
            LinkButton voidLinkButton;

            try
            {
                DataTable dt = bankChequeBook.GetBankChequeBookPagesByAutoRefNo(autoRefNo);

                if (dt.Rows.Count > 0)
                {
                    chequeBookPageListGridView.DataSource = dt;
                    chequeBookPageListGridView.DataBind();

                    for (int i = 0; i < chequeBookPageListGridView.Rows.Count; i++)
                    {
                        voidNarrationTextBox = (TextBox)chequeBookPageListGridView.Rows[i].Cells[6].FindControl("voidNarrationTextBox");
                        voidNarrationTextBox.Text = dt.Rows[i]["VoidNarration"].ToString();

                        if (chequeBookPageListGridView.Rows[i].Cells[2].Text.ToString() == "Void")
                        {
                            voidLinkButton = (LinkButton)chequeBookPageListGridView.Rows[i].Cells[7].FindControl("voidLinkButton");
                            voidLinkButton.Visible = false;

                            voidNarrationTextBox.ReadOnly = true;
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