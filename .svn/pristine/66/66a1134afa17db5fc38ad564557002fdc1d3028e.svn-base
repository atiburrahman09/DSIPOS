using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Vendor
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
                    vendorNameTextBox.Focus();
                    LoadWarehouses();
                    LoadSalesCenter();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + "Something goes wrong!! Try later."; }
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
                salescenterDropDownList.Items[0].Value = "A";
                salescenterDropDownList.SelectedValue = LumexSessionManager.Get("UserSalesCenterId").ToString();


                //warehouseDropDownList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

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
            VendorBLL vendor = new VendorBLL();
            int isaddanother = 1;
            Button btn = (Button)sender;
            if (btn.Text == "Save")
            {
                isaddanother = 0;
            }
            try
            {
                if (vendorNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Vendor Name field is required.";
                }
                else if (addressTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                }
                else
                {
                    vendor.VendorName = vendorNameTextBox.Text.Trim();
                    vendor.Address = addressTextBox.Text.Trim();
                    vendor.Country = countryTextBox.Text.Trim();
                    vendor.City = cityTextBox.Text.Trim();
                    vendor.District = "";//districtTextBox.Text.Trim();
                    vendor.PostalCode = "";// postalCodeTextBox.Text.Trim();
                    vendor.Phone = phoneTextBox.Text.Trim();
                    vendor.Mobile = "";//mobileTextBox.Text.Trim();
                    vendor.Fax = "";//faxTextBox.Text.Trim();
                    vendor.Email = emailTextBox.Text.Trim();
                    vendor.salescenter = salescenterDropDownList.SelectedValue;
                    vendor.warehouse = warehouseDropDownList.SelectedValue;

                    if (!vendor.CheckDuplicateVendor(vendor.VendorName, vendor.warehouse, vendor.salescenter))
                    {
                        DataTable dt = vendor.SaveVendor();

                        if (dt.Rows.Count > 0)
                        {
                            if (isaddanother == 0)
                            {
                                string message = "Vendor <span class='actionTopic'>Created</span> Successfully with Vendor ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Vendor/List.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                            }
                            else
                            {
                                string message = "Vendor <span class='actionTopic'>Created</span> Successfully with Vendor ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Vendor/Create.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Vendor.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Vendor <span class='actionTopic'>already exist</span>, try another one.";
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
                vendor = null;
            }
        }
    }
}