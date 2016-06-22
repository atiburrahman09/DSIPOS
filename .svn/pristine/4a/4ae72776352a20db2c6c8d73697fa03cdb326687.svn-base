using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserGroup
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    GetUserGroupList();
                }

                if (userGroupListGridView.Rows.Count > 0)
                {
                    userGroupListGridView.UseAccessibleHeader = true;
                    userGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetUserGroupList()
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                DataTable dt = userGroup.GetUserGroupList();
                userGroupListGridView.DataSource = dt;
                userGroupListGridView.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["UserGroupName"].ToString() == "Super Admin")
                    {
                        LinkButton editLinkButton = (LinkButton)userGroupListGridView.Rows[i].FindControl("editLinkButton");
                        LinkButton activateLinkButton = (LinkButton)userGroupListGridView.Rows[i].FindControl("activateLinkButton");
                        LinkButton deactivateLinkButton = (LinkButton)userGroupListGridView.Rows[i].FindControl("deactivateLinkButton");
                        LinkButton deleteLinkButton = (LinkButton)userGroupListGridView.Rows[i].FindControl("deleteLinkButton");
                        editLinkButton.Visible = false;
                        activateLinkButton.Visible = false;
                        deactivateLinkButton.Visible = false;
                        deleteLinkButton.Visible = false;

                        break;
                    }
                }

                if (userGroupListGridView.Rows.Count > 0)
                {
                    userGroupListGridView.UseAccessibleHeader = true;
                    userGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "User Group List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserGroupIdForUpdate", userGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/UserGroup/Update.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                UserGroupBLL userGroup = new UserGroupBLL();
                userGroup.UpdateUserGroupActivation(userGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                userGroupListGridView.Rows[row.RowIndex].Cells[3].Text = "True";
                string message = "User Group <span class='actionTopic'>Activated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deactivateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                UserGroupBLL userGroup = new UserGroupBLL();
                userGroup.UpdateUserGroupActivation(userGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                userGroupListGridView.Rows[row.RowIndex].Cells[3].Text = "False";
                string message = "User Group <span class='actionTopic'>Deactivated</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deleteLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                UserGroupBLL userGroup = new UserGroupBLL();
                string status = userGroup.DeleteUserGroup(userGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                if (status == "Deleted")
                {
                    GetUserGroupList();
                    string message = "User Group <span class='actionTopic'>Deleted</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    GetUserGroupList();
                    string message = "This User Group contains " + status + " user(s). You can't delete this User Group. You must move the user(s) first to another user group.";
                    MyAlertBox("WarningAlert(\"" + "Data Dependency" + "\", \"" + message + "\", \"\");");
                }
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