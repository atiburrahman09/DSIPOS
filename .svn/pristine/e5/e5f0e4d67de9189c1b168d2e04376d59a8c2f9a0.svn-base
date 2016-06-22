using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;
using Lumex.Project.BLL;
using System.Data;

namespace lmxIpos.UI.production
{
    public partial class newproductionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblProductionID.Text = (string)LumexSessionManager.Get("newPoroductId");
                getProductionDetails(lblProductionID.Text);
                getRawmetarialDetailsByProductionID(lblProductionID.Text);
            }
        }
        protected void getProductionDetails(string productionID)
        {
            newproductionBLL newProductionBll = new newproductionBLL();
     
            try
            {
                DataTable dt = newProductionBll.getProductionDetailsbyProductionID(productionID);
                if (dt.Rows.Count > 0)
                {
                    //lblProductCreatedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    lblProductionName.Text = dt.Rows[0]["ProductName"].ToString();
                    lblProductCreatedBy.Text = dt.Rows[0]["CreatedByUser"].ToString();
                    lblProduceWeight.Text = dt.Rows[0]["ProduceWight"].ToString();
                    lblProductBundle.Text = dt.Rows[0]["ProduceBundle"].ToString();
                    lblProduceDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    lblUnitCost.Text = dt.Rows[0]["UnitCost"].ToString();
                    lblProductionCost.Text = dt.Rows[0]["ProductionCost"].ToString();
                    lblTotQuantity.Text = dt.Rows[0]["TotalQualnity"].ToString();
                    lblRawMetarialCost.Text = dt.Rows[0]["RawMaterialCost"].ToString();
                    lblOtherAmmount.Text = dt.Rows[0]["OtherAmount"].ToString();
                    lblWorkingCost.Text = dt.Rows[0]["WorkingCost"].ToString();
                    lblDecreaseRate.Text = dt.Rows[0]["DecreaseRate"].ToString();
                    lblDecreaseWeight.Text = dt.Rows[0]["DecreaseWeight"].ToString();
                    lblDescription.Text = dt.Rows[0]["DescripTions"].ToString();
                    lblStatus.Value = dt.Rows[0]["ProduceStatus"].ToString();
                    if (lblStatus.Value == "Pending")
                    {
                        btnAccept.Visible = true;
                        btnReject.Visible = true;
                    }
                    else
                    {
                        btnAccept.Visible = false;
                        btnReject.Visible = false;
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Not Found"; msgDetailLabel.Text = "No production data found";
                }
            }
            catch(Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
        protected void getRawmetarialDetailsByProductionID(string productionID)
        {
            newproductionBLL newProductionBll = new newproductionBLL();
            try
            {
                DataTable dt = newProductionBll.getRawmetarialsbyProductionID(productionID);

                if (dt.Rows.Count > 0)
                {
                    gridRawMetarials.DataSource = dt;
                    gridRawMetarials.DataBind();

                    if (gridRawMetarials.Rows.Count > 0)
                    {
                        gridRawMetarials.UseAccessibleHeader = true;
                        gridRawMetarials.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            newproductionBLL newProductionBLl = new newproductionBLL();
            DataTable dt = new DataTable();
            try
            {
                newProductionBLl.productionId = lblProductionID.Text.Trim();
                if (rejectProduct(newProductionBLl.productionId))
                {
                    string message = "Product's <span class='actionTopic'>Rejected</span> Successfully <span class='actionTopic'>" +
                           "</span>.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/production/approval.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\",callbackOk);");
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Production does not rejected"; msgDetailLabel.Text = "";
                }
       
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected bool rejectProduct(string ProductionID)
        {
            newproductionBLL newProductionBll = new newproductionBLL();
            bool status = false;
            try
            {
                status = newProductionBll.rejectProduct(ProductionID);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            return status;
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            bool status;
            try
            {
                string ID = lblProductionID.Text.Trim();
                if (approveNewProduction(ID))
                {
                    string message = "New Production <span class='actionTopic'>Approved</span> Successfully <span class='actionTopic'>" +
                          "</span>.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/production/approval.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\",callbackOk);");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected bool approveNewProduction(string productionId)
        {
            bool status = false;
            try
            {
                newproductionBLL newProductionBll = new newproductionBLL();
                status = newProductionBll.approveNewProductionwithProductionId(productionId);
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }
      
    }
}