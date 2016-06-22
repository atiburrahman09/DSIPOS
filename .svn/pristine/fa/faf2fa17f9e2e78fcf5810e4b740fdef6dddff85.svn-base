using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;

namespace lmxIpos.UI.Warehouse
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
                    warehouseNameTextBox.Focus();
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                if (warehouseNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else if (addressTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                }
                else
                {
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

                    if (!warehouse.CheckDuplicateWarehouse(warehouse.WarehouseName.Trim()))
                    {
                        DataTable dt = warehouse.SaveWarehouse();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "Warehouse <span class='actionTopic'>Created</span> Successfully with Warehouse ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Warehouse/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Warehouse.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Warehouse <span class='actionTopic'>already exist</span>, try another one.";
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
                warehouse = null;
            }
        }
    }
}