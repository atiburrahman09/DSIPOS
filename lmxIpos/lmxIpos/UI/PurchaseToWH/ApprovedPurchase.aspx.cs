using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseToWH
{
    public partial class ApprovedPurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = purchaseRecordIdForViewHiddenField.Value = LumexSessionManager.Get("PurchaseRecordIdForView").ToString().Trim();
                    GetPurchaseRecordById(purchaseRecordIdForViewHiddenField.Value.Trim());
                    GetPurchaseRecordProductListById(purchaseRecordIdForViewHiddenField.Value.Trim());
                }

                if (purchaseOrderProductListGridView.Rows.Count > 0)
                {
                    purchaseOrderProductListGridView.UseAccessibleHeader = true;
                    purchaseOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetPurchaseRecordById(string purchaseRecordId)
        {
            PurchaseToWHBLL purchaseRecord = new PurchaseToWHBLL();

            try
            {
                DataTable dt = purchaseRecord.GetPurchaseRecordById(purchaseRecordId);

                if (dt.Rows.Count > 0)
                {
                    //prIDLabel.Text = dt.Rows[0]["PurchaseRequisitionId"].ToString();
                    //prDateLabel.Text = " , " + dt.Rows[0]["PurchaseRequisitionDate"].ToString();
                    //poIDLabel.Text = dt.Rows[0]["PurchaseOrderId"].ToString();
                    //poDateLabel.Text = " , " + dt.Rows[0]["PurchaseOrderDate"].ToString();
                    warehouseIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                    warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    vendorIdLabel.Text = dt.Rows[0]["VendorId"].ToString();
                    vendorNameLabel.Text = dt.Rows[0]["VendorName"].ToString();
                    //requisitionNarrationLabel.Text = dt.Rows[0]["RequisitionNarration"].ToString();
                    vendorOrderDateLabel.Text = dt.Rows[0]["VendorOrderDate"].ToString();
                    vendorOrderNumberLabel.Text = dt.Rows[0]["VendorOrderNumber"].ToString();
                    vendorInvoiceNumberLabel.Text = dt.Rows[0]["VendorInvoiceNumber"].ToString();
                    receivedDateLabel.Text = dt.Rows[0]["ReceivedDate"].ToString();
                   // lcNumberLabel.Text = dt.Rows[0]["LCNumber"].ToString();
                  //  transportTypeLabel.Text = dt.Rows[0]["TransportType"].ToString();
                    paymentModeLabel.Text = dt.Rows[0]["PaymentMode"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    bankLabel.Text = dt.Rows[0]["BankName"].ToString();
                    bankBranchLabel.Text = dt.Rows[0]["BankBranch"].ToString();
                    chequeNumberLabel.Text = dt.Rows[0]["ChequeNumber"].ToString();
                    chequeDateLabel.Text = dt.Rows[0]["ChequeDate"].ToString();
                   // shippingAddressLabel.Text = dt.Rows[0]["ShippingAddress"].ToString();
                  //  billingAddressLabel.Text = dt.Rows[0]["BillingAddress"].ToString();
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    //vatLabel.Text = dt.Rows[0]["VAT"].ToString();
                    //totalPayableLabel.Text = dt.Rows[0]["TotalPayable"].ToString();
                    paidAmountLabel.Text = dt.Rows[0]["PaidAmount"].ToString();
                    transportCostLabel.Text = dt.Rows[0]["TransportCost"].ToString();
                    discountAmountLabel.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    totalPayableLabel.Text = dt.Rows[0]["TotalPayable"].ToString();
                    CreatedByLabel.Text = dt.Rows[0]["CreatedBy"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        protected void GetPurchaseRecordProductListById(string purchaseRecordId)
        {
            PurchaseToWHBLL purchaseRecord = new PurchaseToWHBLL();

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
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                purchaseRecord = null;
            }
        }
    }
}