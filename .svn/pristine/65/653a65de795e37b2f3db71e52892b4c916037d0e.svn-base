using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;
using Lumex.Project.BLL;
using System.Data;
using Lumex.Report.BLL;

namespace lmxIpos.ReportUI
{
    public partial class AvailablePrdLstBySC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
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

        protected void LoadWarehouse()
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

        protected void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (titleSalesCenterOrWarehouse.Text == "Sales Center")
                {
                    if (drpdwnReportOnStock.SelectedValue == "1")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductBySaclesCenterId(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                    }
                    else if (drpdwnReportOnStock.SelectedValue == "2")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductBySaclesCenterIdPRWise(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                    }
                }
                else
                {
                    if (drpdwnReportOnStock.SelectedValue == "1")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductByWarehouseId(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                    }
                    else if (drpdwnReportOnStock.SelectedValue == "2")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductByWarehouseIdPRWise(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (titleSalesCenterOrWarehouse.Text == "Sales Center")
                {
                    if (drpdwnReportOnStock.SelectedValue == "1")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductBySaclesCenterId(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);

                    }
                    else if (drpdwnReportOnStock.SelectedValue == "2")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductBySaclesCenterIdPRWise(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);

                    }
                }
                else
                {
                    if (drpdwnReportOnStock.SelectedValue == "1")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductByWarehouseId(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);

                    }
                    else if (drpdwnReportOnStock.SelectedValue == "2")
                    {
                        IPOSReportBLL iposReport = new IPOSReportBLL();
                        iposReport.GetAvailableProductByWarehouseIdPRWise(drpdwnSalesCenterOrWarehouse.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);

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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void drpdwnReportOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpdwnReportOn.SelectedIndex == 0)
                {
                    drpdwnSalesCenterOrWarehouse.Items.Clear();
                    LoadSalesCenters();
                    titleSalesCenterOrWarehouse.Text = "Sales Center";
                }
                else if (drpdwnReportOn.SelectedIndex == 1)
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
    }
}