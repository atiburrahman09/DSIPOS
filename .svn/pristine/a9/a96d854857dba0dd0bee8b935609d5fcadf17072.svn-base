using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseRequisition
{
    public partial class ApprovedRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = purchaseRequisitionIdForViewHiddenField.Value = LumexSessionManager.Get("PurchaseRequisitionIdForView").ToString().Trim();
                    GetPurchaseRequisitionById(purchaseRequisitionIdForViewHiddenField.Value.Trim());
                    GetPurchaseRequisitionProductListById(purchaseRequisitionIdForViewHiddenField.Value.Trim());
                }

                if (purchaseRequisitionProductListGridView.Rows.Count > 0)
                {
                    purchaseRequisitionProductListGridView.UseAccessibleHeader = true;
                    purchaseRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetPurchaseRequisitionById(string purchaseRequisitionId)
        {
            PurchaseRequisitionBLL purchaseRequisition = new PurchaseRequisitionBLL();

            try
            {
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionById(purchaseRequisitionId);

                if (dt.Rows.Count > 0)
                {
                    requisitionDateLabel.Text = dt.Rows[0]["RequisitionDate"].ToString();
                    warehouseIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                    warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
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
                purchaseRequisition = null;
            }
        }

        protected void GetPurchaseRequisitionProductListById(string purchaseRequisitionId)
        {
            PurchaseRequisitionBLL purchaseRequisition = new PurchaseRequisitionBLL();

            try
            {
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionProductListById(purchaseRequisitionId);

                if (dt.Rows.Count > 0)
                {
                    purchaseRequisitionProductListGridView.DataSource = dt;
                    purchaseRequisitionProductListGridView.DataBind();

                    if (purchaseRequisitionProductListGridView.Rows.Count > 0)
                    {
                        purchaseRequisitionProductListGridView.UseAccessibleHeader = true;
                        purchaseRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                purchaseRequisition = null;
            }
        }
    }
}