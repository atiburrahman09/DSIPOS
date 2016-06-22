using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace IPOSSystem.UI.AppMenu
{
    public partial class MenuGroupList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadMenuApps();
                GetMenuGroupList();
            }

            if (menuGroupListGridView.Rows.Count > 0)
            {
                menuGroupListGridView.UseAccessibleHeader = true;
                menuGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                }
                else
                {
                    menuTypeDropDownList.Items.Insert(0, "All");
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

        protected void GetMenuGroupList()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupList();

                menuGroupListGridView.DataSource = dt;
                menuGroupListGridView.DataBind();

                if (menuGroupListGridView.Rows.Count > 0)
                {
                    menuGroupListGridView.UseAccessibleHeader = true;
                    menuGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetMenuGroupListByMenuAppAndType()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupsByMenuAppAndType(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());
                menuGroupListGridView.DataSource = dt;
                menuGroupListGridView.DataBind();

                if (menuGroupListGridView.Rows.Count > 0)
                {
                    menuGroupListGridView.UseAccessibleHeader = true;
                    menuGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("AppMenuGroupIdForUpdate", menuGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/AppMenu/UpdateMenuGroup.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                AppMenuBLL appMenu = new AppMenuBLL();
                appMenu.UpdateMenuGroupActivation(menuGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                MyAlertBox("alert(\"Menu Group Activated Successfully.\"); window.location=\"/UI/AppMenu/MenuGroupList.aspx\"");
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
                appMenu.UpdateMenuGroupActivation(menuGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                MyAlertBox("alert(\"Menu Group Deactivated Successfully.\"); window.location=\"/UI/AppMenu/MenuGroupList.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                AppMenuBLL appMenu = new AppMenuBLL();
                string status = appMenu.DeleteMenuGroupById(menuGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                if (status == "Deleted")
                {
                    MyAlertBox("alert(\"Menu Group Deleted Successfully.\"); window.location=\"/UI/AppMenu/MenuGroupList.aspx\"");
                }
                else
                {
                    MyAlertBox("alert(\"This Menu Group contains " + status + " child(s). You can't delete this Menu Group. You must move the child(s) first to another menu group.\"); window.location=\"/UI/AppMenu/MenuGroupList.aspx\"");
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuForAppDropDownList.Text == "")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else
            {
                LoadMenuTypesByApp();
            }
        }

        protected void getGroupListButton_Click(object sender, EventArgs e)
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
                GetMenuGroupListByMenuAppAndType();
            }
        }

        protected void getAllGroupListButton_Click(object sender, EventArgs e)
        {
            GetMenuGroupList();
        }
    }
}