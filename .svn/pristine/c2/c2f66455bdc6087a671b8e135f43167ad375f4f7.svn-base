using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.production
{
    public partial class approval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgbox.Visible = false;

            if (!IsPostBack)
            {
                LoadWarehouses();
                fromDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                toDateTextBox.Text = LumexLibraryManager.GetAppDateView(DateTime.Today.ToString());
                ddlWareHouseList.Focus();
               
            }
            if (gridProductionList.Rows.Count > 0)
            {
                gridProductionList.UseAccessibleHeader = true;
                gridProductionList.HeaderRow.TableSection = TableRowSection.TableHeader;
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

                ddlWareHouseList.DataSource = dt;
                ddlWareHouseList.DataValueField = "WarehouseId";
                ddlWareHouseList.DataTextField = "WarehouseName";
                ddlWareHouseList.DataBind();
                ddlWareHouseList.Items.Insert(0, "");
                ddlWareHouseList.SelectedIndex = 0;
                ddlWareHouseList.SelectedValue = LumexSessionManager.Get("UserWareHouseId").ToString();

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

        protected void btnProducktionRL_Click(object sender, EventArgs e)
        {
            newproductionBLL newProduction = new newproductionBLL();
            try
            {
                if (ddlWareHouseList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Sales Center Name field is required.";
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
                    newProduction.wareHouseID = ddlWareHouseList.SelectedValue.ToString().Trim();
                    newProduction.formDate = LumexLibraryManager.ParseAppDate(fromDateTextBox.Text.Trim());
                    newProduction.toDate = LumexLibraryManager.ParseAppDate(toDateTextBox.Text.Trim());
                    newProduction.status = ddlstatus.SelectedValue.ToString().Trim();

                    DataTable dt = newProduction.getApprovalProductList();
                    //if (gridProductionList.Rows.Count > 0)
                    //{
                    //    gridProductionList.DataSource = null;
                    //}

                    gridProductionList.DataSource = dt;
                    gridProductionList.DataBind();

                    if (gridProductionList.Rows.Count > 0)
                    {
                        //gridProductionList.Visible = true;
                        gridProductionList.UseAccessibleHeader = true;
                        gridProductionList.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                newProduction = null;
            }
        }

        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton viewButton = (LinkButton)sender;
                GridViewRow row = (GridViewRow)viewButton.NamingContainer;

                LumexSessionManager.Add("newPoroductId", gridProductionList.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/UI/production/newproductionDetails.aspx");
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