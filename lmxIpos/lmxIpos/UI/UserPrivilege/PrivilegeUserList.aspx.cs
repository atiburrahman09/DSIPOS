using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserPrivilege
{
    public partial class PrivilegeUserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    GetUserList();
                }

                if (userListGridView.Rows.Count > 0)
                {
                    userListGridView.UseAccessibleHeader = true;
                    userListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetUserList()
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserList();
                userListGridView.DataSource = dt;
                userListGridView.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["UserId"].ToString() == LumexSessionManager.Get("ActiveUserId").ToString())
                    {
                        LinkButton setMenuLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("setMenuLinkButton");
                        LinkButton setWarehouseLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("setWarehouseLinkButton");
                        LinkButton setSalesCenterLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("setSalesCenterLinkButton");
                        setMenuLinkButton.Visible = false;
                        setWarehouseLinkButton.Visible = false;
                        setSalesCenterLinkButton.Visible = false;

                        break;
                    }
                }

                if (LumexSessionManager.Get("ActiveUserId").ToString() != "Developer")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["UserId"].ToString() == "Developer")
                        {
                            LinkButton setMenuLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("setMenuLinkButton");
                            LinkButton setWarehouseLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("setWarehouseLinkButton");
                            LinkButton setSalesCenterLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("setSalesCenterLinkButton");
                            setMenuLinkButton.Visible = false;
                            setWarehouseLinkButton.Visible = false;
                            setSalesCenterLinkButton.Visible = false;

                            break;
                        }
                    }
                }

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "User List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void setMenuLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserIdForSetMenu", userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/UserPrivilege/SetUserMenu.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void setWarehouseLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserIdForSetWarehouse", userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/UserPrivilege/SetUserWarehouse.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void setSalesCenterLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserIdForSetSalesCenter", userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/UserPrivilege/SetUserSalesCenter.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
    }
}