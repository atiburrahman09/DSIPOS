using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductTransferRequisition
{
    public partial class ApproveRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = transferRequisitionIdForApproveHiddenField.Value = LumexSessionManager.Get("TransferRequisitionIdForApprove").ToString().Trim();
                    GetProductTransferRequisitionById(transferRequisitionIdForApproveHiddenField.Value.Trim());
                    GetProductTransferRequisitionProductListById(transferRequisitionIdForApproveHiddenField.Value.Trim());
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
                        approveButton.Enabled = true;
                        productTransferRequisitionProductListGridView.UseAccessibleHeader = true;
                        productTransferRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        TextBox approveQuantityTextBox;

                        for (int i = 0; i < productTransferRequisitionProductListGridView.Rows.Count; i++)
                        {
                            approveQuantityTextBox = (TextBox)productTransferRequisitionProductListGridView.Rows[i].FindControl("approveQuantityTextBox");
                            //approveQuantityTextBox.Text = productTransferRequisitionProductListGridView.Rows[i].Cells[3].Text.ToString();
                            approveQuantityTextBox.Text = dt.Rows[i][3].ToString();
                        }
                    }
                    else
                    {
                        approveButton.Enabled = false;
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

        protected void approveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productTransferRequisitionProductListGridView.Rows.Count > 0)
                {
                    TextBox approveQuantityTextBox;
                    int num; bool isApproveQuantityNum;
                    DropDownList statusDropDownList;
                    TextBox narrationTextBox;
                    string freeQtyWas;

                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("ProductId"));
                    dt.Columns.Add(new DataColumn("ApprovedQuantity"));
                    dt.Columns.Add(new DataColumn("Status"));
                    dt.Columns.Add(new DataColumn("Narration"));
                    dt.Columns.Add(new DataColumn("FreeQuantityWas"));

                    for (int i = 0; i < productTransferRequisitionProductListGridView.Rows.Count; i++)
                    {
                        approveQuantityTextBox = (TextBox)productTransferRequisitionProductListGridView.Rows[i].FindControl("approveQuantityTextBox");
                        isApproveQuantityNum = int.TryParse(approveQuantityTextBox.Text.Trim(), out num);
                        statusDropDownList = (DropDownList)productTransferRequisitionProductListGridView.Rows[i].FindControl("statusDropDownList");
                        narrationTextBox = (TextBox)productTransferRequisitionProductListGridView.Rows[i].FindControl("narrationTextBox");
                        freeQtyWas = productTransferRequisitionProductListGridView.Rows[i].Cells[4].Text.Trim();

                        if (statusDropDownList.SelectedValue == "")
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product ID [" + productTransferRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no status selected.";
                            return;
                        }

                        dr = dt.NewRow();
                        dr["ProductId"] = productTransferRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ApprovedQuantity"] = approveQuantityTextBox.Text.Trim();
                        dr["Status"] = statusDropDownList.SelectedValue.Trim();
                        dr["Narration"] = narrationTextBox.Text.Trim();
                        dr["FreeQuantityWas"] = freeQtyWas.Trim();
                        dt.Rows.Add(dr);
                    }

                    if (dt.Rows.Count == productTransferRequisitionProductListGridView.Rows.Count)
                    {
                        ProductTransferRequisitionBLL productTransferRequisition = new ProductTransferRequisitionBLL();

                        productTransferRequisition.TransferRequisitionId = idLabel.Text.Trim();
                        productTransferRequisition.TransferFrom = transferFromIdLabel.Text.Trim();
                        productTransferRequisition.TransferTo = transferToIdLabel.Text.Trim();
                        productTransferRequisition.TransferType = transferTypeLabel.Text.Trim();

                        string msg = productTransferRequisition.ApproveTransferRequisitionAndCreateTransferOrder(dt);

                        MyAlertBox("alert(\"" + msg + " \"); window.location=\"/UI/ProductTransferRequisition/ApprovalRequisitionList.aspx\"");
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Collected Data Count Mismatch!!!"; msgDetailLabel.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}