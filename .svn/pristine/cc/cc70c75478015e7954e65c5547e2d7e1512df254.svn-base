using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.JournalVoucher
{
    public partial class JournalVoucherListView : System.Web.UI.Page
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
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    fromDateTextBox.Focus();
                }

                if (voucherListGridView.Rows.Count > 0)
                {
                    voucherListGridView.UseAccessibleHeader = true;
                    voucherListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void voucherListButton_Click(object sender, EventArgs e)
        {
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

            try
            {
                if (fromDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date From field is required.";
                }
                else if (toDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date To field is required.";
                }
                else
                {
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());

                    DataTable dt = journalVoucher.GetJournalVoucherApprovedListByDateRangeAndAll(drpdwnSalesCenterOrWarehouse.SelectedValue, fromDate, toDate, "");

                    voucherListGridView.DataSource = dt;
                    voucherListGridView.DataBind();

                    if (voucherListGridView.Rows.Count > 0)
                    {
                        voucherListGridView.UseAccessibleHeader = true;
                        voucherListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Journal Voucher List Data Not Found!!!"; msgDetailLabel.Text = "";
                        msgbox.Attributes.Add("class", "alert alert-info");
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
                journalVoucher = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void allVoucherListButton_Click(object sender, EventArgs e)
        {
            JournalVoucherBLL journalVoucher = new JournalVoucherBLL();

            try
            {
                string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());

                DataTable dt = journalVoucher.GetJournalVoucherApprovedListByDateRangeAndAll(drpdwnSalesCenterOrWarehouse.SelectedValue, fromDate, toDate, "All");

                voucherListGridView.DataSource = dt;
                voucherListGridView.DataBind();

                if (voucherListGridView.Rows.Count > 0)
                {
                    voucherListGridView.UseAccessibleHeader = true;
                    voucherListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Journal Voucher List Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-info");
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

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("JournalNumberForView", voucherListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AccUI/JournalVoucher/ViewJournalVoucher.aspx", false);
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