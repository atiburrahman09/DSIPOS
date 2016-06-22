using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;

namespace lmxIpos.UI.UserGroup
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    userGroupNameTextBox.Focus();
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                if (userGroupNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group Name field is required.";
                }
                else if (descriptionTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    userGroup.UserGroupName = userGroupNameTextBox.Text.Trim();
                    userGroup.Description = descriptionTextBox.Text.Trim();

                    if (!userGroup.CheckDuplicateUserGroup(userGroup.UserGroupName.Trim()))
                    {
                        DataTable dt = userGroup.SaveUserGroup();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "User Group <span class='actionTopic'>Created</span> Successfully with User Group ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/UserGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create User Group.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This User Group <span class='actionTopic'>already exist</span>, try another one.";
                        MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
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