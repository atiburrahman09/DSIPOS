﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.User
{
    public partial class DeletedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                    GetAllDeletedList();
                    fromDateTextBox.Focus();
                }

                if (deletedListGridView.Rows.Count > 0)
                {
                    deletedListGridView.UseAccessibleHeader = true;
                    deletedListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserIdForView", deletedListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/User/View.aspx", false);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void deletedListButton_Click(object sender, EventArgs e)
        {
            UserBLL user = new UserBLL();

            try
            {
                if (fromDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date From field is required.";
                }
                else if (toDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date To field is required.";
                }
                else
                {
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());

                    DataTable dt = user.GetDeletedUserListByDateRangeAll(fromDate, toDate, "");

                    deletedListGridView.DataSource = dt;
                    deletedListGridView.DataBind();

                    if (deletedListGridView.Rows.Count > 0)
                    {
                        deletedListGridView.UseAccessibleHeader = true;
                        deletedListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Deleted User List Data Not Found!!!"; msgDetailLabel.Text = "";
                        msgbox.Attributes.Add("class", "alert alert-info");
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void GetAllDeletedList()
        {
            UserBLL user = new UserBLL();

            try
            {
                string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());

                DataTable dt = user.GetDeletedUserListByDateRangeAll(fromDate, toDate, "All");

                deletedListGridView.DataSource = dt;
                deletedListGridView.DataBind();

                if (deletedListGridView.Rows.Count > 0)
                {
                    deletedListGridView.UseAccessibleHeader = true;
                    deletedListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Deleted User List Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-info");
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

        protected void allDeletedListButton_Click(object sender, EventArgs e)
        {
            GetAllDeletedList();
        }
    }
}