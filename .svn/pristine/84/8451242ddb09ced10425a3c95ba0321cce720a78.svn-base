using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductRequisition
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
                    idLabel.Text = productRequisitionIdForApproveHiddenField.Value = LumexSessionManager.Get("ProductRequisitionIdForApprove").ToString().Trim();
                    GetProductRequisitionById(productRequisitionIdForApproveHiddenField.Value.Trim());
                    GetProductRequisitionProductListById(productRequisitionIdForApproveHiddenField.Value.Trim(), reqTypelabel.Text);
                }

                if (productRequisitionProductListGridView.Rows.Count > 0)
                {
                    productRequisitionProductListGridView.UseAccessibleHeader = true;
                    productRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetProductRequisitionById(string productRequisitionId)
        {
            ProductRequisitionBLL productRequisition = new ProductRequisitionBLL();
            spanreqsc.Attributes.Remove("class");
            spanreqwh.Attributes.Remove("class");

            try
            {
                DataTable dt = productRequisition.GetProductRequisitionById(productRequisitionId);

                if (dt.Rows.Count > 0)
                {
                    requisitionDateLabel.Text = dt.Rows[0]["RequisitionDate"].ToString();
                    salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                    salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    warehouseIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                    warehouseNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    narrationLabel.Text = dt.Rows[0]["Narration"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();
                    lblCreatedBy.Text = dt.Rows[0]["CreatedUser"].ToString();
                    reqTypelabel.Text = dt.Rows[0]["RequisitionType"].ToString();
                    if (reqTypelabel.Text == "WH-SC")
                    {

                        spanreqwh.Attributes.Add("class", "text-error icon icon-upload");
                        spanreqsc.Attributes.Add("class", "text-success icon icon-download-alt");
                    }
                    else if (reqTypelabel.Text == "SC-WH")
                    {
                        spanreqsc.Attributes.Add("class", "text-error icon icon-upload");
                        spanreqwh.Attributes.Add("class", "text-success icon icon-download-alt");
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
                productRequisition = null;
            }
        }

        protected void GetProductRequisitionProductListById(string productRequisitionId, string reqType)
        {
            ProductRequisitionBLL productRequisition = new ProductRequisitionBLL();

            try
            {
                DataTable dt = productRequisition.GetProductRequisitionProductListById(productRequisitionId, reqType);

                if (dt.Rows.Count > 0)
                {
                    productRequisitionProductListGridView.DataSource = dt;
                    productRequisitionProductListGridView.DataBind();

                    if (productRequisitionProductListGridView.Rows.Count > 0)
                    {
                        approveButton.Enabled = true;
                        productRequisitionProductListGridView.UseAccessibleHeader = true;
                        productRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        TextBox approveQuantityTextBox;

                        for (int i = 0; i < productRequisitionProductListGridView.Rows.Count; i++)
                        {
                            approveQuantityTextBox = (TextBox)productRequisitionProductListGridView.Rows[i].FindControl("approveQuantityTextBox");
                            //approveQuantityTextBox.Text = productRequisitionProductListGridView.Rows[i].Cells[3].Text.ToString();
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
                productRequisition = null;
            }
        }

        protected void approveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productRequisitionProductListGridView.Rows.Count > 0)
                {
                    TextBox approveQuantityTextBox;
                    decimal num; bool isApproveQuantityNum;
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

                    for (int i = 0; i < productRequisitionProductListGridView.Rows.Count; i++)
                    {
                        approveQuantityTextBox = (TextBox)productRequisitionProductListGridView.Rows[i].FindControl("approveQuantityTextBox");
                        isApproveQuantityNum = decimal.TryParse(approveQuantityTextBox.Text.Trim(), out num);
                        statusDropDownList = (DropDownList)productRequisitionProductListGridView.Rows[i].FindControl("statusDropDownList");
                        narrationTextBox = (TextBox)productRequisitionProductListGridView.Rows[i].FindControl("narrationTextBox");
                        freeQtyWas = productRequisitionProductListGridView.Rows[i].Cells[4].Text.Trim();

                        if (statusDropDownList.SelectedValue == "")
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product ID [" + productRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no status selected.";
                            return;
                        }

                        dr = dt.NewRow();
                        dr["ProductId"] = productRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ApprovedQuantity"] = num.ToString();//approveQuantityTextBox.Text.Trim();
                        dr["Status"] = statusDropDownList.SelectedValue.Trim();
                        dr["Narration"] = narrationTextBox.Text.Trim();
                        dr["FreeQuantityWas"] = freeQtyWas.Trim();
                        dt.Rows.Add(dr);
                    }

                    if (dt.Rows.Count == productRequisitionProductListGridView.Rows.Count)
                    {
                        ProductRequisitionBLL productRequisition = new ProductRequisitionBLL();

                        string productRequisitionId = idLabel.Text.Trim();
                        string transferFrom = "";
                        string transferTo = "";
                        if (reqTypelabel.Text == "WH-SC")
                        {


                            transferFrom = warehouseIdLabel.Text.Trim();
                            transferTo = salesCenterIdLabel.Text.Trim();

                        }
                        else if (reqTypelabel.Text == "SC-WH")
                        {
                            transferTo = warehouseIdLabel.Text.Trim();
                            transferFrom = salesCenterIdLabel.Text.Trim();
                        }
                        string transferType = reqTypelabel.Text;

                        string msg = productRequisition.ApproveTransferRequisitionAndCreateTransferOrder(dt, productRequisitionId, transferFrom, transferTo, transferType);

                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/ProductRequisition/ApprovalRequisitionList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + msg + "\", callbackOk);");
                        //MyAlertBox("alert(\"" + msg + " \"); window.location=\"/UI/ProductRequisition/ApprovalRequisitionList.aspx\"");
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Collected Data Count Mismatch!!!"; msgDetailLabel.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                // msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}