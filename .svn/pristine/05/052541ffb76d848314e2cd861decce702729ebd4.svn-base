using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseToSC
{
    public partial class PurchaseApprovalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadSalesCenters();
                GetPurchaseRecordsApprovalListBySalesCenter(salesCenterDropDownList.SelectedValue.Trim());
                salesCenterDropDownList.Focus();
            }

            if (purchaseRecordListGridView.Rows.Count > 0)
            {
                purchaseRecordListGridView.UseAccessibleHeader = true;
                purchaseRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
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
                salesCenter = null;
            }
        }

        protected void approvalListButton_Click(object sender, EventArgs e)
        {
            GetPurchaseRecordsApprovalListBySalesCenter(salesCenterDropDownList.SelectedValue.Trim());
        }

        protected void GetPurchaseRecordsApprovalListBySalesCenter(string salesCenterId)
        {
            PurchaseToSCBLL purchaseRecord = new PurchaseToSCBLL();

            try
            {
                DataTable dt = purchaseRecord.GetPurchaseRecordsApprovalListBySalesCenter(salesCenterId);

                purchaseRecordListGridView.DataSource = dt;
                purchaseRecordListGridView.DataBind();

                if (purchaseRecordListGridView.Rows.Count > 0)
                {
                    purchaseRecordListGridView.UseAccessibleHeader = true;
                    purchaseRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void viewToApproveLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("PurchaseRecordIdForEditView", purchaseRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/PurchaseToSC/ApprovePurchase.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}