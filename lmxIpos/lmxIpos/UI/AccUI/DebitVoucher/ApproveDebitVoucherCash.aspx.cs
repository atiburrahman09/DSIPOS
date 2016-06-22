using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;
using Newtonsoft.Json;

namespace lmxIpos.UI.AccUI.DebitVoucher
{
    public partial class ApproveDebitVoucherCash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    if (drpdwnAccountOn.SelectedIndex == 0)
                    {
                        LoadSalesCenters();
                    }
                    //GetApprovalList();
                }

                if (voucherListGridView.Rows.Count > 0)
                {
                    voucherListGridView.UseAccessibleHeader = true;
                    voucherListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    approveButton.Enabled = true;
                    rejectButton.Enabled = true;
                }
                else
                {
                    approveButton.Enabled = false;
                    rejectButton.Enabled = false;
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

        protected void drpdwnAccountOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                voucherListGridView.DataSource = null;
                voucherListGridView.DataBind();

                if (drpdwnAccountOn.SelectedIndex == 0)
                {
                    drpdwnSalesCenterOrWarehouse.Items.Clear();
                    LoadSalesCenters();
                    titleSalesCenterOrWarehouse.Text = "Sales Center";
                }
                else if (drpdwnAccountOn.SelectedIndex == 1)
                {
                    drpdwnSalesCenterOrWarehouse.Items.Clear();
                    LoadWarehouse();
                    titleSalesCenterOrWarehouse.Text = "Warehouse";
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

                drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void GetListButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetApprovalList();
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {

                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void GetApprovalList()
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                string fromDate = LumexLibraryManager.ParseAppDate("");
                string toDate = LumexLibraryManager.ParseAppDate("");

                DataTable dt = debitCreditVoucher.GetDebitVoucherApprovalListByDateRangeAndAll(drpdwnSalesCenterOrWarehouse.SelectedValue, fromDate, toDate, "Cash", "All");

                voucherListGridView.DataSource = dt;
                voucherListGridView.DataBind();

                if (voucherListGridView.Rows.Count > 0)
                {
                    voucherListGridView.UseAccessibleHeader = true;
                    voucherListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                    approveButton.Enabled = true;
                    rejectButton.Enabled = true;
                }
                else
                {
                    approveButton.Enabled = false;
                    rejectButton.Enabled = false;

                    msgbox.Visible = true; msgTitleLabel.Text = "Debit Voucher Cash Approval List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        [WebMethod]
        public static string GetDebitVoucherViewByJournal(string journalNumber)
        {
            try
            {
                DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

                string json = JsonConvert.SerializeObject(debitCreditVoucher.GetDebitVoucherApprovalByJournal("Cash", journalNumber));
                json = json.Substring(1, json.Length - 2);

                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void approveButton_Click(object sender, EventArgs e)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();
            CheckBox selectCheckBox;
            int count = 0;

            try
            {
                for (int i = 0; i < voucherListGridView.Rows.Count; i++)
                {
                    selectCheckBox = (CheckBox)voucherListGridView.Rows[i].Cells[5].FindControl("selectCheckBox");

                    if (selectCheckBox.Checked)
                    {
                        debitCreditVoucher.ApproveDebitVoucherByJournal(voucherListGridView.Rows[i].Cells[0].Text.Trim(), "Cash");
                        count++;
                    }
                }

                if (count > 0)
                {
                    GetApprovalList();
                    string message = count.ToString() + " Debit Voucher Cash(s) <span class='actionTopic'>Approved</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "No Voucher(s) are selected to Approve.";
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void rejectButton_Click(object sender, EventArgs e)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();
            CheckBox selectCheckBox;
            int count = 0;

            try
            {
                for (int i = 0; i < voucherListGridView.Rows.Count; i++)
                {
                    selectCheckBox = (CheckBox)voucherListGridView.Rows[i].Cells[5].FindControl("selectCheckBox");

                    if (selectCheckBox.Checked)
                    {
                        debitCreditVoucher.RejectDebitCreditJournalVoucherByJournal(voucherListGridView.Rows[i].Cells[0].Text.Trim());
                        count++;
                    }
                }

                if (count > 0)
                {
                    GetApprovalList();
                    string message = count.ToString() + " Debit Voucher Cash(s) <span class='actionTopic'>Rejected</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "No Voucher(s) are selected to Reject.";
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void approveLinkButton_Click(object sender, EventArgs e)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                debitCreditVoucher.ApproveDebitVoucherByJournal(journalNumberForApproveHiddenField.Value.Trim(), "Cash");

                GetApprovalList();
                string message = "Debit Voucher Cash <span class='actionTopic'>Approved</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void rejectLinkButton_Click(object sender, EventArgs e)
        {
            DebitCreditVoucherBLL debitCreditVoucher = new DebitCreditVoucherBLL();

            try
            {
                debitCreditVoucher.RejectDebitCreditJournalVoucherByJournal(journalNumberForApproveHiddenField.Value.Trim());

                GetApprovalList();
                string message = "Debit Voucher Cash <span class='actionTopic'>Rejected</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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
                MyAlertBox("MyOverlayStop();");
            }
        }
    }
}