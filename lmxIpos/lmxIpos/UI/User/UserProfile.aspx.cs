using System;
using System.Data;
using System.Web.UI;
using Lumex.Tech;
using Lumex.Project.BLL;

namespace lmxIpos.UI.User
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    GetUserById(LumexSessionManager.Get("ActiveUserId").ToString());
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
                    employeeIdLabel.Text = dt.Rows[0]["EmployeeId"].ToString();
                    departmentLabel.Text = dt.Rows[0]["Department"].ToString();
                    designationLabel.Text = dt.Rows[0]["Designation"].ToString();
                    addressLabel.Text = dt.Rows[0]["Address"].ToString();
                    contactNumberLabel.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailLabel.Text = dt.Rows[0]["Email"].ToString();
                    nationalIdLabel.Text = dt.Rows[0]["NationalId"].ToString();
                    passportNumberLabel.Text = dt.Rows[0]["PassportNumber"].ToString();
                    userGroupLabel.Text = dt.Rows[0]["UserGroupName"].ToString();
                }
                else
                {
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
            }
        }
    }
}