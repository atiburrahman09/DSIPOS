using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserPrivilege
{
    public partial class SetUserWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    GetWarehouseList();
                    LoadUserInfoAndWarehouseList(LumexSessionManager.Get("UserIdForSetWarehouse").ToString().Trim());
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

        protected void GetWarehouseList()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetWarehouseList();

                if (dt.Rows.Count > 0)
                {
                    warehouseListListBox.Items.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        warehouseListListBox.Items.Add(new ListItem(dt.Rows[i]["WarehouseName"].ToString(), dt.Rows[i]["WarehouseId"].ToString()));
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Warehouse List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                countWarehouseLabel.Text = "Total: " + warehouseListListBox.Items.Count.ToString();
            }
        }

        protected void LoadUserInfoAndWarehouseList(string userId)
        {
            UserBLL user = new UserBLL();
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);

                if (dt.Rows.Count > 0)
                {
                    userIdLabel.Text = dt.Rows[0]["UserId"].ToString();
                    userNameLabel.Text = dt.Rows[0]["UserName"].ToString();
                    employeeIdLabel.Text = dt.Rows[0]["EmployeeId"].ToString();
                    userGroupNameLabel.Text = dt.Rows[0]["UserGroupName"].ToString();
                    activeStatusLabel.Text = dt.Rows[0]["IsActive"].ToString();

                    userWarehouseListListBox.Items.Clear();
                    DataTable dtWarehouse = warehouse.GetUserWarehousesByUserId(userIdLabel.Text.Trim());

                    for (int i = 0; i < dtWarehouse.Rows.Count; i++)
                    {
                        userWarehouseListListBox.Items.Add(new ListItem(dtWarehouse.Rows[i]["WarehouseName"].ToString(), dtWarehouse.Rows[i]["WarehouseId"].ToString()));
                    }

                    userPriviligePane.Visible = true;
                }
                else
                {
                    userPriviligePane.Visible = false;
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
                warehouse = null;
                countUserWarehouseLabel.Text = "Total: " + userWarehouseListListBox.Items.Count.ToString();
            }
        }

        protected void removeAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (userWarehouseListListBox.Items.Count > 0)
                {
                    userWarehouseListListBox.Items.Clear();
                    countUserWarehouseLabel.Text = "Total: " + userWarehouseListListBox.Items.Count.ToString();
                }
                else
                {
                    string message = "No item(s) is found from User's Warehouse List.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void addAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (warehouseListListBox.Items.Count > 0)
                {
                    userWarehouseListListBox.Items.Clear();

                    for (int i = 0; i < warehouseListListBox.Items.Count; i++)
                    {
                        userWarehouseListListBox.Items.Add(new ListItem(warehouseListListBox.Items[i].Text, warehouseListListBox.Items[i].Value));
                    }
                }
                else
                {
                    string message = "No item(s) is found from Warehouse List.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserWarehouseLabel.Text = "Total: " + userWarehouseListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (userWarehouseListListBox.SelectedIndex > -1)
                {
                    userWarehouseListListBox.Items.RemoveAt(userWarehouseListListBox.SelectedIndex);
                }
                else
                {
                    string message = "Select an item from User's Warehouse List to remove.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserWarehouseLabel.Text = "Total: " + userWarehouseListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (warehouseListListBox.SelectedIndex > -1)
                {
                    for (int i = 0; i < userWarehouseListListBox.Items.Count; i++)
                    {
                        if (userWarehouseListListBox.Items[i].Value == warehouseListListBox.SelectedValue) { return; }
                    }

                    userWarehouseListListBox.Items.Add(new ListItem(warehouseListListBox.SelectedItem.Text, warehouseListListBox.SelectedItem.Value));
                    userWarehouseListListBox.SelectedIndex = userWarehouseListListBox.Items.Count - 1;
                }
                else
                {
                    string message = "Select an item from Warehouse List to add.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserWarehouseLabel.Text = "Total: " + userWarehouseListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            WarehouseBLL warehouse = new WarehouseBLL();
            List<string> warehouses = new List<string>();

            try
            {
                for (int i = 0; i < userWarehouseListListBox.Items.Count; i++)
                {
                    warehouses.Add(userWarehouseListListBox.Items[i].Value.Trim());
                }

                warehouse.SaveUserWarehousesByUserId(userIdLabel.Text.Trim(), warehouses);

                string message = "User's Warehouse List <span class='actionTopic'>Saved</span> Successfully.";
                MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/UserPrivilege/PrivilegeUserList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                warehouses = null;
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/UserPrivilege/PrivilegeUserList.aspx", false);
        }
    }
}