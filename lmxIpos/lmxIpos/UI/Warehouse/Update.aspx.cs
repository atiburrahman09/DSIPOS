using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Warehouse
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
                    idLabel.Text = warehouseIdForUpdateHiddenField.Value = LumexSessionManager.Get("WarehouseIdForUpdate").ToString().Trim();
                    GetWarehouseById(warehouseIdForUpdateHiddenField.Value.Trim());

                    warehouseNameTextBox.Focus();
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

        protected void GetWarehouseById(string warehouseId)
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetWarehouseById(warehouseId);

                if (dt.Rows.Count > 0)
                {
                    warehouseNameForUpdateHiddenField.Value = warehouseNameTextBox.Text = dt.Rows[0]["WarehouseName"].ToString();
                    countryTextBox.Text = dt.Rows[0]["Country"].ToString();
                    cityTextBox.Text = dt.Rows[0]["City"].ToString();
                    districtTextBox.Text = dt.Rows[0]["District"].ToString();
                    postalCodeTextBox.Text = dt.Rows[0]["PostalCode"].ToString();
                    phoneTextBox.Text = dt.Rows[0]["Phone"].ToString();
                    mobileTextBox.Text = dt.Rows[0]["Mobile"].ToString();
                    faxTextBox.Text = dt.Rows[0]["Fax"].ToString();
                    emailTextBox.Text = dt.Rows[0]["Email"].ToString();
                    addressTextBox.Text = dt.Rows[0]["Address"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Warehousr Data Not Found!!!"; msgDetailLabel.Text = "";
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
                warehouse = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                if (warehouseIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Warehouse not found to update.";
                }
                else if (warehouseNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else if (emailTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Email field is required.";
                }
                else if (addressTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                }
                else
                {
                    warehouse.WarehouseId = warehouseIdForUpdateHiddenField.Value.Trim();
                    warehouse.WarehouseName = warehouseNameTextBox.Text.Trim();
                    warehouse.Address = addressTextBox.Text.Trim();
                    warehouse.Country = countryTextBox.Text.Trim();
                    warehouse.City = cityTextBox.Text.Trim();
                    warehouse.District = districtTextBox.Text.Trim();
                    warehouse.PostalCode = postalCodeTextBox.Text.Trim();
                    warehouse.Phone = phoneTextBox.Text.Trim();
                    warehouse.Mobile = mobileTextBox.Text.Trim();
                    warehouse.Fax = faxTextBox.Text.Trim();
                    warehouse.Email = emailTextBox.Text.Trim();

                    if (!warehouse.CheckDuplicateWarehouse(warehouseNameTextBox.Text.Trim()))
                    {
                        warehouse.UpdateWarehouse();

                        warehouseNameForUpdateHiddenField.Value = "";
                        warehouseIdForUpdateHiddenField.Value = "";

                        string message = "Warehouse <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Warehouse/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (warehouseNameForUpdateHiddenField.Value == warehouseNameTextBox.Text.Trim())
                        {
                            warehouse.WarehouseName = "WithOut";
                            warehouse.UpdateWarehouse();

                            warehouseNameForUpdateHiddenField.Value = "";
                            warehouseIdForUpdateHiddenField.Value = "";

                            string message = "Warehouse <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Warehouse/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "This Warehouse <span class='actionTopic'>already exist</span>, try another one.";
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
                warehouse = null;
            }
        }
    }
}