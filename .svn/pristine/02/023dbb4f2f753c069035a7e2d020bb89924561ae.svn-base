using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.PayToFromCompany
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
                    GetPayToFromCompanyList();
                }

                if (payToFromCompanyListGridView.Rows.Count > 0)
                {
                    payToFromCompanyListGridView.UseAccessibleHeader = true;
                    payToFromCompanyListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetPayToFromCompanyList()
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                DataTable dt = payToFromCompany.GetPayToFromCompanyList();
                payToFromCompanyListGridView.DataSource = dt;
                payToFromCompanyListGridView.DataBind();

                if (payToFromCompanyListGridView.Rows.Count > 0)
                {
                    payToFromCompanyListGridView.UseAccessibleHeader = true;
                    payToFromCompanyListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Company List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("PayToFromCompanyIdForUpdate", payToFromCompanyListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AccUI/PayToFromCompany/Update.aspx", false);
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

                PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();
                payToFromCompany.UpdatePayToFromCompanyActivation(payToFromCompanyListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                payToFromCompanyListGridView.Rows[row.RowIndex].Cells[3].Text = "True";
                string message = "Company <span class='actionTopic'>Activated</span> Successfully.";
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

                PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();
                payToFromCompany.UpdatePayToFromCompanyActivation(payToFromCompanyListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                payToFromCompanyListGridView.Rows[row.RowIndex].Cells[3].Text = "False";
                string message = "Company <span class='actionTopic'>Deactivated</span> Successfully.";
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

                PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();
                payToFromCompany.DeletePayToFromCompany(payToFromCompanyListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());

                GetPayToFromCompanyList();
                string message = "Company <span class='actionTopic'>Deleted</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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