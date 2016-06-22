using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.PaymentToVendor
{
    public partial class PayVendorPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    //LoadVendors();
                }

                if (paymentDetailsGridView.Rows.Count > 0)
                {
                    paymentDetailsGridView.UseAccessibleHeader = true;
                    paymentDetailsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        //protected void LoadVendors()
        //{
        //    VendorBLL vendor = new VendorBLL();

        //    try
        //    {
        //        DataTable dt = vendor.GetActiveVendors();

        //        vendorDropDownList.DataSource = dt;
        //        vendorDropDownList.DataValueField = "VendorId";
        //        vendorDropDownList.DataTextField = "VendorName";
        //        vendorDropDownList.DataBind();
        //        vendorDropDownList.Items.Insert(0, "");
        //        vendorDropDownList.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        vendor = null;
        //    }
        //}

        protected void GetPaymentInfo()
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();
            PurchaseRecordBLL purchaseRecord = new PurchaseRecordBLL();

            try
            {
                DataTable dtInfo = purchaseRecord.GetPurchaseRecordById(purchaseRecordIdTextBox.Text.Trim());

                if (dtInfo.Rows.Count > 0)
                {
                    salesCenterIdLabel.Text = dtInfo.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dtInfo.Rows[0]["SalesCenterName"].ToString();
                    recordIdLabel.Text = dtInfo.Rows[0]["PurchaseRecordId"].ToString();
                    recordDateLabel.Text = dtInfo.Rows[0]["RecordDate"].ToString();
                    vendorIdLabel.Text = dtInfo.Rows[0]["VendorId"].ToString();
                    vendorNameLabel.Text = dtInfo.Rows[0]["VendorName"].ToString();
                    warehouseIdLabel.Text = dtInfo.Rows[0]["WarehouseId"].ToString();
                    warehouseNameLabel.Text = dtInfo.Rows[0]["WarehouseName"].ToString();
                    salesCenterIdLabel.Text = dtInfo.Rows[0]["WarehouseId"].ToString();
                    salesCenterNameLabel.Text = dtInfo.Rows[0]["WarehouseName"].ToString();
                    totalAmountLabel.Text = dtInfo.Rows[0]["TotalAmount"].ToString();
                    //vatLabel.Text = dtInfo.Rows[0]["VAT"].ToString();
                    transportCostLabel.Text = dtInfo.Rows[0]["TransportCost"].ToString();
                    totalPayableLabel.Text = dtInfo.Rows[0]["TotalPayable"].ToString();
                }

                DataTable dt = receivePayment.GetVendorPayments(vendorIdLabel.Text.Trim(), purchaseRecordIdTextBox.Text.Trim(), "PA");
                paymentDetailsGridView.DataSource = dt;
                paymentDetailsGridView.DataBind();

                decimal amt = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Status"].ToString() == "Approved")
                    {
                        amt = amt + decimal.Parse(dt.Rows[i]["Amount"].ToString());
                    }
                }

                totalReceivedLabel.Text = amt.ToString();
                currentPayableLabel.Text = (decimal.Parse(totalPayableLabel.Text) - decimal.Parse(totalReceivedLabel.Text)).ToString();

                if (paymentDetailsGridView.Rows.Count > 0)
                {
                    paymentDetailsGridView.UseAccessibleHeader = true;
                    paymentDetailsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                receivePayment = null;
                purchaseRecord = null;
            }
        }

        protected void makePaymentButton_Click(object sender, EventArgs e)
        {
            GetPaymentInfo();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ReceivePaymentBLL receivePayment = new ReceivePaymentBLL();

            try
            {
                if (decimal.Parse(currentPayableLabel.Text) > 0)
                {
                    receivePayment.PurchaseRecordId = recordIdLabel.Text;
                    receivePayment.VendorId = vendorIdLabel.Text;
                    receivePayment.SalesCenterId = salesCenterIdLabel.Text;
                    receivePayment.Amount = amountTextBox.Text.Trim();
                    receivePayment.CurrentPayable = currentPayableLabel.Text;

                    receivePayment.SaveVendorPaymentBySC();
                    GetPaymentInfo();

                    string message = "";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                    MyAlertBox("alert(\"Saved Successfully.\");");
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "No Payable to Payment.";
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