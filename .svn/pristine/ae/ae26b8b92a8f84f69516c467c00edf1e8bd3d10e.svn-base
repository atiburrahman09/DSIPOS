using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankChequeBook
{
    public partial class ChequeVoidList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    GetChequeVoidListByDateRangeAndAll("All");

                    fromDateTextBox.Focus();
                }

                if (chequeVoidListGridView.Rows.Count > 0)
                {
                    chequeVoidListGridView.UseAccessibleHeader = true;
                    chequeVoidListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetChequeVoidListByDateRangeAndAll(string search)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                bankChequeBook.FromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                bankChequeBook.ToDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());

                DataTable dt = bankChequeBook.GetChequeVoidListByDateRangeAndAll(bankChequeBook.FromDate, bankChequeBook.ToDate, search);

                chequeVoidListGridView.DataSource = dt;
                chequeVoidListGridView.DataBind();

                if (chequeVoidListGridView.Rows.Count > 0)
                {
                    chequeVoidListGridView.UseAccessibleHeader = true;
                    chequeVoidListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Cheque Void List Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-info");
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

        protected void getVoidListButton_Click(object sender, EventArgs e)
        {
            GetChequeVoidListByDateRangeAndAll("");
            MyAlertBox("MyOverlayStop();");
        }

        protected void getAllVoidListButton_Click(object sender, EventArgs e)
        {
            GetChequeVoidListByDateRangeAndAll("All");
            MyAlertBox("MyOverlayStop();");
        }
    }
}