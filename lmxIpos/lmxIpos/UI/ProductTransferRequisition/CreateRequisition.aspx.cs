using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferRequisition
{
    public partial class CreateRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                checkedRowCountHiddenField.Value = "0";

                GetActiveProducts();
            }

            if (productListGridView.Rows.Count > 0)
            {
                productListGridView.UseAccessibleHeader = true;
                productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (selectedProductListGridView.Rows.Count > 0)
            {
                selectedProductListGridView.UseAccessibleHeader = true;
                selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                    DataTable dt = warehouse.GetActiveWarehouseListByUser();

                    transferFromDropDownList.DataSource = dt;
                    transferFromDropDownList.DataValueField = "WarehouseId";
                    transferFromDropDownList.DataTextField = "WarehouseName";
                    transferFromDropDownList.DataBind();
                    transferFromDropDownList.Items.Insert(0, "");
                    transferFromDropDownList.SelectedIndex = 0;

                    transferToDropDownList.DataSource = dt;
                    transferToDropDownList.DataValueField = "WarehouseId";
                    transferToDropDownList.DataTextField = "WarehouseName";
                    transferToDropDownList.DataBind();
                    transferToDropDownList.Items.Insert(0, "");
                    transferToDropDownList.SelectedIndex = 0;
                }
                else if (transferType == "WH-SC")
                {
                    DataTable dt1 = warehouse.GetActiveWarehouseListByUser();

                    transferFromDropDownList.DataSource = dt1;
                    transferFromDropDownList.DataValueField = "WarehouseId";
                    transferFromDropDownList.DataTextField = "WarehouseName";
                    transferFromDropDownList.DataBind();
                    transferFromDropDownList.Items.Insert(0, "");
                    transferFromDropDownList.SelectedIndex = 0;

                    DataTable dt2 = salesCenter.GetActiveSalesCenterListByUser();

                    transferToDropDownList.DataSource = dt2;
                    transferToDropDownList.DataValueField = "SalesCenterId";
                    transferToDropDownList.DataTextField = "SalesCenterName";
                    transferToDropDownList.DataBind();
                    transferToDropDownList.Items.Insert(0, "");
                    transferToDropDownList.SelectedIndex = 0;
                }
                else if (transferType == "SC-SC")
                {
                    DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                    transferFromDropDownList.DataSource = dt;
                    transferFromDropDownList.DataValueField = "SalesCenterId";
                    transferFromDropDownList.DataTextField = "SalesCenterName";
                    transferFromDropDownList.DataBind();
                    transferFromDropDownList.Items.Insert(0, "");
                    transferFromDropDownList.SelectedIndex = 0;

                    transferToDropDownList.DataSource = dt;
                    transferToDropDownList.DataValueField = "SalesCenterId";
                    transferToDropDownList.DataTextField = "SalesCenterName";
                    transferToDropDownList.DataBind();
                    transferToDropDownList.Items.Insert(0, "");
                    transferToDropDownList.SelectedIndex = 0;
                }
                else if (transferType == "SC-WH")
                {
                    DataTable dt1 = salesCenter.GetActiveSalesCenterListByUser();

                    transferFromDropDownList.DataSource = dt1;
                    transferFromDropDownList.DataValueField = "SalesCenterId";
                    transferFromDropDownList.DataTextField = "SalesCenterName";
                    transferFromDropDownList.DataBind();
                    transferFromDropDownList.Items.Insert(0, "");
                    transferFromDropDownList.SelectedIndex = 0;

                    DataTable dt2 = warehouse.GetActiveWarehouseListByUser();

                    transferToDropDownList.DataSource = dt2;
                    transferToDropDownList.DataValueField = "WarehouseId";
                    transferToDropDownList.DataTextField = "WarehouseName";
                    transferToDropDownList.DataBind();
                    transferToDropDownList.Items.Insert(0, "");
                    transferToDropDownList.SelectedIndex = 0;
                }
                else
                {
                    transferFromDropDownList.Items.Clear();
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

        protected void GetActiveProducts()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetActiveProducts();
                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (dt.Rows.Count < 1)
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
                product = null;
            }
        }

        protected void addSelectedProductButton_Click(object sender, EventArgs e)
        {
            AddNewProductInList();
        }

        protected void AddNewProductInList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            try
            {
                dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("RequisitionQuantity"));
                dt.Columns.Add(new DataColumn("RequiredDate"));
                dt.Columns.Add(new DataColumn("ProductNarration"));

                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();

                    TextBox requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                    dr["RequisitionQuantity"] = requisitionQuantityTextBox.Text.Trim();

                    TextBox requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                    dr["RequiredDate"] = requiredDateTextBox.Text.Trim();

                    TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
                    dr["ProductNarration"] = productNarrationTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                int previousRowcount = dt.Rows.Count;

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");

                    if (chkbx.Checked && !CheckAddedProduct(productListGridView.Rows[i].Cells[1].Text.ToString()))
                    {
                        dr = dt.NewRow();

                        dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ProductId"] = productListGridView.Rows[i].Cells[1].Text.ToString();
                        dr["ProductName"] = productListGridView.Rows[i].Cells[2].Text.ToString();
                        dr["Unit"] = productListGridView.Rows[i].Cells[3].Text.ToString();
                        dr["RequisitionQuantity"] = string.Empty;
                        dr["RequiredDate"] = string.Empty;
                        dr["ProductNarration"] = string.Empty;

                        dt.Rows.Add(dr);
                    }
                }

                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

                for (int i = 0; i < previousRowcount; i++)
                {
                    TextBox requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                    requisitionQuantityTextBox.Text = dt.Rows[i]["RequisitionQuantity"].ToString();

                    TextBox requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                    requiredDateTextBox.Text = dt.Rows[i]["RequiredDate"].ToString();

                    TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
                    productNarrationTextBox.Text = dt.Rows[i]["ProductNarration"].ToString();
                }

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            finally
            {
                dt.Dispose();
                dr = null;
            }
        }

        protected bool CheckAddedProduct(string productBarcodeIdName)
        {
            bool status = false;

            try
            {
                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    if (selectedProductListGridView.Rows[i].Cells[0].Text.ToString() == productBarcodeIdName || selectedProductListGridView.Rows[i].Cells[1].Text.ToString() == productBarcodeIdName || selectedProductListGridView.Rows[i].Cells[2].Text.ToString() == productBarcodeIdName)
                    {
                        status = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }

            return status;
        }

        protected void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string productBarcodeIdName = productTextBox.Text.Trim();

                if (string.IsNullOrEmpty(productBarcodeIdName))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Write Product Barcode or ID or Name to search.";
                }
                else
                {
                    if (CheckAddedProduct(productTextBox.Text.Trim()))
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "This product already added in the selected product list.";
                    }
                    else
                    {
                        for (int j = 0; j < productListGridView.Rows.Count; j++)
                        {
                            if (productListGridView.Rows[j].Cells[0].Text.ToString() == productBarcodeIdName || productListGridView.Rows[j].Cells[1].Text.ToString() == productBarcodeIdName || productListGridView.Rows[j].Cells[2].Text.ToString() == productBarcodeIdName)
                            {
                                DataTable dt = new DataTable();
                                DataRow dr = null;

                                dt.Columns.Add(new DataColumn("Barcode"));
                                dt.Columns.Add(new DataColumn("ProductId"));
                                dt.Columns.Add(new DataColumn("ProductName"));
                                dt.Columns.Add(new DataColumn("Unit"));
                                dt.Columns.Add(new DataColumn("RequisitionQuantity"));
                                dt.Columns.Add(new DataColumn("RequiredDate"));
                                dt.Columns.Add(new DataColumn("ProductNarration"));

                                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                                {
                                    dr = dt.NewRow();

                                    dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();

                                    TextBox requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                                    dr["RequisitionQuantity"] = requisitionQuantityTextBox.Text.Trim();

                                    TextBox requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                                    dr["RequiredDate"] = requiredDateTextBox.Text.Trim();

                                    TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
                                    dr["ProductNarration"] = productNarrationTextBox.Text.Trim();

                                    dt.Rows.Add(dr);
                                }

                                int previousRowcount = dt.Rows.Count;

                                dr = dt.NewRow();
                                dr["Barcode"] = productListGridView.Rows[j].Cells[0].Text.ToString();
                                dr["ProductId"] = productListGridView.Rows[j].Cells[1].Text.ToString();
                                dr["ProductName"] = productListGridView.Rows[j].Cells[2].Text.ToString();
                                dr["Unit"] = productListGridView.Rows[j].Cells[3].Text.ToString();
                                dr["RequisitionQuantity"] = string.Empty;
                                dr["RequiredDate"] = string.Empty;
                                dr["ProductNarration"] = string.Empty;
                                dt.Rows.Add(dr);

                                selectedProductListGridView.DataSource = dt;
                                selectedProductListGridView.DataBind();

                                for (int i = 0; i < previousRowcount; i++)
                                {
                                    TextBox requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                                    requisitionQuantityTextBox.Text = dt.Rows[i]["RequisitionQuantity"].ToString();

                                    TextBox requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                                    requiredDateTextBox.Text = dt.Rows[i]["RequiredDate"].ToString();

                                    TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
                                    productNarrationTextBox.Text = dt.Rows[i]["ProductNarration"].ToString();
                                }

                                if (selectedProductListGridView.Rows.Count > 0)
                                {
                                    selectedProductListGridView.UseAccessibleHeader = true;
                                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                                    saveButton.Enabled = true;
                                }
                                else
                                {
                                    saveButton.Enabled = false;
                                }

                                CheckBox chkbx = (CheckBox)productListGridView.Rows[j].FindControl("selectCheckBox");
                                chkbx.Checked = true;
                                checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) + 1).ToString();

                                productBarcodeIdName = "added";
                                break;
                            }
                        }

                        if (productBarcodeIdName != "added")
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            List<ProductTransferRequisitionBLL> productTransferRequisitions = new List<ProductTransferRequisitionBLL>();
            ProductTransferRequisitionBLL productTransferRequisition;
            int quantity = 0;
            TextBox requisitionQuantityTextBox;
            TextBox requiredDateTextBox;
            TextBox productNarrationTextBox;
            int i = 0;

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
                else if (transferFromDropDownList.SelectedValue == transferToDropDownList.SelectedValue)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer From & Transfer To field value should be different.";
                }
                else
                {
                    for (i = 0; i < selectedProductListGridView.Rows.Count; i++)
                    {
                        requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].Cells[4].FindControl("requisitionQuantityTextBox");
                        requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].Cells[5].FindControl("requiredDateTextBox");
                        productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].Cells[6].FindControl("productNarrationTextBox");

                        if (!string.IsNullOrEmpty(requisitionQuantityTextBox.Text.Trim()) && Int32.TryParse(requisitionQuantityTextBox.Text.Trim(), out quantity))
                        {
                            productTransferRequisition = new ProductTransferRequisitionBLL();

                            productTransferRequisition.ProductId = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                            productTransferRequisition.RequisitionQuantity = quantity.ToString();
                            productTransferRequisition.RequiredDate = LumexLibraryManager.ParseAppDate(requiredDateTextBox.Text.ToString());
                            productTransferRequisition.ProductNarration = productNarrationTextBox.Text.ToString();

                            productTransferRequisitions.Add(productTransferRequisition);
                        }
                        else
                        {
                            msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid quantity.";
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                            return;
                        }
                    }

                    if (productTransferRequisitions.Count > 0)
                    {
                        productTransferRequisition = new ProductTransferRequisitionBLL();
                        string transferRequisitionId = productTransferRequisition.SaveProductTransferRequisition(productTransferRequisitions, transferTypeDropDownList.SelectedValue.Trim(), transferFromDropDownList.SelectedValue.Trim(), transferToDropDownList.SelectedValue.Trim(), narrationTextBox.Text.Trim());

                        MyAlertBox("alert(\"Product Transfer Requisition Created Successfully with Transfer Requisition ID: " + transferRequisitionId + " \"); window.location=\"/UI/ProductTransferRequisition/RequisitionList.aspx\"");
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                productTransferRequisition = null;
                productTransferRequisitions = null;
            }
        }

        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
                int index = gvRow.RowIndex;

                string productId = selectedProductListGridView.Rows[index].Cells[1].Text.ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("RequisitionQuantity"));
                dt.Columns.Add(new DataColumn("RequiredDate"));
                dt.Columns.Add(new DataColumn("ProductNarration"));

                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();

                    TextBox requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                    dr["RequisitionQuantity"] = requisitionQuantityTextBox.Text.Trim();

                    TextBox requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                    dr["RequiredDate"] = requiredDateTextBox.Text.Trim();

                    TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
                    dr["ProductNarration"] = productNarrationTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    if (productListGridView.Rows[i].Cells[1].Text.ToString() == productId)
                    {
                        CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");
                        chkbx.Checked = false;

                        CheckBox allchkbx = (CheckBox)productListGridView.HeaderRow.FindControl("allCheckBox");
                        allchkbx.Checked = false;
                        checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) - 1).ToString();

                        break;
                    }
                }

                dt.Rows.RemoveAt(index);
                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                    requisitionQuantityTextBox.Text = dt.Rows[i]["RequisitionQuantity"].ToString();

                    TextBox requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                    requiredDateTextBox.Text = dt.Rows[i]["RequiredDate"].ToString();

                    TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
                    productNarrationTextBox.Text = dt.Rows[i]["ProductNarration"].ToString();
                }

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void transferTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transferTypeDropDownList.SelectedValue == "")
            {
                transferFromDropDownList.Items.Clear();
                transferToDropDownList.Items.Clear();
                transferTypeDropDownList.Focus();

                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transfer Type field is required.";
            }
            else
            {
                LoadTransferFromToItems(transferTypeDropDownList.SelectedValue.Trim());
            }
        }
    }
}