using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.ChartOfAccount
{
    public partial class ListView : System.Web.UI.Page
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

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ChartOfAccountIdForView", chartOfAccountListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AccUI/ChartOfAccount/View.aspx", false);
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