using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Lumex.Tech;
using Lumex.Project.BLL;

namespace lmxIpos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LumexLibraryManager.EncryptWebConenctionString();

                Page.Title = "Default Page";
                if (Session["DateFormatForDatePicker"] == null)
                {
                    LumexSessionManager.Add("DateFormatForDatePicker", LumexLibraryManager.GetAppDateFormat().ToLower());
                }
                if ((string)LumexSessionManager.Get("Userapp")== "lib")
                {

                    divSalesStatistic.Visible = false;
                    divShortcuts.Visible = false;
                }
                else
                {
                    divSalesStatistic.Visible = true;
                    divShortcuts.Visible = true;
                    getTodaysTotalCashCreditSales();

                }

                string ActiveUser = (string)LumexSessionManager.Get("ActiveUserId");
                if (!string.IsNullOrEmpty(ActiveUser))
                {
                    getUserById(ActiveUser);

                }
            }

        }

        private void getTodaysTotalCashCreditSales()
        {
            SalesCenterBLL salesCenterBll = new SalesCenterBLL();
            try
            {
                string startdate = DateTime.Now.ToString("dd/MM/yyyy");
                string EndDate = startdate;

                DataTable dt = salesCenterBll.getTotalCashCreditSalesByDateRange(startdate, EndDate, (string)LumexSessionManager.Get("ActiveUserId"));

                if (dt.Rows.Count > 0)
                {
                    lblTotalSales.Text = dt.Rows[0][0].ToString();
                    lblInCash.Text = dt.Rows[0][1].ToString();
                    lblInDue.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString()) - Convert.ToDecimal(dt.Rows[0][1].ToString())).ToString();
                }
                else
                {
                    lblTotalSales.Text = "0.00";
                    lblInCash.Text = "0.00";
                    lblInDue.Text = "0.00";
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }
        }

        private void getUserById(string userId)
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);
                lblUserId.Text = dt.Rows[0]["UserId"].ToString();
                lblUserName.Text = dt.Rows[0]["UserName"].ToString();
                lblUserGroup.Text = dt.Rows[0]["UserGroupName"].ToString();
                lblContactNumber.Text = dt.Rows[0]["ContactNumber"].ToString();
                lblEmail.Text = dt.Rows[0]["Email"].ToString(); ;
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblSalesCenterName.Text = dt.Rows[0]["SalesCenterName"].ToString();
                lblWarehouseName.Text = dt.Rows[0]["WareHouseName"].ToString();

                if (dt.Rows[0]["IsActive"].ToString() == "True")
                {
                    lblStatus.Text = "Active";
                    lblStatus.CssClass = "bold text-success";
                }
                else
                {
                    lblStatus.Text = "Deactive";
                    lblStatus.CssClass = "bold text-error";
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
                user = null;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}