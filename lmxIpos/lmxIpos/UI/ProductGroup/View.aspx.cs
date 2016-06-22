using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.ProductGroup
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
                    idLabel.Text = productGroupIdForViewHiddenField.Value = LumexSessionManager.Get("ProductGroupIdForView").ToString().Trim();
                    GetProductGroupById(productGroupIdForViewHiddenField.Value.Trim());
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

        protected void GetProductGroupById(string productGroupId)
        {
            ProductGroupBLL productGroup = new ProductGroupBLL();

            try
            {
                DataTable dt = productGroup.GetProductGroupById(productGroupId);

                if (dt.Rows.Count > 0)
                {
                    productGroupNameLabel.Text = dt.Rows[0]["ProductGroupName"].ToString();
                    descriptionLabel.Text = dt.Rows[0]["Description"].ToString();
                }
                else
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
    }
}