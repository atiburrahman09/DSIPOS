using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.BankBranch
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadBanks();
                    bankDropDownList.Focus();
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

        protected void LoadBanks()
        {
            BankBLL bank = new BankBLL();

            try
            {
                DataTable dt = bank.GetActiveBankList();

                bankDropDownList.DataSource = dt;
                bankDropDownList.DataValueField = "BankId";
                bankDropDownList.DataTextField = "BankName";
                bankDropDownList.DataBind();
                bankDropDownList.Items.Insert(0, "");
                bankDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bank = null;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BankBranchBLL bankBranch = new BankBranchBLL();

            try
            {
                if (bankDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Name field is required.";
                }
                else if (bankBranchNameTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Bank Branch Name field is required.";
                }
                else if (descriptionTextBox.Text.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    bankBranch.BankId = bankDropDownList.SelectedValue.Trim();
                    bankBranch.BankBranchName = bankBranchNameTextBox.Text.Trim();
                    bankBranch.Description = descriptionTextBox.Text.Trim();

                    if (!bankBranch.CheckDuplicateBankBranch(bankBranch.BankId.Trim(), bankBranch.BankBranchName.Trim()))
                    {
                        DataTable dt = bankBranch.SaveBankBranch();

                        if (dt.Rows.Count > 0)
                        {
                            string message = "Bank Branch <span class='actionTopic'>Created</span> Successfully with Bank Branch ID: <span class='actionTopic'>" + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/BankBranch/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "<span class='actionTopic'>Failed</span> to Create Bank Branch.";
                            MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                        }
                    }
                    else
                    {
                        string message = "This Bank Branch Name <span class='actionTopic'>already exist</span>, try another one.";
                        MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                    }
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
                bankBranch = null;
            }
        }
    }
}