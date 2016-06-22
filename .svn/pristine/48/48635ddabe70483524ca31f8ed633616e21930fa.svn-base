using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Report.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PaymentToVendor
{
    public partial class VendorPaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadVendors();

            }
            if (vendorPaymentListGridView.Rows.Count > 0)
            {
                vendorPaymentListGridView.UseAccessibleHeader = true;
                vendorPaymentListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void LoadVendors()
        {
            VendorBLL vendor = new VendorBLL();

            try
            {
                DataTable dt = vendor.GetActiveVendors();
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

        protected void btnVendorPaymentList_OnClick(object sender, EventArgs e)
        {
            VendorBLL vendorBll = new VendorBLL();

            try
            {
                if (vendorDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Business Name field is required.";
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
                    string vendorId = vendorDropDownList.SelectedValue.Trim();
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    string status = statusDropDownList.SelectedValue;

                    DataTable dt = vendorBll.GetVendorWisePaymentList(vendorId, fromDate, toDate, status);
                    vendorPaymentListGridView.DataSource = dt;
                    vendorPaymentListGridView.DataBind();

                    if (vendorPaymentListGridView.Rows.Count > 0)
                    {
                        vendorPaymentListGridView.UseAccessibleHeader = true;
                        vendorPaymentListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                vendorBll = null;
            }
        }

        //protected void printInvoiceButton_OnClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton lnkBtn = (LinkButton)sender;
        //        GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

        //        string JournalNo = vendorPaymentListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
        //        string vendorId = vendorDropDownList.SelectedValue;
        //        string WHSCId = LumexSessionManager.Get("UserWareHouseId").ToString();

        //        IPOSReportBLL iposReport = new IPOSReportBLL();
        //        iposReport.GetReceivePaymentVaucharbyVendororCustomer(JournalNo, vendorId, WHSCId);
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ViewReportForm();", true);


        //    }
        //    catch (Exception ex)
        //    {

        //        //
        //    }
        //}
    }
}