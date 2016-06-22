using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.User
{
    public partial class ResetUserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                newPasswordTextBox.Attributes.Add("autocomplete", "off");
                confirmNewPasswordTextBox.Attributes.Add("autocomplete", "off");

                if (!IsPostBack)
                {
                    userIdTextBox.Focus();
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

        protected void GetUserById(string userId)
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);

                if (dt.Rows.Count > 0)
                {
                    userIdLabel.Text = dt.Rows[0]["UserId"].ToString();
                    userNameLabel.Text = dt.Rows[0]["UserName"].ToString();
                    //employeeIdLabel.Text = dt.Rows[0]["EmployeeId"].ToString();
                    userGroupLabel.Text = dt.Rows[0]["UserGroupName"].ToString();
                    contactNumberLabel.Text = dt.Rows[0]["ContactNumber"].ToString();

                    actionPane.Visible = true;
                }
                else
                {
                    actionPane.Visible = false;
                    msgbox.Visible = true; msgTitleLabel.Text = "User Data Not Found!!!"; msgDetailLabel.Text = "";
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void getUserInfoButton_Click(object sender, EventArgs e)
        {
            GetUserById(userIdTextBox.Text.Trim());
        }

        protected void passwordResetButton_Click(object sender, EventArgs e)
        {
            UserBLL user = new UserBLL();

            try
            {
                if (string.IsNullOrEmpty(newPasswordTextBox.Text.Trim()))
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
                    user.UserId = userIdLabel.Text.Trim();
                    user.Password = newPasswordTextBox.Text.Trim();
                    user.UpdateUserPassword(user.UserId, user.Password);

                    string message = "User <span class='actionTopic'>Password Reset</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/User/ResetUserPassword.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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