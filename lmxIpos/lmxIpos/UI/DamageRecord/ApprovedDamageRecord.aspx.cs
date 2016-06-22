using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.DamageRecord
{
    public partial class ApprovedDamageRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = damageRecordIdForViewHiddenField.Value = LumexSessionManager.Get("DamageRecordIdForView").ToString().Trim();
                    GetDamageRecordById(damageRecordIdForViewHiddenField.Value.Trim());
                    GetDamageRecordProductListById(damageRecordIdForViewHiddenField.Value.Trim());
                }

                if (damageRecordProductListGridView.Rows.Count > 0)
                {
                    damageRecordProductListGridView.UseAccessibleHeader = true;
                    damageRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetDamageRecordById(string damageRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetDamageRecordById(damageRecordId);

                if (dt.Rows.Count > 0)
                {
                    recordIdLabel.Text = dt.Rows[0]["DamageRecordId"].ToString();
                    recordDateLabel.Text = dt.Rows[0]["RecordDate"].ToString();
                    statusLabel.Text = dt.Rows[0]["Status"].ToString();

                  
                    if (string.IsNullOrEmpty(dt.Rows[0]["WarehouseId"].ToString()))
                    {
                        salesCenterIdLabel.Text = dt.Rows[0]["SalesCenterId"].ToString();
                        salesCenterNameLabel.Text = dt.Rows[0]["SalesCenterName"].ToString();
                    }
                    else
                    {
                        salesCenterIdLabel.Text = dt.Rows[0]["WarehouseId"].ToString();
                        salesCenterNameLabel.Text = dt.Rows[0]["WarehouseName"].ToString();
                    }
                   
                    totalAmountLabel.Text = dt.Rows[0]["TotalAmount"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesOrder = null;
            }
        }

        protected void GetDamageRecordProductListById(string damageRecordId)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                DataTable dt = salesOrder.GetDamageRecordProductListById(damageRecordId);

                if (dt.Rows.Count > 0)
                {
                    damageRecordProductListGridView.DataSource = dt;
                    damageRecordProductListGridView.DataBind();

                    if (damageRecordProductListGridView.Rows.Count > 0)
                    {
                        damageRecordProductListGridView.UseAccessibleHeader = true;
                        damageRecordProductListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                salesOrder = null;
            }
        }
    }
}