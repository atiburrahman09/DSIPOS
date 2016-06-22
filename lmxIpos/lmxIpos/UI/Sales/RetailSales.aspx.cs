﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Sales
{
    public partial class RetailSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                productTextBox.Attributes.Add("autocomplete", "off");

                if (!IsPostBack)
                {
                    checkedRowCountHiddenField.Value = "0";

                    GetAvailableProductListBySalesCenter();
                    // GetActiveProducts();
                    LoadActiveCustomerList();
                    GetOverallVATPercentage();
                    getUserDefaultSalesCenterName();
                    // getCustomerList();

                    productTextBox.Focus();
                    loadCashorChequeAccountHead();
                }

                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    saveButton.Enabled = true;
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

                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                    totalAmountTextBox.Text = "";
                    //totalReceivableTextBox.Text = "";
                    receivedAmountTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        //protected void GetActiveProducts()
        //{
        //    ProductBLL product = new ProductBLL();

        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        if (ddlWHorSC.SelectedValue == "SC")
        //        {
        //            dt = product.GetAllProductsBySalesCenter(ddlSelectWareHouseOrSalesCenter.SelectedValue);
        //        }
        //        else
        //        {
        //            dt = product.GetAllProductsByWareHouse(ddlSelectWareHouseOrSalesCenter.SelectedValue);

        //        }
        //        productListGridView.DataSource = dt;
        //        productListGridView.DataBind();

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
        //            productListGridView.DataSource = "";
        //            productListGridView.DataBind();
        //        }
        //        if (productListGridView.Rows.Count > 0)
        //        {
        //            productListGridView.UseAccessibleHeader = true;
        //            productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        private string getUserDefaultSalesCenterName()
        {

            string SalescenterName = "";
            SalesCenterBLL scbll = new SalesCenterBLL();
            DataTable dt = scbll.GetSalesCenterById(LumexSessionManager.Get("UserSalesCenterId").ToString());

            SalescenterName = lblSalesCenterName.Text = dt.Rows[0]["SalesCenterName"].ToString();
            lblSalescenterId.Text = dt.Rows[0]["SalesCenterId"].ToString();

            return SalescenterName;



        }


        private void getCustomerList()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                //DataTable dt = customer.GetCustomerById((string)LumexSessionManager.Get("ActiveUserId"));
                DataTable dt = customer.GetCustomerList();
                customerListGridView.DataSource = dt;
                customerListGridView.DataBind();

                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Customer are not available !!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void gotoRecievepayment(object sender, EventArgs e)
        {
            LumexSessionManager.Add("forClientReceive", customerIdDropDownList.SelectedValue);
        }
        protected void customerIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getCustomerByCustomerId();
                getCustomerTotalReceivableByCustomerId();
                customerIdDropDownList.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void selectCustomerLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;

                customerIdDropDownList.SelectedValue = customerListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();

                getCustomerByCustomerId();
                getCustomerTotalReceivableByCustomerId();

                // customerIdDropDownList.Focus();

                totalAmountTextBox.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        private void getCustomerTotalReceivableByCustomerId()
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();

            try
            {
                DataTable dt = receivePayment.GetCustomerTotalReceivable(customerIdDropDownList.SelectedValue, LumexSessionManager.Get("UserSalesCenterId").ToString());

                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["TotalDue"].ToString()))
                    {
                        previousDueTextBox.Text = dt.Rows[0]["TotalDue"].ToString();
                        previousDueDiv.Visible = true;
                        DuesAmoutPayTextBox.ReadOnly = false;
                    }
                    else
                    {
                        previousDueTextBox.Text = "0.00";
                        previousDueDiv.Visible = false;
                        DuesAmoutPayTextBox.ReadOnly = true;
                    }
                }
                else
                {
                    //string message = "Customer <span class='actionTopic'>Due</span> Data not found.";
                    //MyAlertBox("WarningAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");

                    previousDueTextBox.Text = "0.00";
                    previousDueDiv.Visible = false;
                    DuesAmoutPayTextBox.ReadOnly = true;
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
                receivePayment = null;
            }
        }

        private void getCustomerByCustomerId()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                //DataTable dt = customer.GetCustomerById(customerIdDropDownList.SelectedValue);
                //customerNameTextBox.Text = dt.Rows[0]["CustomerName"].ToString();
                //customerContactNumberTextBox.Text = dt.Rows[0]["ContactNumber"].ToString();
                //customerAddressTextBox.Text = dt.Rows[0]["Address"].ToString();
                if (!string.IsNullOrEmpty(customerIdDropDownList.SelectedValue))
                {
                    for (int i = 0; i < customerListGridView.Rows.Count; i++)
                    {
                        if (customerListGridView.Rows[i].Cells[0].Text.Equals(customerIdDropDownList.SelectedValue))
                        {
                            customerNameTextBox.Text = customerListGridView.Rows[i].Cells[1].Text;
                            customerContactNumberTextBox.Text = customerListGridView.Rows[i].Cells[2].Text;
                            customerAddressTextBox.Text = customerListGridView.Rows[i].Cells[3].Text;
                            break;
                        }
                    }
                }
                else
                {
                    customerNameTextBox.Text = "";
                    customerContactNumberTextBox.Text = "";
                    customerAddressTextBox.Text = "";
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
                customer = null;
            }
        }

        protected void GetOverallVATPercentage()
        {
            ProductPriceBLL productPrice = new ProductPriceBLL();

            try
            {
                DataTable dt = productPrice.GetOverallProductVAT();

                txtbxdiscountPer.Text = dt.Rows[0][0].ToString();
                //vatTextBox.ReadOnly = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                productPrice = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadActiveCustomerList()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                DataTable dt = customer.GetActiveCustomerList();

                customerIdDropDownList.DataSource = dt;
                customerIdDropDownList.DataValueField = "CustomerId";
                customerIdDropDownList.DataTextField = "CustomerIdName";
                customerIdDropDownList.DataBind();
                //customerIdDropDownList.Items.Insert(0, "");
                //customerIdDropDownList.Items.Insert(1, "Retail");
                //customerIdDropDownList.SelectedIndex = 1;
                customerIdDropDownList.Items.Insert(0, "Retail");
                customerIdDropDownList.SelectedIndex = 0;
                customerIdDropDownList.Items[0].Value = "Retail";
                //Customer Gridview Load
                customerListGridView.DataSource = dt;
                customerListGridView.DataBind();

                if (customerListGridView.Rows.Count > 0)
                {
                    customerListGridView.UseAccessibleHeader = true;
                    customerListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Customer are not available !!!"; msgDetailLabel.Text = "";
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
                customer = null;
            }
        }

        protected void GetAvailableProductListBySalesCenter()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetAvailableProductListBySalesCenter(LumexSessionManager.Get("UserSalesCenterId").ToString());
                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Products are not available for the selected Sales Center!!!"; msgDetailLabel.Text = "";
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

        protected void addSelectedProductButton_Click(object sender, EventArgs e)
        {
            AddNewProductInList();
            productTextBox.Focus();
            productTextBox.Text = "";
        }

        protected void drpdwnCreditStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbxServiceCharge.ReadOnly = false;
            txtbxServiceChargePercentage.ReadOnly = false;
            txtbxServicePer.ReadOnly = false;
            string[] val = drpdwnCreditStatus.SelectedValue.Split('#');
            txtbxServicePer.Text = val[1];

            if (val[0] == "S")
            {
                txtbxServiceCharge.Text = "0";
            }
            else if (val[0] == "P")
            {
                txtbxServiceCharge.ReadOnly = true;
                txtbxServiceChargePercentage.ReadOnly = true;
                txtbxServicePer.ReadOnly = true;
            }

            CalculateOthersAmount();

            addCustomerButton.Focus();
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
                dt.Columns.Add(new DataColumn("FreeQuantity"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("OrderQuantity"));
                dt.Columns.Add(new DataColumn("Amount"));
                dt.Columns.Add(new DataColumn("VATPercentage"));

                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["FreeQuantity"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[4].Text.ToString();
                    dr["VATPercentage"] = selectedProductListGridView.Rows[i].Cells[7].Text.ToString();

                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["OrderQuantity"] = orderQuantityTextBox.Text.Trim();

                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    dr["Amount"] = amountTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                //int previousRowcount = dt.Rows.Count;

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    CheckBox chkbx = (CheckBox)productListGridView.Rows[i].FindControl("selectCheckBox");

                    if (chkbx.Checked && !CheckAddedProduct(productListGridView.Rows[i].Cells[1].Text.ToString()))
                    {
                        dr = dt.NewRow();

                        dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ProductId"] = productListGridView.Rows[i].Cells[1].Text.ToString();
                        dr["ProductName"] = productListGridView.Rows[i].Cells[2].Text.ToString();
                        dr["FreeQuantity"] = productListGridView.Rows[i].Cells[5].Text.ToString();
                        dr["Unit"] = productListGridView.Rows[i].Cells[3].Text.ToString();
                        dr["RatePerUnit"] = productListGridView.Rows[i].Cells[6].Text.ToString();
                        dr["OrderQuantity"] = "1";
                        dr["VATPercentage"] = productListGridView.Rows[i].Cells[7].Text.ToString();
                        dr["Amount"] = (decimal.Parse(productListGridView.Rows[i].Cells[6].Text.ToString()) - (decimal.Parse(productListGridView.Rows[i].Cells[6].Text.ToString()) * decimal.Parse(productListGridView.Rows[i].Cells[7].Text.ToString())) / 100).ToString();

                        dt.Rows.Add(dr);
                    }
                }

                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++) //for (int i = 0; i < previousRowcount; i++)
                {
                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    orderQuantityTextBox.Text = dt.Rows[i]["OrderQuantity"].ToString();

                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();
                }

                CalculateTotalAmount();
                CalculateOthersAmount();

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    otherInformation.Visible = true;
                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                    totalAmountTextBox.Text = "";
                    //totalReceivableTextBox.Text = "";
                    otherInformation.Visible = false;
                    receivedAmountTextBox.Text = "";
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
                        TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");

                        TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                        orderQuantityTextBox.Text = (int.Parse(orderQuantityTextBox.Text) + 1).ToString();

                        TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                        amountTextBox.Text = (int.Parse(orderQuantityTextBox.Text) * decimal.Parse(ratePerUnitTextBox.Text)).ToString();

                        amountTextBox.Text = (decimal.Parse(amountTextBox.Text) - (decimal.Parse(amountTextBox.Text) * decimal.Parse(selectedProductListGridView.Rows[i].Cells[7].Text.ToString())) / 100).ToString();

                        status = true;
                        break;
                    }
                }

                CalculateTotalAmount();
                CalculateOthersAmount();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

            return status;
        }

        protected void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string productBarcodeIdName = "";
                string[] pid = productTextBox.Text.Trim().Split('[');
                if (pid.Length > 1)
                {
                    productBarcodeIdName = pid[0];
                }
                else
                {
                    productBarcodeIdName = productTextBox.Text.Trim();
                }

                if (string.IsNullOrEmpty(productBarcodeIdName))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Write Product Barcode or ID or Name to search.";
                }
                else
                {
                    if (CheckAddedProduct(productBarcodeIdName))
                    {
                        CalculateTotalAmount();
                        //msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "This product already added in the selected product list.";
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
                                dt.Columns.Add(new DataColumn("FreeQuantity"));
                                dt.Columns.Add(new DataColumn("Unit"));
                                dt.Columns.Add(new DataColumn("RatePerUnit"));
                                dt.Columns.Add(new DataColumn("OrderQuantity"));
                                dt.Columns.Add(new DataColumn("Amount"));
                                dt.Columns.Add(new DataColumn("VATPercentage"));

                                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                                {
                                    dr = dt.NewRow();

                                    dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                                    dr["FreeQuantity"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[4].Text.ToString();
                                    dr["VATPercentage"] = selectedProductListGridView.Rows[i].Cells[7].Text.ToString();

                                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                                    dr["OrderQuantity"] = orderQuantityTextBox.Text.Trim();

                                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                                    dr["Amount"] = amountTextBox.Text.Trim();

                                    dt.Rows.Add(dr);
                                }

                                //int previousRowcount = dt.Rows.Count;

                                dr = dt.NewRow();
                                dr["Barcode"] = productListGridView.Rows[j].Cells[0].Text.ToString();
                                dr["ProductId"] = productListGridView.Rows[j].Cells[1].Text.ToString();
                                dr["ProductName"] = productListGridView.Rows[j].Cells[2].Text.ToString();
                                dr["FreeQuantity"] = productListGridView.Rows[j].Cells[5].Text.ToString();
                                dr["Unit"] = productListGridView.Rows[j].Cells[3].Text.ToString();
                                dr["RatePerUnit"] = productListGridView.Rows[j].Cells[6].Text.ToString();
                                dr["OrderQuantity"] = "1";
                                dr["VATPercentage"] = productListGridView.Rows[j].Cells[7].Text.ToString();
                                dr["Amount"] = (decimal.Parse(productListGridView.Rows[j].Cells[6].Text.ToString()) - (decimal.Parse(productListGridView.Rows[j].Cells[6].Text.ToString()) * decimal.Parse(productListGridView.Rows[j].Cells[7].Text.ToString())) / 100).ToString();
                                dt.Rows.Add(dr);

                                selectedProductListGridView.DataSource = dt;
                                selectedProductListGridView.DataBind();

                                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++) //for (int i = 0; i < previousRowcount; i++)
                                {
                                    TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                                    TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                                    orderQuantityTextBox.Text = dt.Rows[i]["OrderQuantity"].ToString();

                                    TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();
                                }

                                if (selectedProductListGridView.Rows.Count > 0)
                                {
                                    selectedProductListGridView.UseAccessibleHeader = true;
                                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                                    saveButton.Enabled = true;
                                    otherInformation.Visible = true;
                                }
                                else
                                {
                                    saveButton.Enabled = false;
                                    otherInformation.Visible = false;
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

                        CalculateTotalAmount();
                        CalculateOthersAmount();
                    }
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
                productTextBox.Focus();
                productTextBox.Text = "";
            }
        }

        protected void CalculateTotalAmount()
        {
            decimal amt = 0;
            decimal recAmt = 0;
            decimal Discount = 0;

            for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
            {
                TextBox amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                amt += decimal.Parse(amountTextBox.Text.Trim());

                TextBox rateUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");

                TextBox UnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");

                //Discount += (decimal.Parse(amountTextBox.Text.Trim()) - (decimal.Parse(rateUnitTextBox.Text.Trim()) * decimal.Parse(UnitTextBox.Text.Trim())));

                //  discountTextBox.Text = (Discount*-1).ToString();
                //totalReceivableTextBox.Text = amt.ToString();
            }
            totalAmountTextBox.Text = (amt + Convert.ToDecimal(txtbxOthersAmount.Text)).ToString();
            if (!string.IsNullOrEmpty(receivedAmountTextBox.Text.Trim()))
            {
                recAmt = decimal.Parse(receivedAmountTextBox.Text.Trim());
            }
        }

        protected void CalculateOthersAmount()
        {
            totalVATAmountHiddenField.Value = "0";
            decimal netAmt = 0;
            decimal totalAmt = 0;
            decimal discount = 0;
            decimal Service = 0;
            decimal ServicePercentage = 0;
            decimal discountPercentage = 0;
            decimal receivable = 0;
            decimal received = 0;

            decimal.TryParse(totalAmountTextBox.Text, out totalAmt);
            decimal.TryParse(discountTextBox.Text, out discount);
            decimal.TryParse(txtbxdiscountPer.Text, out discountPercentage);
            decimal.TryParse(receivableAmountTextBox.Text, out receivable);
            decimal.TryParse(receivedAmountTextBox.Text, out received);
            decimal.TryParse(txtbxServiceCharge.Text, out Service);
            decimal.TryParse(txtbxServicePer.Text, out ServicePercentage);
            if (ServicePercentage > 0)
            {
                Service = totalAmt * ServicePercentage / 100;
            }

            if (discountPercentage > 0)
            {
                discount = totalAmt * discountPercentage / 100;
            }

            netAmt = totalAmt - discount + Service;
            receivable = netAmt; //- (netAmt * vat / 100) + (netAmt * ServicePercentage / 100);
            totalDiscountAmountHdnField.Value = (totalAmt * discountPercentage / 100).ToString();
            totalServiceChargeHdnField.Value = (totalAmt * ServicePercentage / 100).ToString();

            receivableAmountTextBox.Text = receivable.ToString();
            changeAmountTextBox.Text = (received - receivable).ToString();
            txtbxdiscountPer.Text = discountPercentage.ToString();
            discountTextBox.Text = discount.ToString();
            txtbxServiceCharge.Text = Service.ToString();
            txtbxServicePer.Text = ServicePercentage.ToString();
            txtbxTotalDiscount.Text = totalDiscountAmountHdnField.Value;
            txtbxServiceChargePercentage.Text = totalServiceChargeHdnField.Value;

        }

        protected decimal CalculateTotalVATAmount()
        {
            decimal qty = 0;
            decimal rate = 0;
            decimal amt = 0;
            decimal vatRate = 0;
            decimal vatAmt = 0;

            for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
            {
                TextBox orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                qty = decimal.Parse(orderQuantityTextBox.Text.Trim());

                TextBox ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                rate = decimal.Parse(ratePerUnitTextBox.Text.Trim());

                vatRate = decimal.Parse(selectedProductListGridView.Rows[i].Cells[7].Text);

                amt = qty * rate;

                vatAmt += amt * (vatRate / 100);
            }

            return vatAmt;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            SalesOrderBLL salesOrder = new SalesOrderBLL();
            DataTable dtPrdList = new DataTable();
            DataRow dr = null;
            decimal quantity = 0;
            double rate = 0;
            double amount = 0;
            TextBox orderQuantityTextBox;
            TextBox ratePerUnitTextBox;
            TextBox amountTextBox;
            int i = 0;

            dtPrdList.Columns.Add("ProductId");
            dtPrdList.Columns.Add("Available");
            dtPrdList.Columns.Add("Quantity");
            dtPrdList.Columns.Add("RatePerUnit");
            dtPrdList.Columns.Add("VATPercentage");
            dtPrdList.Columns.Add("Amount");

            try
            {
                for (i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    orderQuantityTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    ratePerUnitTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    amountTextBox = (TextBox)selectedProductListGridView.Rows[i].FindControl("amountTextBox");

                    if (string.IsNullOrEmpty(orderQuantityTextBox.Text.Trim()) || !decimal.TryParse(orderQuantityTextBox.Text.Trim(), out quantity))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid quantity.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (string.IsNullOrEmpty(ratePerUnitTextBox.Text.Trim()) || !double.TryParse(ratePerUnitTextBox.Text.Trim(), out rate))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid rate.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (string.IsNullOrEmpty(amountTextBox.Text.Trim()) || !double.TryParse(amountTextBox.Text.Trim(), out amount))
                    {
                        msg = "Product ID [" + selectedProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid amount.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else
                    {
                        dr = dtPrdList.NewRow();

                        dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                        dr["Available"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                        dr["Quantity"] = quantity.ToString();
                        dr["RatePerUnit"] = rate.ToString();
                        dr["VATPercentage"] = selectedProductListGridView.Rows[i].Cells[7].Text.ToString();
                        dr["Amount"] = amount.ToString();

                        dtPrdList.Rows.Add(dr);
                    }
                }

                if (totalAmountTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Total Amount field is required.";
                    return;
                }
                else if (receivedAmountTextBox.Text.Trim() == "" && customerIdDropDownList.SelectedIndex == 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Received Amount field is required.";
                    return;
                }
                else if (changeAmountTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Change Amount field is required.";
                    return;
                }
                else if (customerIdDropDownList.SelectedItem.Text == "Retail" && customerNameTextBox.Text == "" && customerContactNumberTextBox.Text == "" && Convert.ToDecimal(changeAmountTextBox.Text) < 0)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Customer Name and Contact is required for Due amount.";
                    return;
                }
                if (string.IsNullOrEmpty(DuesAmoutPayTextBox.Text))
                {
                    DuesAmoutPayTextBox.Text = "0";
                }
                if (receivedAmountTextBox.Text == "")
                {
                    receivedAmountTextBox.Text = "0";
                }
                salesOrder.SalesCenterId = lblSalescenterId.Text;
                salesOrder.CustomerId = customerIdDropDownList.SelectedValue.Trim();
                salesOrder.CustomerName = customerNameTextBox.Text.Trim();
                salesOrder.CustomerContactNumber = customerContactNumberTextBox.Text.Trim();
                salesOrder.CustomerAddress = customerAddressTextBox.Text.Trim();
                salesOrder.TotalAmount = totalAmountTextBox.Text.Trim();
                salesOrder.DiscountAmount = discountTextBox.Text.Trim();
                salesOrder.ServiceAmount = txtbxServiceCharge.Text.Trim();
                salesOrder.ServicePercentage = txtbxServicePer.Text.Trim();
                salesOrder.DiscountPercentage = txtbxdiscountPer.Text.Trim();
                salesOrder.TotalReceivable = receivableAmountTextBox.Text.Trim();
                salesOrder.Due = DuesAmoutPayTextBox.Text;
                salesOrder.OthersDes = txtbxDescription.Text;
                salesOrder.OthersAmount = txtbxOthersAmount.Text;
                salesOrder.creditStatus = drpdwnCreditStatus.SelectedItem.Text[0];
                if (salesOrder.creditStatus == 'P')
                {
                    salesOrder.ServicePercentage = "18";
                    decimal changeAmountCal = Convert.ToDecimal(changeAmountTextBox.Text);
                    if (changeAmountCal < 0)
                    {
                        changeAmountCal = changeAmountCal * (-1);

                        salesOrder.ServiceAmount = ((changeAmountCal *18 )/ 100).ToString();
                    }

                }
                //new field added here //

                salesOrder.SalesOrderId = "";
                salesOrder.AccountId = accountHeadDropDownList.SelectedValue;
                salesOrder.PaymentMode = paymentModeDropDownList.SelectedValue;
                salesOrder.Bank = bankDropDownList.Text;
                salesOrder.BankBranch = bankBranchTextBox.Text;
                salesOrder.ChequeNumber = chequeNumberTextBox.Text;
                if (paymentModeDropDownList.SelectedValue == "Cash")
                {
                    salesOrder.ChequeDate = LumexLibraryManager.ParseAppDate("1/1/1900");
                }
                else
                {
                    salesOrder.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim());// LumexLibraryManager.ParseAppDate("1/1/1900")
                }


                salesOrder.ReceivedAmount = receivedAmountTextBox.Text.Trim();
                salesOrder.ChangeAmount = (Convert.ToDecimal(salesOrder.ReceivedAmount) - Convert.ToDecimal(salesOrder.TotalReceivable)).ToString();
                // salesOrder.ChangeAmount = changeAmountTextBox.Text.Trim();
                //salesOrder.TotalVATAmount = CalculateTotalVATAmount().ToString();
                salesOrder.TotalVATAmount = totalVATAmountHiddenField.Value;
                salesOrder.TotalDiscount = "0";


                if (dtPrdList.Rows.Count == selectedProductListGridView.Rows.Count)
                {
                    string salesRecordId = salesOrder.SaveRetailSales(dtPrdList);

                    if (!string.IsNullOrEmpty(salesRecordId))
                    {
                        if (Convert.ToDecimal(salesOrder.Due) > 0)
                        {
                            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();
                            receivePayment.AccountId = accountHeadDropDownList.SelectedValue;
                            receivePayment.CustomerId = customerIdDropDownList.SelectedValue.Trim();
                            receivePayment.Bank = bankDropDownList.Text;
                            receivePayment.BankBrach = bankBranchTextBox.Text;
                            receivePayment.ChequeNo = chequeNumberTextBox.Text;
                            if (paymentModeDropDownList.SelectedValue == "Cash")
                            {
                                salesOrder.ChequeDate = LumexLibraryManager.ParseAppDate("1/1/1900");
                            }
                            else
                            {
                                salesOrder.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim());// LumexLibraryManager.ParseAppDate("1/1/1900")
                            }
                            DataTable dt = new DataTable();

                            receivePayment.SalesCenterId = LumexSessionManager.Get("UserSalesCenterId").ToString();
                            receivePayment.CustomerId = customerIdDropDownList.SelectedValue.Trim();
                            receivePayment.CashCheque = paymentModeDropDownList.SelectedValue;
                            receivePayment.CurrentReceivable = previousDueTextBox.Text;
                            receivePayment.Amount = salesOrder.Due;
                            if (Convert.ToDecimal(receivePayment.Amount) <= Convert.ToDecimal(salesOrder.ChangeAmount) && Convert.ToDecimal(receivePayment.Amount) > 0)
                            {
                                receivePayment.SaveCustomerPayment(salesOrder.SalesCenterId, dt);
                            }
                        }

                        string message = "Product's <span class='actionTopic'>Sales</span> Successfully with Sale ID: <span class='actionTopic'>" +
                            salesRecordId + "</span>.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Sales/RetailSales.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    //MyAlertBox("alert(\"Retail Sales Created Successfully with Sales ID: " + salesRecordId.Trim() + " \"); window.location=\"/UI/Sales/RetailSalesList.aspx\"");
                    //Response.Redirect("/UI/Sales/RetailSalesList.aspx", false);
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
                salesOrder = null;
                dtPrdList = null;
            }
        }

        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow) (sender as Control).Parent.Parent;
                int index = gvRow.RowIndex;

                string productId = selectedProductListGridView.Rows[index].Cells[1].Text.ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("FreeQuantity"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("OrderQuantity"));
                dt.Columns.Add(new DataColumn("Amount"));
                dt.Columns.Add(new DataColumn("VATPercentage"));

                for (int i = 0; i < selectedProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = selectedProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = selectedProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = selectedProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["FreeQuantity"] = selectedProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["Unit"] = selectedProductListGridView.Rows[i].Cells[4].Text.ToString();
                    dr["VATPercentage"] = selectedProductListGridView.Rows[i].Cells[7].Text.ToString();

                    TextBox ratePerUnitTextBox =
                        (TextBox) selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    TextBox orderQuantityTextBox =
                        (TextBox) selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    dr["OrderQuantity"] = orderQuantityTextBox.Text.Trim();

                    TextBox amountTextBox = (TextBox) selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    dr["Amount"] = amountTextBox.Text.Trim();

                    dt.Rows.Add(dr);
                }

                for (int i = 0; i < productListGridView.Rows.Count; i++)
                {
                    if (productListGridView.Rows[i].Cells[1].Text.ToString() == productId)
                    {
                        CheckBox chkbx = (CheckBox) productListGridView.Rows[i].FindControl("selectCheckBox");
                        chkbx.Checked = false;

                        CheckBox allchkbx = (CheckBox) productListGridView.HeaderRow.FindControl("allCheckBox");
                        allchkbx.Checked = false;
                        checkedRowCountHiddenField.Value = (int.Parse(checkedRowCountHiddenField.Value) - 1).ToString();

                        break;
                    }
                }

                dt.Rows.RemoveAt(index);
                selectedProductListGridView.DataSource = dt;
                selectedProductListGridView.DataBind();

                double amount = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox ratePerUnitTextBox =
                        (TextBox) selectedProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    TextBox orderQuantityTextBox =
                        (TextBox) selectedProductListGridView.Rows[i].FindControl("orderQuantityTextBox");
                    orderQuantityTextBox.Text = dt.Rows[i]["OrderQuantity"].ToString();

                    TextBox amountTextBox = (TextBox) selectedProductListGridView.Rows[i].FindControl("amountTextBox");
                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    {
                        amount += double.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                }

                totalAmountTextBox.Text = amount.ToString();
                discountTextBox.Text = "0";
                //totalReceivableTextBox.Text = amount.ToString();
                CalculateTotalAmount();
                CalculateOthersAmount();

                if (selectedProductListGridView.Rows.Count > 0)
                {
                    selectedProductListGridView.UseAccessibleHeader = true;
                    selectedProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                    totalAmountTextBox.Text = "";
                    //totalReceivableTextBox.Text = "";
                    receivedAmountTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += " --> " + ex.InnerException.Message;
                }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                productTextBox.Focus();
            }
        }
        protected void paymentModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (paymentModeDropDownList.SelectedValue == "Cash")
                {
                    //customerIdDropDownList.Enabled = false;
                    //customerAddressTextBox.Enabled = false;
                    //customerContactNumberTextBox.Enabled = false;
                    //customerNameTextBox.Enabled = false;
                    //CustomerInformation.Visible = false;
                    bankBranchTextBox.Enabled = false;
                    bankDropDownList.Enabled = false;
                    chequeDateTextBox.Enabled = false;
                    chequeNumberTextBox.Enabled = false;
                    loadCashorChequeAccountHead();
                }
                else
                {
                    bankBranchTextBox.Enabled = true;
                    bankDropDownList.Enabled = true;
                    chequeDateTextBox.Enabled = true;
                    chequeNumberTextBox.Enabled = true;
                    loadCashorChequeAccountHead();
                    // CustomerInformation.Visible = true;
                    //customerIdDropDownList.Enabled = true;
                    //customerAddressTextBox.Enabled = true;
                    //customerContactNumberTextBox.Enabled = true;
                    //customerNameTextBox.Enabled = true;
                    //customerIdDropDownList.Enabled = true;
                }
            }
            catch (Exception)
            {


            }
        }
        protected void loadCashorChequeAccountHead()
        {
            try
            {
                accountHeadDropDownList.Items.Clear();
                ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();
                if (paymentModeDropDownList.SelectedItem.Text == "Cash")
                {
                    DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashHeadList();

                    accountHeadDropDownList.DataSource = dt;
                    accountHeadDropDownList.DataValueField = "AccountId";
                    accountHeadDropDownList.DataTextField = "AccountHead";
                    accountHeadDropDownList.DataBind();
                    // accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;

                }
                else if (paymentModeDropDownList.SelectedItem.Text == "Cheque")
                {
                    DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsBankHeadList();
                    accountHeadDropDownList.DataSource = dt;
                    accountHeadDropDownList.DataValueField = "AccountId";
                    accountHeadDropDownList.DataTextField = "AccountHead";
                    accountHeadDropDownList.DataBind();
                    // accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}