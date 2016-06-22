using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferRecord
{
    public partial class ApprovedTransferRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = productTransferRecordIdForViewHiddenField.Value = LumexSessionManager.Get("ProductTransferRecordIdForView").ToString().Trim();
                    GetProductTransferRecordById(productTransferRecordIdForViewHiddenField.Value.Trim());
                    GetProductTransferRecordProductListById(productTransferRecordIdForViewHiddenField.Value.Trim());
                }

                if (transferRecordProductListGridView.Rows.Count > 0)
                {
                    transferRecordProductListGridView.UseAccessibleHeader = true;
                    transferRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetProductTransferRecordById(string transferRecordId)
        {
            ProductTransferRecordBLL productTransferRecord = new ProductTransferRecordBLL();

            try
            {
                DataTable dt = productTransferRecord.GetProductTransferRecordById(transferRecordId);

                if (dt.Rows.Count > 0)
                {
                    receivedDateLabel.Text = dt.Rows[0]["ReceivedDate"].ToString();
                    recordStatusLabel.Text = dt.Rows[0]["RecordStatus"].ToString();
                    orderIdLabel.Text = dt.Rows[0]["TransferOrderId"].ToString();
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
                productTransferRecord = null;
            }
        }

        protected void GetProductTransferRecordProductListById(string transferRecordId)
        {
            ProductTransferRecordBLL productTransferRecord = new ProductTransferRecordBLL();

            try
            {
                DataTable dt = productTransferRecord.GetProductTransferRecordProductListById(transferRecordId);

                if (dt.Rows.Count > 0)
                {
                    transferRecordProductListGridView.DataSource = dt;
                    transferRecordProductListGridView.DataBind();

                    if (transferRecordProductListGridView.Rows.Count > 0)
                    {
                        transferRecordProductListGridView.UseAccessibleHeader = true;
                        transferRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                productTransferRecord = null;
            }
        }
    }
}