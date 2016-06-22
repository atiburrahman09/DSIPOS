using System;
using System.Data;
using System.Web.UI;
using System.Data;
using Lumex.Tech;
using Lumex.Project.BLL;

namespace lmxIpos.UI.SalesCenter
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
                    LoadWarehouses();
                    salesCenterNameTextBox.Focus();
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
                DataTable dt = warehouse.GetUserWarehousesByUserId((string)LumexSessionManager.Get("ActiveUserId"));

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "");
                warehouseDropDownList.SelectedIndex = 0;
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
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                if (salesCenterNameTextBox.Text == "")
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

                    if (!salesCenter.CheckDuplicateSalesCenter(salesCenter.SalesCenterName))
                    {
                        DataTable dt = salesCenter.SaveSalesCenter();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "Sales Center <span class='actionTopic'>Created</span> Successfully with Sales Center ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/SalesCenter/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Sales Center.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Sales Center <span class='actionTopic'>already exist</span>, try another one.";
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
                salesCenter = null;
            }
        }
    }
}