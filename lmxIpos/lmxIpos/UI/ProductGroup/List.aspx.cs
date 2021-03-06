﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductGroup
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
                    GetProductGroupList();
                    productGroupListGridView.Columns[7].Visible = false;
                }

                if (productGroupListGridView.Rows.Count > 0)
                {
                    productGroupListGridView.UseAccessibleHeader = true;
                    productGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GetProductGroupList()
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                DataTable dt = productGroup.GetProductGroupList();
                productGroupListGridView.DataSource = dt;
                productGroupListGridView.DataBind();

                if (productGroupListGridView.Rows.Count > 0)
                {
                    productGroupListGridView.UseAccessibleHeader = true;
                    productGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Group List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                productGroup = null;
            }
        }

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ProductGroupIdForUpdate", productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/ProductGroup/Update.aspx", false);
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

                ProductGroupBLL productGroup = new ProductGroupBLL();
                productGroup.UpdateProductGroupActivation(productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                productGroupListGridView.Rows[row.RowIndex].Cells[3].Text = "True";
                string message = "Product Group <span class='actionTopic'>Activated</span> Successfully.";
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

                ProductGroupBLL productGroup = new ProductGroupBLL();
                productGroup.UpdateProductGroupActivation(productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                productGroupListGridView.Rows[row.RowIndex].Cells[3].Text = "False";
                string message = "Product Group <span class='actionTopic'>Deactivated</span> Successfully.";
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

                ProductGroupBLL productGroup = new ProductGroupBLL();
                string status = productGroup.DeleteProductGroup(productGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                if (status == "Deleted")
                {
                    GetProductGroupList();
                    string message = "Product Group <span class='actionTopic'>Deleted</span> Successfully.";
                    MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    GetProductGroupList();
                    string message = "This Product Group contains " + status + " product(s). You can't delete this Product Group. You must move the product(s) first to another product group.";
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