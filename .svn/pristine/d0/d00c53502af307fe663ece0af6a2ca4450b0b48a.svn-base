using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseOrder
{
    public partial class PurchaseOrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = purchaseOrderIdForViewHiddenField.Value = LumexSessionManager.Get("PurchaseOrderIdForView").ToString().Trim();
                    GetPurchaseOrderById(purchaseOrderIdForViewHiddenField.Value.Trim());
                    GetPurchaseOrderProductListById(purchaseOrderIdForViewHiddenField.Value.Trim());
                }

                if (purchaseOrderProductListGridView.Rows.Count > 0)
                {
                    purchaseOrderProductListGridView.UseAccessibleHeader = true;
                    purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetPurchaseOrderById(string purchaseOrderId)
        {
            PurchaseOrderBLL purchaseOrder = new PurchaseOrderBLL();

            try
            {
                DataTable dt = purchaseOrder.GetPurchaseOrderById(purchaseOrderId);

                if (dt.Rows.Count > 0)
                {
                    orderDateLabel.Text = dt.Rows[0]["OrderDate"].ToString();
                    prIDLabel.Text = dt.Rows[0]["PurchaseRequisitionId"].ToString();
                    prDateLabel.Text = ", " + dt.Rows[0]["PurchaseRequisitionDate"].ToString();
                    warehouseIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                    warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    vendorIdLabel.Text = dt.Rows[0]["VendorId"].ToString();
                    vendorNameLabel.Text = dt.Rows[0]["VendorName"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        protected void GetPurchaseOrderProductListById(string purchaseOrderId)
        {
            PurchaseOrderBLL purchaseOrder = new PurchaseOrderBLL();

            try
            {
                DataTable dt = purchaseOrder.GetPurchaseOrderProductListById(purchaseOrderId, prIDLabel.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    purchaseOrderProductListGridView.DataSource = dt;
                    purchaseOrderProductListGridView.DataBind();

                    if (purchaseOrderProductListGridView.Rows.Count > 0)
                    {
                        purchaseOrderProductListGridView.UseAccessibleHeader = true;
                        purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                purchaseOrder = null;
            }
        }
    }
}