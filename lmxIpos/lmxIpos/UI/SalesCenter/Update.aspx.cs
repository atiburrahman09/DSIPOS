using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesCenter
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
                    LoadWarehouses();
                    salesCenterNameTextBox.Focus();

                    idLabel.Text = salesCenterIdForUpdateHiddenField.Value = LumexSessionManager.Get("SalesCenterIdForUpdate").ToString().Trim();
                    GetSalesCenterById(salesCenterIdForUpdateHiddenField.Value.Trim());
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
                DataTable dt = warehouse.GetActiveWarehouseList();

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "");
                warehouseDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void GetSalesCenterById(string salesCenterId)
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetSalesCenterById(salesCenterId);

                if (dt.Rows.Count > 0)
                {
                    salesCenterNameForUpdateHiddenField.Value = salesCenterNameTextBox.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    countryTextBox.Text = dt.Rows[0]["Country"].ToString();
                    cityTextBox.Text = dt.Rows[0]["City"].ToString();
                    //districtTextBox.Text = dt.Rows[0]["District"].ToString();
                    //postalCodeTextBox.Text = dt.Rows[0]["PostalCode"].ToString();
                    phoneTextBox.Text = dt.Rows[0]["Phone"].ToString();
                    mobileTextBox.Text = dt.Rows[0]["Mobile"].ToString();
                    faxTextBox.Text = dt.Rows[0]["Fax"].ToString();
                    emailTextBox.Text = dt.Rows[0]["Email"].ToString();
                    addressTextBox.Text = dt.Rows[0]["Address"].ToString();

                    warehouseDropDownList.SelectedValue = dt.Rows[0]["WarehouseId"].ToString();
                    if (warehouseDropDownList.SelectedValue != dt.Rows[0]["WarehouseId"].ToString())
                    {
                        warehouseDropDownList.Items.Insert(1, new ListItem(dt.Rows[0]["WarehouseName"].ToString(), dt.Rows[0]["WarehouseId"].ToString()));
                        warehouseDropDownList.SelectedIndex = 1;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
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
                salesCenter = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                if (salesCenterIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Sales Center not found to update.";
                }
                else if (salesCenterNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Sales Center Name field is required.";
                }
                //else if (emailTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Email field is required.";
                //}
                else if (addressTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                }
                else if (warehouseDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else
                {
                    salesCenter.SalesCenterId = salesCenterIdForUpdateHiddenField.Value.Trim();
                    salesCenter.SalesCenterName = salesCenterNameTextBox.Text.Trim();
                    salesCenter.Address = addressTextBox.Text.Trim();
                    salesCenter.Country = countryTextBox.Text.Trim();
                    salesCenter.City = cityTextBox.Text.Trim();
                    salesCenter.District = "";
                    salesCenter.PostalCode = "";
                    salesCenter.Phone = phoneTextBox.Text.Trim();
                    salesCenter.Mobile = mobileTextBox.Text.Trim();
                    salesCenter.Fax = faxTextBox.Text.Trim();
                    salesCenter.Email = emailTextBox.Text.Trim();
                    salesCenter.WarehouseId = warehouseDropDownList.SelectedValue.Trim();

                    if (!salesCenter.CheckDuplicateSalesCenter(salesCenterNameTextBox.Text.Trim()))
                    {
                        salesCenter.UpdateSalesCenter();

                        salesCenterNameForUpdateHiddenField.Value = "";
                        salesCenterIdForUpdateHiddenField.Value = "";

                        string message = "Sales Center <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesCenter/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (salesCenterNameForUpdateHiddenField.Value == salesCenterNameTextBox.Text.Trim())
                        {
                            salesCenter.SalesCenterName = "WithOut";
                            salesCenter.UpdateSalesCenter();

                            salesCenterNameForUpdateHiddenField.Value = "";
                            salesCenterIdForUpdateHiddenField.Value = "";

                            string message = "Sales Center <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesCenter/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "This Sales Center <span class='actionTopic'>already exist</span>, try another one.";
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
                salesCenter = null;
            }
        }
    }
}