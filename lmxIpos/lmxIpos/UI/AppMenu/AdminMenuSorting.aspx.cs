using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace IPOSSystem.UI.AppMenu
{
    public partial class AdminMenuSorting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadMenuApps();
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        private void PopulateTestMenu()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetTestMenuData(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());

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
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
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
                    //msgbox.Visible = true; msgTitleLabel.Text = "Menu Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
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
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
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
                    PopulateAllMenu();
                }
                else
                {
                    menuTypeDropDownList.Items.Insert(0, "");
                    menuTypeDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
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
                menuGroupDropDownList.Items.Insert(1, "All");
                menuGroupDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void LoadParentMenusByMenuAppAndType()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.LoadParentMenusByMenuAppAndType(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());

                groupWiseUserMenuListListBox.DataSource = dt;
                groupWiseUserMenuListListBox.DataValueField = "MenuId";
                groupWiseUserMenuListListBox.DataTextField = "MenuName";
                groupWiseUserMenuListListBox.DataBind();

                if (groupWiseUserMenuListListBox.Items.Count > 0)
                {
                    upImageButton.Enabled = true;
                    downImageButton.Enabled = true;
                    saveButton.Enabled = true;
                    menuSortingPane.Visible = true;
                }
                else
                {
                    upImageButton.Enabled = false;
                    downImageButton.Enabled = false;
                    saveButton.Enabled = false;
                    menuSortingPane.Visible = false;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void LoadChildMenusByParentMenuId(string parentMenuId)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetChildMenusByParentMenuId(parentMenuId);

                groupWiseUserMenuListListBox.DataSource = dt;
                groupWiseUserMenuListListBox.DataValueField = "MenuId";
                groupWiseUserMenuListListBox.DataTextField = "MenuName";
                groupWiseUserMenuListListBox.DataBind();

                if (groupWiseUserMenuListListBox.Items.Count > 0)
                {
                    upImageButton.Enabled = true;
                    downImageButton.Enabled = true;
                    saveButton.Enabled = true;
                }
                else
                {
                    upImageButton.Enabled = false;
                    downImageButton.Enabled = false;
                    saveButton.Enabled = false;
                }

                countChildMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void LoadMenuLevelsByMenuAppTypeAndGroup()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuLevelsByMenuAppTypeAndGroup(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim());

                menuLevelDropDownList.DataSource = dt;
                menuLevelDropDownList.DataValueField = "MenuLevel";
                menuLevelDropDownList.DataTextField = "MenuLevel";
                menuLevelDropDownList.DataBind();
                menuLevelDropDownList.Items.Insert(0, "");
                menuLevelDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void LoadOnlyParentMenusByMenuAppTypeGroupAndLevel()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                groupWiseMenuListListBox.Items.Clear();
                groupWiseUserMenuListListBox.Items.Clear();

                DataTable dt = appMenu.GetOnlyParentMenusByMenuAppTypeGroupAndLevel(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim(), menuLevelDropDownList.SelectedValue.Trim());

                groupWiseMenuListListBox.DataSource = dt;
                groupWiseMenuListListBox.DataValueField = "MenuId";
                groupWiseMenuListListBox.DataTextField = "MenuName";
                groupWiseMenuListListBox.DataBind();

                if (groupWiseMenuListListBox.Items.Count > 0)
                {
                    refreshImageButton.Enabled = true;
                    getChildsButton.Enabled = true;
                }
                else
                {
                    refreshImageButton.Enabled = false;
                    getChildsButton.Enabled = false;
                }

                countSubParentMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
                countChildMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuSortingPane.Visible = false;
            testAllMenu.Items.Clear();
            menuTypeDropDownList.Items.Clear();
            menuGroupDropDownList.Items.Clear();
            menuLevelDropDownList.Items.Clear();

            if (menuForAppDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else
            {
                LoadMenuTypesByApp();
            }
        }

        protected void menuTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuSortingPane.Visible = false;
            testAllMenu.Items.Clear();
            menuGroupDropDownList.Items.Clear();
            menuLevelDropDownList.Items.Clear();

            if (menuTypeDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                LoadMenuGroupsByMenuAppAndType();
                PopulateAllMenu();
            }
        }

        protected void menuGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuSortingPane.Visible = false;
            menuLevelDropDownList.Items.Clear();
            refreshImageButton.Enabled = false;
            getChildsButton.Enabled = false;
            upImageButton.Enabled = false;
            downImageButton.Enabled = false;
            groupWiseMenuListListBox.Items.Clear();
            countSubParentMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserMenuListListBox.Items.Clear();
            countChildMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            saveButton.Enabled = false;

            if (menuGroupDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
            }
            if (menuGroupDropDownList.SelectedValue == "All")
            {
                this.groupWiseMenuListListBox.Attributes.Add("disabled", "");
                parentMenuIdHiddenField.Value = "0";
                menuLevelDropDownList.Items.Clear();
                menuLevelDropDownList.Enabled = false;
                groupWiseMenuListListBox.Items.Clear();

                LoadParentMenusByMenuAppAndType();

                countChildMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            else
            {
                this.groupWiseMenuListListBox.Attributes.Remove("disabled");
                menuLevelDropDownList.Enabled = true;
                LoadMenuLevelsByMenuAppTypeAndGroup();
            }
        }

        protected void menuLevelDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuSortingPane.Visible = false;
            refreshImageButton.Enabled = false;
            getChildsButton.Enabled = false;
            upImageButton.Enabled = false;
            downImageButton.Enabled = false;
            groupWiseMenuListListBox.Items.Clear();
            groupWiseUserMenuListListBox.Items.Clear();
            saveButton.Enabled = false;

            if (menuLevelDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Level field is required.";
            }
            else
            {
                LoadOnlyParentMenusByMenuAppTypeGroupAndLevel();
                menuSortingPane.Visible = true;
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
                PopulateTestMenu();
            }
        }

        protected void refreshImageButton_Click(object sender, ImageClickEventArgs e)
        {
            LoadOnlyParentMenusByMenuAppTypeGroupAndLevel();
        }

        protected void downImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (groupWiseUserMenuListListBox.Items.Count > 0)
            {
                int selectedIndex = groupWiseUserMenuListListBox.SelectedIndex;
                if (selectedIndex < groupWiseUserMenuListListBox.Items.Count - 1)
                {
                    ListItem li = groupWiseUserMenuListListBox.Items[selectedIndex + 1];
                    groupWiseUserMenuListListBox.Items.RemoveAt(selectedIndex + 1);
                    groupWiseUserMenuListListBox.Items.Insert(selectedIndex, li);
                }
            }
        }

        protected void upImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (groupWiseUserMenuListListBox.Items.Count > 0)
            {
                int selectedIndex = groupWiseUserMenuListListBox.SelectedIndex;
                if (selectedIndex > 0)
                {
                    ListItem li = groupWiseUserMenuListListBox.Items[selectedIndex - 1];
                    groupWiseUserMenuListListBox.Items.RemoveAt(selectedIndex - 1);
                    groupWiseUserMenuListListBox.Items.Insert(selectedIndex, li);
                }
            }
        }

        protected void getChildsButton_Click(object sender, EventArgs e)
        {
            if (groupWiseMenuListListBox.SelectedIndex > -1)
            {
                parentMenuIdHiddenField.Value = groupWiseMenuListListBox.SelectedValue.Trim();
                LoadChildMenusByParentMenuId(parentMenuIdHiddenField.Value);
            }
            else
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Select an item from Parent Menu List.";
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                if (groupWiseUserMenuListListBox.Items.Count > 0)
                {
                    appMenu.UpdateMenuSorting(groupWiseUserMenuListListBox, parentMenuIdHiddenField.Value.Trim());
                    PopulateAllMenu();
                    MyAlertBox("alert(\"Menu Sorted Successfully.\");");
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }
    }
}