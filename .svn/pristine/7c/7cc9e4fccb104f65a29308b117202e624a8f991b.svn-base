using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductRequisition
{
    public partial class ApprovalRequisitionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
               // LoadSalesCenters();
               // GetProductRequisitionsApprovalListByWarehouse(salesCenterDropDownList.SelectedValue.Trim());
                drpdwnRequisationTo.Focus();
            }

            if (productRequisitionApprovalListGridView.Rows.Count > 0)
            {
                productRequisitionApprovalListGridView.UseAccessibleHeader = true;
                productRequisitionApprovalListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void transferTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpdwnRequisationTo.SelectedValue == "")
            {
                salesCenterDropDownList.Items.Clear();
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer Type field is required.";
            }
            else
            {
                LoadTransferFromToItems(drpdwnRequisationTo.SelectedValue.Trim());
            }
        }
        protected void LoadTransferFromToItems(string transferType)
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                //if (transferType == "WH-WH")
                //{
                //    DataTable dt = warehouse.GetActiveWarehouseListByUser();

                //    transferFromDropDownList.DataSource = dt;
                //    transferFromDropDownList.DataValueField = "WarehouseId";
                //    transferFromDropDownList.DataTextField = "WarehouseName";
                //    transferFromDropDownList.DataBind();
                //    transferFromDropDownList.Items.Insert(0, "");
                //    transferFromDropDownList.SelectedIndex = 0;

                //    transferToDropDownList.DataSource = dt;
                //    transferToDropDownList.DataValueField = "WarehouseId";
                //    transferToDropDownList.DataTextField = "WarehouseName";
                //    transferToDropDownList.DataBind();
                //    transferToDropDownList.Items.Insert(0, "");
                //    transferToDropDownList.SelectedIndex = 0;
                //}
                //else 
                if (transferType == "WH-SC")
                {
                    DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                    salesCenterDropDownList.DataSource = dt;
                    salesCenterDropDownList.DataValueField = "SalesCenterId";
                    salesCenterDropDownList.DataTextField = "SalesCenterName";
                    salesCenterDropDownList.DataBind();
                    salesCenterDropDownList.Items.Insert(0, "Select Please...");
                    salesCenterDropDownList.SelectedIndex = 0;
                    salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();


                }
                //else if (transferType == "SC-SC")
                //{
                //    DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                //    transferFromDropDownList.DataSource = dt;
                //    transferFromDropDownList.DataValueField = "SalesCenterId";
                //    transferFromDropDownList.DataTextField = "SalesCenterName";
                //    transferFromDropDownList.DataBind();
                //    transferFromDropDownList.Items.Insert(0, "");
                //    transferFromDropDownList.SelectedIndex = 0;

                //    transferToDropDownList.DataSource = dt;
                //    transferToDropDownList.DataValueField = "SalesCenterId";
                //    transferToDropDownList.DataTextField = "SalesCenterName";
                //    transferToDropDownList.DataBind();
                //    transferToDropDownList.Items.Insert(0, "");
                //    transferToDropDownList.SelectedIndex = 0;
                //}
                else if (transferType == "SC-WH")
                {


                    DataTable dt = warehouse.GetActiveWarehouseListByUser();


                    salesCenterDropDownList.DataSource = dt;
                    salesCenterDropDownList.DataValueField = "WarehouseId";
                    salesCenterDropDownList.DataTextField = "WarehouseName";
                    salesCenterDropDownList.DataBind();
                    salesCenterDropDownList.Items.Insert(0, "Select Please...");
                    salesCenterDropDownList.SelectedIndex = 0;
                    salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

                }
                else
                {
                    salesCenterDropDownList.Items.Clear();

                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesCenter = null;
                warehouse = null;
            }
        }

        protected void LoadSalesCenters()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetActiveSalesCenterList();

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataValueField = "SalesCenterId";
                salesCenterDropDownList.DataTextField = "SalesCenterName";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "All");
                salesCenterDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesCenter = null;
            }
        }

        protected void approvalListButton_Click(object sender, EventArgs e)
        {
            GetProductRequisitionsApprovalListByWarehouse(salesCenterDropDownList.SelectedValue.Trim());
            MyAlertBox("MyOverlayStop();");
        }

        protected void GetProductRequisitionsApprovalListByWarehouse(string salesCenterId)
        {
            ProductRequisitionBLL productRequisition = new ProductRequisitionBLL();

            try
            {
                DataTable dt = productRequisition.GetProductRequisitionsApprovalListBySalesCenter(salesCenterId,drpdwnRequisationTo.SelectedValue);

                productRequisitionApprovalListGridView.DataSource = dt;
                productRequisitionApprovalListGridView.DataBind();

                if (productRequisitionApprovalListGridView.Rows.Count > 0)
                {
                    productRequisitionApprovalListGridView.UseAccessibleHeader = true;
                    productRequisitionApprovalListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                productRequisition = null;
            }
        }

        protected void viewToApproveLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ProductRequisitionIdForApprove", productRequisitionApprovalListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/ProductRequisition/ApproveRequisition.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}