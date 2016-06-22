using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesOrder
{
    public partial class OnTransportSalesOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadSalesCenters();
                GetSalesOrderList();
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
                salesCenterDropDownList.Items.Insert(0, "All");
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

        protected void GetSalesOrderList()
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetSalesOrdersListBySalesCenterAndStatus(salesCenterDropDownList.SelectedValue.Trim(), "OT");

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

        protected void onTransportOrderListButton_Click(object sender, EventArgs e)
        {
            GetSalesOrderList();
        }
    }
}