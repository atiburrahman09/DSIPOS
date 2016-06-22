using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseOrder
{
    public partial class PendingPurchaseOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
                GetPendingOrderList();
            }

            if (pendingPurchaseOrderListGridView.Rows.Count > 0)
            {
                pendingPurchaseOrderListGridView.UseAccessibleHeader = true;
                pendingPurchaseOrderListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadWarehouses()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseList();

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "All");
                warehouseDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                warehouse = null;
            }
        }

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("PurchaseOrderIdForView", pendingPurchaseOrderListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/PurchaseOrder/PurchaseOrderDetail.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void GetPendingOrderList()
        {
            PurchaseOrderBLL purchaseOrder = new PurchaseOrderBLL();

            try
            {
                DataTable dt = purchaseOrder.GetPendingPurchaseOrdersListByWarehouse(warehouseDropDownList.SelectedValue.Trim());

                pendingPurchaseOrderListGridView.DataSource = dt;
                pendingPurchaseOrderListGridView.DataBind();

                if (pendingPurchaseOrderListGridView.Rows.Count > 0)
                {
                    pendingPurchaseOrderListGridView.UseAccessibleHeader = true;
                    pendingPurchaseOrderListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void pendingOrderListButton_Click(object sender, EventArgs e)
        {
            GetPendingOrderList();
        }
    }
}