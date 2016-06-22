using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.UserGroup
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = userGroupIdForViewHiddenField.Value = LumexSessionManager.Get("UserGroupIdForView").ToString().Trim();
                    GetUserGroupById(userGroupIdForViewHiddenField.Value.Trim());
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

        protected void GetUserGroupById(string userGroupId)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                DataTable dt = userGroup.GetUserGroupById(userGroupId);

                if (dt.Rows.Count > 0)
                {
                    userGroupNameLabel.Text = dt.Rows[0]["UserGroupName"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
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
    }
}