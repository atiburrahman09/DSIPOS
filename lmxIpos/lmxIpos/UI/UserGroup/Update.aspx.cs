using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserGroup
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = userGroupIdForUpdateHiddenField.Value = LumexSessionManager.Get("UserGroupIdForUpdate").ToString().Trim();
                    GetUserGroupById(userGroupIdForUpdateHiddenField.Value.Trim());
                    userGroupNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                updateButton.Enabled = false;

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetUserGroupById(string userGroupId)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                DataTable dt = userGroup.GetUserGroupById(userGroupId);

                if (dt.Rows.Count > 0)
                {
                    userGroupNameForUpdateHiddenField.Value = userGroupNameTextBox.Text = dt.Rows[0]["UserGroupName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["Description"].ToString();
                }
                else
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

        protected void updateButton_Click(object sender, EventArgs e)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                if (userGroupIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "User Group not found to update.";
                }
                else if (userGroupNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group Name field is required.";
                }
                else if (descriptionTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    userGroup.UserGroupId = userGroupIdForUpdateHiddenField.Value.Trim();
                    userGroup.UserGroupName = userGroupNameTextBox.Text.Trim();
                    userGroup.Description = descriptionTextBox.Text.Trim();

                    if (!userGroup.CheckDuplicateUserGroup(userGroupNameTextBox.Text.Trim()))
                    {
                        userGroup.UpdateUserGroup();

                        userGroupNameForUpdateHiddenField.Value = "";
                        userGroupIdForUpdateHiddenField.Value = "";

                        string message = "User Group <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/UserGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (userGroupNameForUpdateHiddenField.Value == userGroupNameTextBox.Text.Trim())
                        {
                            userGroup.UserGroupName = "WithOut";
                            userGroup.UpdateUserGroup();

                            userGroupNameForUpdateHiddenField.Value = "";
                            userGroupIdForUpdateHiddenField.Value = "";

                            string message = "User Group <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/UserGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "This User Group <span class='actionTopic'>already exist</span>, try another one.";
                            MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                        }
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
                userGroup = null;
            }
        }
    }
}