﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseOrder
{
    public partial class PurchaseOrderCancelRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
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
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "");
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

        protected void cancelRequestLinkButton_Click(object sender, EventArgs e)
        {
            PurchaseOrderBLL purchaseOrder = new PurchaseOrderBLL();

            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                purchaseOrder.UpdatePurchaseOrderStatusById(pendingPurchaseOrderListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "CP");

                MyAlertBox("alert(\"Purchase Order [" + pendingPurchaseOrderListGridView.Rows[row.RowIndex].Cells[0].Text.ToString() + "] Cancel Request Submitted Successfully.\"); window.location=\"/UI/PurchaseOrder/PurchaseOrderCancelRequestList.aspx\"");
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
            PurchaseOrderBLL purchaseOrder = new PurchaseOrderBLL();

            try
            {
                if (warehouseDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else
                {
                    string warehouseId = warehouseDropDownList.SelectedValue.Trim();

                    DataTable dt = purchaseOrder.GetPendingPurchaseOrdersListByWarehouse(warehouseId);

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