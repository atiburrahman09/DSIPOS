using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Sales
{
    public partial class ApprovedRetailSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = salesRecordIdForViewHiddenField.Value = LumexSessionManager.Get("SalesRecordIdForView").ToString().Trim();
                    GetSalesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
                    GetSalesRecordProductListById(salesRecordIdForViewHiddenField.Value.Trim());
                }

                if (salesRecordProductListGridView.Rows.Count > 0)
                {
                    salesRecordProductListGridView.UseAccessibleHeader = true;
                    salesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetSalesRecordById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordById(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
                    lblSalesPerson.Text = dt.Rows[0]["SalesPerson"].ToString();
                  //  statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    customerIdLabel.Text = dt.Rows[0]["CustomerId"].ToString();
                    customerNameLabel.Text = dt.Rows[0]["CustomerName"].ToString();
                    customerContactLabel.Text = dt.Rows[0]["CustomerContactNumber"].ToString();
                    customerAddressLabel.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    UncollectedAmountLabel.Text = dt.Rows[0]["UncollectableAmount"].ToString();
                    receivedAmountLabel.Text = dt.Rows[0]["ReceivedAmount"].ToString();
                    discountAmountLabel.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    otherAmountLabel.Text = dt.Rows[0]["OthersAmount"].ToString();
                    serviceChargeLabel.Text = dt.Rows[0]["ServiceAmount"].ToString();
                    AddedServiceChargeLabel.Text = dt.Rows[0]["AddedServiceCharge"].ToString();
                    totalReceivableLabel.Text = dt.Rows[0]["TotalReceivable"].ToString();
                    DiscountParLabel.Text = dt.Rows[0]["DiscountPercentage"].ToString();
                    serviceChargeParLabel.Text = dt.Rows[0]["ServicePercentage"].ToString();
                    OthersSaleLabel.Text = dt.Rows[0]["OthersDes"].ToString();
                    creditStatusLabel.Text = dt.Rows[0]["CreditStatus"].ToString();
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

        protected void GetSalesRecordProductListById(string salesRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesRecordProductListById(salesRecordId);

                if (dt.Rows.Count > 0)
                {
                    salesRecordProductListGridView.DataSource = dt;
                    salesRecordProductListGridView.DataBind();

                    if (salesRecordProductListGridView.Rows.Count > 0)
                    {
                        salesRecordProductListGridView.UseAccessibleHeader = true;
                        salesRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
    }
}