using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesOrder
{
    public partial class CancelSalesOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadSalesCenters();
                salesCenterDropDownList.Focus();
            }

            if (pendingSalesOrderListGridView.Rows.Count > 0)
            {
                pendingSalesOrderListGridView.UseAccessibleHeader = true;
                pendingSalesOrderListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
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
                salesCenterDropDownList.Items.Insert(0, "");
                salesCenterDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesCenter = null;
            }
        }

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("SalesOrderIdForView", pendingSalesOrderListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/SalesOrder/SalesOrderDetail.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void GetPendingOrderList()
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetPendingSalesOrdersListBySalesCenter(salesCenterDropDownList.SelectedValue.Trim());

                pendingSalesOrderListGridView.DataSource = dt;
                pendingSalesOrderListGridView.DataBind();

                if (pendingSalesOrderListGridView.Rows.Count > 0)
                {
                    pendingSalesOrderListGridView.UseAccessibleHeader = true;
                    pendingSalesOrderListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void pendingOrderListButton_Click(object sender, EventArgs e)
        {
            GetPendingOrderList();
        }

        protected void cancelOrderLinkButton_Click(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                salesOrder.CancelSalesOrderById(pendingSalesOrderListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());

                MyAlertBox("alert(\"Sales Order Canceled Successfully.\"); window.location=\"/UI/SalesOrder/CancelSalesOrder.aspx\"");
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