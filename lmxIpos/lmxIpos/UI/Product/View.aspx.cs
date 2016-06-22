using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Product
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
                    idLabel.Text = productIdForViewHiddenField.Value = LumexSessionManager.Get("ProductIdForView").ToString().Trim();
                    GetProductById(productIdForViewHiddenField.Value.Trim());
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

        protected void GetProductById(string productId)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetProductById(productId);

                if (dt.Rows.Count > 0)
                {
                    barcodeLabel.Text = dt.Rows[0]["Barcode"].ToString();
                    productNameOnlyLabel.Text = dt.Rows[0]["ProductNameOnly"].ToString();
                    productGroupLabel.Text = dt.Rows[0]["ProductGroupName"].ToString();
                    productVolumeLabel.Text = dt.Rows[0]["ProductVolume"].ToString();
                    volumeQuantityLabel.Text = dt.Rows[0]["VolumeQuantity"].ToString();
                    unitLabel.Text = dt.Rows[0]["Unit"].ToString();
                    productRateLabel.Text = dt.Rows[0]["ProductRate"].ToString();
                    lblWarehouse.Text = dt.Rows[0]["WareHouse"].ToString();
                    lblSalesCenter.Text = dt.Rows[0]["SalesCenter"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Data Not Found!!!"; msgDetailLabel.Text = "";
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
                product = null;
            }
        }
    }
}