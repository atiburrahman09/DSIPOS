using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseRecord
{
    public partial class CreatePurchase : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
                LoadBankList();
                LoadChartOfAccountsCashAndBankHeadList();
            }

            if (purchaseOrderProductListGridView.Rows.Count > 0)
            {
                purchaseOrderProductListGridView.UseAccessibleHeader = true;
                purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadChartOfAccountsCashAndBankHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashAndBankHeadList();

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountHead";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Cash & Bank Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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
                chartOfAccount = null;
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

        protected void LoadBankList()
        {
            BankBLL bank = new BankBLL();

            try
            {
                DataTable dt = bank.GetActiveBankList();

                bankDropDownList.DataSource = dt;
                bankDropDownList.DataValueField = "BankId";
                bankDropDownList.DataTextField = "BankName";
                bankDropDownList.DataBind();
                bankDropDownList.Items.Insert(0, "");
                bankDropDownList.Items.Insert(1, "N/A");
                bankDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                bank = null;
            }
        }

        protected void purchaseOrderDetailsButton_Click(object sender, EventArgs e)
        {
            PurchaseOrderBLL purchaseOrder = new PurchaseOrderBLL();

            try
            {
                if (warehouseDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else if (purchaseOrderIdTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Purchase Order ID field is required.";
                }
                else
                {
                    DataTable dt;

                    dt = purchaseOrder.GetPendingPurchaseOrderByIdAndWarehouse(purchaseOrderIdTextBox.Text.Trim(), warehouseDropDownList.SelectedValue.Trim());

                    if (dt.Rows.Count > 0)
                    {
                        prIDLabel.Text = dt.Rows[0]["PurchaseRequisitionId"].ToString();
                        prDateLabel.Text = ", " + dt.Rows[0]["PurchaseRequisitionDate"].ToString();
                        poIDLabel.Text = dt.Rows[0]["PurchaseOrderId"].ToString();
                        poDateLabel.Text = ", " + dt.Rows[0]["OrderDate"].ToString();
                        warehouseIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                        warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                        vendorIdLabel.Text = dt.Rows[0]["VendorId"].ToString();
                        vendorNameLabel.Text = dt.Rows[0]["VendorName"].ToString();
                        requisitionNarrationLabel.Text = dt.Rows[0]["Narration"].ToString();

                        dt = purchaseOrder.GetPurchaseOrderProductListById(poIDLabel.Text.Trim(), prIDLabel.Text.Trim());
                        purchaseOrderProductListGridView.DataSource = dt;
                        purchaseOrderProductListGridView.DataBind();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TextBox purchaseQuantityTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("purchaseQuantityTextBox");
                            purchaseQuantityTextBox.Text = dt.Rows[i]["Quantity"].ToString();
                        }

                        orderInfoContainer.Visible = true;
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        orderInfoContainer.Visible = false;
                        saveButton.Enabled = false;
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }

                    if (purchaseOrderProductListGridView.Rows.Count > 0)
                    {
                        purchaseOrderProductListGridView.UseAccessibleHeader = true;
                        purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                purchaseOrder = null;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PurchaseRecordBLL purchaseRecord = new PurchaseRecordBLL();

            string msg = string.Empty;
            TextBox purchaseQuantityTextBox;
            TextBox ratePerUnitTextBox;
            TextBox amountTextBox;
            TextBox productNarrationTextBox;
            TextBox unitPriceTextBox;
            float fnum;
            int num;
            float uprice;
            int pNDCount = 0;

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("ProductId");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("RatePerUnit");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Status");
            dt.Columns.Add("Narration");

            try
            {
                if (vendorOrderDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(vendorOrderDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Vendor Order Date field is required.";
                    return;
                }
                else if (vendorOrderNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Vendor Order Number field is required.";
                    return;
                }
                else if (vendorInvoiceNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Vendor Invoice Number field is required.";
                    return;
                }
                else if (receivedDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(receivedDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Received Date field is required.";
                    return;
                }
                else if (transportTypeDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Transport Type field is required.";
                    return;
                }

                if (paymentModeDropDownList.SelectedValue == "Cheque")
                {
                    if (chequeNumberTextBox.Text.Trim() == "")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Cheque Number field is required.";
                        return;
                    }
                    else if (chequeDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim()) == "False")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Cheque Date field is required.";
                        return;
                    }
                    else if (bankDropDownList.SelectedValue == "")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Bank Name field is required.";
                        return;
                    }
                    else if (bankBranchTextBox.Text.Trim() == "")
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Bank Branch Name field is required.";
                        return;
                    }
                }

                UnitPriceCalculation();

                for (int i = 0; i < purchaseOrderProductListGridView.Rows.Count; i++)
                {
                    purchaseQuantityTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("purchaseQuantityTextBox");
                    ratePerUnitTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("ratePerUnitTextBox");
                    amountTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("amountTextBox");
                    unitPriceTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("unitPriceTextBox");
                    productNarrationTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("productNarrationTextBox");

                    if (!int.TryParse(purchaseQuantityTextBox.Text.Trim(), out num))
                    {
                        msg = "Product ID [" + purchaseOrderProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid Purchase Qty.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!float.TryParse(ratePerUnitTextBox.Text.Trim(), out fnum))
                    {
                        msg = "Product ID [" + purchaseOrderProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid Rate Per Unit.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!float.TryParse(amountTextBox.Text.Trim(), out fnum))
                    {
                        msg = "Product ID [" + purchaseOrderProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid Amount.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else if (!float.TryParse(unitPriceTextBox.Text.Trim(), out uprice))
                    {
                        msg = "Product ID [" + purchaseOrderProductListGridView.Rows[i].Cells[1].Text.ToString() + "] has no valid Unit Price.";
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = msg;
                        return;
                    }
                    else
                    {
                        dr = dt.NewRow();

                        dr["ProductId"] = purchaseOrderProductListGridView.Rows[i].Cells[1].Text.ToString();
                        dr["Quantity"] = purchaseQuantityTextBox.Text.Trim();
                        dr["Amount"] = amountTextBox.Text.Trim();
                        dr["RatePerUnit"] = ratePerUnitTextBox.Text.Trim();
                        dr["UnitPrice"] = unitPriceTextBox.Text.Trim();
                        dr["Narration"] = productNarrationTextBox.Text.Trim();

                        string[] oQty = purchaseOrderProductListGridView.Rows[i].Cells[4].Text.ToString().Split(' ');

                        if (int.Parse(purchaseQuantityTextBox.Text.Trim()) == 0)
                        {
                            dr["Status"] = "ND"; pNDCount++;
                        }
                        else if (oQty[0].ToString().Trim() == purchaseQuantityTextBox.Text.Trim())
                        {
                            dr["Status"] = "D";
                        }
                        else
                        {
                            dr["Status"] = "PD";
                        }

                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == purchaseOrderProductListGridView.Rows.Count)
                {
                    purchaseRecord.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                    purchaseRecord.WarehouseId = warehouseIdLabel.Text.Trim();
                    purchaseRecord.PurchaseRequisitionId = prIDLabel.Text.Trim();
                    purchaseRecord.PurchaseOrderId = poIDLabel.Text.Trim();
                    purchaseRecord.VendorId = vendorIdLabel.Text.Trim();
                    purchaseRecord.VendorOrderDate = LumexLibraryManager.ParseAppDate(vendorOrderDateTextBox.Text.Trim());
                    purchaseRecord.VendorOrderNumber = vendorOrderNumberTextBox.Text.Trim();
                    purchaseRecord.VendorInvoiceNumber = vendorInvoiceNumberTextBox.Text.Trim();
                    purchaseRecord.ReceivedDate = LumexLibraryManager.ParseAppDate(receivedDateTextBox.Text.Trim());
                    purchaseRecord.TotalAmount = totalAmountTextBox.Text.Trim();
                    //purchaseRecord.VAT = vatTextBox.Text.Trim();
                    purchaseRecord.DiscountAmount = discountTextBox.Text.Trim();
                    purchaseRecord.TotalPayable = totalPayableTextBox.Text.Trim();
                    purchaseRecord.PaidAmount = paidAmountTextBox.Text.Trim();
                    purchaseRecord.TransportCost = transportCostTextBox.Text.Trim();
                    purchaseRecord.Narration = narrationTextBox.Text.Trim();
                    purchaseRecord.LCNumber = lcNumberTextBox.Text.Trim();
                    purchaseRecord.TransportType = transportTypeDropDownList.SelectedValue.Trim();
                    purchaseRecord.ShippingAddress = shippingAddressTextBox.Text.Trim();
                    purchaseRecord.BillingAddress = billingAddressTextBox.Text.Trim();
                    purchaseRecord.PaymentMode = paymentModeDropDownList.SelectedValue.Trim();
                    purchaseRecord.Bank = bankDropDownList.SelectedValue;
                    purchaseRecord.BankBranch = bankBranchTextBox.Text.Trim();
                    purchaseRecord.ChequeNumber = chequeNumberTextBox.Text.Trim();
                    purchaseRecord.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim());

                    if (pNDCount > 0)
                    {
                        purchaseRecord.Status = "PD";
                    }
                    else
                    {
                        purchaseRecord.Status = "D";
                    }

                    string id = purchaseRecord.SavePurchaseRecord(dt);

                    if (!string.IsNullOrEmpty(id))
                    {
                        MyAlertBox("alert(\"Purchase Record Created Successfully with Purchase Record ID: " + id + " \"); window.location=\"/UI/PurchaseRecord/PurchaseList.aspx\"");
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Failed to Create Purchase Record!!!"; msgDetailLabel.Text = "";
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
                purchaseRecord = null;
            }
        }

        protected void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            UnitPriceCalculation();
        }

        protected void transportCostTextBox_TextChanged(object sender, EventArgs e)
        {
            UnitPriceCalculation();
        }

        protected void UnitPriceCalculation()
        {
            try
            {
                if (discountTextBox.Text.Trim() == "")
                {
                    discountTextBox.Text = "0";
                }

                if (transportCostTextBox.Text.Trim() == "")
                {
                    transportCostTextBox.Text = "0";
                }

                decimal ratePerTaka = (decimal.Parse(transportCostTextBox.Text.Trim()) - decimal.Parse(discountTextBox.Text.Trim())) / decimal.Parse(totalAmountTextBox.Text.Trim());

                for (int i = 0; i < purchaseOrderProductListGridView.Rows.Count; i++)
                {
                    TextBox purchaseQuantityTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("purchaseQuantityTextBox");
                    TextBox amountTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("amountTextBox");
                    TextBox unitPriceTextBox = (TextBox)purchaseOrderProductListGridView.Rows[i].FindControl("unitPriceTextBox");

                    unitPriceTextBox.Text = (((ratePerTaka * decimal.Parse(amountTextBox.Text)) + decimal.Parse(amountTextBox.Text)) / decimal.Parse(purchaseQuantityTextBox.Text)).ToString();
                }
            }
            catch
            {


            }
        }
    }
}

