using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Lumex.Tech;
using Lumex.Project.BLL;

namespace lmxIpos.UI.production
{
    public partial class newproduction : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;
            if (!IsPostBack)
            {
                txtOtherAmmount.Attributes.Add("autocomplete", "off");
                checkedRowCountHiddenField.Value = "0";
                // productTextBox.Attributes.Add("autocomplete", "off");
                LoadWarehouses();
                loadProductList();
            }
            if (productListGridView.Rows.Count > 0)
            {
                productListGridView.UseAccessibleHeader = true;
                productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (purchaseProductListGridView.Rows.Count > 0)
            {
                purchaseProductListGridView.UseAccessibleHeader = true;
                purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GridfinalGoodsReport.Rows.Count > 0)
            {
                GridfinalGoodsReport.UseAccessibleHeader = true;
                GridfinalGoodsReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void loadProductList()
        {
            ProductBLL productBLL = new ProductBLL();
            try
            {
                DataTable dt = productBLL.GetProductList();

                ddlProduct.DataSource = dt;
                ddlProduct.DataValueField = "ProductId";
                ddlProduct.DataTextField = "ProductVolUnit";
                ddlProduct.DataBind();

                ddlProduct.Items.Insert(0, "--Select Product--");


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
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
                warehouseDropDownList.Items.Insert(0, "");
                warehouseDropDownList.SelectedIndex = 0;
                warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

                warehouseDropDownList_SelectedIndexChanged(this, new EventArgs());

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
        protected void GetActiveProducts(string id)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetAvailableProductListByWarehouse(id);
                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    productListGridView.DataSource = "";
                    productListGridView.DataBind();
                }
                if (purchaseProductListGridView.Rows.Count > 0)
                {
                    purchaseProductListGridView.UseAccessibleHeader = true;
                    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected bool CheckAddedProduct(string productBarcodeIdName)
        {
            bool status = false;

            try
            {
                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    if (purchaseProductListGridView.Rows[i].Cells[0].Text.ToString() == productBarcodeIdName || purchaseProductListGridView.Rows[i].Cells[1].Text.ToString() == productBarcodeIdName || purchaseProductListGridView.Rows[i].Cells[2].Text.ToString() == productBarcodeIdName)
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
        //protected void addProductButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double totalPrice = 0;
        //        double totalQuantity = 1;
        //        string productBarcodeIdName = productTextBox.Text.Trim();

        //        if (string.IsNullOrEmpty(productBarcodeIdName))
        //        {
        //            msgbox.Visible = true;
        //            msgTitleLabel.Text = "Exception!!!";
        //            msgDetailLabel.Text = "Write Product Barcode or ID or Name to search.";
        //        }
        //        else
        //        {
        //            if (CheckAddedProduct(productTextBox.Text.Trim()))
        //            {
        //                msgbox.Visible = true;
        //                msgTitleLabel.Text = "Exception!!!";
        //                msgDetailLabel.Text = "This product already added in the selected product list.";

        //            }
        //            else
        //            {
        //                for (int j = 0; j < productListGridView.Rows.Count; j++)
        //                {
        //                    if (productListGridView.Rows[j].Cells[0].Text.ToString() == productBarcodeIdName ||
        //                        productListGridView.Rows[j].Cells[1].Text.ToString() == productBarcodeIdName ||
        //                        productListGridView.Rows[j].Cells[2].Text.ToString() == productBarcodeIdName)
        //                    {
        //                        DataTable dt = new DataTable();
        //                        DataRow dr = null;

        //                        dt.Columns.Add(new DataColumn("Barcode"));
        //                        dt.Columns.Add(new DataColumn("ProductId"));
        //                        dt.Columns.Add(new DataColumn("ProductName"));
        //                        dt.Columns.Add(new DataColumn("Unit"));
        //                        dt.Columns.Add(new DataColumn("Quantity"));
        //                        dt.Columns.Add(new DataColumn("RatePerUnit"));
        //                        dt.Columns.Add(new DataColumn("Amount"));

        //                        for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
        //                        {
        //                            dr = dt.NewRow();

        //                            dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
        //                            dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
        //                            dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();
        //                            dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[3].Text.ToString();

        //                            TextBox quantityTextBox =
        //                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
        //                            dr["Quantity"] = quantityTextBox.Text.Trim();

        //                            TextBox ratePerUnitTextBox =
        //                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
        //                            dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

        //                            TextBox amountTextBox =
        //                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
        //                            dr["Amount"] = amountTextBox.Text.Trim();
        //                            totalQuantity += Convert.ToDouble(quantityTextBox.Text.Trim());
        //                            if (amountTextBox.Text != string.Empty)
        //                            {
        //                                totalPrice += Convert.ToDouble(amountTextBox.Text.Trim());
        //                            }

        //                            dt.Rows.Add(dr);
        //                        }


        //                        //int previousRowcount = dt.Rows.Count;

        //                        dr = dt.NewRow();
        //                        dr["Barcode"] = productListGridView.Rows[j].Cells[0].Text.ToString();
        //                        dr["ProductId"] = productListGridView.Rows[j].Cells[1].Text.ToString();
        //                        dr["ProductName"] = productListGridView.Rows[j].Cells[2].Text.ToString();
        //                        dr["Unit"] = productListGridView.Rows[j].Cells[3].Text.ToString();
        //                        dr["Quantity"] = "1";
        //                        dr["RatePerUnit"] = productListGridView.Rows[j].Cells[6].Text.ToString();
        //                        dr["Amount"] = productListGridView.Rows[j].Cells[6].Text.ToString();
        //                        dt.Rows.Add(dr);

        //                        purchaseProductListGridView.DataSource = dt;
        //                        purchaseProductListGridView.DataBind();

        //                        for (int i = 0; i < productListGridView.Rows.Count; i++)
        //                        {
        //                            TextBox quantityTextBox =
        //                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
        //                            quantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();

        //                            TextBox ratePerUnitTextBox =
        //                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
        //                            ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

        //                            TextBox amountTextBox =
        //                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
        //                            amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

        //                        }

        //                        if (purchaseProductListGridView.Rows.Count > 0)
        //                        {
        //                            purchaseProductListGridView.UseAccessibleHeader = true;
        //                            purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //                            saveButton.Enabled = true;
        //                        }
        //                        else
        //                        {
        //                            saveButton.Enabled = false;
        //                        }

        //                        CheckBox chkbx = (CheckBox)productListGridView.Rows[j].FindControl("selectCheckBox");
        //                        chkbx.Checked = true;
        //                        checkedRowCountHiddenField.Value =
        //                            (int.Parse(checkedRowCountHiddenField.Value) + 1).ToString();

        //                        productBarcodeIdName = "added";
        //                        break;
        //                    }
        //                }

        //                if (productBarcodeIdName != "added")
        //                {
        //                    msgbox.Visible = true;
        //                    msgTitleLabel.Text = "Exception!!!";
        //                    msgDetailLabel.Text = "Product not found.";
        //                }

        //            }

        //        }

        //        double otherAmt = 0;
        //        double workingCost = 0;
        //        string amt = txtOtherAmmount.Text.Trim();
        //        string wrkingCost = txtWorkingCost.Text.Trim();
        //        if (amt != "" && wrkingCost != "")
        //        {
        //            otherAmt = Convert.ToDouble(amt);
        //            workingCost = Convert.ToDouble(wrkingCost);
        //        }
        //        InitialProuctAddTextbox();
        //        txtTotAmmount.Text = Convert.ToString(totalPrice);
        //        double totPayable = totalPrice + otherAmt + workingCost;
        //        txtPayableAmmount.Text = Convert.ToString(totPayable);
        //        txtTotQuantity.Text = Convert.ToString(totalQuantity);
        //        lblTotoWeight.Text = Convert.ToString(totalQuantity);
        //        lblTotAmmount.Text = Convert.ToString(totPayable);

        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null)
        //        {
        //            message += " --> " + ex.InnerException.Message;
        //        }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        MyAlertBox("MyOverlayStop();");
        //    }

        //}
        ////protected void InitialProuctAddTextbox()
        //{
        //    productTextBox.Text = "";
        //    productTextBox.Focus();
        //    //  MyAlertBox("MyOverlayStop();");
        //}

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
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("Amount"));

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[3].Text.ToString();

                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                    dr["Quantity"] = quantityTextBox.Text.Trim();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
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
                        dr["Unit"] = productListGridView.Rows[i].Cells[3].Text.ToString();
                        dr["Quantity"] = "1";
                        dr["RatePerUnit"] = productListGridView.Rows[i].Cells[6].Text.ToString();
                        dr["Amount"] = productListGridView.Rows[i].Cells[6].Text.ToString();

                        dt.Rows.Add(dr);
                    }
                }

                purchaseProductListGridView.DataSource = dt;
                purchaseProductListGridView.DataBind();

                double totQuantity = 0;
                double totRawmeraialCost = 0;
                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                    quantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                    totQuantity += Convert.ToDouble(quantityTextBox.Text.Trim());
                    totRawmeraialCost += Convert.ToDouble(amountTextBox.Text.Trim());

                }

                txtTotQuantity.Text = Convert.ToString(totQuantity);
                txtTotAmmount.Text = Convert.ToString(totRawmeraialCost);


                double otherAmt = 0;
                double workingCost = 0;
                string amt = txtOtherAmmount.Text.Trim();
                string wrkingCost = txtWorkingCost.Text.Trim();
                if (amt != "" && wrkingCost != "")
                {
                    otherAmt = Convert.ToDouble(amt);
                    workingCost = Convert.ToDouble(wrkingCost);
                }
                double totPayable = totRawmeraialCost + otherAmt + workingCost;
                txtPayableAmmount.Text = Convert.ToString(totPayable);
                lblTotAmmount.Text = txtPayableAmmount.Text;
                lblTotoWeight.Text = txtTotQuantity.Text;

                if (purchaseProductListGridView.Rows.Count > 0)
                {
                    purchaseProductListGridView.UseAccessibleHeader = true;
                    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    saveButton.Enabled = true;
                }
                else
                {
                    saveButton.Enabled = false;
                }
                //  InitialProuctAddTextbox();
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
                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
                int index = gvRow.RowIndex;

                string productId = purchaseProductListGridView.Rows[index].Cells[1].Text.ToString();

                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("Barcode"));
                dt.Columns.Add(new DataColumn("ProductId"));
                dt.Columns.Add(new DataColumn("ProductName"));
                dt.Columns.Add(new DataColumn("Unit"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("Amount"));
                dt.Columns.Add(new DataColumn("UnitPrice"));

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[3].Text.ToString();

                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                    dr["Quantity"] = quantityTextBox.Text.Trim();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    dr["Amount"] = amountTextBox.Text.Trim();

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
                purchaseProductListGridView.DataSource = dt;
                purchaseProductListGridView.DataBind();

                double amount = 0;
                double totQuantity = 0;
                double totPayableAmmount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                    quantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                    ratePerUnitTextBox.Text = dt.Rows[i]["RatePerUnit"].ToString();

                    TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    amountTextBox.Text = dt.Rows[i]["Amount"].ToString();
                    totQuantity += double.Parse(quantityTextBox.Text);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    {
                        totPayableAmmount += Convert.ToDouble(amountTextBox.Text);
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    {
                        amount += double.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                }
                double otherAmt = 0;
                double workingCost = 0;
                string amt = txtOtherAmmount.Text.Trim();
                string wrkingCost = txtWorkingCost.Text.Trim();
                if (amt != "" && wrkingCost != "")
                {
                    otherAmt = Convert.ToDouble(amt);
                    workingCost = Convert.ToDouble(wrkingCost);
                }
                txtTotAmmount.Text = Convert.ToString(totPayableAmmount);
                totPayableAmmount = totPayableAmmount + workingCost + otherAmt;
                lblTotoWeight.Text = Convert.ToString(totQuantity);
                txtTotQuantity.Text = Convert.ToString(totQuantity);
                txtPayableAmmount.Text = Convert.ToString(totPayableAmmount);
                lblTotAmmount.Text = Convert.ToString(totPayableAmmount);

                //totalAmountTextBox.Text = amount.ToString();
                //totalPayableTextBox.Text = (decimal.Parse(totalAmountTextBox.Text.Trim()) - decimal.Parse(discountTextBox.Text.Trim())).ToString();
                //if (string.IsNullOrEmpty(vatTextBox.Text.Trim()))
                //{
                //    totalPayableTextBox.Text = amount.ToString();
                //}
                //else
                //{
                //    totalPayableTextBox.Text = ((amount * double.Parse(vatTextBox.Text.Trim()) / 100) + amount).ToString();
                //}

                if (purchaseProductListGridView.Rows.Count > 0)
                {
                    purchaseProductListGridView.UseAccessibleHeader = true;
                    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    saveButton.Enabled = true;
                }
                else
                {
                    txtTotAmmount.Text = "0";
                    if (txtOtherAmmount.Text != string.Empty && txtWorkingCost.Text != string.Empty)
                    {
                        txtPayableAmmount.Text = Convert.ToString(Convert.ToDouble(txtOtherAmmount.Text) + Convert.ToDouble(txtWorkingCost.Text));
                    }
                    else
                    {
                        if (txtOtherAmmount.Text == string.Empty)
                        {
                            txtPayableAmmount.Text = txtWorkingCost.Text;
                        }
                        if (txtWorkingCost.Text == string.Empty)
                        {
                            txtPayableAmmount.Text = txtOtherAmmount.Text;
                        }
                        txtPayableAmmount.Text = "0";
                    }
                    lblTotAmmount.Text = txtPayableAmmount.Text;
                    //lblTotalQntity.Text = "0";
                    saveButton.Enabled = false;
                }
                //  InitialProuctAddTextbox();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlProduct.SelectedValue.ToString() != string.Empty)
                {
                    if (purchaseProductListGridView.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataRow dr = dt.NewRow();
                        double totalQuantity = 0;
                        double totalPrice = 0;
                        for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                        {
                            TextBox quantityTextBox =
                                       (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");


                            TextBox amountTextBox =
                                (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");

                            totalQuantity += Convert.ToDouble(quantityTextBox.Text.Trim());

                            totalPrice += Convert.ToDouble(amountTextBox.Text.Trim());
                        }
                        txtTotAmmount.Text = Convert.ToString(totalPrice);
                        txtTotQuantity.Text = Convert.ToString(totalQuantity);
                        string workingCost = txtWorkingCost.Text;
                        string otherAmt = txtOtherAmmount.Text;
                        if (otherAmt != string.Empty && workingCost != string.Empty)
                        {
                            double totPayableAmount = totalPrice + Convert.ToDouble(otherAmt) + Convert.ToDouble(workingCost);
                            txtPayableAmmount.Text = Convert.ToString(totPayableAmount);
                        }
                        else
                        {

                            txtPayableAmmount.Text = Convert.ToString(totalPrice);
                        }
                        lblTotAmmount.Text = txtPayableAmmount.Text;
                        lblTotoWeight.Text = txtTotQuantity.Text;
                        lblWestedWeight.Text = Convert.ToString(totalQuantity - Convert.ToDouble(txtGoodsWeights.Text));
                        lblDecreaseRate.Text = Convert.ToString((Convert.ToDouble(lblWestedWeight.Text) * 100) / totalQuantity) + " %";
                    }

                    string costing = "";
                    string goodsWeight = txtGoodsWeights.Text;
                    string goodsBundle = txtGoodsBundle.Text;

                    if (stockOnRadioBtn.SelectedIndex == 0)
                    {
                        costing = Convert.ToString(Convert.ToDouble(lblTotAmmount.Text) / Convert.ToDouble(goodsWeight));
                    }
                    else
                    {
                        costing = Convert.ToString(Convert.ToDouble(lblTotAmmount.Text) / Convert.ToDouble(goodsBundle));
                    }
                    DataTable dm = new DataTable();

                    dm.Columns.Add(new DataColumn("ProductId"));
                    dm.Columns.Add(new DataColumn("ProductName"));
                    dm.Columns.Add(new DataColumn("Quantity"));
                    dm.Columns.Add(new DataColumn("Costing"));

                    DataRow datarow = dm.NewRow();
                    datarow["ProductId"] = ddlProduct.SelectedValue.ToString();
                    datarow["ProductName"] = ddlProduct.SelectedItem.Text;
                    datarow["Quantity"] = txtGoodsWeights.Text;
                    datarow["Costing"] = costing;

                    dm.Rows.Add(datarow);

                    GridfinalGoodsReport.DataSource = dm;
                    GridfinalGoodsReport.DataBind();

                    if (GridfinalGoodsReport.Rows.Count > 0)
                    {
                        GridfinalGoodsReport.UseAccessibleHeader = true;
                        GridfinalGoodsReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (purchaseProductListGridView.Rows.Count > 0)
                    {
                        purchaseProductListGridView.UseAccessibleHeader = true;
                        purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    msgDetailLabel.Text = "Please select product first.";
                    msgTitleLabel.Text = "Validation!!.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    msgbox.Visible = true;
                }

            }
            catch (Exception ex)
            {
                msgDetailLabel.Text = "Some Things Goes Wrong . Please Fill all required Field";
                msgTitleLabel.Text = "Warning!!.";
                msgbox.Attributes.Add("Class", "alert alert-warning");
                msgbox.Visible = true;
                //string message = "Warning !!!";
                //if (ex.InnerException != null) { message += " Some Things Goes Wrong . Please Fill all required Field"; }
                //MyAlertBox("ErrorAlert( \"" + message + "\", \"\");");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (saveFinalProductDetails())
                {
                    string message = "Product's <span class='actionTopic'>created</span> Successfully <span class='actionTopic'>" +
                            "</span>.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/production/approval.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\",callbackOk);");
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Production does not created"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected bool saveFinalProductDetails()
        {
            bool status = false;
            try
            {
                string[] decreseRate = lblDecreaseRate.Text.Split('%');
                DataTable dt = new DataTable();
                newproductionBLL newProduction = new newproductionBLL();
                string unitCost = GridfinalGoodsReport.Rows[0].Cells[3].Text.ToString();
                string otherammount;
                string workingCost;
                if (string.IsNullOrEmpty(txtOtherAmmount.Text))
                {
                    otherammount = "0";
                }
                else
                {
                    otherammount = txtOtherAmmount.Text;
                }
                if (string.IsNullOrEmpty(txtWorkingCost.Text))
                {
                    workingCost = "0";
                }
                else
                {
                    workingCost = txtWorkingCost.Text;
                }
                newProduction.wareHouseID = warehouseDropDownList.SelectedValue.ToString();
                newProduction.productID = ddlProduct.SelectedValue.ToString();
                newProduction.produceWeight = Convert.ToDouble(txtGoodsWeights.Text.Trim());
                newProduction.produceBundle = Convert.ToDouble(txtGoodsBundle.Text.Trim());
                newProduction.produceDate = LumexLibraryManager.ParseAppDate(txtDate.Text.Trim());
                newProduction.unitCost = Convert.ToDouble(unitCost);
                newProduction.productionCost = Convert.ToDouble(lblTotAmmount.Text.Trim());
                newProduction.totalQuantity = Convert.ToDouble(lblTotoWeight.Text.Trim());
                newProduction.rawMetarialCost = Convert.ToDouble(txtTotAmmount.Text.Trim());
                newProduction.otherAmmount = Convert.ToDouble(otherammount);
                newProduction.workingCost = Convert.ToDouble(workingCost);
                newProduction.decreaseWeight = Convert.ToDouble(lblWestedWeight.Text.Trim());
                newProduction.decreaseRate = Convert.ToDouble(decreseRate[0].Trim());
                newProduction.description = txtDescription.Text.Trim();
                newProduction.createdBy = (string)LumexSessionManager.Get("ActiveUserId");
                newProduction.createdDate = Convert.ToDateTime(LumexLibraryManager.ParseAppDate(DateTime.Now.ToString("dd/MM/yyyy")));
                //get production auto id
                AutoIdGenerateBLL autoid = new AutoIdGenerateBLL();
                DataTable dt2 = autoid.CreateId("Pro");
                newProduction.productionId = dt2.Rows[0][0].ToString();

                if (stockOnRadioBtn.SelectedIndex == 0)
                {
                    newProduction.forStock = txtGoodsWeights.Text.Trim();
                }
                else
                {
                    newProduction.forStock = txtGoodsBundle.Text.Trim();
                }


                DataTable dtRawMet = new DataTable();

                dtRawMet.Columns.Add("productId");
                dtRawMet.Columns.Add("quantity");
                dtRawMet.Columns.Add("rate");
                dtRawMet.Columns.Add("cost");

                if (purchaseProductListGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                    {
                        DataRow dr = null;

                        dr = dtRawMet.NewRow();
                        dr["productId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                        TextBox quantity = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                        dr["quantity"] = quantity.Text.Trim();
                        TextBox rate = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                        dr["rate"] = rate.Text;
                        TextBox cost = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                        dr["cost"] = cost.Text;

                        dtRawMet.Rows.Add(dr);
                    }
                }

                if (newProduction.SaveProductionDetails(dtRawMet))
                {
                    autoid.updateId("Pro");
                    autoid.deleteId(newProduction.productionId);
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }


    }
}