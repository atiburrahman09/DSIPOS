using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.TodaysCashOut
{
    public partial class TodaysCashOutList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    //if (drpdwnAccountOn.SelectedIndex == 0)
                    //{
                    //    LoadSalesCenters();
                    //}
                    LoadSalesCenters();
                    //LoadTransactionBranchesByUser();
                    entryDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    entryDateTextBox.Focus();
                    approveButton.Enabled = false;
                }

                if (cashOutListGridView.Rows.Count > 0)
                {
                    cashOutListGridView.UseAccessibleHeader = true;
                    cashOutListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        //protected void LoadSalesCenters()
        //{
        //    SalesCenterBLL salesCenter = new SalesCenterBLL();

        //    try
        //    {
        //        DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

        //        drpdwnSalesCenterOrWarehouse.DataSource = dt;
        //        drpdwnSalesCenterOrWarehouse.DataValueField = "SalesCenterId";
        //        drpdwnSalesCenterOrWarehouse.DataTextField = "SalesCenterName";
        //        drpdwnSalesCenterOrWarehouse.DataBind();
        //        //drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
        //        //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;

        //        drpdwnSalesCenterOrWarehouse.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

        //        if (dt.Rows.Count < 1)
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
        //            msgbox.Attributes.Add("class", "alert alert-warning");
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
        //        salesCenter = null;
        //    }
        //}

        //protected void LoadTransactionBranchesByUser()
        //{
        //    UserBLL user = new UserBLL();

        //    try
        //    {
        //        DataTable dt = user.GetTransactionBranchesByUser((string)LumexSessionManager.Get("ActiveUserId"));

        //        transactionBranchDropDownList.DataSource = dt;
        //        transactionBranchDropDownList.DataValueField = "TransactionBranchId";
        //        transactionBranchDropDownList.DataTextField = "TransactionBranchName";
        //        transactionBranchDropDownList.DataBind();
        //        transactionBranchDropDownList.Items.Insert(0, "");
        //        transactionBranchDropDownList.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        user = null;
        //    }
        //}
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

        protected void GetTodaysCashOutEntryList()
        {
            CashOutBLL cashOut = new CashOutBLL();

            try
            {
                cashOut.EntryDate = LumexLibraryManager.ParseAppDate(entryDateTextBox.Text.Trim());
                cashOut.SalesCenterId = drpdwnSalesCenterOrWarehouse.SelectedValue.Trim();
                cashOut.Status = ddlStatus.SelectedValue.Trim();
                DataTable dt = cashOut.GetTodaysCashOutEntryList();
                cashOutListGridView.DataSource = dt;
                cashOutListGridView.DataBind();


               // bool disableApproveButton = true;



                for (int i = 0; i < cashOutListGridView.Rows.Count; i++)
                {

                    if (cashOutListGridView.Rows[i].Cells[7].Text.Trim() != "Pending")
                    {
                        //LinkButton editLinkButton = (LinkButton)cashOutListGridView.Rows[i].FindControl("editLinkButton");
                        //editLinkButton.Visible = false;

                        //LinkButton deleteLinkButton = (LinkButton)cashOutListGridView.Rows[i].FindControl("deleteLinkButton");
                        //deleteLinkButton.Visible = false;
                        //cashOutListGridView.Rows[i].Cells[8].Visible = false;
                        //cashOutListGridView.Rows[i].Cells[9].Visible = false;
                        //cashOutListGridView.Rows[i].Cells[10].Visible = false;
                        this.cashOutListGridView.Columns[8].Visible = false;
                        this.cashOutListGridView.Columns[9].Visible = false;
                        this.cashOutListGridView.Columns[10].Visible = false;
                    }
                }

            

                if (ddlStatus.SelectedValue=="A")
                {
                    approveButton.Enabled = false;
                }
                else if (ddlStatus.SelectedValue=="D")
                {
                    approveButton.Enabled = false;
                    this.cashOutListGridView.Columns[8].Visible = false;
                    this.cashOutListGridView.Columns[9].Visible = false;
                    this.cashOutListGridView.Columns[10].Visible = false;
                }
                else
                {
                    approveButton.Enabled = true;
                    this.cashOutListGridView.Columns[8].Visible = true;
                    this.cashOutListGridView.Columns[9].Visible = true;
                    this.cashOutListGridView.Columns[10].Visible = true;
                }

                if (cashOutListGridView.Rows.Count > 0)
                {
                    cashOutListGridView.UseAccessibleHeader = true;
                    cashOutListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    approveButton.Enabled = true;
                    
                }
                else
                {
                    approveButton.Enabled = false;
                    msgbox.Visible = true; msgTitleLabel.Text = "Todays Cash Out Entry List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                cashOut = null;
            }
        }

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                Label lb1 = (Label)row.FindControl("lblSerial");
                string id = lb1.Text;

                LumexSessionManager.Add("CashOutSerialForUpdate", id);
                Response.Redirect("~/UI/TodaysCashOut/UpdateCashOutEntry.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
                Label lb1 = (Label)row.FindControl("lblSerial");
                string id = lb1.Text;


                CashOutBLL cashOut = new CashOutBLL();
                cashOut.DeleteTodaysCashOutEntryBySerial(id);

                GetTodaysCashOutEntryList();
                string message = "Cash Out Entry <span class='actionTopic'>Deleted</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");

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
            List<CashOutBLL> cashOuts = new List<CashOutBLL>();
            CashOutBLL cashOut = new CashOutBLL();

            int i = 0;

            try
            {

                for (i = 0; i < cashOutListGridView.Rows.Count; i++)
                {
                    CheckBox selectCheckBox = (CheckBox)cashOutListGridView.Rows[i].Cells[7].FindControl("selectCheckBox");
                    Label lblSerial = (Label)cashOutListGridView.Rows[i].Cells[0].FindControl("lblSerial");

                    if (selectCheckBox.Checked)
                    {

                        cashOut.Serial = lblSerial.Text;


                        cashOuts.Add(cashOut);

                    }
                }
                if (cashOuts.Count > 0)
                {
                    cashOut.ApproveTodaysCashOutBySerial(cashOuts);

                }
                
                GetTodaysCashOutEntryList();
                string message = "Todays Cash Out Entries <span class='actionTopic'>Approved</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void entryListButton_Click(object sender, EventArgs e)
        {
            GetTodaysCashOutEntryList();
        }

        //protected void drpdwnAccountOn_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cashOutListGridView.DataSource = null;
        //        cashOutListGridView.DataBind();

        //        if (drpdwnAccountOn.SelectedIndex == 0)
        //        {
        //            drpdwnSalesCenterOrWarehouse.Items.Clear();
        //            LoadSalesCenters();
        //            titleSalesCenterOrWarehouse.Text = "Sales Center";
        //        }
        //        else if (drpdwnAccountOn.SelectedIndex == 1)
        //        {
        //            drpdwnSalesCenterOrWarehouse.Items.Clear();
        //            LoadWarehouse();
        //            titleSalesCenterOrWarehouse.Text = "Warehouse";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}
        protected void drpdwnAccountOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                drpdwnSalesCenterOrWarehouse.Items.Clear();
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
    }
}