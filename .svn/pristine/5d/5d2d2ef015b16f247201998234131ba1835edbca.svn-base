using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseRequisition
{
    public partial class ApprovalRequisitionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
                GetPurchaseRequisitionsApprovalListByWarehouse(warehouseDropDownList.SelectedValue.Trim());
            }

            if (purchaseRequisitionApprovalListGridView.Rows.Count > 0)
            {
                purchaseRequisitionApprovalListGridView.UseAccessibleHeader = true;
                purchaseRequisitionApprovalListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void approvalListButton_Click(object sender, EventArgs e)
        {
            GetPurchaseRequisitionsApprovalListByWarehouse(warehouseDropDownList.SelectedValue.Trim());
        }

        protected void GetPurchaseRequisitionsApprovalListByWarehouse(string warehouseId)
        {
            PurchaseRequisitionBLL purchaseRequisition = new PurchaseRequisitionBLL();

            try
            {
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionsApprovalListByWarehouse(warehouseId);

                purchaseRequisitionApprovalListGridView.DataSource = dt;
                purchaseRequisitionApprovalListGridView.DataBind();

                if (purchaseRequisitionApprovalListGridView.Rows.Count > 0)
                {
                    purchaseRequisitionApprovalListGridView.UseAccessibleHeader = true;
                    purchaseRequisitionApprovalListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                purchaseRequisition = null;
            }
        }

        protected void viewToApproveLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("PurchaseRequisitionIdForApprove", purchaseRequisitionApprovalListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/PurchaseRequisition/ApproveRequisition.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}