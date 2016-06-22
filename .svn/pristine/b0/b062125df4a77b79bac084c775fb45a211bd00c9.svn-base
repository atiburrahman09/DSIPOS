using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesReturn
{
    public partial class ApprovedSalesReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = salesReturnIdForViewHiddenField.Value = LumexSessionManager.Get("SalesReturnIdForView").ToString().Trim();
                    GetSalesReturnById(salesReturnIdForViewHiddenField.Value.Trim());
                    GetSalesReturnProductListById(salesReturnIdForViewHiddenField.Value.Trim());
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

        protected void GetSalesReturnById(string salesReturnId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesReturnById(salesReturnId);

                if (dt.Rows.Count > 0)
                {
                    returnIdLabel.Text = dt.Rows[0]["SalesReturnId"].ToString();
                    returnDateLabel.Text = dt.Rows[0]["ReturnDate"].ToString();
                    salesRecordIdLabel.Text = dt.Rows[0]["SalesRecordId"].ToString();
                    returnAmountLabel.Text = dt.Rows[0]["ReturnAmount"].ToString();
                    returnVATAmountLabel.Text = dt.Rows[0]["ReturnVATAmount"].ToString();
                    dueAmountLabel.Text = dt.Rows[0]["SalesDueAmount"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
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
                salesOrder = null;
            }
        }

        protected void GetSalesReturnProductListById(string salesReturnId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesReturnProductListById(salesReturnId);

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
                salesOrder = null;
            }
        }
    }
}