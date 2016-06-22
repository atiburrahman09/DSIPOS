using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferRecord
{
    public partial class TransferRecordApprovalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {

            }

            if (transferRecordListGridView.Rows.Count > 0)
            {
                transferRecordListGridView.UseAccessibleHeader = true;
                transferRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadTransferToItems(string transferDestination)
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                if (transferDestination == "WH")
                {
                    DataTable dt = warehouse.GetActiveWarehouseList();

                    transferToDropDownList.DataSource = dt;
                    transferToDropDownList.DataValueField = "WarehouseId";
                    transferToDropDownList.DataTextField = "WarehouseName";
                    transferToDropDownList.DataBind();
                    transferToDropDownList.Items.Insert(0, "");
                }
                else if (transferDestination == "SC")
                {
                    DataTable dt = salesCenter.GetActiveSalesCenterList();

                    transferToDropDownList.DataSource = dt;
                    transferToDropDownList.DataValueField = "SalesCenterId";
                    transferToDropDownList.DataTextField = "SalesCenterName";
                    transferToDropDownList.DataBind();
                    transferToDropDownList.Items.Insert(0, "");
                }
                else
                {
                    transferToDropDownList.Items.Clear();
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

        protected void viewToApproveLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ProductTransferRecordIdForApprove", transferRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/ProductTransferRecord/ApproveTransferRecord.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void GetApprovalList()
        {
            ProductTransferRecordBLL productTransferRecord = new ProductTransferRecordBLL();

            try
            {
                if (transferTypeDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer Type field is required.";
                }
                else if (transferToDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer To field is required.";
                }
                else
                {
                    productTransferRecord.Description = transferDescriptionDropDownList.SelectedValue.Trim();
                    productTransferRecord.TransferType = transferTypeDropDownList.SelectedValue.Trim();
                    productTransferRecord.TransferTo = transferToDropDownList.SelectedValue.Trim();
                    productTransferRecord.Status = "P";

                    DataTable dt = productTransferRecord.GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatus();

                    transferRecordListGridView.DataSource = dt;
                    transferRecordListGridView.DataBind();

                    if (transferRecordListGridView.Rows.Count > 0)
                    {
                        transferRecordListGridView.UseAccessibleHeader = true;
                        transferRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                productTransferRecord = null;
            }
        }

        protected void approvalListButton_Click(object sender, EventArgs e)
        {
            GetApprovalList();
        }

        protected void transferDestinationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransferToItems(transferDestinationDropDownList.SelectedValue.Trim());

            transferTypeDropDownList.Items.Clear();

            if (transferDestinationDropDownList.SelectedValue.Trim() == "SC")
            {
                ListItem i1 = new ListItem("Warehouse to Salse Center", "WH-SC");
                ListItem i2 = new ListItem("Salse Center to Salse Center", "SC-SC");

                transferTypeDropDownList.Items.Insert(0, i1);
                transferTypeDropDownList.Items.Insert(0, i2);
                transferTypeDropDownList.Items.Insert(0, "All");
            }
            else if (transferDestinationDropDownList.SelectedValue.Trim() == "WH")
            {
                ListItem i1 = new ListItem("Salse Center to Warehouse", "SC-WH");
                ListItem i2 = new ListItem("Warehouse to Warehouse", "WH-WH");

                transferTypeDropDownList.Items.Insert(0, i1);
                transferTypeDropDownList.Items.Insert(0, i2);
                transferTypeDropDownList.Items.Insert(0, "All");
            }
        }
    }
}