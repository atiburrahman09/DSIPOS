using Lumex.Project.BLL;
using Lumex.Tech;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lmxIpos.UI.PaymentSchedule
{
    public partial class ServiceChargeCalculate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    if (ddlWHorSC.SelectedValue.ToString() == "SC")
                    {
                        LoadSalesCenters();
                    }
                    else
                    {
                        LoadWarehouses();
                    }


                    if (paymentScheduleCalulateListGridView.Rows.Count > 0)
                    {
                        paymentScheduleCalulateListGridView.UseAccessibleHeader = true;
                        paymentScheduleCalulateListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                }
            }
            catch (Exception)
            {

                //  throw;
            }
        }
        protected void ddlWHorSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlWHorSC.SelectedValue.ToString() == "SC")
                {
                    LoadSalesCenters();
                }
                else
                {
                    LoadWarehouses();
                }
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

                ddlSelectWareHouseOrSalesCenter.DataSource = dt;
                ddlSelectWareHouseOrSalesCenter.DataValueField = "SalesCenterId";
                ddlSelectWareHouseOrSalesCenter.DataTextField = "SalesCenterName";
                ddlSelectWareHouseOrSalesCenter.DataBind();
                //ddlSelectWareHouseOrSalesCenter.Items.Insert(0, "Select Please");
                //ddlSelectWareHouseOrSalesCenter.SelectedIndex = 0;
                ddlSelectWareHouseOrSalesCenter.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesCenter = null;
            }
        }
        protected void LoadWarehouses()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                ddlSelectWareHouseOrSalesCenter.DataSource = dt;
                ddlSelectWareHouseOrSalesCenter.DataValueField = "WarehouseId";
                ddlSelectWareHouseOrSalesCenter.DataTextField = "WarehouseName";
                ddlSelectWareHouseOrSalesCenter.DataBind();
                //ddlSelectWareHouseOrSalesCenter.Items.Insert(0, "Select Please");
                //ddlSelectWareHouseOrSalesCenter.SelectedIndex = 0;
                ddlSelectWareHouseOrSalesCenter.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                warehouse = null;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void CalculateChargeButton_OnClick(object sender, EventArgs e)
        {
            PaymentScheduleBLL scheduleBll = new PaymentScheduleBLL();
            try
            {
                scheduleBll.SCWHId = ddlSelectWareHouseOrSalesCenter.SelectedValue.ToString();

                bool status = scheduleBll.CalculateServiceChargeBySCWHID();
                if (status)
                {
                    string message =
                            "Service Charge  <span class='actionTopic'>Calculated </span> Successfully.";
                    MyAlertBox(
                        "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/PaymentSchedule/ServiceChargeCalculate.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\",\"\");");

                    getServiceChargeCalculedList(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"));
                }
                else
                {
                    string message =
                            "Service Charge <span class='actionTopic'>Calculated !!!!</span>";
                    MyAlertBox(
                        "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/PaymentSchedule/ServiceChargeCalculate.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\",\"\");");
                }


            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void btnViewCalcuate_OnClick(object sender, EventArgs e)
        {
            getServiceChargeCalculedList(fromDateTextBox.Text, toDateTextBox.Text);
        }

        private void getServiceChargeCalculedList(string fromDate, string toDate)
        {
            PaymentScheduleBLL scheduleBll = new PaymentScheduleBLL();
            try
            {
                DataTable dt = scheduleBll.getServiceChargeCalculatedListByDateRange(ddlSelectWareHouseOrSalesCenter.SelectedValue,fromDate, toDate);
                paymentScheduleCalulateListGridView.DataSource = dt;
                paymentScheduleCalulateListGridView.DataBind();
                if (dt.Rows.Count > 0)
                {
                    if (paymentScheduleCalulateListGridView.Rows.Count > 0)
                    {
                        paymentScheduleCalulateListGridView.UseAccessibleHeader = true;
                        paymentScheduleCalulateListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    msgbox.Visible = true;
                    msgDetailLabel.Text = "No Data Found!!!";
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