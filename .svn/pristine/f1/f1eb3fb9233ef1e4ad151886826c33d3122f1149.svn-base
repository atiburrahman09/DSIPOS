using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Report.BLL;
using Lumex.Tech;

namespace lmxIpos.ReportUI
{
    public partial class VendorReceivePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadSalesCenters();
                    LoadVendor();
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    if (drpdwnReportOn.SelectedIndex == 0)
                    {
                        LoadSalesCenters();
                    }
                    drpdwnReportOn.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        private void LoadVendor()
        {
            VendorBLL vendor = new VendorBLL();

            try
            {
                DataTable dt = vendor.GetVendorListByActivationStatus("True");

                vendorDropDownList.DataSource = dt;
                vendorDropDownList.DataValueField = "VendorId";
                vendorDropDownList.DataTextField = "VendorName";
                vendorDropDownList.DataBind();
                vendorDropDownList.Items.Insert(0, "");
                vendorDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                vendor = null;
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
                //salesCenterDropDownList.Items.Insert(0, "All");
                //salesCenterDropDownList.Items[0].Value = "All";
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

        protected void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                if (statusDropDownList.SelectedIndex == 0)
                {
                    status = "PA";
                }
                else if (statusDropDownList.SelectedIndex == 1)
                {
                    status = "P";
                }
                else if (statusDropDownList.SelectedIndex == 2)
                {
                    status = "A";
                }

                if (titleSalesCenterOrWarehouse.Text == "Sales Center")
                {
                    IPOSReportBLL iposReport = new IPOSReportBLL();
                    iposReport.GetSalesCenterVendorReceivePaymentList(salesCenterDropDownList.SelectedValue, vendorDropDownList.SelectedValue, fromDateTextBox.Text, toDateTextBox.Text, status);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);
                }
                else
                {
                    IPOSReportBLL iposReport = new IPOSReportBLL();
                    iposReport.GetWarehouseVendorReceivePaymentList(salesCenterDropDownList.SelectedValue, vendorDropDownList.SelectedValue, fromDateTextBox.Text, toDateTextBox.Text, status);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "";
                if (statusDropDownList.SelectedIndex == 0)
                {
                    status = "PA";
                }
                else if (statusDropDownList.SelectedIndex == 1)
                {
                    status = "P";
                }
                else if (statusDropDownList.SelectedIndex == 2)
                {
                    status = "A";
                }

                if (titleSalesCenterOrWarehouse.Text == "Sales Center")
                {
                    IPOSReportBLL iposReport = new IPOSReportBLL();
                    iposReport.GetSalesCenterVendorReceivePaymentList(salesCenterDropDownList.SelectedValue, vendorDropDownList.SelectedValue, fromDateTextBox.Text, toDateTextBox.Text, status);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);
                }
                else
                {
                    IPOSReportBLL iposReport = new IPOSReportBLL();
                    iposReport.GetWarehouseVendorReceivePaymentList(salesCenterDropDownList.SelectedValue, vendorDropDownList.SelectedValue, fromDateTextBox.Text, toDateTextBox.Text, status);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void LoadWarehouse()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataTextField = "WarehouseName";
                salesCenterDropDownList.DataValueField = "WarehouseId";
                salesCenterDropDownList.DataBind();
                //drpdwnSalesCenterOrWarehouse.Items.Insert(0, "");
                //drpdwnSalesCenterOrWarehouse.SelectedIndex = 0;
                salesCenterDropDownList.SelectedIndex = 0;

                salesCenterDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Warehouse Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void drpdwnReportOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpdwnReportOn.SelectedIndex == 0)
                {
                    salesCenterDropDownList.Items.Clear();
                    LoadSalesCenters();
                    titleSalesCenterOrWarehouse.Text = "Sales Center";
                }
                else if (drpdwnReportOn.SelectedIndex == 1)
                {
                    salesCenterDropDownList.Items.Clear();
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
    }
}