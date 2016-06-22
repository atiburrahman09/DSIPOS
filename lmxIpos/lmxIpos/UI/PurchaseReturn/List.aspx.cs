using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseReturn
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // LoadWarehouse();
                fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                salesCenterDropDownList.Focus();
            }
          //  LoadVendors();
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        //protected void LoadVendors()
        //{
        //    VendorBLL vendor = new VendorBLL();

        //    try
        //    {
        //        DataTable dt = vendor.GetVendorListByActivationStatus("True");

        //        vendorNameDropqownList.DataSource = dt;
        //        vendorNameDropqownList.DataValueField = "VendorId";
        //        vendorNameDropqownList.DataTextField = "VendorName";
        //        vendorNameDropqownList.DataBind();
        //        vendorNameDropqownList.Items.Insert(0, "");
        //        vendorNameDropqownList.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }

        //    finally
        //    {
        //        vendor = null;
        //    }
        //}
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
        protected void purchaseReturnFormDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (purchaseReturnFormDropdownList.SelectedValue == "WH")
                {
                    LoadWarehouse();
                    wareHouseorSCLabel.Text = "Warehouse";
                }
                else
                {
                    LoadSalesCenters();
                    wareHouseorSCLabel.Text = "Sales Center";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void recordListButton_Click(object sender, EventArgs e)
        {
            PurchaseReturnBLL purchaseReturn = new PurchaseReturnBLL();

            try
            {
                if (salesCenterDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Sales Center Name field is required.";
                }
                else if (fromDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date From field is required.";
                }
                else if (toDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date To field is required.";
                }
                else
                {
                    string CenterId = salesCenterDropDownList.SelectedValue.Trim();
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    string status = statusDropDownList.SelectedValue.Trim();

                    DataTable dt = purchaseReturn.GetPurchaseReturnsListBySalesCenterDateRangeAndStatus(CenterId, fromDate, toDate, status);

                    PurchaseReturnListGridView.DataSource = dt;
                    PurchaseReturnListGridView.DataBind();

                    if (PurchaseReturnListGridView.Rows.Count > 0)
                    {
                        PurchaseReturnListGridView.UseAccessibleHeader = true;
                        PurchaseReturnListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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
                purchaseReturn = null;
            }

        }
        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ReturnIdForView", PurchaseReturnListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/PurchaseReturn/Approve.aspx");
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