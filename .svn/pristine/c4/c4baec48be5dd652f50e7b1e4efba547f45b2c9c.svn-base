using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductGroup
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                if (!IsPostBack)
                {
                    LoadSalesCenter();
                    LoadWarehouses();
                    productGroupNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
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


        protected void saveButton_Click(object sender, EventArgs e)
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();
            int isaddanother = 1;

            Button btn = (Button)sender;
            if (btn.Text == "Save")
            {
                isaddanother = 0;
            }


            try
            {
                if (productGroupNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Product Group Name field is required.";
                }
                //else if (descriptionTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                //}
                else
                {
                    productGroup.ProductGroupName = productGroupNameTextBox.Text.Trim();
                    productGroup.Description = descriptionTextBox.Text.Trim();
                    productGroup.warehouse = warehouseDropDownList.SelectedValue;
                    productGroup.salescenter = salescenterDropDownList.SelectedValue;

                    if (!productGroup.CheckDuplicateProductGroup(productGroup.ProductGroupName.Trim(), productGroup.warehouse, productGroup.salescenter))
                    {
                        DataTable dt = productGroup.SaveProductGroup();

                        if (dt.Rows.Count > 0)
                        {
                            if (isaddanother == 0)
                            {
                                string message =
                                    "Product Group <span class='actionTopic'>Created</span> Successfully with Product Group ID: <span class='actionTopic'>" +
                                    dt.Rows[0][0].ToString() + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/ProductGroup/List.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                            else
                            {
                                string message =
                                    "Product Group <span class='actionTopic'>Created</span> Successfully with Product Group ID: <span class='actionTopic'>" +
                                    dt.Rows[0][0].ToString() + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/ProductGroup/Create.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Product Group.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Product Group <span class='actionTopic'>already exist</span>, try another one.";
                        MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
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
    }
}