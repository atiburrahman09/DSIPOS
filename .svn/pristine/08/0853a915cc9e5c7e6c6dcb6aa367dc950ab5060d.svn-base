using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesOrder
{
    public partial class DeliverSalesOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = salesOrderIdForViewHiddenField.Value = LumexSessionManager.Get("SalesOrderIdForDeliver").ToString().Trim();
                    GetSalesOrderById(salesOrderIdForViewHiddenField.Value.Trim());
                    GetSalesOrderProductListById(salesOrderIdForViewHiddenField.Value.Trim());
                }

                if (salesOrderProductListGridView.Rows.Count > 0)
                {
                    salesOrderProductListGridView.UseAccessibleHeader = true;
                    salesOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetSalesOrderById(string salesOrderId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesOrderById(salesOrderId);

                if (dt.Rows.Count > 0)
                {
                    orderIdLabel.Text = dt.Rows[0]["SalesOrderId"].ToString();
                    orderDateLabel.Text = dt.Rows[0]["OrderDate"].ToString();
                    salesPersonIdLabel.Text = dt.Rows[0]["SalesPersonId"].ToString();
                    salesPersonNameLabel.Text = dt.Rows[0]["SalesPersonName"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    customerIdLabel.Text = dt.Rows[0]["CustomerId"].ToString();
                    customerNameLabel.Text = dt.Rows[0]["CustomerName"].ToString();
                    customerContactNumberLabel.Text = dt.Rows[0]["CustomerContactNumber"].ToString();
                    customerAddressLabel.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    transportTypeLabel.Text = dt.Rows[0]["TransportType"].ToString();
                    shippingAddressLabel.Text = dt.Rows[0]["ShippingAddress"].ToString();
                    billingAddressLabel.Text = dt.Rows[0]["BillingAddress"].ToString();
                    paymentModeLabel.Text = dt.Rows[0]["PaymentMode"].ToString();
                    chequeNumberLabel.Text = dt.Rows[0]["ChequeNumber"].ToString();
                    chequeDateLabel.Text = dt.Rows[0]["ChequeDate"].ToString();
                    bankLabel.Text = dt.Rows[0]["Bank"].ToString();
                    bankBranchLabel.Text = dt.Rows[0]["BankBranch"].ToString();
                    deliveryDateLabel.Text = dt.Rows[0]["DeliveryDate"].ToString();
                    lcNumberLabel.Text = dt.Rows[0]["LCNumber"].ToString();
                    transportDateLabel.Text = dt.Rows[0]["TransportDate"].ToString();
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    vatLabel.Text = dt.Rows[0]["VAT"].ToString();
                    totalReceivableLabel.Text = dt.Rows[0]["TotalReceivable"].ToString();
                    receivedAmountLabel.Text = dt.Rows[0]["ReceivedAmount"].ToString();
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
                salesOrder = null;
            }
        }

        protected void GetSalesOrderProductListById(string salesOrderId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesOrderProductListById(salesOrderId);

                if (dt.Rows.Count > 0)
                {
                    salesOrderProductListGridView.DataSource = dt;
                    salesOrderProductListGridView.DataBind();

                    if (salesOrderProductListGridView.Rows.Count > 0)
                    {
                        salesOrderProductListGridView.UseAccessibleHeader = true;
                        salesOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                        deliveredButton.Enabled = true;
                    }
                    else
                    {
                        deliveredButton.Enabled = false;
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
                salesOrder = null;
            }
        }

        protected void deliveredButton_Click(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                salesOrder.UpdateSalesOrderOnDelivered(idLabel.Text.ToString());
                MyAlertBox("alert(\"Sales Order Updated Successfully.\"); window.location=\"/UI/SalesOrder/SalesOrderDelivery.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesOrder = null;
            }
        }
    }
}