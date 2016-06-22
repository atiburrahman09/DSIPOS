using System;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                currentPasswordTextBox.Attributes.Add("autocomplete", "off");
                newPasswordTextBox.Attributes.Add("autocomplete", "off");
                confirmNewPasswordTextBox.Attributes.Add("autocomplete", "off");

                if (!IsPostBack)
                {
                    currentPasswordTextBox.Focus();
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

        protected void passwordUpdateButton_Click(object sender, EventArgs e)
        {
            UserBLL user = new UserBLL();

            try
            {
                if (string.IsNullOrEmpty(currentPasswordTextBox.Text.Trim()))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Current Password field is required.";
                }
                else if (string.IsNullOrEmpty(newPasswordTextBox.Text.Trim()))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "New Password field is required.";
                }
                else if (string.IsNullOrEmpty(confirmNewPasswordTextBox.Text.Trim()))
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Confirm New Password field is required.";
                }
                else if (newPasswordTextBox.Text.Trim() != confirmNewPasswordTextBox.Text.Trim())
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "New Password & Confirm New Password do not match.";
                }
                else
                {
                    user.UserId = LumexSessionManager.Get("ActiveUserId").ToString();
                    user.Password = currentPasswordTextBox.Text.Trim();

                    if (user.ValidateUser())
                    {
                        user.Password = newPasswordTextBox.Text.Trim();
                        user.UpdateUserPassword(user.UserId, user.Password);

                        string message = "Password <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/Logout.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        string message = "<span class='actionTopic'>Invalid</span> Current Password. You can't change your password.";
                        MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
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
                user = null;
            }
        }
    }
}