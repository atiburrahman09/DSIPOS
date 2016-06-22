using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesCenter
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
                    idLabel.Text = salesCenterIdForViewHiddenField.Value = LumexSessionManager.Get("SalesCenterIdForView").ToString().Trim();
                    GetSalesCenterById(salesCenterIdForViewHiddenField.Value.Trim());
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

        protected void GetSalesCenterById(string salesCenterId)
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetSalesCenterById(salesCenterId);

                if (dt.Rows.Count > 0)
                {
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    countryLabel.Text = dt.Rows[0]["Country"].ToString();
                    cityLabel.Text = dt.Rows[0]["City"].ToString();
                    districtLabel.Text = dt.Rows[0]["District"].ToString();
                    postalCodeLabel.Text = dt.Rows[0]["PostalCode"].ToString();
                    phoneLabel.Text = dt.Rows[0]["Phone"].ToString();
                    mobileLabel.Text = dt.Rows[0]["Mobile"].ToString();
                    faxLabel.Text = dt.Rows[0]["Fax"].ToString();
                    emailLabel.Text = dt.Rows[0]["Email"].ToString();
                    addressLabel.Text = dt.Rows[0]["Address"].ToString();
                    warehouseLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
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
                salesCenter = null;
            }
        }
    }
}