using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserPrivilege
{
    public partial class SetUserGroupMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                userGroupDropDownList.Focus();

                if (!IsPostBack)
                {
                    LoadUserGroups();
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
                userGroupDropDownList.Items.Insert(0, "");
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

        private void PopulateUserMenu()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dtUserMenu = appMenu.GetUserGroupMenuData(userGroupIdForSetMenuHiddenField.Value.Trim(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());
                DataTable dtAllMenu = appMenu.GetAllMenusForMappingUserMenu(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());
                DataRow dr = null;

                //for (int i = 0; i < dtUserMenu.Rows.Count; i++)
                //{
                //    if (dtUserMenu.Rows[i]["IsDisplay"].ToString() == "False")
                //    {
                //        dtUserMenu.Rows.RemoveAt(i);
                //        i--;
                //    }
                //}

                for (int i = 0; i < dtUserMenu.Rows.Count; i++)
                {
                    for (int j = 0; j < dtAllMenu.Rows.Count; j++)
                    {
                        if (dtUserMenu.Rows[i]["ParentMenuId"].ToString() == dtAllMenu.Rows[j]["MenuId"].ToString())
                        {
                            dr = dtUserMenu.NewRow();

                            dr["MenuId"] = dtAllMenu.Rows[j]["MenuId"].ToString();
                            dr["MenuName"] = dtAllMenu.Rows[j]["MenuName"].ToString();
                            dr["ToolTipDescription"] = dtAllMenu.Rows[j]["ToolTipDescription"].ToString();
                            dr["ParentMenuId"] = dtAllMenu.Rows[j]["ParentMenuId"].ToString();
                            dr["URL"] = dtAllMenu.Rows[j]["URL"].ToString();
                            dr["MenuSorting"] = dtAllMenu.Rows[j]["MenuSorting"].ToString();
                            dr["DisplayName"] = dtAllMenu.Rows[j]["DisplayName"].ToString();
                            dr["ImageURL"] = dtAllMenu.Rows[j]["ImageURL"].ToString();
                            dr["MenuTarget"] = dtAllMenu.Rows[j]["MenuTarget"].ToString();

                            dtUserMenu.Rows.Add(dr);
                        }
                    }
                }

                ///////////////////////////////to convert column data type////////////////////////////////
                //DataTable dtCloned = dtUserMenu.Clone();
                //dtCloned.Columns["UserMenuSorting"].DataType = typeof(Int32);
                //foreach (DataRow row in dtUserMenu.Rows)
                //{
                //    dtCloned.ImportRow(row);
                //}

                dtUserMenu = dtUserMenu.DefaultView.ToTable(true, "MenuId", "MenuName", "ToolTipDescription", "ParentMenuId", "URL", "MenuSorting", "DisplayName", "MenuTarget", "ImageURL");
                dtUserMenu.DefaultView.Sort = "MenuSorting";
                dtUserMenu = dtUserMenu.DefaultView.ToTable();

                ///////////////////////////////to sort by column(s)///////////////////////////////////////
                //if (dtUserMenu.Rows.Count > 0)
                //{
                //    DataView dv = dtUserMenu.DefaultView;
                //    dv.Sort = "UserMenuSorting";
                //    dtUserMenu = dv.ToTable();
                //}

                if (dtUserMenu.Rows.Count > 0)
                {
                    testAllMenu.Items.Clear();
                    AddTopMenuItems(dtUserMenu);
                }
                else
                {
                    //msgbox.Visible = true; msgTitleLabel.Text = "User Menu Not Found!!!"; msgDetailLabel.Text = "";
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
                appMenu = null;
            }
        }

        private void PopulateAllMenu()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetAllMenuData(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());

                if (dt.Rows.Count > 0)
                {
                    testAllMenu.Items.Clear();
                    AddTopMenuItems(dt);
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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
                appMenu = null;
            }
        }

        private void AddTopMenuItems(DataTable menuData)
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "ParentMenuId=0";

            foreach (DataRowView row in view)
            {
                MenuItem newMenuItem = new MenuItem(row["DisplayName"].ToString(), row["MenuId"].ToString());
                newMenuItem.NavigateUrl = "javascript:void(0)"; //row["URL"].ToString();
                newMenuItem.ToolTip = row["ToolTipDescription"].ToString();
                //newMenuItem.SeparatorImageUrl = "~/Content/Images/home.png";
                //newMenuItem.PopOutImageUrl = "~/Content/Images/home.png";
                newMenuItem.Target = row["MenuTarget"].ToString();
                newMenuItem.ImageUrl = row["ImageURL"].ToString();
                testAllMenu.Items.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }
        }

        private void AddChildMenuItems(DataTable menuData, MenuItem parentMenuItem)
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "ParentMenuId=" + parentMenuItem.Value;

            foreach (DataRowView row in view)
            {
                MenuItem newMenuItem = new MenuItem(row["DisplayName"].ToString(), row["MenuId"].ToString());
                newMenuItem.NavigateUrl = "javascript:void(0)"; //row["URL"].ToString();
                newMenuItem.ToolTip = row["ToolTipDescription"].ToString();
                //newMenuItem.SeparatorImageUrl = "~/Content/Images/home.png";
                //newMenuItem.PopOutImageUrl = "~/Content/Images/home.png";
                newMenuItem.Target = row["MenuTarget"].ToString();
                newMenuItem.ImageUrl = row["ImageURL"].ToString();
                parentMenuItem.ChildItems.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }
        }

        protected void allMenuImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (menuForAppDropDownList.Text == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else if (menuTypeDropDownList.Text == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                PopulateAllMenu();
            }

            MyAlertBox("MyOverlayStop();");
        }

        protected void refreshMenuImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (menuForAppDropDownList.Text == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else if (menuTypeDropDownList.Text == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                PopulateUserMenu();
            }

            MyAlertBox("MyOverlayStop();");
        }

        protected void LoadMenuApps()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuApps();

                menuForAppDropDownList.DataSource = dt;
                menuForAppDropDownList.DataValueField = "MenuForApp";
                menuForAppDropDownList.DataTextField = "MenuForApp";
                menuForAppDropDownList.DataBind();

                if (dt.Rows.Count == 1)
                {
                    menuForAppDropDownList.SelectedIndex = 0;
                    LoadMenuTypesByApp();
                }
                else
                {
                    menuForAppDropDownList.Items.Insert(0, "");
                    menuForAppDropDownList.SelectedIndex = 0;
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
                appMenu = null;
            }
        }

        protected void LoadMenuTypesByApp()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuTypesByApp(menuForAppDropDownList.SelectedValue.Trim());

                menuTypeDropDownList.DataSource = dt;
                menuTypeDropDownList.DataValueField = "MenuType";
                menuTypeDropDownList.DataTextField = "MenuType";
                menuTypeDropDownList.DataBind();

                if (dt.Rows.Count == 1)
                {
                    menuTypeDropDownList.SelectedIndex = 0;
                    LoadMenuGroupsByMenuAppAndType();
                    PopulateUserMenu();
                }
                else
                {
                    menuTypeDropDownList.Items.Insert(0, "");
                    menuTypeDropDownList.SelectedIndex = 0;
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
                appMenu = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void LoadMenuGroupsByMenuAppAndType()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupsByMenuAppAndType(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());

                menuGroupDropDownList.DataSource = dt;
                menuGroupDropDownList.DataValueField = "MenuGroupId";
                menuGroupDropDownList.DataTextField = "MenuGroupName";
                menuGroupDropDownList.DataBind();
                menuGroupDropDownList.Items.Insert(0, "");
                menuGroupDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count > 1)
                {
                    menuGroupDropDownList.SelectedIndex = 1;
                    userMenuPane.Visible = true;
                    GetMenuListToPrivilegeUser();
                    GetPrivilegedMenuByUserGroup();
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
                appMenu = null;
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            userMenuPane.Visible = false;
            menuTypeDropDownList.Items.Clear();
            menuGroupDropDownList.Items.Clear();
            testAllMenu.Items.Clear();
            groupWiseMenuListListBox.Items.Clear();
            countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserGroupMenuListListBox.Items.Clear();
            countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();

            if (menuForAppDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else
            {
                LoadMenuTypesByApp();
            }

            MyAlertBox("MyOverlayStop();");
        }

        protected void menuTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            userMenuPane.Visible = false;
            menuGroupDropDownList.Items.Clear();
            testAllMenu.Items.Clear();
            groupWiseMenuListListBox.Items.Clear();
            countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserGroupMenuListListBox.Items.Clear();
            countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();

            if (menuTypeDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                LoadMenuGroupsByMenuAppAndType();
                PopulateUserMenu();
            }

            MyAlertBox("MyOverlayStop();");
        }

        protected void menuGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupWiseMenuListListBox.Items.Clear();
            countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserGroupMenuListListBox.Items.Clear();
            countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();

            if (menuGroupDropDownList.SelectedValue == "")
            {
                userMenuPane.Visible = false;
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
            }
            else
            {
                userMenuPane.Visible = true;
                GetMenuListToPrivilegeUser();
                GetPrivilegedMenuByUserGroup();
            }

            MyAlertBox("MyOverlayStop();");
        }

        protected void GetMenuListToPrivilegeUser()
        {
            AppMenuBLL appMenuBLL = new AppMenuBLL();

            try
            {
                groupWiseMenuListListBox.Items.Clear();

                DataTable dt = appMenuBLL.GetMenuListToPrivilegeUser(LumexSessionManager.Get("ActiveUserId").ToString(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim());

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        groupWiseMenuListListBox.Items.Add(new ListItem(dt.Rows[i]["MenuName"].ToString(), dt.Rows[i]["MenuId"].ToString()));
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
                appMenuBLL = null;
                countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            }
        }

        protected void GetPrivilegedMenuByUserGroup()
        {
            AppMenuBLL appMenuBLL = new AppMenuBLL();

            try
            {
                groupWiseUserGroupMenuListListBox.Items.Clear();

                DataTable dt = appMenuBLL.GetPrivilegedMenuByUserGroup(userGroupIdForSetMenuHiddenField.Value.Trim(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim());

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        groupWiseUserGroupMenuListListBox.Items.Add(new ListItem(dt.Rows[i]["MenuName"].ToString(), dt.Rows[i]["MenuId"].ToString()));
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
                appMenuBLL = null;
                countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();
            }
        }

        protected void removeAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupWiseUserGroupMenuListListBox.Items.Count > 0)
                {
                    groupWiseUserGroupMenuListListBox.Items.Clear();
                    countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();
                }
                else
                {
                    string message = "No item(s) is found Group Wise User's Menu List.";
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
                if (groupWiseMenuListListBox.Items.Count > 0)
                {
                    groupWiseUserGroupMenuListListBox.Items.Clear();

                    for (int i = 0; i < groupWiseMenuListListBox.Items.Count; i++)
                    {
                        groupWiseUserGroupMenuListListBox.Items.Add(new ListItem(groupWiseMenuListListBox.Items[i].Text, groupWiseMenuListListBox.Items[i].Value));
                    }
                }
                else
                {
                    string message = "No item(s) is found from Group Wise Menu List.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();
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
                if (groupWiseUserGroupMenuListListBox.SelectedIndex > -1)
                {
                    groupWiseUserGroupMenuListListBox.Items.RemoveAt(groupWiseUserGroupMenuListListBox.SelectedIndex);
                }
                else
                {
                    string message = "Select an item from Group Wise User's Menu List to remove.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();
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
                if (groupWiseMenuListListBox.SelectedIndex > -1)
                {
                    for (int i = 0; i < groupWiseUserGroupMenuListListBox.Items.Count; i++)
                    {
                        if (groupWiseUserGroupMenuListListBox.Items[i].Value == groupWiseMenuListListBox.SelectedValue) { return; }
                    }

                    groupWiseUserGroupMenuListListBox.Items.Add(new ListItem(groupWiseMenuListListBox.SelectedItem.Text, groupWiseMenuListListBox.SelectedItem.Value));
                    groupWiseUserGroupMenuListListBox.SelectedIndex = groupWiseUserGroupMenuListListBox.Items.Count - 1;
                }
                else
                {
                    string message = "Select an item from Group Wise Menu List to add.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countUserMenuLabel.Text = "Total: " + groupWiseUserGroupMenuListListBox.Items.Count.ToString();
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
            AppMenuBLL appMenuBLL = new AppMenuBLL();
            List<string> userGroupPrivilegeMenus = new List<string>();

            try
            {
                if (menuForAppDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
                }
                else if (menuTypeDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
                }
                else if (menuGroupDropDownList.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
                }
                else
                {
                    for (int i = 0; i < groupWiseUserGroupMenuListListBox.Items.Count; i++)
                    {
                        userGroupPrivilegeMenus.Add(groupWiseUserGroupMenuListListBox.Items[i].Value.Trim());
                    }

                    appMenuBLL.SaveUserGroupPrivilegeMenu(userGroupIdForSetMenuHiddenField.Value.Trim(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim(), userGroupPrivilegeMenus);

                    PopulateUserMenu();
                    string message = "User Group's Menu List <span class='actionTopic'>Saved</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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
                appMenuBLL = null;
                userGroupPrivilegeMenus = null;
            }
        }

        protected void userGroupMenuListButton_Click(object sender, EventArgs e)
        {
            if (userGroupDropDownList.SelectedValue == "")
            {
                userPriviligePane.Visible = false;
                userMenuPane.Visible = false;
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group field is required.";
            }
            else
            {
                userGroupIdForSetMenuHiddenField.Value = userGroupDropDownList.SelectedValue.Trim();
                LoadMenuApps();

                userPriviligePane.Visible = true;
                userMenuPane.Visible = true;
            }

            MyAlertBox("MyOverlayStop();");
        }
    }
}