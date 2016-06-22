using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferRequisition
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
                    idLabel.Text = transferRequisitionIdForViewHiddenField.Value = LumexSessionManager.Get("TransferRequisitionIdForView").ToString().Trim();
                    GetProductTransferRequisitionById(transferRequisitionIdForViewHiddenField.Value.Trim());
                    GetProductTransferRequisitionProductListById(transferRequisitionIdForViewHiddenField.Value.Trim());
                }

                if (productTransferRequisitionProductListGridView.Rows.Count > 0)
                {
                    productTransferRequisitionProductListGridView.UseAccessibleHeader = true;
                    productTransferRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetProductTransferRequisitionById(string transferRequisitionId)
        {
            ProductTransferRequisitionBLL productTransferRequisition = new ProductTransferRequisitionBLL();

            try
            {
                DataTable dt = productTransferRequisition.GetProductTransferRequisitionById(transferRequisitionId);

                if (dt.Rows.Count > 0)
                {
                    requisitionDateLabel.Text = dt.Rows[0]["RequisitionDate"].ToString();
                    transferTypeLabel.Text = dt.Rows[0]["TransferType"].ToString();
                    transferFromIdLabel.Text = dt.Rows[0]["TransferFrom"].ToString();
                    transferFromNameLabel.Text = dt.Rows[0]["TransferFromName"].ToString();
                    transferToIdLabel.Text = dt.Rows[0]["TransferTo"].ToString();
                    transferToNameLabel.Text = dt.Rows[0]["TransferToName"].ToString();
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
                productTransferRequisition = null;
            }
        }

        protected void GetProductTransferRequisitionProductListById(string transferRequisitionId)
        {
            ProductTransferRequisitionBLL productTransferRequisition = new ProductTransferRequisitionBLL();

            try
            {
                DataTable dt = productTransferRequisition.GetProductTransferRequisitionProductListById(transferRequisitionId);

                if (dt.Rows.Count > 0)
                {
                    productTransferRequisitionProductListGridView.DataSource = dt;
                    productTransferRequisitionProductListGridView.DataBind();

                    if (productTransferRequisitionProductListGridView.Rows.Count > 0)
                    {
                        productTransferRequisitionProductListGridView.UseAccessibleHeader = true;
                        productTransferRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                productTransferRequisition = null;
            }
        }
    }
}