using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;
using Lumex.UserAccess;
using Lumex.Project.BLL;
using System.Data;
using System.Web.Services;

namespace lmxIpos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Login";
                //{
                //    if (true)
                //    {
                //        if (Session["ActiveUserId"] != null)
                //        {
                //            Response.Redirect("~/Default.aspx");
                //        }
                //        else
                //        {
                //            LumexSessionManager.RemoveAll();
                //        }
                //    }
                //    else
                //    {
                //        //userIdTextBox.Visible = false;
                //        //passwordTextBox.Visible = false;
                //        //loginButton.Visible = false;
                //        //statusLabel.Text = "!!! illegal access !!!";
                //        //Response.Redirect("/ApplicationAccessibility.aspx", false);

                //        //MyAlertBox("ErrorAlert(\"\", \"" + HttpContext.Current.Request.Url.AbsoluteUri + "\", \"\");");
                //    }
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

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            UserBLL user = new UserBLL();

            try
            {
                user.UserId = txtbxUserName.Text.Trim();
                user.Password = txtbxPass.Text.Trim();

                if (user.ValidateUser())
                {
                    DataTable dt = user.GetUserById(user.UserId);

                    if (dt.Rows[0]["IsActive"].ToString() == "True" && dt.Rows[0]["IsUserGroupActive"].ToString() == "True")
                    {
                        LumexSessionManager.Add("ActiveUserId", dt.Rows[0]["UserId"].ToString());
                        LumexSessionManager.Add("ActiveUserName", dt.Rows[0]["UserName"].ToString());
                        LumexSessionManager.Add("isMenu", "N");
                        LumexSessionManager.Add("ActiveMenuFor", "inv");
                       
                        LumexSessionManager.Add("ScreenLock", "False");
                        LumexSessionManager.Add("ScreenLock", "False");
                        LumexSessionManager.Add("UserSalesCenterId", dt.Rows[0]["SalesCenterId"].ToString());
                        LumexSessionManager.Add("UserWareHouseId", dt.Rows[0]["WarehouseId"].ToString());
                        LumexSessionManager.Add("UserGroupId", dt.Rows[0]["UserGroupId"].ToString());


                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        lblnotify.Text = "User Access Denied!!!";
                    }
                }
                else
                {
                    lblnotify.Text = "Invalid User or Password";
                }
                //if (txtbxUserName.Text != "" && txtbxPass.Text != "")
                //{
                //    UserLogin user = new UserLogin();
                //    user.UserId = txtbxUserName.Text.Trim();
                //    user.Password = txtbxPass.Text.Trim();


                //    if (user.ValidateUser(user))
                //    {

                //        LumexSessionManager.Add("ActiveUserId", user.UserId);
                //        LumexSessionManager.Add("ActiveUserName", user.UserName);
                //        LumexSessionManager.Add("ScreenLock", "False");
                //        LumexSessionManager.Add("UserDasignation", user.Designation);

                //        Response.Redirect("~/Default.aspx");
                //        //statusLabel.Text = "Invalid User or Password";
                //    }
                //    else
                //    {
                //        lblnotify.Text = "Invalid User or Password";
                //    }
                // }
                //else
                //{
                //    lblnotify.Text = "Enter UserID or Password";
                //}

            }
            catch (Exception ex)
            {
                lblnotify.Text = ex.Message;
            }
            finally
            {
                //     user = null;
            }
        }
        [WebMethod]
        public static string GetDemoAccessibility(string name, string companyName, string contact, string message)
        {
            try
            {
                if (name == "" || contact == "" || message == "")
                {
                    return "Please Fill all TextBox..";
                }
                else
                {
                    string a = name;
                    string b = companyName;
                    string c = contact;
                    string d = message;
                    // email.IsBodyHtml = true; = "Name:"+a+"Company"+b+"Contact"+c+"Message"+d;
                    string messageBody = "Name:" + a + "\r\nCompany:" + b + "\r\nContact:" + c + "\r\nMessege :" + d;
                    LumexLibraryManager.SendEmail("lumextech@gmail.com", "For IPOS Demo", messageBody);

                    //int.Parse("a");

                    return "Done";
                }
            }
            catch (Exception)
            {
                return "Not Done";
            }
        }


    }
}