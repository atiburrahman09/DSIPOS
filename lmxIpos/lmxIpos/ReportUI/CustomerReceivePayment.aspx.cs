using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Lumex.Tech;
using Lumex.Project.BLL;
using Lumex.Report.BLL;

namespace lmxIpos.ReportUI
{
    public partial class CustomerReceivePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadSalesCenters();
                    LoadActiveCustomerList();
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    customerIdDropDownList.Focus();
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

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataValueField = "SalesCenterId";
                salesCenterDropDownList.DataTextField = "SalesCenterName";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "All");
                salesCenterDropDownList.Items[0].Value = "All";
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

        protected void LoadActiveCustomerList()
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                DataTable dt = customer.GetActiveCustomerList();

                customerIdDropDownList.DataSource = dt;
                customerIdDropDownList.DataValueField = "CustomerId";
                customerIdDropDownList.DataTextField = "CustomerIdName";
                customerIdDropDownList.DataBind();
                customerIdDropDownList.Items.Insert(0, "");
                customerIdDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                customer = null;
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
                iposReport.GetCustomerReceivePaymentList(salesCenterDropDownList.SelectedValue, customerIdDropDownList.SelectedValue, fromDateTextBox.Text, toDateTextBox.Text);
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
                iposReport.GetCustomerReceivePaymentList(salesCenterDropDownList.SelectedValue, customerIdDropDownList.SelectedValue, fromDateTextBox.Text, toDateTextBox.Text);
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
    }
}