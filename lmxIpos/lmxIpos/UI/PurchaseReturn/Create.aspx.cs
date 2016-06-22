﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseReturn
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                purchesRecordIdTextBox.Focus();
                receiveSalesReturnforAdjustButton.Enabled = false;
                receiveSalesReturnForMoneyBackButton.Enabled = false;
            }

            //if (productListGridView.Rows.Count > 0)
            //{
            //    productListGridView.UseAccessibleHeader = true;
            //    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}

            //if (selectedProductListGridView.Rows.Count > 0)
            //{
            //    selectedProductListGridView.UseAccessibleHeader = true;
            //    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
            if (purchesRecordProductListGridView.Rows.Count > 0)
            {
                purchesRecordProductListGridView.UseAccessibleHeader = true;
                purchesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void GetPurchesRecordById(string PurchesRecordId)
        {
            PurchaseRecordBLL parRecordBll = new PurchaseRecordBLL();

            try
            {
                DataTable dt = parRecordBll.GetPurchaseRecordById(PurchesRecordId);

                if (dt.Rows.Count > 0)
                {
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();

                    if (string.IsNullOrEmpty(dt.Rows[0]["WarehouseId"].ToString()))
                    {
                        salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                        salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    }
                    else
                    {
                        salesCenterIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                        salesCenterNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                        salesCenterOrWareHouseIdLabel.Text = "Warehouse Id";
                        salesCenterOrWareHouseNameLabel.Text = "Warehouse Name";
                    }
                    // salesCenterIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                    //if (salesCenterIdLabel.Text[0] == 'W')
                    //{

                    //}
                    // salesCenterNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    VendorIdLabel.Text = dt.Rows[0]["VendorId"].ToString();
                    vendorNameLabel.Text = dt.Rows[0]["VendorName"].ToString();
                    OderDatelabel.Text = dt.Rows[0]["VendorOrderDate"].ToString();
                    orderNumberLabel.Text = dt.Rows[0]["VendorOrderNumber"].ToString();
                    invoiceNumberLabel.Text = dt.Rows[0]["VendorInvoiceNumber"].ToString();
                    receiveDateLabel.Text = dt.Rows[0]["ReceivedDate"].ToString();
                    // [ReceivedDate]
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    discountAmountLabel.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    transportCostLabel.Text = dt.Rows[0]["TransportCost"].ToString();
                    paidAmountLabel.Text = dt.Rows[0]["PaidAmount"].ToString();

                    //vatPercentageLabel.Text = dt.Rows[0]["VATPercentage"].ToString();
                    totalpayableLabel.Text = dt.Rows[0]["TotalPayable"].ToString();
                    NarationLabel.Text = dt.Rows[0]["Narration"].ToString();

                    salesDueAmountTextBox.Text = (decimal.Parse(totalpayableLabel.Text) - decimal.Parse(paidAmountLabel.Text)).ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
            finally
            {
                parRecordBll = null;
            }
        }

        protected void GetPurchesRecordProductListByIdForReturn(string salesRecordId)
        {
            PurchaseRecordBLL purchaseRecord = new PurchaseRecordBLL();

            try
            {
                DataTable dt = purchaseRecord.GetPurchaseRecordProductListByIdForReturn(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("ReturnQuantity");
                    dt.Columns.Add("ReturnAmount");
                    dt.AcceptChanges();

                    purchesRecordProductListGridView.DataSource = dt;
                    purchesRecordProductListGridView.DataBind();

                    LumexSessionManager.Add("RPLdt", dt);

                    for (int i = 0; i < purchesRecordProductListGridView.Rows.Count; i++)
                    {
                        if (purchesRecordProductListGridView.Rows[i].Cells[2].Text.Trim() == purchesRecordProductListGridView.Rows[i].Cells[6].Text.Trim())
                        {
                            TextBox returnQuantityTextBox = (TextBox)purchesRecordProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
                            returnQuantityTextBox.Enabled = false;
                            receiveSalesReturnforAdjustButton.Enabled = false;
                            receiveSalesReturnForMoneyBackButton.Enabled = false;
                        }
                        else
                        {
                            receiveSalesReturnforAdjustButton.Enabled = true;
                            receiveSalesReturnForMoneyBackButton.Enabled = true;
                        }
                    }

                    if (purchesRecordProductListGridView.Rows.Count > 0)
                    {
                        purchesRecordProductListGridView.UseAccessibleHeader = true;
                        purchesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        protected void getPurchesDetailsButton_Click(object sender, EventArgs e)
        {
            recordDateLabel.Text = "";
            statusLabel.Text = "";


            salesCenterIdLabel.Text = "";
            salesCenterNameLabel.Text = "";

            VendorIdLabel.Text = "";
            vendorNameLabel.Text = "";
            OderDatelabel.Text = "";
            orderNumberLabel.Text = "";
            invoiceNumberLabel.Text = "";
            receiveDateLabel.Text = "";
            // [ReceivedDate]
            totalAmountLabel.Text = "";
            discountAmountLabel.Text = "";
            transportCostLabel.Text = "";
            paidAmountLabel.Text = "";

            //vatPercentageLabel.Text = dt.Rows[0]["VATPercentage"].ToString();
            totalpayableLabel.Text = "";
            NarationLabel.Text = "";

            purchesRecordProductListGridView.DataSource = null;
            purchesRecordProductListGridView.DataBind();

            idLabel.Text = salesRecordIdForViewHiddenField.Value = purchesRecordIdTextBox.Text.Trim();
            GetPurchesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
            GetPurchesRecordProductListByIdForReturn(salesRecordIdForViewHiddenField.Value.Trim());
        }

        protected void purchaseReturnButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SavePurchesReturn(btn.CommandArgument.ToString());
        }

        protected void SavePurchesReturn(string isDuesAdjust)
        {
            PurchaseReturnBLL purchaseReturn = new PurchaseReturnBLL();

            try
            {
                if (Convert.ToDecimal(totalReturnAmountTextBox.Text) > 0)
                {
                    DataTable dtPrdList = (DataTable)LumexSessionManager.Get("RPLdt");

                    for (int i = 0; i < purchesRecordProductListGridView.Rows.Count; i++)
                    {
                        TextBox returnQuantityTextBox =
                            (TextBox)purchesRecordProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
                        dtPrdList.Rows[i]["ReturnQuantity"] = returnQuantityTextBox.Text.Trim();

                        TextBox returnAmountTextBox =
                            (TextBox)purchesRecordProductListGridView.Rows[i].FindControl("returnAmountTextBox");
                        dtPrdList.Rows[i]["ReturnAmount"] = returnAmountTextBox.Text.Trim();
                    }
                    dtPrdList.AcceptChanges();
                    for (int i = 0; i < dtPrdList.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dtPrdList.Rows[i]["ReturnQuantity"].ToString()) ||
                            dtPrdList.Rows[i]["ReturnQuantity"].ToString() == "0")
                        {
                            dtPrdList.Rows.RemoveAt(i);
                            i--;
                        }
                    }

                    purchaseReturn.PurchaseRecordId = idLabel.Text.Trim();
                    purchaseReturn.SalesCenterId = salesCenterIdLabel.Text.Trim();
                    purchaseReturn.ReturnAmount = totalReturnAmountTextBox.Text.Trim();
                    purchaseReturn.ReturnVATAmount = totalReturnVATAmountTextBox.Text.Trim();
                    purchaseReturn.dueAmount = salesDueAmountTextBox.Text.Trim();
                    purchaseReturn.VendorId = VendorIdLabel.Text.Trim();
                    purchaseReturn.IsDuesAdjustforSalesReturn = isDuesAdjust;

                    DataTable dt = purchaseReturn.SavePurchesReturn(dtPrdList);

                    if (isDuesAdjust == "Y")
                    {

                        LumexSessionManager.Add("ReturnableAmount", dt.Rows[0]["ReturnAmount"]);
                        string message =
                            "Purchase <span class='actionTopic'>Return</span> Successfully with Adjust Dues of Return ID: <span class='actionTopic'>" +
                            dt.Rows[0]["PurchaseReturnId"] + " And get Money Back Amount:" + dt.Rows[0]["ReturnAmount"] +
                            "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");

                    }
                    else
                    {
                        string message =
                            "Purchase <span class='actionTopic'>Return</span> Successfully with Money Back Only of Return ID: <span class='actionTopic'>" +
                            dt.Rows[0]["PurchaseReturnId"] + " And get Money Back Amount:" + dt.Rows[0]["ReturnAmount"] +
                            "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesReturn/SalesReturnList.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");

                    }
                    receiveSalesReturnforAdjustButton.Enabled = false;
                    receiveSalesReturnForMoneyBackButton.Enabled = false;
                    totalReturnAmountTextBox.Text = "0.00";
                    totalReturnVATAmountTextBox.Text = "0.00";
                }
                else
                {
                    string message = "Sales Return Amount must be greater than 0.00";

                    MyAlertBox("WarningAlert(  \"" + message + "\", \"\");");
                }
            }
            catch (Exception ex)
            {
                string message = "Some things goes wrong on create Sales Return";
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(  \"" + message + "\", \"\");");
            }
            finally
            {
                purchaseReturn = null;
            }
        }

        //protected void LoadVendors()
        //{
        //    VendorBLL vendor = new VendorBLL();

        //    try
        //    {
        //        DataTable dt = vendor.GetVendorListByActivationStatus("True");

        //        vendorDropDownList.DataSource = dt;
        //        vendorDropDownList.DataValueField = "VendorId";
        //        vendorDropDownList.DataTextField = "VendorName";
        //        vendorDropDownList.DataBind();
        //        vendorDropDownList.Items.Insert(0, "");
        //        vendorDropDownList.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }

        //    finally
        //    {
        //        vendor = null;
        //    }
        //}

        //protected void LoadSalesCenters()
        //{
        //    SalesCenterBLL salesCenter = new SalesCenterBLL();

        //    try
        //    {
        //        DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

        //        drpdwnSalesCenterOrWarehouse.DataSource = dt;
        //        drpdwnSalesCenterOrWarehouse.DataValueField = "SalesCenterId";
        //        drpdwnSalesCenterOrWarehouse.DataTextField = "SalesCenterName";
        //        drpdwnSalesCenterOrWarehouse.DataBind();
        //        drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
        //        drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;

        //        drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
        //            msgbox.Attributes.Add("class", "alert alert-warning");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        salesCenter = null;
        //    }
        //}

        //protected void drpdwnReturnFrom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        productListGridView.DataSource = null;
        //        productListGridView.DataBind();

        //        if (drpdwnReturnFrom.SelectedIndex == 0)
        //        {
        //            drpdwnSalesCenterOrWarehouse.Items.Clear();
        //            LoadSalesCenters();
        //            titleSalesCenterOrWarehouse.Text = "Sales Center";
        //        }
        //        else if (drpdwnReturnFrom.SelectedIndex == 1)
        //        {
        //            drpdwnSalesCenterOrWarehouse.Items.Clear();
        //            LoadWarehouse();
        //            titleSalesCenterOrWarehouse.Text = "Warehouse";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}

        //protected void drpdwnSalesCenterOrWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        productListGridView.DataSource = null;
        //        productListGridView.DataBind();

        //        if (drpdwnReturnFrom.SelectedIndex == 0)
        //        {
        //            GetAvailableProductListBySalesCenter();
        //        }
        //        else if (drpdwnReturnFrom.SelectedIndex == 1)
        //        {
        //            GetAvailableProductListByWarehouse();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}

        //protected void GetAvailableProductListByWarehouse()
        //{
        //    ProductBLL product = new ProductBLL();

        //    try
        //    {
        //        DataTable dt = product.GetAvailableProductListByWarehouse(drpdwnSalesCenterOrWarehouse.SelectedValue.Trim());
        //        productListGridView.DataSource = dt;
        //        productListGridView.DataBind();

        //        if (productListGridView.Rows.Count > 0)
        //        {
        //            productListGridView.UseAccessibleHeader = true;
        //            productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Products are not available for the selected Sales Center!!!"; msgDetailLabel.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        product = null;
        //    }
        //}

        //private void LoadWarehouse()
        //{
        //    WarehouseBLL warehouse = new WarehouseBLL();

        //    try
        //    {
        //        DataTable dt = warehouse.GetActiveWarehouseListByUser();

        //        drpdwnSalesCenterOrWarehouse.DataSource = dt;
        //        drpdwnSalesCenterOrWarehouse.DataTextField = "WarehouseName";
        //        drpdwnSalesCenterOrWarehouse.DataValueField = "WarehouseId";
        //        drpdwnSalesCenterOrWarehouse.DataBind();
        //        drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
        //        drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;

        //        drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserWarehouseId").ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}

        //protected void GetAvailableProductListBySalesCenter()
        //{
        //    ProductBLL product = new ProductBLL();

        //    try
        //    {
        //        DataTable dt = product.GetAvailableProductListBySalesCenter(drpdwnSalesCenterOrWarehouse.SelectedValue.Trim());
        //        productListGridView.DataSource = dt;
        //        productListGridView.DataBind();

        //        if (productListGridView.Rows.Count > 0)
        //        {
        //            productListGridView.UseAccessibleHeader = true;
        //            productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Products are not available for the selected Sales Center!!!"; msgDetailLabel.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        product = null;
        //    }
        //}

        //protected void GetActiveProducts()
        //{
        //    ProductBLL product = new ProductBLL();

        //    try
        //    {
        //        DataTable dt = product.GetActiveProducts();
        //        productListGridView.DataSource = dt;
        //        productListGridView.DataBind();

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        product = null;
        //    }
        //}

        //protected void addSelectedProductButton_Click(object sender, EventArgs e)
        //{
        //    AddNewProductInList();
        //}

        //protected void AddNewProductInList()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;

        //    try
        //    {
        //        dt.Columns.Add(new DataColumn("Barcode"));
        //        dt.Columns.Add(new DataColumn("ProductId"));
        //        dt.Columns.Add(new DataColumn("ProductName"));
        //        dt.Columns.Add(new DataColumn("Unit"));
        //        dt.Columns.Add(new DataColumn("ReturnQuantity"));
        //        dt.Columns.Add(new DataColumn("ProductNarration"));

        //        for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
        //        {
        //            dr = dt.NewRow();

        //            dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
        //            dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
        //            dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
        //            dr["Unit"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();

        //            TextBox returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //            dr["ReturnQuantity"] = returnQuantityTextBox.Text.Trim();

        //            TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
        //            dr["ProductNarration"] = productNarrationTextBox.Text.Trim();

        //            dt.Rows.Add(dr);
        //        }

        //        int previousRowcount = dt.Rows.Count;

        //        for (int i = 0; i < productListGridView.Rows.Count; i++)
        //        {
        //            CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");

        //            if (chkbx.Checked && !CheckAddedProduct(productListGridView.Rows[i].Cells[1].Text.ToString()))
        //            {
        //                dr = dt.NewRow();

        //                dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
        //                dr["ProductId"] = productListGridView.Rows[i].Cells[1].Text.ToString();
        //                dr["ProductName"] = productListGridView.Rows[i].Cells[2].Text.ToString();
        //                dr["Unit"] = productListGridView.Rows[i].Cells[3].Text.ToString();
        //                dr["ReturnQuantity"] = string.Empty;
        //                dr["ProductNarration"] = string.Empty;

        //                dt.Rows.Add(dr);
        //            }
        //        }

        //        selectedProductListGridView.DataSource = dt;
        //        selectedProductListGridView.DataBind();

        //        for (int i = 0; i < previousRowcount; i++)
        //        {
        //            TextBox returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //            returnQuantityTextBox.Text = dt.Rows[i]["ReturnQuantity"].ToString();

        //            TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
        //            productNarrationTextBox.Text = dt.Rows[i]["ProductNarration"].ToString();
        //        }

        //        if (selectedProductListGridView.Rows.Count > 0)
        //        {
        //            selectedProductListGridView.UseAccessibleHeader = true;
        //            selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //            saveButton.Enabled = true;
        //        }
        //        else
        //        {
        //            saveButton.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        dt.Dispose();
        //        dr = null;
        //        MyAlertBox("MyOverlayStop();");
        //    }
        //}

        //protected bool CheckAddedProduct(string productBarcodeIdName)
        //{
        //    bool status = false;

        //    try
        //    {
        //        for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
        //        {
        //            if (selectedProductListGridView.Rows[i].Cells[0].Text.ToString() == productBarcodeIdName || selectedProductListGridView.Rows[i].Cells[1].Text.ToString() == productBarcodeIdName || selectedProductListGridView.Rows[i].Cells[2].Text.ToString() == productBarcodeIdName)
        //            {
        //                status = true;
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }

        //    return status;
        //}

        //protected void addProductButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string productBarcodeIdName = productTextBox.Text.Trim();

        //        if (string.IsNullOrEmpty(productBarcodeIdName))
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Write Product Barcode or ID or Name to search.";
        //        }
        //        else
        //        {
        //            if (CheckAddedProduct(productTextBox.Text.Trim()))
        //            {
        //                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "This product already added in the selected product list.";
        //            }
        //            else
        //            {
        //                for (int j = 0; j < productListGridView.Rows.Count; j++)
        //                {
        //                    if (productListGridView.Rows[j].Cells[0].Text.ToString() == productBarcodeIdName || productListGridView.Rows[j].Cells[1].Text.ToString() == productBarcodeIdName || productListGridView.Rows[j].Cells[2].Text.ToString() == productBarcodeIdName)
        //                    {
        //                        DataTable dt = new DataTable();
        //                        DataRow dr = null;

        //                        dt.Columns.Add(new DataColumn("Barcode"));
        //                        dt.Columns.Add(new DataColumn("ProductId"));
        //                        dt.Columns.Add(new DataColumn("ProductName"));
        //                        dt.Columns.Add(new DataColumn("Unit"));
        //                        dt.Columns.Add(new DataColumn("ReturnQuantity"));
        //                        dt.Columns.Add(new DataColumn("ProductNarration"));

        //                        for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
        //                        {
        //                            dr = dt.NewRow();

        //                            dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
        //                            dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
        //                            dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
        //                            dr["Unit"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();

        //                            TextBox returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //                            dr["ReturnQuantity"] = returnQuantityTextBox.Text.Trim();

        //                            TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
        //                            dr["ProductNarration"] = productNarrationTextBox.Text.Trim();

        //                            dt.Rows.Add(dr);
        //                        }

        //                        int previousRowcount = dt.Rows.Count;

        //                        dr = dt.NewRow();
        //                        dr["Barcode"] = productListGridView.Rows[j].Cells[0].Text.ToString();
        //                        dr["ProductId"] = productListGridView.Rows[j].Cells[1].Text.ToString();
        //                        dr["ProductName"] = productListGridView.Rows[j].Cells[2].Text.ToString();
        //                        dr["Unit"] = productListGridView.Rows[j].Cells[3].Text.ToString();
        //                        dr["ReturnQuantity"] = string.Empty;
        //                        dr["ProductNarration"] = string.Empty;
        //                        dt.Rows.Add(dr);

        //                        selectedProductListGridView.DataSource = dt;
        //                        selectedProductListGridView.DataBind();

        //                        for (int i = 0; i < previousRowcount; i++)
        //                        {
        //                            TextBox returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //                            returnQuantityTextBox.Text = dt.Rows[i]["ReturnQuantity"].ToString();

        //                            TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
        //                            productNarrationTextBox.Text = dt.Rows[i]["ProductNarration"].ToString();
        //                        }

        //                        if (selectedProductListGridView.Rows.Count > 0)
        //                        {
        //                            selectedProductListGridView.UseAccessibleHeader = true;
        //                            selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //                            saveButton.Enabled = true;
        //                        }
        //                        else
        //                        {
        //                            saveButton.Enabled = false;
        //                        }

        //                        CheckBox chkbx = (CheckBox)productListGridView.Rows[j].FindControl("selectCheckBox");
        //                        chkbx.Checked = true;
        //                        checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) + 1).ToString();

        //                        productBarcodeIdName = "added";
        //                        break;
        //                    }
        //                }

        //                if (productBarcodeIdName != "added")
        //                {
        //                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product not found.";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }
        //}

        //protected void saveButton_Click(object sender, EventArgs e)
        //{
        //    string msg = string.Empty;

        //    List<PurchaseReturnBLL> purchaseReturns = new List<PurchaseReturnBLL>();
        //    PurchaseReturnBLL purchaseReturn;
        //    int quantity = 0;
        //    TextBox returnQuantityTextBox;
        //    TextBox productNarrationTextBox;
        //    int i = 0;

        //    try
        //    {
        //        if (drpdwnSalesCenterOrWarehouse.SelectedValue == "")
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Sales Center Name field is required.";
        //        }
        //        else
        //        {
        //            for (i = 0; i < selectedProductListGridView.Rows.Count; i++)
        //            {
        //                returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //                productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");

        //                if (!string.IsNullOrEmpty(returnQuantityTextBox.Text.Trim()) && Int32.TryParse(returnQuantityTextBox.Text.Trim(), out quantity))
        //                {
        //                    quantity = int.Parse(returnQuantityTextBox.Text.Trim());

        //                    purchaseReturn = new PurchaseReturnBLL();

        //                    purchaseReturn.ProductId = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
        //                    purchaseReturn.ReturnQuantity = quantity.ToString();
        //                    purchaseReturn.ProductNarration = productNarrationTextBox.Text.ToString();

        //                    purchaseReturns.Add(purchaseReturn);
        //                }
        //                else
        //                {
        //                    msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid quantity.";
        //                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
        //                    return;
        //                }
        //            }

        //            if (purchaseReturns.Count > 0)
        //            {
        //                purchaseReturn = new PurchaseReturnBLL();
        //                string purchaseReturnId = purchaseReturn.SavePurchaseReturn(purchaseReturns, drpdwnSalesCenterOrWarehouse.SelectedValue.Trim(), narrationTextBox.Text.Trim());

        //                string message = "Purchase Return <span class='actionTopic'>Created</span> Successfully with Return ID: <span class='actionTopic'>" + purchaseReturnId + "</span>.";
        //                MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/PurchaseReturn/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        purchaseReturn = null;
        //        purchaseReturns = null;
        //    }
        //}

        //protected void removeLinkButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        //        int index = gvRow.RowIndex;

        //        string productId = selectedProductListGridView.Rows[index].Cells[1].Text.ToString();

        //        DataTable dt = new DataTable();
        //        DataRow dr = null;

        //        dt.Columns.Add(new DataColumn("Barcode"));
        //        dt.Columns.Add(new DataColumn("ProductId"));
        //        dt.Columns.Add(new DataColumn("ProductName"));
        //        dt.Columns.Add(new DataColumn("Unit"));
        //        dt.Columns.Add(new DataColumn("ReturnQuantity"));
        //        dt.Columns.Add(new DataColumn("ProductNarration"));

        //        for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
        //        {
        //            dr = dt.NewRow();

        //            dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
        //            dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
        //            dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
        //            dr["Unit"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();

        //            TextBox returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //            dr["ReturnQuantity"] = returnQuantityTextBox.Text.Trim();

        //            TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
        //            dr["ProductNarration"] = productNarrationTextBox.Text.Trim();

        //            dt.Rows.Add(dr);
        //        }

        //        for (int i = 0; i < productListGridView.Rows.Count; i++)
        //        {
        //            if (productListGridView.Rows[i].Cells[1].Text.ToString() == productId)
        //            {
        //                CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");
        //                chkbx.Checked = false;

        //                CheckBox allchkbx = (CheckBox)productListGridView.HeaderRow.FindControl("allCheckBox");
        //                allchkbx.Checked = false;
        //                checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) - 1).ToString();

        //                break;
        //            }
        //        }

        //        dt.Rows.RemoveAt(index);
        //        selectedProductListGridView.DataSource = dt;
        //        selectedProductListGridView.DataBind();

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            TextBox returnQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("returnQuantityTextBox");
        //            returnQuantityTextBox.Text = dt.Rows[i]["ReturnQuantity"].ToString();

        //            TextBox productNarrationTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("productNarrationTextBox");
        //            productNarrationTextBox.Text = dt.Rows[i]["ProductNarration"].ToString();
        //        }

        //        if (selectedProductListGridView.Rows.Count > 0)
        //        {
        //            selectedProductListGridView.UseAccessibleHeader = true;
        //            selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //            saveButton.Enabled = true;
        //        }
        //        else
        //        {
        //            saveButton.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }
        //}


    }
}