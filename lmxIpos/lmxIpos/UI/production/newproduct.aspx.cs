using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.production
{
    public partial class newproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;
            if (!IsPostBack)
            {
                checkedRowCountHiddenField.Value = "0";
                //loadWarehouse();
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
           
        }

        
        protected void loadProductList()
        {
            ProductBLL productBLL = new ProductBLL();
            try
            {
                DataTable dt = productBLL.GetProductList();

                mainProductionDrpDwnList.DataSource = dt;
                mainProductionDrpDwnList.DataValueField = "ProductId";
                mainProductionDrpDwnList.DataTextField = "ProductVolUnit";
                mainProductionDrpDwnList.DataBind();

                mainProductionDrpDwnList.Items.Insert(0, "--Select Product--");


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
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
                dt.Columns.Add(new DataColumn("FreeQuantity"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["FreeQuantity"] = purchaseProductListGridView.Rows[i].Cells[4].Text.ToString();

                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                    dr["Quantity"] = quantityTextBox.Text.Trim();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    //TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    //dr["Amount"] = amountTextBox.Text.Trim();


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
                        dr["FreeQuantity"] = productListGridView.Rows[i].Cells[5].Text.ToString();
                       // dr["Amount"] = productListGridView.Rows[i].Cells[6].Text.ToString();

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

                    //TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    //amountTextBox.Text = dt.Rows[i]["Amount"].ToString();

                    totQuantity += Convert.ToDouble(quantityTextBox.Text.Trim());
                   // totRawmeraialCost += Convert.ToDouble(amountTextBox.Text.Trim());

                }

                //txtTotQuantity.Text = Convert.ToString(totQuantity);
                //txtTotAmmount.Text = Convert.ToString(totRawmeraialCost);


                //double otherAmt = 0;
                //double workingCost = 0;
                //string amt = txtOtherAmmount.Text.Trim();
                //string wrkingCost = txtWorkingCost.Text.Trim();
                //if (amt != "" && wrkingCost != "")
                //{
                //    otherAmt = Convert.ToDouble(amt);
                //    workingCost = Convert.ToDouble(wrkingCost);
                //}
                //double totPayable = totRawmeraialCost + otherAmt + workingCost;
                //txtPayableAmmount.Text = Convert.ToString(totPayable);
                //lblTotAmmount.Text = txtPayableAmmount.Text;
                //lblTotoWeight.Text = txtTotQuantity.Text;

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
                //MyAlertBox("MyOverlayStop();");
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
                dt.Columns.Add(new DataColumn("FreeQuantity"));
                dt.Columns.Add(new DataColumn("RatePerUnit"));
                dt.Columns.Add(new DataColumn("UnitPrice"));

                for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Barcode"] = purchaseProductListGridView.Rows[i].Cells[0].Text.ToString();
                    dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                    dr["ProductName"] = purchaseProductListGridView.Rows[i].Cells[2].Text.ToString();
                    dr["Unit"] = purchaseProductListGridView.Rows[i].Cells[3].Text.ToString();
                    dr["FreeQuantity"] = purchaseProductListGridView.Rows[i].Cells[4].ToString();

                    TextBox quantityTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                    dr["Quantity"] = quantityTextBox.Text.Trim();

                    TextBox ratePerUnitTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtRate");
                    dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();

                    //TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    //dr["Amount"] = amountTextBox.Text.Trim();

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

                    //TextBox amountTextBox = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                    //amountTextBox.Text = dt.Rows[i]["Amount"].ToString();
                    //totQuantity += double.Parse(quantityTextBox.Text);
                    //if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    //{
                    //    totPayableAmmount += Convert.ToDouble(amountTextBox.Text);
                    //}

                    //if (!string.IsNullOrEmpty(dt.Rows[i]["Amount"].ToString()))
                    //{
                    //    amount += double.Parse(dt.Rows[i]["Amount"].ToString());
                    //}
                }
                //double otherAmt = 0;
                //double workingCost = 0;
                //string amt = txtOtherAmmount.Text.Trim();
                //string wrkingCost = txtWorkingCost.Text.Trim();
                //if (amt != "" && wrkingCost != "")
                //{
                //    otherAmt = Convert.ToDouble(amt);
                //    workingCost = Convert.ToDouble(wrkingCost);
                //}
                //txtTotAmmount.Text = Convert.ToString(totPayableAmmount);
                //totPayableAmmount = totPayableAmmount + workingCost + otherAmt;
                //lblTotoWeight.Text = Convert.ToString(totQuantity);
                //txtTotQuantity.Text = Convert.ToString(totQuantity);
                //txtPayableAmmount.Text = Convert.ToString(totPayableAmmount);
                //lblTotAmmount.Text = Convert.ToString(totPayableAmmount);

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
                    //txtTotAmmount.Text = "0";
                    //if (txtOtherAmmount.Text != string.Empty && txtWorkingCost.Text != string.Empty)
                    //{
                    //    txtPayableAmmount.Text = Convert.ToString(Convert.ToDouble(txtOtherAmmount.Text) + Convert.ToDouble(txtWorkingCost.Text));
                    //}
                    //else
                    //{
                    //    if (txtOtherAmmount.Text == string.Empty)
                    //    {
                    //        txtPayableAmmount.Text = txtWorkingCost.Text;
                    //    }
                    //    if (txtWorkingCost.Text == string.Empty)
                    //    {
                    //        txtPayableAmmount.Text = txtOtherAmmount.Text;
                    //    }
                    //    txtPayableAmmount.Text = "0";
                    //}
                    //lblTotAmmount.Text = txtPayableAmmount.Text;
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
        protected void TypeDrpDwn_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeDrpDwn.SelectedValue == "warehouse")
                {
                    loadWarehouse();
                    wareHouseOrsalesCenterLabel.Text = "Ware House";
                }
                else
                {
                    loadSalescenter();
                    wareHouseOrsalesCenterLabel.Text = "Sales Center";
                }
            }
            catch (Exception ex)
            {
                msgDetailLabel.Text = "Some Things Goes Wrong . Please Fill all required Field";
                msgTitleLabel.Text = "Warning!!.";
                msgbox.Attributes.Add("Class", "alert alert-warning");
                msgbox.Visible = true;
            }
        }

        private void loadSalescenter()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                wareHouseOrSalesCenterDrpDwn.DataSource = dt;
                wareHouseOrSalesCenterDrpDwn.DataValueField = "SalesCenterId";
                wareHouseOrSalesCenterDrpDwn.DataTextField = "SalesCenterName";
                wareHouseOrSalesCenterDrpDwn.DataBind();
                wareHouseOrSalesCenterDrpDwn.Items.Insert(0, "Select Please");
                wareHouseOrSalesCenterDrpDwn.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesCenter = null;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        private void loadWarehouse()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                wareHouseOrSalesCenterDrpDwn.DataSource = dt;
                wareHouseOrSalesCenterDrpDwn.DataValueField = "WarehouseId";
                wareHouseOrSalesCenterDrpDwn.DataTextField = "WarehouseName";
                wareHouseOrSalesCenterDrpDwn.DataBind();
                wareHouseOrSalesCenterDrpDwn.Items.Insert(0, "--select--");
                wareHouseOrSalesCenterDrpDwn.SelectedIndex = 0;
               // wareHouseOrSalesCenterDrpDwn.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

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

        protected void wareHouseOrSalesCenterDrpDwn_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeDrpDwn.SelectedIndex==1)
                {
                    loadAcTiveProductFromWareHouse(wareHouseOrSalesCenterDrpDwn.SelectedValue);
                }
                if (TypeDrpDwn.SelectedIndex==2)
                {
                    loadActiveProductFromSalesCenter(wareHouseOrSalesCenterDrpDwn.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        private void loadActiveProductFromSalesCenter(string salesCenterId)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = new DataTable();

                dt = product.GetAvailableProductListBySalesCenter(salesCenterId);

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

        private void loadAcTiveProductFromWareHouse(string wareHouseId)
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetAvailableProductListByWarehouse(wareHouseId);
                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    productListGridView.DataSource = "";
                    productListGridView.DataBind();
                }
                //if (purchaseProductListGridView.Rows.Count > 0)
                //{
                //    purchaseProductListGridView.UseAccessibleHeader = true;
                //    purchaseProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                //}
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

        protected void mainProductionDrpDwnList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainProductionDrpDwnList.SelectedIndex==0)
            {
                productDetailsDiv.Visible = false;
            }
            else
            {
                productDetailsDiv.Visible = true;
                DataTable dt = new DataTable();
                newproductionBLL newproductionBll = new newproductionBLL();
                try
                {
                    if (wareHouseOrSalesCenterDrpDwn.SelectedValue == "")
                    {
                        msgbox.Visible = true;
                        msgTitleLabel.Text = "Please Select Ware House or Sales Center";
                        msgDetailLabel.Text = "";
                        msgbox.Attributes.Add("Class","alert alert-warning");
                    }
                    else
                    {
                        dt = newproductionBll.getProductDetails(mainProductionDrpDwnList.SelectedValue,
                            wareHouseOrSalesCenterDrpDwn.SelectedValue);
                        if (dt.Rows.Count > 0)
                        {

                            productNamelbl.Text = mainProductionDrpDwnList.SelectedItem.Text.ToString();

                            UnitCostLabel.Text = dt.Rows[0]["lastUnitPrice"].ToString();
                            string inStock = dt.Rows[0]["FreeQuantity"].ToString();

                            if (string.IsNullOrEmpty(inStock))
                            {
                                instockLabel.Text = "0";
                            }
                            else
                            {
                                instockLabel.Text = inStock;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                    MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
                }
            }
           
        }

        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                double quantity = 0;
                double newPriceOfProduct = 0;
                if(workingCostTxtBx.Text=="")
                {
                    workingCostTxtBx.Text = "0";
                }
                if(otherCostTxtBx.Text=="")
                {
                    otherCostTxtBx.Text = "0";
                }
                newproductionBLL newproductionBll = new newproductionBLL();
                newproductionBll.typeOf = TypeDrpDwn.SelectedValue.ToString();
                newproductionBll.wareHouseID = wareHouseOrSalesCenterDrpDwn.SelectedValue.ToString();
                newproductionBll.mainProductionID = mainProductionDrpDwnList.SelectedValue.ToString();
                newproductionBll.workingCost = Convert.ToDouble(workingCostTxtBx.Text.Trim());
                newproductionBll.otherAmmount = Convert.ToDouble(otherCostTxtBx.Text.Trim());
                newproductionBll.usedWeightOfNewProduction = weightofMainProductinTxtBx.Text.Trim();
                newproductionBll.unitCost = Convert.ToDouble(UnitCostLabel.Text.Trim());
                newproductionBll.totalCost = (Convert.ToDouble(weightofMainProductinTxtBx.Text.Trim())*
                                             Convert.ToDouble(UnitCostLabel.Text.Trim())+ Convert.ToDouble(otherCostTxtBx.Text)+Convert.ToDouble(workingCostTxtBx.Text));
                //get production auto id
                 AutoIdGenerateBLL autoid = new AutoIdGenerateBLL();
                DataTable dt2 = autoid.CreateId("Pro");
                newproductionBll.productionId =  dt2.Rows[0][0].ToString();

                bool status = false;


                DataTable productTable = new DataTable();

                DataRow dr = null;

                productTable.Columns.Add("ProductId");
                productTable.Columns.Add("NewQuantity");
                productTable.Columns.Add("NewUnitPrice");

                if (purchaseProductListGridView.Rows.Count>0)
                {
                    for (int i = 0; i < purchaseProductListGridView.Rows.Count; i++)
                    {
                        dr = productTable.NewRow();

                        dr["ProductId"] = purchaseProductListGridView.Rows[i].Cells[1].Text.ToString();
                        TextBox quantityTxtBx = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtQuantity");
                        dr["NewQuantity"] = Convert.ToDecimal(quantityTxtBx.Text);
                        TextBox NewUnitPrice = (TextBox)purchaseProductListGridView.Rows[i].FindControl("txtPrice");
                        dr["NewUnitPrice"] = Convert.ToDecimal(NewUnitPrice.Text);

                        productTable.Rows.Add(dr);
                    }
                }
                if (TypeDrpDwn.SelectedIndex==0)
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Error !!!"; 
                    msgDetailLabel.Text = "PLease Select Ware House Or Sales Center";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    
                }
                else
                {
                   
                    status = newproductionBll.saveNewProcutToWarehouse(productTable);
                    if (status)
                    {
                        autoid.updateId("Pro");
                        autoid.deleteId(newproductionBll.productionId);
                        string message = "New Product's <span class='actionTopic'>information Saved</span> Successfully <span class='actionTopic'>" +
                            "</span>.";
                        MyAlertBox("var callbackOk = function () {window.location = \"/UI/production/newproduct.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\",callbackOk);");
                    }
                    else
                    {
                        msgbox.Visible = true;
                        msgTitleLabel.Text = "Error !!!";
                        msgDetailLabel.Text = "New Product's Information can not be saved";
                        msgbox.Attributes.Add("Class", "alert alert-warning");
                    }
                }
               
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
    }
}