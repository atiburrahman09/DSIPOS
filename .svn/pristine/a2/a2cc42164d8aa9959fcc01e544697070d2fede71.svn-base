using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.ReceiveFromCustomer
{
    public partial class UnCollectablePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    salesRecordIdTextBox.Focus();
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
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    customerIdLabel.Text = dt.Rows[0]["CustomerId"].ToString();
                    customerNameLabel.Text = dt.Rows[0]["CustomerName"].ToString();
                    customerContactLabel.Text = dt.Rows[0]["CustomerContactNumber"].ToString();
                    customerAddressLabel.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                    totalVATAmountLabel.Text = dt.Rows[0]["TotalVATAmount"].ToString();
                    receivedAmountLabel.Text = dt.Rows[0]["ReceivedAmount"].ToString();
                    discountAmountLabel.Text = dt.Rows[0]["DiscountAmount"].ToString();
                    vatPercentageLabel.Text = dt.Rows[0]["VATPercentage"].ToString();
                    totalReceivableLabel.Text = dt.Rows[0]["TotalReceivable"].ToString();
                    SalesPersonLabel.Text = dt.Rows[0]["SalesPerson"].ToString();
                    dueAmountLabel.Text = (decimal.Parse(totalReceivableLabel.Text) - decimal.Parse(receivedAmountLabel.Text)).ToString();
                    divSalesInformation.Visible = true;
                    divSalesDuePay.Visible = true;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    divSalesInformation.Visible = false;
                    divSalesDuePay.Visible = false;
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

        protected void getSalesRecordButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(salesRecordIdTextBox.Text))
            {
                idLabel.Text = salesRecordIdForViewHiddenField.Value = salesRecordIdTextBox.Text.Trim();
                GetSalesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
                GetSalesRecordProductListById(salesRecordIdForViewHiddenField.Value.Trim());
            }
            else
            {
                msgbox.Visible = true;
                msgTitleLabel.Text = "Validation Requiered.";
                msgDetailLabel.Text = "Sales Record Field is Empty!!!";
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                if (uncollectableAmountTextBox.Text!="0.00")
                {
                    salesOrder.SaveUncollectableAmountBySalesRecordId(idLabel.Text.Trim(),uncollectableAmountTextBox.Text.Trim());

                    uncollectableAmountTextBox.Text = "0.00";
                    GetSalesRecordById(salesRecordIdForViewHiddenField.Value.Trim());
                    GetSalesRecordProductListById(salesRecordIdForViewHiddenField.Value.Trim());
                }
                else
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation Requiered.";
                    msgDetailLabel.Text = "Amounts Field is Empty!!!";

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