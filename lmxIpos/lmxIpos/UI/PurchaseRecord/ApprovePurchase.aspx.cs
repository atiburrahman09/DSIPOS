﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseRecord
{
    public partial class ApprovePurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = purchaseRecordIdForEditViewHiddenField.Value = LumexSessionManager.Get("PurchaseRecordIdForEditView").ToString().Trim();
                    GetPurchaseRecordById(purchaseRecordIdForEditViewHiddenField.Value.Trim());
                    GetPurchaseRecordProductListById(purchaseRecordIdForEditViewHiddenField.Value.Trim());
                }

                if (purchaseOrderProductListGridView.Rows.Count > 0)
                {
                    purchaseOrderProductListGridView.UseAccessibleHeader = true;
                    purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetPurchaseRecordById(string purchaseRecordId)
        {
            PurchaseRecordBLL purchaseRecord = new PurchaseRecordBLL();

            try
            {
                DataTable dt = purchaseRecord.GetPurchaseRecordById(purchaseRecordId);

                if (dt.Rows.Count > 0)
                {
                    prIDLabel.Text = dt.Rows[0]["PurchaseRequisitionId"].ToString();
                    prDateLabel.Text = " , " + dt.Rows[0]["PurchaseRequisitionDate"].ToString();
                    poIDLabel.Text = dt.Rows[0]["PurchaseOrderId"].ToString();
                    poDateLabel.Text = " , " + dt.Rows[0]["PurchaseOrderDate"].ToString();
                    warehouseIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                    warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    vendorIdLabel.Text = dt.Rows[0]["VendorId"].ToString();
                    vendorNameLabel.Text = dt.Rows[0]["VendorName"].ToString();
                    requisitionNarrationLabel.Text = dt.Rows[0]["RequisitionNarration"].ToString();
                    vendorOrderDateLabel.Text = dt.Rows[0]["VendorOrderDate"].ToString();
                    vendorOrderNumberLabel.Text = dt.Rows[0]["VendorOrderNumber"].ToString();
                    vendorInvoiceNumberLabel.Text = dt.Rows[0]["VendorInvoiceNumber"].ToString();
                    receivedDateLabel.Text = dt.Rows[0]["ReceivedDate"].ToString();
                    lcNumberLabel.Text = dt.Rows[0]["LCNumber"].ToString();
                    transportTypeLabel.Text = dt.Rows[0]["TransportType"].ToString();
                    paymentModeLabel.Text = dt.Rows[0]["PaymentMode"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    bankLabel.Text = dt.Rows[0]["BankName"].ToString();
                    bankBranchLabel.Text = dt.Rows[0]["BankBranch"].ToString();
                    chequeNumberLabel.Text = dt.Rows[0]["ChequeNumber"].ToString();
                    chequeDateLabel.Text = dt.Rows[0]["ChequeDate"].ToString();
                    shippingAddressLabel.Text = dt.Rows[0]["ShippingAddress"].ToString();
                    billingAddressLabel.Text = dt.Rows[0]["BillingAddress"].ToString();
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    //vatLabel.Text = dt.Rows[0]["VAT"].ToString();
                    //totalPayableLabel.Text = dt.Rows[0]["TotalPayable"].ToString();
                    paidAmountLabel.Text = dt.Rows[0]["PaidAmount"].ToString();
                    transportCostLabel.Text = dt.Rows[0]["TransportCost"].ToString();
                    discountAmountLabel.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    totalPayableLabel.Text = dt.Rows[0]["TotalPayable"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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
                purchaseRecord = null;
            }
        }

        protected void GetPurchaseRecordProductListById(string purchaseRecordId)
        {
            PurchaseRecordBLL purchaseRecord = new PurchaseRecordBLL();

            try
            {
                DataTable dt = purchaseRecord.GetPurchaseRecordProductListById(purchaseRecordId);

                if (dt.Rows.Count > 0)
                {
                    purchaseOrderProductListGridView.DataSource = dt;
                    purchaseOrderProductListGridView.DataBind();

                    if (purchaseOrderProductListGridView.Rows.Count > 0)
                    {
                        purchaseOrderProductListGridView.UseAccessibleHeader = true;
                        purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        approveButton.Enabled = true;
                    }
                    else
                    {
                        approveButton.Enabled = false;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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
                purchaseRecord = null;
            }
        }

        protected void approveButton_Click(object sender, EventArgs e)
        {
            PurchaseRecordBLL purchaseRecord = new PurchaseRecordBLL();

            try
            {
                purchaseRecord.ApprovePurchaseRecord(warehouseIdLabel.Text.Trim(), idLabel.Text.Trim());

                MyAlertBox("alert(\"Purchase Record Approved Successfully.\"); window.location=\"/UI/PurchaseRecord/PurchaseApprovalList.aspx\"");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                purchaseRecord = null;
            }
        }
    }
}
