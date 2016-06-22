using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankBranch
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = bankBranchIdForViewHiddenField.Value = LumexSessionManager.Get("BankBranchIdForView").ToString().Trim();
                    GetBankBranchById(bankBranchIdForViewHiddenField.Value.Trim());
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

        protected void GetBankBranchById(string bankBranchId)
        {
            BankBranchBLL bankBranch = new BankBranchBLL();

            try
            {
                DataTable dt = bankBranch.GetBankBranchById(bankBranchId);

                if (dt.Rows.Count > 0)
                {
                    bankBranchNameLabel.Text = dt.Rows[0]["BranchName"].ToString();
                    bankIdLabel.Text = dt.Rows[0]["BankId"].ToString();
                    bankNameLabel.Text = dt.Rows[0]["BankName"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Branch Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bankBranch = null;
            }
        }
    }
}