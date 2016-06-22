using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Warehouse
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
                    idLabel.Text = warehouseIdForViewHiddenField.Value = LumexSessionManager.Get("WarehouseIdForView").ToString().Trim();
                    GetWarehouseById(warehouseIdForViewHiddenField.Value.Trim());
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

        protected void GetWarehouseById(string warehouseId)
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetWarehouseById(warehouseId);

                if (dt.Rows.Count > 0)
                {
                    warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    countryLabel.Text = dt.Rows[0]["Country"].ToString();
                    cityLabel.Text = dt.Rows[0]["City"].ToString();
                    districtLabel.Text = dt.Rows[0]["District"].ToString();
                    postalCodeLabel.Text = dt.Rows[0]["PostalCode"].ToString();
                    phoneLabel.Text = dt.Rows[0]["Phone"].ToString();
                    mobileLabel.Text = dt.Rows[0]["Mobile"].ToString();
                    faxLabel.Text = dt.Rows[0]["Fax"].ToString();
                    emailLabel.Text = dt.Rows[0]["Email"].ToString();
                    addressLabel.Text = dt.Rows[0]["Address"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Warehouse Data Not Found!!!"; msgDetailLabel.Text = "";
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
                warehouse = null;
            }
        }
    }
}