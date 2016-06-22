using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.SalesPerson
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
                    idLabel.Text = salesPersonIdForViewHiddenField.Value = LumexSessionManager.Get("SalesPersonIdForView").ToString().Trim();
                    GetSalesPersonById(salesPersonIdForViewHiddenField.Value.Trim());
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

        protected void GetSalesPersonById(string salesPersonId)
        {
            SalesPersonBLL salesPerson = new SalesPersonBLL();

            try
            {
                DataTable dt = salesPerson.GetSalesPersonById(salesPersonId);

                if (dt.Rows.Count > 0)
                {
                    salesPersonNameLabel.Text = dt.Rows[0]["SalesPersonName"].ToString();
                    countryLabel.Text = dt.Rows[0]["Country"].ToString();
                    cityLabel.Text = dt.Rows[0]["City"].ToString();
                    districtLabel.Text = dt.Rows[0]["District"].ToString();
                    postalCodeLabel.Text = dt.Rows[0]["PostalCode"].ToString();
                    nationalIdLabel.Text = dt.Rows[0]["NationalId"].ToString();
                    passportNumberLabel.Text = dt.Rows[0]["PassportNumber"].ToString();
                    contactNumberLabel.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailLabel.Text = dt.Rows[0]["Email"].ToString();
                    addressLabel.Text = dt.Rows[0]["Address"].ToString();
                    joinDateLabel.Text = LumexLibraryManager.GetAppDateView(dt.Rows[0]["joinDate"].ToString());
                    joiningSalesCenterLabel.Text = dt.Rows[0]["JoiningSalesCenterName"].ToString();
                    workingSalesCenterLabel.Text = dt.Rows[0]["WorkingSalesCenterName"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Sales Person Data Not Found!!!"; msgDetailLabel.Text = "";
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
                salesPerson = null;
            }
        }
    }
}