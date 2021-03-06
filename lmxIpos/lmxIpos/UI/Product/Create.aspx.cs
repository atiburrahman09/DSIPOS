﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Product
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadProductGroups();
                    LoadVendors();
                    LoadSalesCenter();
                    LoadWarehouses();
                    barcodeTextBox.Focus();
                    productNameOnlyTextBox.Attributes.Add("autocomplete", "off");
                    barcodeTextBox.Attributes.Add("autocomplete", "off");
                    unitTextBox.Attributes.Add("autocomplete", "off");
                    productVolumeTextBox.Attributes.Add("autocomplete", "off");
                    //  volumeQuantityTextBox.Attributes.Add("autocomplete", "off");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadVendors()
        {
            VendorBLL vendor = new VendorBLL();

            try
            {
                DataTable dt = vendor.GetActiveVendors();

                vendorDropDownList.DataSource = dt;
                vendorDropDownList.DataValueField = "VendorId";
                vendorDropDownList.DataTextField = "VendorName";
                vendorDropDownList.DataBind();
                vendorDropDownList.Items.Insert(0, "");
                vendorDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                vendor = null;
            }
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
                warehouseDropDownList.Items.Insert(0, "For all Warehouse");
                warehouseDropDownList.SelectedIndex = 0;
                warehouseDropDownList.Items[0].Value = "A";
                warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

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
        protected void LoadSalesCenter()
        {
            SalesCenterBLL warehouse = new SalesCenterBLL();

            try
            {
                DataTable dt = warehouse.GetActiveSalesCenterListByUser();

                salescenterDropDownList.DataSource = dt;
                salescenterDropDownList.DataValueField = "SalesCenterId";
                salescenterDropDownList.DataTextField = "SalesCenterName";
                salescenterDropDownList.DataBind();
                salescenterDropDownList.Items.Insert(0, "For all Sales Center");
                salescenterDropDownList.SelectedIndex = 0;
                salescenterDropDownList.Items[0].Value = "A";

                salescenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();


                //warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

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

        protected void LoadProductGroups()
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                DataTable dt = productGroup.GetActiveProductGroupList();

                productGroupDropDownList.DataSource = dt;
                productGroupDropDownList.DataValueField = "ProductGroupId";
                productGroupDropDownList.DataTextField = "ProductGroupName";
                productGroupDropDownList.DataBind();
                productGroupDropDownList.Items.Insert(0, "");
                productGroupDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Group Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                productGroup = null;
            }
        }

        protected void barcode_TextChanged(object sender, EventArgs e)
        {
            ProductBLL product = new ProductBLL();
            if (!product.CheckDuplicateProductByBarcode(barcodeTextBox.Text))
            {
                productNameOnlyTextBox.Focus();
            }
            else
            {
                if (barcodeTextBox.Text != "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Warning!!";
                    msgDetailLabel.Text = "This Barcode already exist, try another one.";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
                barcodeTextBox.Focus();
            }
            
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                //if (barcodeTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Barcode Name field is required.";
                //}
                //else
                if (productNameOnlyTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Name field is required.";
                }
                else if (productVolumeTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Volume field is required.";
                }
                //else if (volumeQuantityTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Volume Quantity field is required.";
                //}
                else if (unitTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Unit field is required.";
                }
                else if (productRateTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Rate field is required.";
                }
                //else if (vatPercentageTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "VAT field is required.";
                //}
                else if (productGroupDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Group field is required.";
                }
                else if (vendorDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Vendor field is required.";
                }
                else
                {
                    int isaddanother = 1;

                    Button btn = (Button)sender;

                    if (btn.Text == "Save")
                    {
                        isaddanother = 0;
                    }

                    product.ProductNameOnly = productNameOnlyTextBox.Text.Trim();
                    product.Barcode = barcodeTextBox.Text.Trim();
                    product.ProductGroupId = productGroupDropDownList.SelectedValue.Trim();
                    product.ProductVolume = productVolumeTextBox.Text.Trim();
                    product.VolumeQuantity = 1;//int.Parse(volumeQuantityTextBox.Text.Trim());
                    product.Unit = unitTextBox.Text.Trim();
                    product.Narretion = txtbxNarretion.Text.Trim();
                    product.ProductRate = decimal.Parse(productRateTextBox.Text.Trim());
                    product.ProductName = product.ProductNameOnly.Trim() + " (" + product.ProductVolume.Trim() + ")";
                    product.VendorId = vendorDropDownList.SelectedValue;
                    product.VATPercentage = float.Parse(vatPercentageTextBox.Text.Trim());
                    product.warehouse = warehouseDropDownList.SelectedValue;
                    product.salescenter = salescenterDropDownList.SelectedValue;
                    product.Description = txtbxDescription.Text.Trim();

                    //if (!product.CheckDuplicateProductByBarcode(product.Barcode.Trim()))
                    //{
                    if (!product.CheckDuplicateProductByName(product.ProductName.Trim(), product.warehouse, product.salescenter))
                    {
                        DataTable dt = product.SaveProduct();

                        if (dt.Rows.Count > 0)
                        {
                            if (isaddanother == 0)
                            {
                                string message =
                                    "Product <span class='actionTopic'>Created</span> Successfully with Product ID: <span class='actionTopic'>" +
                                    dt.Rows[0][0].ToString() + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Product/List.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                            else
                            {
                                string message =
                                   "Product <span class='actionTopic'>Created</span> Successfully with Product ID: <span class='actionTopic'>" +
                                   dt.Rows[0][0].ToString() + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Product/Create.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Product.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Product Name <span class='actionTopic'>already exist</span>, try another one.";
                        MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                    }
                    //}
                    //else
                    //{
                    //    string message = "This Barcode <span class='actionTopic'>already exist</span>, try another one.";
                    //    MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                    //}
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                product = null;
            }
        }
    }
}