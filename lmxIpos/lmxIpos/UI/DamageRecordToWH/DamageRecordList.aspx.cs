﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.DamageRecordToWH
{
    public partial class DamageRecordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
                fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                warehouseDropDownList.Focus();
            }

            if (damageRecordListGridView.Rows.Count > 0)
            {
                damageRecordListGridView.UseAccessibleHeader = true;
                damageRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadWarehouses()
        {
            WarehouseBLL warehouse = new WarehouseBLL();

            try
            {
                DataTable dt = warehouse.GetActiveWarehouseListByUser();

                warehouseDropDownList.DataSource = dt;
                warehouseDropDownList.DataValueField = "WarehouseId";
                warehouseDropDownList.DataTextField = "WarehouseName";
                warehouseDropDownList.DataBind();
                warehouseDropDownList.Items.Insert(0, "");
                warehouseDropDownList.SelectedIndex = 0;

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

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("DamageRecordIdForView", damageRecordListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/DamageRecordToWH/ApprovedDamageRecord.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void recordListButton_Click(object sender, EventArgs e)
        {
            SalesOrderBLL salesOrder = new SalesOrderBLL();

            try
            {
                if (warehouseDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Warehouse Name field is required.";
                }
                else if (fromDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date From field is required.";
                }
                else if (toDateTextBox.Text.Trim() == "" || LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim()) == "False")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Date To field is required.";
                }
                else
                {
                    string warehouseId = warehouseDropDownList.SelectedValue.Trim();
                    string fromDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    string toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    string status = statusDropDownList.SelectedValue.Trim();

                    DataTable dt = salesOrder.GetDamageRecordsListByWarehouseDateRangeAndStatus(warehouseId, fromDate, toDate, status);

                    damageRecordListGridView.DataSource = dt;
                    damageRecordListGridView.DataBind();

                    if (damageRecordListGridView.Rows.Count > 0)
                    {
                        damageRecordListGridView.UseAccessibleHeader = true;
                        damageRecordListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }
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