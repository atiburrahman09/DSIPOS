using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using System.Data;
using Lumex.Tech;
using Lumex.Report.BLL;

namespace lmxIpos.ReportUI
{
    public partial class SalesRecordReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadSalesCenters();
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    SalesCenterIdDropDownList.Focus();
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

                SalesCenterIdDropDownList.DataSource = dt;
                SalesCenterIdDropDownList.DataValueField = "SalesCenterId";
                SalesCenterIdDropDownList.DataTextField = "SalesCenterName";
                SalesCenterIdDropDownList.DataBind();
                SalesCenterIdDropDownList.Items.Insert(0, "");
                SalesCenterIdDropDownList.SelectedIndex = 0;

                SalesCenterIdDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

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

        protected void generateButton_Click(object sender, EventArgs e)
        {
            try
            {

                IPOSReportBLL iposReport = new IPOSReportBLL();
                iposReport.GetSalesRecordbySC_Date_RANGE_STATUS(SalesCenterIdDropDownList.SelectedValue, toDateTextBox.Text, fromDateTextBox.Text, drpdwnPRStatus.SelectedValue);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                //}
                //else if (drpdwnReportOnStock.SelectedValue == "2")
                //{
                //    IPOSReportBLL iposReport = new IPOSReportBLL();
                //    iposReport.GetAvailableProductBySaclesCenterIdPRWise(SalesCenterIdDropDownList.SelectedValue);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);

                //}
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

                IPOSReportBLL iposReport = new IPOSReportBLL();
                iposReport.GetSalesRecordbySC_Date_RANGE_STATUS(SalesCenterIdDropDownList.SelectedValue, toDateTextBox.Text, fromDateTextBox.Text, drpdwnPRStatus.SelectedValue);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);


                //else if (drpdwnReportOnStock.SelectedValue == "2")
                //{
                //    IPOSReportBLL iposReport = new IPOSReportBLL();
                //    iposReport.GetAvailableProductBySaclesCenterId(SalesCenterIdDropDownList.SelectedValue);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);

                //}
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
    }
}