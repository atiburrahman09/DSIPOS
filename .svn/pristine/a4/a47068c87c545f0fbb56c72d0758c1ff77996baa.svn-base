using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.Warehouse
{
    public partial class warehose_stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWarehouses();
                drpdwnWarehoseName.Focus();
                getStockLimit();
            }

            if (gridviewwarehouseStock.Rows.Count > 0)
            {
                gridviewwarehouseStock.UseAccessibleHeader = true;
                gridviewwarehouseStock.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void LoadWarehouses()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                drpdwnWarehoseName.DataSource = dt;
                drpdwnWarehoseName.DataValueField = "WarehouseId";
                drpdwnWarehoseName.DataTextField = "WarehouseName";
                drpdwnWarehoseName.DataBind();
                drpdwnWarehoseName.Items.Insert(0, "Select Please...");
                drpdwnWarehoseName.SelectedIndex = 0;
                //drpdwnWarehoseName.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Warehouse Data Not Found!!!"; msgDetailLabel.Text = "";
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
                warehouse = null;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void btnNotificationLimit_Click(object sender, EventArgs e)
        {
            try
            {
                WarehouseBLL warehouseBll = new WarehouseBLL();

                warehouseBll.StockLimit = txtNotification.Text;
                // salesCenter.SalesCenterId = 
                bool status = warehouseBll.UpdateWareHouseNotificationLimit();
                if (status)
                {
                    string message = "Sales Center <span class='actionTopic'>Stock Margin</span> Successfully Updated";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    string message = "<span class='actionTopic'>Failed</span> to Update Sales Center Stock.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }
        }

        protected void getStockLimit()
        {
            try
            {
                WarehouseBLL warehouseBll = new WarehouseBLL();
                DataTable dt = warehouseBll.getStockNotificationLimit();
                if (dt.Rows.Count > 0)
                {
                    txtNotification.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    txtNotification.Text = "0";
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }
        }

        protected void drpdwnWarehoseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WarehouseBLL warehouseBll = new WarehouseBLL();
                DataTable dt = warehouseBll.getAvailableProductListbyWarehouseId(drpdwnWarehoseName.SelectedValue);
                gridviewwarehouseStock.DataSource = dt;
                gridviewwarehouseStock.DataBind();

                if (dt.Rows.Count <= 0)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Product List Not Found for this Warehouse!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }

                if (gridviewwarehouseStock.Rows.Count > 0)
                {
                    gridviewwarehouseStock.UseAccessibleHeader = true;
                    gridviewwarehouseStock.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

        }
        protected void gridviewwarehouseStock_SelectedIndexChanged(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                {

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        if (Convert.ToDecimal(e.Row.Cells[4].Text) <= Convert.ToDecimal(txtNotification.Text))
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#fcd036");
                        }
                    }
                }
                else
                {
                    //if (e.Row.RowType == DataControlRowType.DataRow)
                    //{
                    //    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='orange'");
                    //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='gray'");
                    //    e.Row.BackColor = Color.FromName("gray");
                    //}
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        if (Convert.ToDecimal(e.Row.Cells[4].Text) <= Convert.ToDecimal(txtNotification.Text))
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#fcd036");
                        }
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}