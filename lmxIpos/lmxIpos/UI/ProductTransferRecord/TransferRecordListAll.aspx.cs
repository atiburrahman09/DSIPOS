using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferRecord
{
    public partial class TransferRecordListAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                //fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                //toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());

                LoadTransferFromToItems(transferTypeDropDownList.SelectedValue.Trim());
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

        protected void LoadTransferFromToItems(string transferType)
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                if (transferType == "WH-WH")
                {
                    DataTable dt = warehouse.GetActiveWarehouseList();

                    transferFromDropDownList.DataSource = dt;
                    transferFromDropDownList.DataValueField = "WarehouseId";
                    transferFromDropDownList.DataTextField = "WarehouseName";
                    transferFromDropDownList.DataBind();

                    transferToDropDownList.DataSource = dt;
                    transferToDropDownList.DataValueField = "WarehouseId";
                    transferToDropDownList.DataTextField = "WarehouseName";
                    transferToDropDownList.DataBind();
                }
                else if (transferType == "WH-SC")
                {
                    DataTable dt1 = warehouse.GetActiveWarehouseList();

                    transferFromDropDownList.DataSource = dt1;
                    transferFromDropDownList.DataValueField = "WarehouseId";
                    transferFromDropDownList.DataTextField = "WarehouseName";
                    transferFromDropDownList.DataBind();

                    DataTable dt2 = salesCenter.GetActiveSalesCenterList();

                    transferToDropDownList.DataSource = dt2;
                    transferToDropDownList.DataValueField = "SalesCenterId";
                    transferToDropDownList.DataTextField = "SalesCenterName";
                    transferToDropDownList.DataBind();
                }
                else if (transferType == "SC-SC")
                {
                    DataTable dt = salesCenter.GetActiveSalesCenterList();

                    transferFromDropDownList.DataSource = dt;
                    transferFromDropDownList.DataValueField = "SalesCenterId";
                    transferFromDropDownList.DataTextField = "SalesCenterName";
                    transferFromDropDownList.DataBind();

                    transferToDropDownList.DataSource = dt;
                    transferToDropDownList.DataValueField = "SalesCenterId";
                    transferToDropDownList.DataTextField = "SalesCenterName";
                    transferToDropDownList.DataBind();
                }
                else if (transferType == "SC-WH")
                {
                    DataTable dt1 = salesCenter.GetActiveSalesCenterList();

                    transferFromDropDownList.DataSource = dt1;
                    transferFromDropDownList.DataValueField = "SalesCenterId";
                    transferFromDropDownList.DataTextField = "SalesCenterName";
                    transferFromDropDownList.DataBind();

                    DataTable dt2 = warehouse.GetActiveWarehouseList();

                    transferToDropDownList.DataSource = dt2;
                    transferToDropDownList.DataValueField = "WarehouseId";
                    transferToDropDownList.DataTextField = "WarehouseName";
                    transferToDropDownList.DataBind();
                }
                else
                {
                    transferFromDropDownList.Items.Clear();
                    transferToDropDownList.Items.Clear();
                }

                transferFromDropDownList.Items.Insert(0, "All");
                transferToDropDownList.Items.Insert(0, "All");
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

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ProductTransferRecordIdForView", transferRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/ProductTransferRecord/ApprovedTransferRecord.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void recordListButton_Click(object sender, EventArgs e)
        {
            ProductTransferRecordBLL productTransferRecord = new ProductTransferRecordBLL();

            try
            {
                if (transferTypeDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer Type field is required.";
                }
                else if (transferFromDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer From field is required.";
                }
                else if (transferToDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer To field is required.";
                }
                else if (transferFromDropDownList.SelectedValue != "All" && transferToDropDownList.SelectedValue != "All" && transferFromDropDownList.SelectedValue == transferToDropDownList.SelectedValue)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer From & Transfer To field value should be different.";
                }
                else
                {
                    productTransferRecord.Description = transferDescriptionDropDownList.SelectedValue.Trim();
                    productTransferRecord.TransferType = transferTypeDropDownList.SelectedValue.Trim();
                    productTransferRecord.TransferFrom = transferFromDropDownList.SelectedValue.Trim();
                    productTransferRecord.TransferTo = transferToDropDownList.SelectedValue.Trim();
                    productTransferRecord.FromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    productTransferRecord.ToDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    productTransferRecord.Status = statusDropDownList.SelectedValue.Trim();

                    DataTable dt = productTransferRecord.GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatusAll();

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

        protected void transferTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transferTypeDropDownList.SelectedValue == "")
            {
                transferFromDropDownList.Items.Clear();
                transferToDropDownList.Items.Clear();
                transferTypeDropDownList.Focus();

                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer Type field is required.";
            }
            else if (transferTypeDropDownList.SelectedValue == "All")
            {
                transferFromDropDownList.Items.Clear();
                transferFromDropDownList.Items.Insert(0, "All");
                transferToDropDownList.Items.Clear();
                transferToDropDownList.Items.Insert(0, "All");
            }
            else
            {
                LoadTransferFromToItems(transferTypeDropDownList.SelectedValue.Trim());
            }
        }
    }
}