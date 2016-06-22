using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserPrivilege
{
    public partial class SetUserSalesCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    GetSalesCenterList();
                    LoadUserInfoAndSalesCenterList(LumexSessionManager.Get("UserIdForSetSalesCenter").ToString().Trim());
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

        protected void GetSalesCenterList()
        {
            SalesCenterBLL salesCenter = new SalesCenterBLL();

            try
            {
                DataTable dt = salesCenter.GetSalesCenterList();

                if (dt.Rows.Count > 0)
                {
                    salesCenterListListBox.Items.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        salesCenterListListBox.Items.Add(new ListItem(dt.Rows[i]["SalesCenterName"].ToString(), dt.Rows[i]["SalesCenterId"].ToString()));
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Sales Center List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                countSalesCenterLabel.Text = "Total: " + salesCenterListListBox.Items.Count.ToString();
            }
        }

        protected void LoadUserInfoAndSalesCenterList(string userId)
        {
            UserBLL user = new UserBLL();
            SalesCenterBLL salesCenter = new SalesCenterBLL();

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

                    userSalesCenterListListBox.Items.Clear();
                    DataTable dtSalesCenter = salesCenter.GetUserSalesCentersByUserId(userIdLabel.Text.Trim());

                    for (int i = 0; i < dtSalesCenter.Rows.Count; i++)
                    {
                        userSalesCenterListListBox.Items.Add(new ListItem(dtSalesCenter.Rows[i]["SalesCenterName"].ToString(), dtSalesCenter.Rows[i]["SalesCenterId"].ToString()));
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
                salesCenter = null;
                countUserSalesCenterLabel.Text = "Total: " + userSalesCenterListListBox.Items.Count.ToString();
            }
        }

        protected void removeAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (userSalesCenterListListBox.Items.Count > 0)
                {
                    userSalesCenterListListBox.Items.Clear();
                    countUserSalesCenterLabel.Text = "Total: " + userSalesCenterListListBox.Items.Count.ToString();
                }
                else
                {
                    string message = "No item(s) is found from User's Sales Center List.";
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
                if (salesCenterListListBox.Items.Count > 0)
                {
                    userSalesCenterListListBox.Items.Clear();

                    for (int i = 0; i < salesCenterListListBox.Items.Count; i++)
                    {
                        userSalesCenterListListBox.Items.Add(new ListItem(salesCenterListListBox.Items[i].Text, salesCenterListListBox.Items[i].Value));
                    }
                }
                else
                {
                    string message = "No item(s) is found from Sales Center List.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserSalesCenterLabel.Text = "Total: " + userSalesCenterListListBox.Items.Count.ToString();
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
                if (userSalesCenterListListBox.SelectedIndex > -1)
                {
                    userSalesCenterListListBox.Items.RemoveAt(userSalesCenterListListBox.SelectedIndex);
                }
                else
                {
                    string message = "Select an item from User's Sales Center List to remove.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserSalesCenterLabel.Text = "Total: " + userSalesCenterListListBox.Items.Count.ToString();
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
                if (salesCenterListListBox.SelectedIndex > -1)
                {
                    for (int i = 0; i < userSalesCenterListListBox.Items.Count; i++)
                    {
                        if (userSalesCenterListListBox.Items[i].Value == salesCenterListListBox.SelectedValue) { return; }
                    }

                    userSalesCenterListListBox.Items.Add(new ListItem(salesCenterListListBox.SelectedItem.Text, salesCenterListListBox.SelectedItem.Value));
                    userSalesCenterListListBox.SelectedIndex = userSalesCenterListListBox.Items.Count - 1;
                }
                else
                {
                    string message = "Select an item from Sales Center List to add.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserSalesCenterLabel.Text = "Total: " + userSalesCenterListListBox.Items.Count.ToString();
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
            SalesCenterBLL salesCenter = new SalesCenterBLL();
            List<string> salesCenters = new List<string>();

            try
            {
                for (int i = 0; i < userSalesCenterListListBox.Items.Count; i++)
                {
                    salesCenters.Add(userSalesCenterListListBox.Items[i].Value.Trim());
                }

                salesCenter.SaveUserSalesCentersByUserId(userIdLabel.Text.Trim(), salesCenters);

                string message = "User's Sales Center List <span class='actionTopic'>Saved</span> Successfully.";
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
                salesCenter = null;
                salesCenters = null;
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/UserPrivilege/PrivilegeUserList.aspx", false);
        }
    }
}