using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseRequisition
{
    public partial class CreateRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                checkedRowCountHiddenField.Value = "0";

                LoadWarehouses();
                // GetActiveProducts();
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

        protected void GetActiveProducts(string id)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetActiveProductsByWareHouseorSalesCenter(id);
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

            List<PurchaseRequisitionBLL> purchaseRequisitions = new List<PurchaseRequisitionBLL>();
            PurchaseRequisitionBLL purchaseRequisition;
            int quantity = 0;
            TextBox requisitionQuantityTextBox;
            TextBox requiredDateTextBox;
            TextBox productNarrationTextBox;
            int i = 0;

            try
            {
                if (warehouseDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else
                {
                    for (i = 0; i < selectedProductListGridView.Rows.Count; i++)
                    {
                        requisitionQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requisitionQuantityTextBox");
                        requiredDateTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("requiredDateTextBox");
                        productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");

                        if (!string.IsNullOrEmpty(requisitionQuantityTextBox.Text.Trim()) && Int32.TryParse(requisitionQuantityTextBox.Text.Trim(), out quantity))
                        {
                            purchaseRequisition = new PurchaseRequisitionBLL();

                            purchaseRequisition.ProductId = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                            purchaseRequisition.RequisitionQuantity = quantity.ToString();
                            purchaseRequisition.RequiredDate = LumexLibraryManager.ParseAppDate(requiredDateTextBox.Text.ToString());
                            purchaseRequisition.ProductNarration = productNarrationTextBox.Text.ToString();

                            purchaseRequisitions.Add(purchaseRequisition);
                        }
                        else
                        {
                            msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid quantity.";
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                            return;
                        }
                    }

                    if (purchaseRequisitions.Count > 0)
                    {
                        purchaseRequisition = new PurchaseRequisitionBLL();
                        string purchaseRequisitionId = purchaseRequisition.SavePurchaseRequisition(purchaseRequisitions, warehouseDropDownList.SelectedValue.Trim(), narrationTextBox.Text.Trim());

                        MyAlertBox("alert(\"Product(s) Purchase Requisition Created Successfully with Purchase Requisition ID: " + purchaseRequisitionId + " \"); window.location=\"/UI/PurchaseRequisition/RequisitionList.aspx\"");
                    }
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

        protected void warehouseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetActiveProducts(warehouseDropDownList.SelectedValue);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}