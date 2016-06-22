using System;
using System.Data;
using System.Web.UI;
using Lumex.Tech;
using Lumex.Project.BLL;
using Lumex.Report.BLL;


namespace lmxIpos.ReportUI.AccReports
{
    public partial class TrialBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadSalesCenters();
                SCWHDropDownList.Enabled = false;
                queryDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                reportTypeDropDownList.Focus();
            }
        }

        protected void LoadSCWH()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();
            WarehouseBLL warehouse = new WarehouseBLL();
            DataTable dt = new DataTable();

            try
            {
                if (reportTypeDropDownList.SelectedValue == "Sales Center")
                {
                    dt = salesCenter.GetActiveSalesCenterListByUser();

                    SCWHDropDownList.DataSource = dt;
                    SCWHDropDownList.DataValueField = "SalesCenterId";
                    SCWHDropDownList.DataTextField = "SalesCenterName";
                    SCWHDropDownList.DataBind();
                    SCWHDropDownList.Items.Insert(0, "All");
                    SCWHDropDownList.Items[0].Value = "All";
                    SCWHDropDownList.SelectedIndex = 0;
                }
                else
                {
                    dt = warehouse.GetActiveWarehouseListByUser();

                    SCWHDropDownList.DataSource = dt;
                    SCWHDropDownList.DataValueField = "WarehouseId";
                    SCWHDropDownList.DataTextField = "WarehouseName";
                    SCWHDropDownList.DataBind();
                    SCWHDropDownList.Items.Insert(0, "All");
                    SCWHDropDownList.Items[0].Value = "All";
                    SCWHDropDownList.SelectedIndex = 0;
                }

                //SCWHDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

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
                warehouse = null;
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
                IPOSReportBLL iposReport = new IPOSReportBLL();
                iposReport.Get_Trial_Balance_by_Date(reportTypeDropDownList.SelectedValue, SCWHDropDownList.SelectedValue, queryDateTextBox.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);
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
                iposReport.Get_Trial_Balance_by_Date(reportTypeDropDownList.SelectedValue, SCWHDropDownList.SelectedValue, queryDateTextBox.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ExportReportForm();", true);
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

        protected void reportTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportTypeDropDownList.SelectedValue == "All")
            {
                SCWHDropDownList.Enabled = false;
            }
            else
            {
                SCWHDropDownList.Enabled = true;
                LoadSCWH();
            }
        }
    }
}