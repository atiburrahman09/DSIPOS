using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;
using System.Web.UI.WebControls;

namespace lmxIpos.UI.ProductGroup
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = productGroupIdForUpdateHiddenField.Value = LumexSessionManager.Get("ProductGroupIdForUpdate").ToString().Trim();
                  
                    LoadSalesCenter();
                    LoadWarehouses();
                    GetProductGroupById(productGroupIdForUpdateHiddenField.Value.Trim());

                    productGroupNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                updateButton.Enabled = false;

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void LoadWarehouses()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "For all Warehouse");
                warehouseDropDownList.SelectedIndex = 0;
                warehouseDropDownList.Items[0].Value = "A";
                warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                warehouse = null;
            }
        }
        protected void LoadSalesCenter()
        {
            SalesCenterBLL warehouse = new SalesCenterBLL();

            try
            {
                DataTable dt = warehouse.GetActiveSalesCenterListByUser();

                salescenterDropDownList.DataSource = dt;
                salescenterDropDownList.DataValueField = "SalesCenterId";
                salescenterDropDownList.DataTextField = "SalesCenterName";
                salescenterDropDownList.DataBind();
                salescenterDropDownList.Items.Insert(0, "For all Sales Center");
                salescenterDropDownList.SelectedIndex = 0;

                  salescenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();

                salescenterDropDownList.Items[0].Value = "A";

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                warehouse = null;
            }
        }


        protected void GetProductGroupById(string productGroupId)
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                DataTable dt = productGroup.GetProductGroupById(productGroupId);

                if (dt.Rows.Count > 0)
                {
                    productGroupNameForUpdateHiddenField.Value = productGroupNameTextBox.Text = dt.Rows[0]["ProductGroupName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["Description"].ToString();
                    ListItem listItem = new ListItem();
                    listItem = warehouseDropDownList.Items.FindByValue(dt.Rows[0]["WareHouse"].ToString());

                    if (listItem != null)
                    {
                        warehouseDropDownList.SelectedValue = dt.Rows[0]["WareHouse"].ToString();
                    }
                    else
                    {
                        warehouseDropDownList.Items.Insert(0, "Not Parmitted");
                        warehouseDropDownList.Items[0].Value = dt.Rows[0]["WareHouse"].ToString();
                        warehouseDropDownList.SelectedIndex = 0;
                        warehouseDropDownList.Enabled = false;
                        updateButton.Enabled = false;
                    }
                    listItem = salescenterDropDownList.Items.FindByValue(dt.Rows[0]["SalesCenter"].ToString());
                    if (listItem != null)
                    {
                        salescenterDropDownList.SelectedValue = dt.Rows[0]["SalesCenter"].ToString();
                    }
                    else
                    {
                        salescenterDropDownList.Items.Insert(0, "Not Parmitted");
                        salescenterDropDownList.Items[0].Value = dt.Rows[0]["SalesCenter"].ToString();
                        salescenterDropDownList.SelectedIndex = 0;
                        salescenterDropDownList.Enabled = false;
                        updateButton.Enabled = false;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Group Data Not Found!!!"; msgDetailLabel.Text = "";
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
                productGroup = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                if (productGroupIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Product Group not found to update.";
                }
                else if (productGroupNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Group Name field is required.";
                }
                else if (descriptionTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    productGroup.ProductGroupId = productGroupIdForUpdateHiddenField.Value.Trim();
                    productGroup.ProductGroupName = productGroupNameTextBox.Text.Trim();
                    productGroup.Description = descriptionTextBox.Text.Trim();
                    productGroup.warehouse = warehouseDropDownList.SelectedValue;
                    productGroup.salescenter = salescenterDropDownList.SelectedValue;

                    if (!productGroup.CheckDuplicateProductGroup(productGroupNameTextBox.Text.Trim(),warehouseDropDownList.SelectedValue,salescenterDropDownList.SelectedValue))
                    {
                        productGroup.UpdateProductGroup();

                        productGroupNameForUpdateHiddenField.Value = "";
                        productGroupIdForUpdateHiddenField.Value = "";

                        string message = "Product Group <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/ProductGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (productGroupNameForUpdateHiddenField.Value == productGroupNameTextBox.Text.Trim())
                        {
                            productGroup.ProductGroupName = "WithOut";
                            productGroup.UpdateProductGroup();

                            productGroupNameForUpdateHiddenField.Value = "";
                            productGroupIdForUpdateHiddenField.Value = "";

                            string message = "Product Group <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/ProductGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "This Product Group <span class='actionTopic'>already exist</span>, try another one.";
                            MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                        }
                    }
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
                productGroup = null;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UI/ProductGroup/List.aspx",false);
        }
    }
}