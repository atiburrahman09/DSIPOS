using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.JournalVoucher
{
    public partial class JournalVoucherApprovalList : System.Web.UI.Page
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
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

            try
            {
                string fromDate = LumexLibraryManager.ParseAppDate("");
                string toDate = LumexLibraryManager.ParseAppDate("");

                DataTable dt = journalVoucher.GetJournalVoucherApprovalListByDateRangeAndAll(drpdwnSalesCenterOrWarehouse.SelectedValue, fromDate, toDate, "All");

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
                    msgbox.Visible = true; msgTitleLabel.Text = "Journal Voucher Approval List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                journalVoucher = null;
            }
        }

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("JournalNumberForApprove", voucherListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AccUI/JournalVoucher/ApproveJournalVoucher.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void approveButton_Click(object sender, EventArgs e)
        {
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();
            CheckBox selectCheckBox;
            int count = 0;

            try
            {
                for (int i = 0; i < voucherListGridView.Rows.Count; i++)
                {
                    selectCheckBox = (CheckBox)voucherListGridView.Rows[i].Cells[5].FindControl("selectCheckBox");

                    if (selectCheckBox.Checked)
                    {
                        journalVoucher.ApproveJournalVoucherByJournal(voucherListGridView.Rows[i].Cells[0].Text.Trim());
                        count++;
                    }
                }

                if (count > 0)
                {
                    GetApprovalList();
                    string message = count.ToString() + " Journal Voucher(s) <span class='actionTopic'>Approved</span> Successfully.";
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
                journalVoucher = null;
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
                    string message = count.ToString() + " Journal Voucher(s) <span class='actionTopic'>Rejected</span> Successfully.";
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
    }
}