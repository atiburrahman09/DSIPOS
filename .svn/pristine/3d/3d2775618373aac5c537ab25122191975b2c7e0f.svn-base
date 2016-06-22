using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseToWH
{
    public partial class PurchaseApprovalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
                GetPurchaseRecordsApprovalListByWarehouse(warehouseDropDownList.SelectedValue.Trim());
                warehouseDropDownList.Focus();
            }

            if (purchaseRecordListGridView.Rows.Count > 0)
            {
                purchaseRecordListGridView.UseAccessibleHeader = true;
                purchaseRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                warehouseDropDownList.Items.Insert(0, "All");
                warehouseDropDownList.SelectedIndex = 0;
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

        protected void approvalListButton_Click(object sender, EventArgs e)
        {
            GetPurchaseRecordsApprovalListByWarehouse(warehouseDropDownList.SelectedValue.Trim());
            MyAlertBox("MyOverlayStop();");
        }

        protected void GetPurchaseRecordsApprovalListByWarehouse(string warehouseId)
        {
            PurchaseToWHBLL purchaseRecord = new PurchaseToWHBLL();

            try
            {
                DataTable dt = purchaseRecord.GetPurchaseRecordsApprovalListByWarehouse(warehouseId);

                purchaseRecordListGridView.DataSource = dt;
                purchaseRecordListGridView.DataBind();

                if (purchaseRecordListGridView.Rows.Count > 0)
                {
                    purchaseRecordListGridView.UseAccessibleHeader = true;
                    purchaseRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                purchaseRecord = null;
            }
        }

        protected void viewToApproveLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("PurchaseRecordIdForEditView", purchaseRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/PurchaseToWH/ApprovePurchase.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}