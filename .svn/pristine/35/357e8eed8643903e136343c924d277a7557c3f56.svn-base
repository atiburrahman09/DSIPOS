using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.User
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

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (dt.Rows[i]["UserId"].ToString() == LumexSessionManager.Get("ActiveUserId").ToString())
                //    {
                //        LinkButton editLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("editLinkButton");
                //        LinkButton activateLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("activateLinkButton");
                //        LinkButton deactivateLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("deactivateLinkButton");
                //        LinkButton deleteLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("deleteLinkButton");
                //        editLinkButton.Visible = false;
                //        activateLinkButton.Visible = false;
                //        deactivateLinkButton.Visible = false;
                //        deleteLinkButton.Visible = false;

                //        break;
                //    }
                //}

                //if (LumexSessionManager.Get("ActiveUserId").ToString() != "Developer")
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        if (dt.Rows[i]["UserId"].ToString() == "Developer")
                //        {
                //            LinkButton editLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("editLinkButton");
                //            LinkButton deleteLinkButton = (LinkButton)userListGridView.Rows[i].FindControl("deleteLinkButton");
                //            editLinkButton.Visible = false;
                //            deleteLinkButton.Visible = false;

                //            break;
                //        }
                //    }
                //}

                if (userListGridView.Rows.Count > 0)
                {
                    userListGridView.UseAccessibleHeader = true;
                    userListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
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

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserIdForUpdate", userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/User/Update.aspx", false);
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

                UserBLL user = new UserBLL();
                user.UpdateUserActivation(userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                userListGridView.Rows[row.RowIndex].Cells[5].Text = "True";
                string message = "User <span class='actionTopic'>Activated</span> Successfully.";
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

                UserBLL user = new UserBLL();
                user.UpdateUserActivation(userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                userListGridView.Rows[row.RowIndex].Cells[5].Text = "False";
                string message = "User <span class='actionTopic'>Deactivated</span> Successfully.";
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

                UserBLL user = new UserBLL();
                user.DeleteUser(userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());

                GetUserList();
                string message = "User <span class='actionTopic'>Deleted</span> & User Menu(s), Warehouse(s) and Sales Center(s) Updated Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
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