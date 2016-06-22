using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Product
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
                    //  GetProductList();
                    txtbxProductSearch.Attributes.Add("autocomplete", "off");
                    LoadProductGroups();
                    txtbxProductSearch.Focus();
                }

                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void LoadProductGroups()
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                DataTable dt = productGroup.GetActiveProductGroupList();

                productGroupDropDownList.DataSource = dt;
                productGroupDropDownList.DataValueField = "ProductGroupId";
                productGroupDropDownList.DataTextField = "ProductGroupName";
                productGroupDropDownList.DataBind();
                productGroupDropDownList.Items.Insert(0, "All");
                productGroupDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Group Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void productGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductList(productGroupDropDownList.SelectedValue.Trim());
        }
        protected void GetProductList(string GroupId)
        {
            ProductBLL product = new ProductBLL();
            DataTable dt = new DataTable();

            try
            {

                if (GroupId == "All")
                {
                    dt = product.GetProductList();
                }
                else
                {
                    dt = product.GetProductListbyGroupId(GroupId);
                }


                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product List Data Not Found!!!"; msgDetailLabel.Text = "";
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
                product = null;
            }
        }

        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("ProductIdForUpdate", productListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Update.aspx','_newtab');", true);
                //Response.Redirect("~/UI/Product/Update.aspx", true);
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

                ProductBLL product = new ProductBLL();
                product.UpdateProductActivation(productListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                productListGridView.Rows[row.RowIndex].Cells[8].Text = "True";
                string message = "Product <span class='actionTopic'>Activated</span> Successfully.";
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

                ProductBLL roduct = new ProductBLL();
                roduct.UpdateProductActivation(productListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                productListGridView.Rows[row.RowIndex].Cells[8].Text = "False";
                string message = "Product <span class='actionTopic'>Deactivated</span> Successfully.";
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

                ProductBLL product = new ProductBLL();
                product.DeleteProduct(productListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());

                GetProductList(productGroupDropDownList.SelectedValue);
                string message = "Product <span class='actionTopic'>Deleted</span> Successfully.";
                MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void txtbxProductSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string[] Id = txtbxProductSearch.Text.Split('[');
                ProductBLL product = new ProductBLL();
                DataTable dt = product.SearchProductByIdorBarcode(Id[0]);
                productListGridView.DataSource = dt;
                productListGridView.DataBind();

                if (productListGridView.Rows.Count > 0)
                {
                    productListGridView.UseAccessibleHeader = true;
                    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    txtbxProductSearch.Text = "";
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product List Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                    txtbxProductSearch.Focus();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}