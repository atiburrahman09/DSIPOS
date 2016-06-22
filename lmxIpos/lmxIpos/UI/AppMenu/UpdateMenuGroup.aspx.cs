using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace IPOSSystem.UI.AppMenu
{
    public partial class UpdateMenuGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = appMenuGroupIdForUpdateHiddenField.Value = LumexSessionManager.Get("AppMenuGroupIdForUpdate").ToString().Trim();
                    GetMenuGroupById(appMenuGroupIdForUpdateHiddenField.Value.Trim());
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
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
                    //menuForAppDropDownList.SelectedIndex = 0;
                    //LoadMenuTypeByApp();
                }
                else
                {
                    menuForAppDropDownList.Items.Insert(0, "----------Select----------");
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
                    //menuTypeDropDownList.SelectedIndex = 0;
                }
                else
                {
                    menuTypeDropDownList.Items.Insert(0, "----------Select----------");
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

        protected void GetMenuGroupById(string menuGroupId)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupById(menuGroupId);

                if (dt.Rows.Count > 0)
                {
                    appMenuGroupNameHiddenField.Value = menuGroupNameTextBox.Text = dt.Rows[0]["MenuGroupName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["ToolTipDescription"].ToString();
                    urlTextBox.Text = dt.Rows[0]["URL"].ToString();
                    displayNameTextBox.Text = dt.Rows[0]["DisplayName"].ToString();
                    imageURLTextBox.Text = dt.Rows[0]["ImageURL"].ToString();
                    menuTargetDropDownList.SelectedValue = dt.Rows[0]["MenuTarget"].ToString();

                    LoadMenuApps();
                    menuForAppDropDownList.SelectedValue = dt.Rows[0]["MenuForApp"].ToString();

                    LoadMenuTypesByApp();
                    menuTypeDropDownList.SelectedValue = dt.Rows[0]["MenuType"].ToString();
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

        protected void updateButton_Click(object sender, EventArgs e)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                if (menuGroupNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group Name field is required.";
                }
                else if (displayNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Display Name field is required.";
                }
                else if (urlTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu URL field is required.";
                }
                else if (menuTypeDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
                }
                else if (menuForAppDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
                }
                else
                {
                    appMenu.MenuGroupId = idLabel.Text.Trim();
                    appMenu.MenuGroupName = menuGroupNameTextBox.Text.Trim();
                    appMenu.DisplayName = displayNameTextBox.Text.Trim();
                    appMenu.ToolTipDescription = descriptionTextBox.Text.Trim();
                    appMenu.URL = urlTextBox.Text.Trim();
                    appMenu.MenuType = menuTypeDropDownList.SelectedValue.Trim();
                    appMenu.MenuForApp = menuForAppDropDownList.SelectedValue.Trim();
                    appMenu.MenuTarget = menuTargetDropDownList.SelectedValue.Trim();
                    appMenu.ImageUrl = imageURLTextBox.Text.Trim();

                    if (!appMenu.CheckDuplicateMenuGroup(menuGroupNameTextBox.Text.Trim()))
                    {
                        appMenu.UpdateMenuGroup();

                        appMenuGroupIdForUpdateHiddenField.Value = "";
                        appMenuGroupNameHiddenField.Value = "";
                        MyAlertBox("alert(\"Menu Group Updated Successfully.\"); window.location=\"/UI/AppMenu/MenuGroupList.aspx\"");
                    }
                    else
                    {
                        if (appMenuGroupNameHiddenField.Value == menuGroupNameTextBox.Text.Trim())
                        {
                            appMenu.MenuGroupName = "WithOut";
                            appMenu.UpdateMenuGroup();

                            appMenuGroupIdForUpdateHiddenField.Value = "";
                            appMenuGroupNameHiddenField.Value = "";
                            MyAlertBox("alert(\"Menu Group Updated Successfully.\"); window.location=\"/UI/AppMenu/MenuGroupList.aspx\"");
                        }
                        else
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Data Duplicate!!!"; msgDetailLabel.Text = "This Menu Group already exist, try another one.";
                        }
                    }
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

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuTypesByApp();
        }
    }
}