using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.PurchaseRequisition
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
                    idLabel.Text = purchaseRequisitionIdForApproveHiddenField.Value = LumexSessionManager.Get("PurchaseRequisitionIdForApprove").ToString().Trim();
                    GetPurchaseRequisitionById(purchaseRequisitionIdForApproveHiddenField.Value.Trim());
                    GetPurchaseRequisitionProductListById(purchaseRequisitionIdForApproveHiddenField.Value.Trim());
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
                        approveButton.Enabled = true;
                        purchaseRequisitionProductListGridView.UseAccessibleHeader = true;
                        purchaseRequisitionProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                        TextBox approveQuantityTextBox;
                        DropDownList vendorDropDownList;

                        VendorBLL vendor = new VendorBLL();
                        DataTable dtVendor;

                        for (int i = 0; i < purchaseRequisitionProductListGridView.Rows.Count; i++)
                        {
                            approveQuantityTextBox = (TextBox)purchaseRequisitionProductListGridView.Rows[i].FindControl("approveQuantityTextBox");
                            //approveQuantityTextBox.Text = purchaseRequisitionProductListGridView.Rows[i].Cells[3].Text.ToString();
                            approveQuantityTextBox.Text = dt.Rows[i][3].ToString();

                            dtVendor = vendor.GetProductVendorsByProductId(purchaseRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString());
                            vendorDropDownList = (DropDownList)purchaseRequisitionProductListGridView.Rows[i].FindControl("vendorDropDownList");
                            vendorDropDownList.DataSource = dtVendor;
                            vendorDropDownList.DataValueField = "VendorId";
                            vendorDropDownList.DataTextField = "VendorName";
                            vendorDropDownList.DataBind();
                            vendorDropDownList.Items.Insert(0, "");
                            vendorDropDownList.SelectedIndex = 0;
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
                purchaseRequisition = null;
            }
        }

        protected void approveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (purchaseRequisitionProductListGridView.Rows.Count > 0)
                {
                    TextBox approveQuantityTextBox;
                    int num; bool isApproveQuantityNum;
                    DropDownList vendorDropDownList;
                    DropDownList statusDropDownList;
                    TextBox narrationTextBox;

                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("ProductId"));
                    dt.Columns.Add(new DataColumn("ApprovedQuantity"));
                    dt.Columns.Add(new DataColumn("VendorId"));
                    dt.Columns.Add(new DataColumn("Status"));
                    dt.Columns.Add(new DataColumn("Narration"));

                    for (int i = 0; i < purchaseRequisitionProductListGridView.Rows.Count; i++)
                    {
                        approveQuantityTextBox = (TextBox)purchaseRequisitionProductListGridView.Rows[i].FindControl("approveQuantityTextBox");
                        isApproveQuantityNum = int.TryParse(approveQuantityTextBox.Text.Trim(), out num);
                        vendorDropDownList = (DropDownList)purchaseRequisitionProductListGridView.Rows[i].FindControl("vendorDropDownList");
                        statusDropDownList = (DropDownList)purchaseRequisitionProductListGridView.Rows[i].FindControl("statusDropDownList");
                        narrationTextBox = (TextBox)purchaseRequisitionProductListGridView.Rows[i].FindControl("narrationTextBox");

                        if (statusDropDownList.SelectedValue == "")
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product ID [" + purchaseRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no status selected.";
                            return;
                        }
                        else if (statusDropDownList.SelectedValue == "A")
                        {
                            if (string.IsNullOrEmpty(approveQuantityTextBox.Text.Trim()) || !isApproveQuantityNum)
                            {
                                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product ID [" + purchaseRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no valid approved quantity.";
                                return;
                            }
                            else if (vendorDropDownList.SelectedValue == "")
                            {
                                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product ID [" + purchaseRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString() + "] has no vendor selected.";
                                return;
                            }
                        }

                        dr = dt.NewRow();
                        dr["ProductId"] = purchaseRequisitionProductListGridView.Rows[i].Cells[0].Text.ToString();
                        dr["ApprovedQuantity"] = approveQuantityTextBox.Text.Trim();
                        dr["VendorId"] = vendorDropDownList.SelectedValue.Trim();
                        dr["Status"] = statusDropDownList.SelectedValue.Trim();
                        dr["Narration"] = narrationTextBox.Text.Trim();
                        dt.Rows.Add(dr);
                    }

                    if (dt.Rows.Count == purchaseRequisitionProductListGridView.Rows.Count)
                    {
                        PurchaseRequisitionBLL purchaseRequisition = new PurchaseRequisitionBLL();
                        string msg = purchaseRequisition.ApprovePurchaseRequisitionAndCreatePurchaseOrder(dt, idLabel.Text.Trim(), warehouseIdLabel.Text.Trim());

                        MyAlertBox("alert(\"" + msg + " \"); window.location=\"/UI/PurchaseRequisition/ApprovalRequisitionList.aspx\"");
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