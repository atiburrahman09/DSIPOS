using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Customer
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
                    idLabel.Text = customerIdForViewHiddenField.Value = LumexSessionManager.Get("CustomerIdForView").ToString().Trim();
                    GetCustomerById(customerIdForViewHiddenField.Value.Trim());
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

        protected void GetCustomerById(string customerId)
        {
            CustomerBLL customer = new CustomerBLL();

            try
            {
                DataTable dt = customer.GetCustomerById(customerId);

                if (dt.Rows.Count > 0)
                {
                    customerNameLabel.Text = dt.Rows[0]["CustomerName"].ToString();
                    //countryLabel.Text = dt.Rows[0]["Country"].ToString();
                    //cityLabel.Text = dt.Rows[0]["City"].ToString();
                    //districtLabel.Text = dt.Rows[0]["District"].ToString();
                    //postalCodeLabel.Text = dt.Rows[0]["PostalCode"].ToString();
                    //nationalIdLabel.Text = dt.Rows[0]["NationalId"].ToString();
                    //passportNumberLabel.Text = dt.Rows[0]["PassportNumber"].ToString();
                    contactNumberLabel.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailLabel.Text = dt.Rows[0]["Email"].ToString();
                    addressLabel.Text = dt.Rows[0]["Address"].ToString();
                    joiningSalesCenterLabel.Text = dt.Rows[0]["JoiningSalesCenterName"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Customer Data Not Found!!!"; msgDetailLabel.Text = "";
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
                customer = null;
            }
        }
    }
}