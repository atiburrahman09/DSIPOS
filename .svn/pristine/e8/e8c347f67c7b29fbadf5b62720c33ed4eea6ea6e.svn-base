using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace IPOSSystem.UI.AppMenu
{
    public partial class AdminMenuList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadMenuApps();
                GetMenuList();
            }

            if (menuListGridView.Rows.Count > 0)
            {
                menuListGridView.UseAccessibleHeader = true;
                menuListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                    PopulateTestMenu();
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
                menuLevelDropDownList.Items.Insert(1, "All");
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

        protected void GetMenuList()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuList();
                menuListGridView.DataSource = dt;
                menuListGridView.DataBind();

                if (menuListGridView.Rows.Count > 0)
                {
                    menuListGridView.UseAccessibleHeader = true;
                    menuListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
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

        protected void GetMenuListByMenuAppTypeGroupAndLevel()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenusByMenuAppTypeGroupAndLevel(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim(), menuLevelDropDownList.SelectedValue.Trim());
                menuListGridView.DataSource = dt;
                menuListGridView.DataBind();

                if (menuListGridView.Rows.Count > 0)
                {
                    menuListGridView.UseAccessibleHeader = true;
                    menuListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
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

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                AppMenuBLL appMenu = new AppMenuBLL();
                appMenu.UpdateMenuActivation(menuListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                MyAlertBox("alert(\"Menu Activated Successfully.\"); window.location=\"/UI/AppMenu/AdminMenuList.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void deactivateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                AppMenuBLL appMenu = new AppMenuBLL();
                appMenu.UpdateMenuActivation(menuListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                MyAlertBox("alert(\"Menu Deactivated Successfully.\"); window.location=\"/UI/AppMenu/AdminMenuList.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (menuTypeDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                LoadMenuGroupsByMenuAppAndType();
                PopulateTestMenu();
            }
        }

        protected void menuGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuGroupDropDownList.SelectedValue == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
            }
            else
            {
                LoadMenuLevelsByMenuAppTypeAndGroup();
            }
        }

        protected void getMenuListButton_Click(object sender, EventArgs e)
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
            else if (menuLevelDropDownList.Text == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Level field is required.";
            }
            else
            {
                GetMenuListByMenuAppTypeGroupAndLevel();
            }
        }

        protected void getAllMenuListButton_Click(object sender, EventArgs e)
        {
            GetMenuList();
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
    }
}