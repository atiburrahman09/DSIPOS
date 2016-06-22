using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.AccUI.BankBranch
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadBanks();

                    idLabel.Text = bankBranchIdForUpdateHiddenField.Value = LumexSessionManager.Get("BankBranchIdForUpdate").ToString().Trim();
                    GetBankBranchById(bankBranchIdForUpdateHiddenField.Value.Trim());
                    bankBranchNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                updateButton.Enabled = false;

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

        protected void GetBankBranchById(string bankBranchId)
        {
            BankBranchBLL bankBranch = new BankBranchBLL();

            try
            {
                DataTable dt = bankBranch.GetBankBranchById(bankBranchId);

                if (dt.Rows.Count > 0)
                {
                    bankBranchNameForUpdateHiddenField.Value = bankBranchNameTextBox.Text = dt.Rows[0]["BranchName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["Description"].ToString();
                    bankDropDownList.SelectedValue = dt.Rows[0]["BankId"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Bank Branch Data Not Found!!!"; msgDetailLabel.Text = "";
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
                bankBranch = null;
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            BankBranchBLL bankBranch = new BankBranchBLL();

            try
            {
                if (bankBranchIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Bank Branch not found to update.";
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
                    bankBranch.BankBranchId = bankBranchIdForUpdateHiddenField.Value.Trim();
                    bankBranch.BankBranchName = bankBranchNameTextBox.Text.Trim();
                    bankBranch.Description = descriptionTextBox.Text.Trim();

                    if (!bankBranch.CheckDuplicateBankBranch(bankBranch.BankId, bankBranchNameTextBox.Text.Trim()))
                    {
                        bankBranch.UpdateBankBranch();

                        bankBranchNameForUpdateHiddenField.Value = "";
                        bankBranchIdForUpdateHiddenField.Value = "";

                        string message = "Bank Branch <span class='actionTopic'>Updated</span> Successfully.";
                        MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/BankBranch/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        if (bankBranchNameForUpdateHiddenField.Value == bankBranchNameTextBox.Text.Trim())
                        {
                            bankBranch.BankBranchName = "WithOut";
                            bankBranch.UpdateBankBranch();

                            bankBranchNameForUpdateHiddenField.Value = "";
                            bankBranchIdForUpdateHiddenField.Value = "";

                            string message = "Bank Branch <span class='actionTopic'>Updated</span> Successfully.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/AccUI/BankBranch/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        }
                        else
                        {
                            string message = "This Bank Branch Name <span class='actionTopic'>already exist</span>, try another one.";
                            MyAlertBox("WarningAlert(\"" + "Data Duplicate" + "\", \"" + message + "\");");
                        }
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