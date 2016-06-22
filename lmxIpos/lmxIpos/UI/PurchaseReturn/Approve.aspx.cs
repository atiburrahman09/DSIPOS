using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseReturn
{
    public partial class Approve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = salesReturnIdForViewHiddenField.Value = LumexSessionManager.Get("ReturnIdForView").ToString().Trim();
                    GetPurchaseReturnById(salesReturnIdForViewHiddenField.Value.Trim());
                    GetPurchaseReturnProductListById(salesReturnIdForViewHiddenField.Value.Trim());
                }

                if (salesReturnProductListGridView.Rows.Count > 0)
                {
                    salesReturnProductListGridView.UseAccessibleHeader = true;
                    salesReturnProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetPurchaseReturnById(string ReturnId)
        {
            PurchaseReturnBLL purchaseReturn = new PurchaseReturnBLL();

            try
            {
                DataTable dt = purchaseReturn.GetPurchaseReturnById(ReturnId);

                if (dt.Rows.Count > 0)
                {
                    returnIdLabel.Text = dt.Rows[0]["PurchaseReturnId"].ToString();
                    returnDateLabel.Text = dt.Rows[0]["ReturnDate"].ToString();
                    VendorIdLabel.Text = dt.Rows[0]["VendorId"].ToString() + " " + dt.Rows[0]["VendorName"].ToString();
                    returnAmountLabel.Text = dt.Rows[0]["ReturnAmount"].ToString();
                  //  returnVATAmountLabel.Text = dt.Rows[0]["ReturnVATAmount"].ToString();
                    dueAmountLabel.Text = dt.Rows[0]["PurchaseDueAmount"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["CenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["CenterName"].ToString();
                    AdjustedAmountLabel.Text = dt.Rows[0]["AdjustedAmount"].ToString();
                    SalesPersonLabel.Text = dt.Rows[0]["CreatedBy"].ToString();

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
                purchaseReturn = null;
            }
        }

        protected void GetPurchaseReturnProductListById(string ReturnId)
        {
            PurchaseReturnBLL purchaseReturn = new PurchaseReturnBLL();

            try
            {
                DataTable dt = purchaseReturn.GetPurchaseReturnProductListById(ReturnId);

                if (dt.Rows.Count > 0)
                {
                    salesReturnProductListGridView.DataSource = dt;
                    salesReturnProductListGridView.DataBind();

                    if (salesReturnProductListGridView.Rows.Count > 0)
                    {
                        salesReturnProductListGridView.UseAccessibleHeader = true;
                        salesReturnProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                purchaseReturn = null;
            }
        }
  
    }
}