using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferOrder
{
    public partial class TransferOrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = transferRequisitionIdForViewHiddenField.Value = LumexSessionManager.Get("ProductTransferOrderIdForView").ToString().Trim();
                    GetProductTransferOrderById(transferRequisitionIdForViewHiddenField.Value.Trim());
                    GetProductTransferOrderProductListById(transferRequisitionIdForViewHiddenField.Value.Trim());
                }

                if (productTransferOrderProductListGridView.Rows.Count > 0)
                {
                    productTransferOrderProductListGridView.UseAccessibleHeader = true;
                    productTransferOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetProductTransferOrderById(string transferOrderId)
        {
            ProductTransferOrderBLL productTransferOrder = new ProductTransferOrderBLL();

            try
            {
                DataTable dt = productTransferOrder.GetProductTransferOrderById(transferOrderId);

                if (dt.Rows.Count > 0)
                {
                    orderDateLabel.Text = dt.Rows[0]["OrderDate"].ToString();
                    transferTypeLabel.Text = dt.Rows[0]["TransferType"].ToString();
                    transferFromIdLabel.Text = dt.Rows[0]["TransferFrom"].ToString();
                    transferFromNameLabel.Text = dt.Rows[0]["TransferFromName"].ToString();
                    transferToIdLabel.Text = dt.Rows[0]["TransferTo"].ToString();
                    transferToNameLabel.Text = dt.Rows[0]["TransferToName"].ToString();
                    requisitionIdLabel.Text = dt.Rows[0]["RequisitionId"].ToString();
                    requisitionDateLabel.Text = dt.Rows[0]["RequisitionDate"].ToString();
                    transportDateLabel.Text = dt.Rows[0]["TransportDate"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
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
                productTransferOrder = null;
            }
        }

        protected void GetProductTransferOrderProductListById(string transferOrderId)
        {
            ProductTransferOrderBLL productTransferOrder = new ProductTransferOrderBLL();

            try
            {
                DataTable dt = productTransferOrder.GetProductTransferOrderProductListById(transferOrderId, requisitionIdLabel.Text.Trim(), descriptionLabel.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    productTransferOrderProductListGridView.DataSource = dt;
                    productTransferOrderProductListGridView.DataBind();

                    if (productTransferOrderProductListGridView.Rows.Count > 0)
                    {
                        productTransferOrderProductListGridView.UseAccessibleHeader = true;
                        productTransferOrderProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                productTransferOrder = null;
            }
        }

        protected void orderReceivedButton_Click(object sender, EventArgs e)
        {
            ProductTransferOrderBLL productTransferOrder = new ProductTransferOrderBLL();

            try
            {
                if (transferTypeLabel.Text == "WH-SC")
                {
                    productTransferOrder.ReceivedProductTransferBySC(idLabel.Text.Trim(), transferToIdLabel.Text.Trim());

                }
                else if (transferTypeLabel.Text == "SC-WH")
                {
                    productTransferOrder.ReceivedProductTransferByWH(idLabel.Text.Trim(), transferToIdLabel.Text.Trim());
                }
                string message = "Product Transfer Order <span class='actionTopic'>Received </span> Successfully. ";
                MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/ProductTransferOrder/ReceiveTransferProduct.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                LumexSessionManager.Remove("ProductTransferOrderIdForView");

            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                productTransferOrder = null;
            }
        }
    }
}