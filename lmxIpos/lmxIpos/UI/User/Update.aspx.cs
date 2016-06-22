using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.User
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
                    LoadUserGroups();
                    LoadSalesCenters();
                    LoadWarehouses();

                    idLabel.Text = userIdForUpdateHiddenField.Value = LumexSessionManager.Get("UserIdForUpdate").ToString().Trim();
                    GetUserById(userIdForUpdateHiddenField.Value.Trim());
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


        protected void LoadSalesCenters()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetActiveSalesCenterListByUser();

                salesCenterDropDownList.DataSource = dt;
                salesCenterDropDownList.DataValueField = "SalesCenterId";
                salesCenterDropDownList.DataTextField = "SalesCenterName";
                salesCenterDropDownList.DataBind();
                salesCenterDropDownList.Items.Insert(0, "Please Select");
                salesCenterDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Joining Sales Center Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void LoadUserGroups()
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                DataTable dt = userGroup.GetActiveUserGroupList();

                userGroupDropDownList.DataSource = dt;
                userGroupDropDownList.DataValueField = "UserGroupId";
                userGroupDropDownList.DataTextField = "UserGroupName";
                userGroupDropDownList.DataBind();
                userGroupDropDownList.Items.Insert(0, "Please Select");
                userGroupDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "User Group Data Not Found!!!"; msgDetailLabel.Text = "";
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
                userGroup = null;
            }
        }

        protected void GetUserById(string userId)
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);

                if (dt.Rows.Count > 0)
                {
                    userIdTextBox.Text = dt.Rows[0]["UserId"].ToString();
                    userNameTextBox.Text = dt.Rows[0]["UserName"].ToString();
                  //  employeeIdTextBox.Text = dt.Rows[0]["EmployeeId"].ToString();
                    salesCenterDropDownList.SelectedValue = dt.Rows[0]["SalesCenterId"].ToString();
                    warehouseDropDownList.SelectedValue = dt.Rows[0]["WarehouseId"].ToString();
                    //   designationTextBox.Text = dt.Rows[0]["Designation"].ToString();
                    addressTextBox.Text = dt.Rows[0]["Address"].ToString();
                    contactNumberTextBox.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailTextBox.Text = dt.Rows[0]["Email"].ToString();

                  //  nationalIdTextBox.Text = dt.Rows[0]["NationalId"].ToString();
                   // passportNumberTextBox.Text = dt.Rows[0]["PassportNumber"].ToString();
                    userGroupDropDownList.SelectedValue = dt.Rows[0]["UserGroupId"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "User Data Not Found!!!"; msgDetailLabel.Text = "";
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
                user = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            UserBLL user = new UserBLL();

            try
            {
                if (userIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "User not found to update.";
                }
                if (userIdTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User ID field is required.";
                }
                else if (userNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Name field is required.";
                }
                else if (userGroupDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group field is required.";
                }
                //else if (salesCenterDropDownList.SelectedValue == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Sales Center field is required.";
                //}
                //else if (contactNumberTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Contact Number field is required.";
                //}
                //else if (emailTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Email field is required.";
                //}
                //else if (addressTextBox.Text == "")
                //{
                //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                //}
                else
                {
                    user.UserId = userIdTextBox.Text.Trim();
                    user.UserName = userNameTextBox.Text.Trim();
                    user.EmployeeId = "";
                    user.Department = "";
                    user.SalesCenterId = salesCenterDropDownList.SelectedValue;
                    user.warehouseId = warehouseDropDownList.SelectedValue;
                    user.Designation = "";
                    user.Address = addressTextBox.Text.Trim();
                    user.ContactNumber = contactNumberTextBox.Text.Trim();
                    user.Email = emailTextBox.Text.Trim();
                    user.NationalId =""; //nationalIdTextBox.Text.Trim();
                    user.PassportNumber = "";//passportNumberTextBox.Text.Trim();
                    user.UserGroupId = userGroupDropDownList.SelectedValue.Trim();

                    user.UpdateUser();

                    userIdForUpdateHiddenField.Value = "";

                    string message = "User <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/User/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                user = null;
            }
        }
    }
}