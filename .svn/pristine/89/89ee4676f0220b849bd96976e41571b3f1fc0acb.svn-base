using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.PayToFromCompany
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
                    idLabel.Text = payToFromCompanyIdForViewHiddenField.Value = LumexSessionManager.Get("PayToFromCompanyIdForView").ToString().Trim();
                    GetPayToFromCompanyById(payToFromCompanyIdForViewHiddenField.Value.Trim());
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

        protected void GetPayToFromCompanyById(string companyId)
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();

            try
            {
                DataTable dt = payToFromCompany.GetPayToFromCompanyById(companyId);

                if (dt.Rows.Count > 0)
                {
                    companyNameLabel.Text = dt.Rows[0]["CompanyName"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Company Data Not Found!!!"; msgDetailLabel.Text = "";
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
    }
}