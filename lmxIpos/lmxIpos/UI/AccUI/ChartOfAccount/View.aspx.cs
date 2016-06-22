using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.ChartOfAccount
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
                    idLabel.Text = chartOfAccountIdForViewHiddenField.Value = LumexSessionManager.Get("ChartOfAccountIdForView").ToString().Trim();
                    GetChartOfAccountById(chartOfAccountIdForViewHiddenField.Value.Trim());
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

        protected void GetChartOfAccountById(string accountId)
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetChartOfAccountById(accountId);

                if (dt.Rows.Count > 0)
                {
                    accountNameLabel.Text = dt.Rows[0]["AccountName"].ToString();
                    accountTypeLabel.Text = dt.Rows[0]["AccountTypeName"].ToString();
                    accountNumberLabel.Text = dt.Rows[0]["AccountNumber"].ToString();
                    totallingAccountNumberLabel.Text = dt.Rows[0]["TotallingAccountNumber"].ToString();
                    totallingAccountNameLabel.Text = dt.Rows[0]["TotallingAccountName"].ToString();
                    postedLabel.Text = dt.Rows[0]["IsPosted"].ToString();
                    accountLevelLabel.Text = dt.Rows[0]["AccountLevel"].ToString();
                    useAsLabel.Text = dt.Rows[0]["UseAs"].ToString();
                    bankAccountNumberLabel.Text = dt.Rows[0]["BankAccountNumber"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
                    group1Label.Text = dt.Rows[0]["Group1"].ToString();
                    group2Label.Text = dt.Rows[0]["Group2"].ToString();
                    group3Label.Text = dt.Rows[0]["Group3"].ToString();
                    group4Label.Text = dt.Rows[0]["Group4"].ToString();
                    group5Label.Text = dt.Rows[0]["Group5"].ToString();
                    group1NameLabel.Text = dt.Rows[0]["Group1Name"].ToString();
                    group2NameLabel.Text = dt.Rows[0]["Group2Name"].ToString();
                    group3NameLabel.Text = dt.Rows[0]["Group3Name"].ToString();
                    group4NameLabel.Text = dt.Rows[0]["Group4Name"].ToString();
                    group5NameLabel.Text = dt.Rows[0]["Group5Name"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Chart Of Account Data Not Found!!!"; msgDetailLabel.Text = "";
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
    }
}