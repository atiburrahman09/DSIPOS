﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ReceiveFromCustomer
{
    public partial class PaymentByCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadActiveCustomerList();
                    LoadSalesCenters();
                    
                    LoadChartOfAccountsCashAndBankHeadList();

                    if (Session["forClientReceive"] != null)
                    {
                        string ClientId = (string)LumexSessionManager.Get("forClientReceive").ToString();

                        customerIdDropDownList.SelectedValue = ClientId;
                        GetCustomerReceivableList();
                        //if (ClientId != "" && ClientName != "")
                        //{
                        //    txtbxClientName.Text = ClientId + "[" + ClientName + "]";
                        //    GetClientInformation(ClientId);
                        //    btnSearch_Click(this, e);

                        //    LumexSessionManager.Remove("ClientId");
                        //    LumexSessionManager.Remove("ClientName");
                        //}

                    }
                    customerIdDropDownList.Focus();
                }

                if (receivableListGridView.Rows.Count > 0)
                {
                    receivableListGridView.UseAccessibleHeader = true;
                    receivableListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        private void LoadChartOfAccountsCashAndBankHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();
            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashHeadList();

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountHead";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void purchaseReturnFormDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpdwnAccountOn.SelectedValue == "WH")
                {
                    LoadWarehouse();
                    wareHouseorSCLabel.Text = "Warehouse";
                }
                else
                {
                    LoadSalesCenters();
                    wareHouseorSCLabel.Text = "Sales Center";
                }
                GetCustomerReceivableList();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        private void LoadWarehouse()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataTextField = "WarehouseName";
                salesCenterDropDownList.DataValueField = "WarehouseId";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "");
                salesCenterDropDownList.SelectedIndex = 0;

                salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserWarehouseId").ToString();
                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Warehouse  Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void LoadSalesCenters()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataValueField = "SalesCenterId";
                salesCenterDropDownList.DataTextField = "SalesCenterName";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "");
                salesCenterDropDownList.SelectedIndex = 0;
                salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();
                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
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
                salesCenter = null;
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
                customerIdDropDownList.Items.Insert(0, "");
                customerIdDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                customer = null;
            }
        }

        protected void GetCustomerReceivableList()
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();

            try
            {
                if (customerIdDropDownList.SelectedValue.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Customer ID field is required.";
                }
                else
                {
                    DataTable dt = receivePayment.GetCustomerReceivableList(customerIdDropDownList.SelectedValue, salesCenterDropDownList.SelectedValue);

                    receivableListGridView.DataSource = dt;
                    receivableListGridView.DataBind();

                    if (receivableListGridView.Rows.Count > 0)
                    {
                        receivableListGridView.UseAccessibleHeader = true;
                        receivableListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        decimal currentPayable = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            currentPayable += decimal.Parse(dt.Rows[i]["Due"].ToString());
                        }

                        currentReceivableLabel.Text = currentPayable.ToString();

                        amountTextBox.Focus();
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Customer Receivable List Data Not Found!!!"; msgDetailLabel.Text = "";
                        msgbox.Attributes.Add("class", "alert alert-info");
                        currentReceivableLabel.Text = "0.00";
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
                receivePayment = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void receivableListButton_Click(object sender, EventArgs e)
        {
            GetCustomerReceivableList();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();
            DataRow dr = null;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RecordDate"));
            dt.Columns.Add(new DataColumn("RecordId"));
            dt.Columns.Add(new DataColumn("SalesCenterName"));
            dt.Columns.Add(new DataColumn("TotalAmount"));
            dt.Columns.Add(new DataColumn("DiscountAmount"));
            dt.Columns.Add(new DataColumn("TotalVATAmount"));
            dt.Columns.Add(new DataColumn("TotalReceivable"));
            dt.Columns.Add(new DataColumn("ReceivedAmount"));
            dt.Columns.Add(new DataColumn("Due"));



            try
            {
                if (amountTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Amount field is required.";
                }
                else if (paymentModeDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Select Payment field is required.";
                }
                else if (accountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Select Account Head field is required.";
                }
                else if (paymentModeDropDownList.SelectedValue == "Cheque")
                {
                    if (chequeNumberTextBox.Text == "")
                    {
                        msgbox.Visible = true;
                        msgTitleLabel.Text = "Validation!!!";
                        msgDetailLabel.Text = "Cheque Number field is required.";

                    }
                    else if (chequeDateTextBox.Text == "")
                    {
                        if (chequeNumberTextBox.Text == "")
                        {
                            msgbox.Visible = true;
                            msgTitleLabel.Text = "Validation!!!";
                            msgDetailLabel.Text = "Cheque Date field is required.";
                        }
                    }
                }
                else
                {


                    if (decimal.Parse(currentReceivableLabel.Text) > 0)
                    {
                        if (decimal.Parse(currentReceivableLabel.Text) >= decimal.Parse(amountTextBox.Text.Trim()))
                        {
                            receivePayment.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                            receivePayment.CustomerId = customerIdDropDownList.SelectedValue.Trim();
                            receivePayment.CashCheque = paymentModeDropDownList.SelectedValue.Trim();
                            receivePayment.CurrentReceivable = currentReceivableLabel.Text;
                            receivePayment.Amount = amountTextBox.Text.Trim();
                            receivePayment.Bank = bankDropDownList.Text;
                            receivePayment.BankBrach = bankBranchTextBox.Text;
                            receivePayment.ChequeNo = chequeNumberTextBox.Text;
                            receivePayment.ChequeDate = chequeDateTextBox.Text;

                            for (int i = 0; i < receivableListGridView.Rows.Count; i++)
                            {
                                CheckBox chkbx = (CheckBox)receivableListGridView.Rows[i].FindControl("selectCheckBox");

                                if (chkbx.Checked)
                                {
                                    dr = dt.NewRow();

                                    // dr["Barcode"] = productListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["RecordDate"] = receivableListGridView.Rows[i].Cells[0].Text.ToString();
                                    dr["RecordId"] = receivableListGridView.Rows[i].Cells[1].Text.ToString();
                                    dr["SalesCenterName"] = receivableListGridView.Rows[i].Cells[2].Text.ToString();
                                    dr["TotalAmount"] = receivableListGridView.Rows[i].Cells[3].Text.ToString();
                                    dr["DiscountAmount"] = receivableListGridView.Rows[i].Cells[4].Text.ToString();
                                    dr["TotalVATAmount"] = receivableListGridView.Rows[i].Cells[5].Text.ToString();
                                    dr["TotalReceivable"] = receivableListGridView.Rows[i].Cells[7].Text.ToString();
                                    dr["ReceivedAmount"] = receivableListGridView.Rows[i].Cells[8].Text.ToString();
                                    dr["Due"] = receivableListGridView.Rows[i].Cells[9].Text.ToString();


                                    dt.Rows.Add(dr);
                                }
                            }

                            receivePayment.SaveCustomerPayment(salesCenterDropDownList.SelectedValue, dt);

                            initializeFileds();

                            string message = "Customer Payment <span class='actionTopic'>Saved</span> Successfully.";
                            MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");

                            GetCustomerReceivableList();

                        }
                        else
                        {
                            msgbox.Visible = true;
                            msgTitleLabel.Text = "Exception!!!";
                            msgDetailLabel.Text = "Amount must be equal or less of Current Receivable Amount.";
                        }
                    }

                    else
                    {
                        msgbox.Visible = true;
                        msgTitleLabel.Text = "Exception!!!";
                        msgDetailLabel.Text = "No Receivable to Payment.";
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

        protected void initializeFileds()
        {
            amountTextBox.Text = "0.00";
            paymentModeDropDownList.SelectedIndex = 0;
            accountHeadDropDownList.SelectedIndex = 0;
            chequeNumberTextBox.Text = "";
            chequeDateTextBox.Text = "";
            bankDropDownList.Text = "";
            bankBranchTextBox.Text = "";
        }

        protected void paymentModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
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
                    accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;

                }
                else if (paymentModeDropDownList.SelectedItem.Text == "Cheque")
                {
                    DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsBankHeadList();
                    accountHeadDropDownList.DataSource = dt;
                    accountHeadDropDownList.DataValueField = "AccountId";
                    accountHeadDropDownList.DataTextField = "AccountHead";
                    accountHeadDropDownList.DataBind();
                    accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void customerIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustomerReceivableList();
        }
    }
}