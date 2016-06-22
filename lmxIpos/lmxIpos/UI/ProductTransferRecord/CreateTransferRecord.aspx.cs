using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.ProductTransferRecord
{
    public partial class CreateTransferRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {

                }

                if (productTransferOrderProductListGridView.Rows.Count > 0)
                {
                    productTransferOrderProductListGridView.UseAccessibleHeader = true;
                    productTransferOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
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

        protected void transferDestinationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransferToItems(transferDestinationDropDownList.SelectedValue.Trim());
        }

        protected void GetProductTransferOrderById(string transferOrderId)
        {
            ProductTransferOrderBLL productTransferOrder = new ProductTransferOrderBLL();

            try
            {
                DataTable dt = productTransferOrder.GetProductTransferOrderById(transferOrderId);

                if (dt.Rows.Count > 0 && dt.Rows[0]["TransferTo"].ToString() == transferToDropDownList.SelectedValue.Trim() && dt.Rows[0]["Status"].ToString() == "On Transport")
                {
                    orderIdLabel.Text = dt.Rows[0]["TransferOrderId"].ToString();
                    orderDateLabel.Text = dt.Rows[0]["OrderDate"].ToString();
                    transferTypeLabel.Text = dt.Rows[0]["TransferType"].ToString();
                    transferFromIdLabel.Text = dt.Rows[0]["TransferFrom"].ToString();
                    transferFromNameLabel.Text = dt.Rows[0]["TransferFromName"].ToString();
                    transferToIdLabel.Text = dt.Rows[0]["TransferTo"].ToString();
                    transferToNameLabel.Text = dt.Rows[0]["TransferToName"].ToString();
                    requisitionIdLabel.Text = dt.Rows[0]["RequisitionId"].ToString();
                    requisitionDateLabel.Text = dt.Rows[0]["RequisitionDate"].ToString();
                    transportDateLabel.Text = dt.Rows[0]["TransportDate"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();

                    GetProductTransferOrderProductListById(transferOrderIdTextBox.Text.Trim());
                    orderInfoContainer.Visible = true;
                    saveButton.Enabled = true;
                }
                else
                {
                    orderInfoContainer.Visible = false;
                    saveButton.Enabled = false;
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        protected void GetProductTransferOrderProductListById(string transferOrderId)
        {
            ProductTransferOrderBLL productTransferOrder = new ProductTransferOrderBLL();

            try
            {
                DataTable dt = productTransferOrder.GetProductTransferOrderProductListById(transferOrderId, requisitionIdLabel.Text.Trim(), descriptionLabel.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    productTransferOrderProductListGridView.DataSource = dt;
                    productTransferOrderProductListGridView.DataBind();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox receivedQuantityTextBox = (TextBox)productTransferOrderProductListGridView.Rows[i].FindControl("receivedQuantityTextBox");
                        receivedQuantityTextBox.Text = dt.Rows[i]["ApprovedQuantity"].ToString();
                    }

                    if (productTransferOrderProductListGridView.Rows.Count > 0)
                    {
                        productTransferOrderProductListGridView.UseAccessibleHeader = true;
                        productTransferOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        saveButton.Enabled = true;
                    }
                    else
                    {
                        saveButton.Enabled = false;
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
                productTransferOrder = null;
            }
        }

        protected void transferOrderDetailsButton_Click(object sender, EventArgs e)
        {
            GetProductTransferOrderById(transferOrderIdTextBox.Text.Trim());
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ProductTransferRecordBLL productTransferRecord = new ProductTransferRecordBLL();

            string msg = string.Empty;
            TextBox receivedQuantityTextBox;
            TextBox disappearedQuantityTextBox;
            TextBox narrationTextBox;
            int rQty;
            int dQty;
            int pNClCount = 0;

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("ProductId");
            dt.Columns.Add("OrderQuantity");
            dt.Columns.Add("ReceivedQuantity");
            dt.Columns.Add("DisappearedQuantity");
            dt.Columns.Add("Narration");
            dt.Columns.Add("Status");

            try
            {
                for (int i = 0; i < productTransferOrderProductListGridView.Rows.Count; i++)
                {
                    receivedQuantityTextBox = (TextBox)productTransferOrderProductListGridView.Rows[i].FindControl("receivedQuantityTextBox");
                    disappearedQuantityTextBox = (TextBox)productTransferOrderProductListGridView.Rows[i].FindControl("disappearedQuantityTextBox");
                    narrationTextBox = (TextBox)productTransferOrderProductListGridView.Rows[i].FindControl("narrationTextBox");
                    string[] oQty = productTransferOrderProductListGridView.Rows[i].Cells[2].Text.Trim().Split(' ');

                    if (!int.TryParse(receivedQuantityTextBox.Text.Trim(), out rQty))
                    {
                        msg = "Product ID [" + productTransferOrderProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Received Quantity.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!int.TryParse(disappearedQuantityTextBox.Text.Trim(), out dQty))
                    {
                        msg = "Product ID [" + productTransferOrderProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid Disappeared Quantity.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (disappearedQuantityTextBox.Text.Trim() != "0" && string.IsNullOrEmpty(narrationTextBox.Text.Trim()))
                    {
                        msg = "Narration field is required for Product ID [" + productTransferOrderProductListGridView.Rows[i].Cells[0].Text.ToString() + "]";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else
                    {
                        dr = dt.NewRow();

                        dr["ProductId"] = productTransferOrderProductListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["OrderQuantity"] = oQty[0].ToString().Trim();
                        dr["ReceivedQuantity"] = receivedQuantityTextBox.Text.Trim();
                        dr["DisappearedQuantity"] = disappearedQuantityTextBox.Text.Trim();
                        dr["Narration"] = narrationTextBox.Text.Trim();

                        if (disappearedQuantityTextBox.Text.Trim() == "0")
                        {
                            dr["Status"] = "Cl";
                        }
                        else
                        {
                            dr["Status"] = "NCl"; pNClCount++;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == productTransferOrderProductListGridView.Rows.Count)
                {
                    productTransferRecord.TransferOrderId = orderIdLabel.Text.Trim();
                    productTransferRecord.TransferFrom = transferFromIdLabel.Text.Trim();
                    productTransferRecord.TransferTo = transferToIdLabel.Text.Trim();
                    productTransferRecord.TransferType = transferTypeLabel.Text.Trim();
                    productTransferRecord.Description = descriptionLabel.Text.Trim();

                    if (pNClCount > 0)
                    {
                        productTransferRecord.Status = "PD";
                    }
                    else
                    {
                        productTransferRecord.Status = "D";
                    }

                    string id = productTransferRecord.SaveProductTransferRecord(dt);

                    if (!string.IsNullOrEmpty(id))
                    {
                        MyAlertBox("alert(\"Product Transfer Record Created Successfully with Transfer Record ID: " + id + " \"); window.location=\"/UI/ProductTransferRecord/TransferRecordList.aspx\"");
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Failed to Create Product Transfer Record!!!"; msgDetailLabel.Text = "";
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
    }
}