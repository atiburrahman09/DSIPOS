using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.ChartOfAccount
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    GetChartOfAccountListByAccountType(accountTypeDropDownList.SelectedValue.Trim());

                    accountTypeDropDownList.Focus();
                }

                if (chartOfAccountListGridView.Rows.Count > 0)
                {
                    chartOfAccountListGridView.UseAccessibleHeader = true;
                    chartOfAccountListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void accountListButton_Click(object sender, EventArgs e)
        {
            GetChartOfAccountListByAccountType(accountTypeDropDownList.SelectedValue.Trim());
            MyAlertBox("MyOverlayStop();");
        }

        protected void GetChartOfAccountListByAccountType(string accountType)
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetChartOfAccountListByAccountType(accountType);

                chartOfAccountListGridView.DataSource = dt;
                chartOfAccountListGridView.DataBind();

                if (chartOfAccountListGridView.Rows.Count > 0)
                {
                    chartOfAccountListGridView.UseAccessibleHeader = true;
                    chartOfAccountListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Chart Of Account List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ChartOfAccountIdForUpdate", chartOfAccountListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AccUI/ChartOfAccount/Update.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();
                chartOfAccount.UpdateChartOfAccountActivation(chartOfAccountListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                chartOfAccountListGridView.Rows[row.RowIndex].Cells[6].Text = "True";
                string message = "Chart Of Account <span class='actionTopic'>Activated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deactivateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();
                chartOfAccount.UpdateChartOfAccountActivation(chartOfAccountListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                chartOfAccountListGridView.Rows[row.RowIndex].Cells[6].Text = "False";
                string message = "Chart Of Account <span class='actionTopic'>Deactivated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();
                string status = chartOfAccount.DeleteChartOfAccountById(chartOfAccountListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), chartOfAccountListGridView.Rows[row.RowIndex].Cells[2].Text.ToString(), "False");

                if (status == "Deleted")
                {
                    GetChartOfAccountListByAccountType(accountTypeDropDownList.SelectedValue.Trim());
                    string message = "Chart Of Account <span class='actionTopic'>Deleted</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    GetChartOfAccountListByAccountType(accountTypeDropDownList.SelectedValue.Trim());
                    string message = "This Chart Of Account contains " + status + " child(s). You can't delete this Chart Of Account. You must delete the child(s) first.";
                    MyAlertBox("WarningAlert(\"" + "Data Dependency" + "\", \"" + message + "\", \"\");");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
    }
}