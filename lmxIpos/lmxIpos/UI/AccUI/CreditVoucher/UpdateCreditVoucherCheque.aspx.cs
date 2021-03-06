﻿using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.CreditVoucher
{
    public partial class UpdateCreditVoucherCheque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadChartOfAccountsHeadList();
                    LoadChartOfAccountsBankHeadList();
                    RemoveBankHeadFromAccountsHead();
                    //LoadPayToFromCompanyList();
                    LoadBankList();
                    accountHeadDropDownList.Focus();

                    numberLabel.Text = journalNumberForUpdateHiddenField.Value = LumexSessionManager.Get("CVChequeJournalForUpdate").ToString().Trim();
                    GetCreditVoucherChequeByJournal(journalNumberForUpdateHiddenField.Value.Trim());
                }
            }
            catch (Exception ex)
            {
                updateButton.Enabled = false;

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadChartOfAccountsHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsHeadList();

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountHead";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void LoadChartOfAccountsBankHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsBankHeadList();

                bankAccountHeadDropDownList.DataSource = dt;
                bankAccountHeadDropDownList.DataValueField = "AccountId";
                bankAccountHeadDropDownList.DataTextField = "AccountHead";
                bankAccountHeadDropDownList.DataBind();
                bankAccountHeadDropDownList.Items.Insert(0, "");
                bankAccountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void RemoveBankHeadFromAccountsHead()
        {
            try
            {
                int count = accountHeadDropDownList.Items.Count;

                for (int i = 0; i < bankAccountHeadDropDownList.Items.Count; i++)
                {
                    for (int j = 0; j < accountHeadDropDownList.Items.Count; j++)
                    {
                        if (bankAccountHeadDropDownList.Items[i].Value == accountHeadDropDownList.Items[j].Value)
                        {
                            accountHeadDropDownList.Items.RemoveAt(j);
                            break;
                        }
                    }
                }

                if (count != accountHeadDropDownList.Items.Count)
                {
                    accountHeadDropDownList.Items.Insert(0, "");
                    accountHeadDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void payToFromTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string payCompany = Session["PayToFromCompany"].ToString();
            LoadPayToFromCompanyList();
        }
        protected void drpdwnAccountOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SalesOrWarehouseName = Session["SalesOrWareHouseName"].ToString();
            try
            {
                if (drpdwnAccountOn.SelectedIndex == 0 || SalesOrWarehouseName.Substring(0, 2) == "SC")
                {
                    drpdwnSalesCenterOrWarehouse.Items.Clear();
                    LoadSalesCenters();
                    titleSalesCenterOrWarehouse.Text = "Sales Center";
                    drpdwnAccountOn.SelectedIndex = 0;
                    drpdwnSalesCenterOrWarehouse.SelectedValue = SalesOrWarehouseName;
                    drpdwnSalesCenterOrWarehouse.Enabled = false;
                    drpdwnAccountOn.Enabled = false;
                }
                else if (drpdwnAccountOn.SelectedIndex == 1 || SalesOrWarehouseName.Substring(0, 2) == "SC")
                {
                    drpdwnSalesCenterOrWarehouse.Items.Clear();
                    LoadWarehouse();
                    titleSalesCenterOrWarehouse.Text = "Warehouse";
                    drpdwnAccountOn.SelectedIndex = 1;
                    drpdwnSalesCenterOrWarehouse.SelectedValue = SalesOrWarehouseName;
                    drpdwnSalesCenterOrWarehouse.Enabled = false;
                    drpdwnAccountOn.Enabled = false;
                }
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

                drpdwnSalesCenterOrWarehouse.DataSource = dt;
                drpdwnSalesCenterOrWarehouse.DataTextField = "WarehouseName";
                drpdwnSalesCenterOrWarehouse.DataValueField = "WarehouseId";
                drpdwnSalesCenterOrWarehouse.DataBind();
                //drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
                //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;
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

                drpdwnSalesCenterOrWarehouse.DataSource = dt;
                drpdwnSalesCenterOrWarehouse.DataValueField = "SalesCenterId";
                drpdwnSalesCenterOrWarehouse.DataTextField = "SalesCenterName";
                drpdwnSalesCenterOrWarehouse.DataBind();
                //drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
                //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;

                drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

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
        protected void LoadPayToFromCompanyList()
        {
            PayToFromCompanyBLL payToFromCompany = new PayToFromCompanyBLL();
            string payCompany = Session["PayToFromCompany"].ToString();


            try
            {
                payToFromCompanyDropDownList.Items.Clear();
                DataTable dt = new DataTable();
                if (payToFromTypeDropDownList.SelectedValue == "com" || payCompany.Substring(0, 3) == "PTF")
                {
                    dt = payToFromCompany.GetActivePayToFromCompanyList();
                    payToFromCompanyDropDownList.DataSource = dt;
                    payToFromCompanyDropDownList.DataValueField = "CompanyId";
                    payToFromCompanyDropDownList.DataTextField = "CompanyName";
                    payToFromCompanyDropDownList.DataBind();
                    lblPaytoFromType.Text = "Company";
                    if (payCompany == "NULL")
                    {

                        payToFromCompanyDropDownList.Items.Insert(0, "");
                        payToFromCompanyDropDownList.Items.Insert(1, "N/A");
                        payToFromCompanyDropDownList.SelectedIndex = 0;

                    }
                    else
                    {
                        payToFromCompanyDropDownList.SelectedValue = payCompany;
                        Session["PayToFromCompany"] = "NULL";
                    }

                    payToFromTypeDropDownList.SelectedIndex = 1;

                }
                else if (payToFromTypeDropDownList.SelectedValue == "ven" || payCompany.Substring(0, 3) == "Vnd")
                {
                    VendorBLL vendor = new VendorBLL();
                    dt = vendor.GetActiveVendors();
                    payToFromCompanyDropDownList.DataSource = dt;
                    payToFromCompanyDropDownList.DataValueField = "VendorId";
                    payToFromCompanyDropDownList.DataTextField = "VendorName";
                    payToFromCompanyDropDownList.DataBind();
                    lblPaytoFromType.Text = "Vendor";
                    if (payCompany == "NULL")
                    {
                        payToFromCompanyDropDownList.Items.Insert(0, "");
                        payToFromCompanyDropDownList.Items.Insert(1, "N/A");
                        payToFromCompanyDropDownList.SelectedIndex = 0;

                    }
                    else
                    {
                        payToFromCompanyDropDownList.SelectedValue = payCompany;
                        Session["PayToFromCompany"] = "NULL";
                    }
                    payToFromTypeDropDownList.SelectedIndex = 2;

                }
                else if (payToFromTypeDropDownList.SelectedValue == "cus" || payCompany.Substring(0, 3) == "Cst")
                {
                    CustomerBLL customer = new CustomerBLL();
                    dt = customer.GetActiveCustomerList();
                    payToFromCompanyDropDownList.DataSource = dt;
                    payToFromCompanyDropDownList.DataValueField = "CustomerId";
                    payToFromCompanyDropDownList.DataTextField = "CustomerIdName";
                    payToFromCompanyDropDownList.DataBind();
                    lblPaytoFromType.Text = "Customer";
                    if (payCompany == "NULL")
                    {

                        payToFromCompanyDropDownList.Items.Insert(0, "");
                        payToFromCompanyDropDownList.Items.Insert(1, "N/A");
                        payToFromCompanyDropDownList.SelectedIndex = 0;
                        
                    }
                    else
                    {
                        payToFromCompanyDropDownList.SelectedValue = payCompany;
                        Session["PayToFromCompany"] = "NULL";
                    }
                    payToFromTypeDropDownList.SelectedIndex = 3;


                }



                //payToFromCompanyDropDownList.Items.Insert(0, "");
                //payToFromCompanyDropDownList.Items.Insert(1, "N/A");
                //payToFromCompanyDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Pay To/From Company Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }

                //GetCreditVoucherCashByJournal(journalNumberForUpdateHiddenField.Value.Trim());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                payToFromCompany = null;
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

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bank = null;
            }
        }

        protected void GetCreditVoucherChequeByJournal(string journalNumber)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                DataTable dt = debitCreditVoucher.GetCreditVoucherApprovalByJournal("Cheque", journalNumber);

                if (dt.Rows.Count > 0)
                {
                    voucherNumberTextBox.Text = dt.Rows[0]["ManualVoucherNumber"].ToString();
                    accountHeadDropDownList.SelectedValue = dt.Rows[0]["AccountId"].ToString();
                    bankAccountHeadDropDownList.SelectedValue = dt.Rows[0]["CounterAccountId"].ToString();
                    amountTextBox.Text = dt.Rows[0]["Amount"].ToString();
                    bankDropDownList.SelectedValue = dt.Rows[0]["Bank"].ToString();
                    bankBranchTextBox.Text = dt.Rows[0]["BankBranch"].ToString();
                    chequeNumberTextBox.Text = dt.Rows[0]["ChequeNumber"].ToString();
                    chequeDateTextBox.Text = LumexLibraryManager.GetAppDateView(dt.Rows[0]["ChequeDate"].ToString());
                    //payToFromCompanyDropDownList.SelectedValue = dt.Rows[0]["PayToFromCompany"].ToString();
                    Session["PayToFromCompany"] = payToFromCompanyDropDownList.SelectedValue = dt.Rows[0]["PayToFromCompany"].ToString();
                    payToFromTypeDropDownList_SelectedIndexChanged(this, EventArgs.Empty);
                    Session["SalesOrWareHouseName"] = dt.Rows[0]["OfficeBranchId"].ToString();
                    drpdwnAccountOn_SelectedIndexChanged(this, EventArgs.Empty);
                    narrationTextBox.Text = dt.Rows[0]["Narration"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Credit Voucher Cheque Data Not Found!!!"; msgDetailLabel.Text = "";
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
                debitCreditVoucher = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                if (accountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Account Head field is required.";
                }
                else if (amountTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Please Give Correct Input in Amount Field.";
                }
                else if (bankAccountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Account Head field is required.";
                }
                else if (voucherNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Voucher Number field is required.";
                }
                else if (chequeNumberTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Cheque Number field is required.";
                }
                else if (chequeDateTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Cheque Date field is required.";
                }
                else if (bankDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Name field is required.";
                }
                else if (bankBranchTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Branch Name field is required.";
                }
                else if (payToFromCompanyDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Pay To/From Company field is required.";
                }
                else if (narrationTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Narration field is required.";
                }
                
                else
                {
                    debitCreditVoucher.JournalNumber = journalNumberForUpdateHiddenField.Value;
                    debitCreditVoucher.ManualVoucherNumber = voucherNumberTextBox.Text.Trim();
                    debitCreditVoucher.AccountId = accountHeadDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.CounterAccountId = bankAccountHeadDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.Amount = amountTextBox.Text.Trim();
                    debitCreditVoucher.Bank = bankDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.BankBranch = bankBranchTextBox.Text.Trim();
                    debitCreditVoucher.ChequeNumber = chequeNumberTextBox.Text.Trim();
                    debitCreditVoucher.ChequeDate = LumexLibraryManager.ParseAppDate(chequeDateTextBox.Text.Trim());
                    debitCreditVoucher.PayToFromCompany = payToFromCompanyDropDownList.SelectedValue.Trim();
                    debitCreditVoucher.Narration = narrationTextBox.Text.Trim();
                    debitCreditVoucher.OfficeBranchId = Session["SalesOrWareHouseName"].ToString();

                    debitCreditVoucher.UpdateCreditVoucherCheque();

                    string message = "Credit Voucher Cheque <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/CreditVoucher/CreditVoucherChequeList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                debitCreditVoucher = null;
            }
        }
    }
}