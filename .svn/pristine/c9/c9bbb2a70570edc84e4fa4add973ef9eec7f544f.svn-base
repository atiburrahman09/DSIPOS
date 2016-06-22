using System;
using System.Data;
using System.Web.UI;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.TodaysCashOut
{
    public partial class UpdateCashOutEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = cashOutEntrySerialForUpdateHiddenField.Value = LumexSessionManager.Get("CashOutSerialForUpdate").ToString().Trim();
                    LoadChartOfAccountsHeadList();
                    LoadData();
                    amountTextBox.Focus();
                    
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
        private void LoadData()
        {
            CashOutBLL cashOutBll = new CashOutBLL();
            try
            {


                DataTable dt = cashOutBll.GetTodaysCashOutEntryListBySerial();
                //txtbxSerial.Text = dt.Rows[0]["Serial"].ToString();
                //txtbxSerial.Text = LumexSessionManager.Get("CashOutSerialForUpdate").ToString().Trim();
                accountHeadDropDownList.SelectedValue = dt.Rows[0]["AccountId"].ToString();
                txtbxDescription.Text = dt.Rows[0]["Description"].ToString();
                amountTextBox.Text = dt.Rows[0]["Amount"].ToString();
                narrationTextBox.Text = dt.Rows[0]["Narration"].ToString();
                entryDateTextBox.Text = DateTime.Parse(dt.Rows[0]["CashOutDate"].ToString().Trim()).ToString(LumexLibraryManager.GetAppDateFormat());
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void LoadChartOfAccountsHeadList()
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetChartOfAccountListByAccountType("E");

                accountHeadDropDownList.DataSource = dt;
                accountHeadDropDownList.DataValueField = "AccountId";
                accountHeadDropDownList.DataTextField = "AccountName";
                accountHeadDropDownList.DataBind();
                accountHeadDropDownList.Items.Insert(0, "");
                accountHeadDropDownList.SelectedIndex = 0;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    ListItem item1 = new ListItem(dt.Rows[i]["AccountHead"].ToString(), dt.Rows[i]["AccountId"].ToString());

                //    if (dt.Rows[i]["AccountId"].ToString().Contains("A"))
                //    {
                //        item1.Attributes["OptionGroup"] = "Asset";
                //    }
                //    else if (dt.Rows[i]["AccountId"].ToString().Contains("E"))
                //    {
                //        item1.Attributes["OptionGroup"] = "Expense";
                //    }
                //    else if (dt.Rows[i]["AccountId"].ToString().Contains("I"))
                //    {
                //        item1.Attributes["OptionGroup"] = "Income";
                //    }
                //    else if (dt.Rows[i]["AccountId"].ToString().Contains("L"))
                //    {
                //        item1.Attributes["OptionGroup"] = "Liability";
                //    }

                //    accountHeadDropDownList.Items.Add(item1);

                //}

                //accountHeadDropDownList.DataSource = dt;
                //accountHeadDropDownList.DataValueField = "AccountId";
                //accountHeadDropDownList.DataTextField = "AccountHead";
                //accountHeadDropDownList.DataBind();
                // accountHeadDropDownList.Items.Insert(0, "");
                //accountHeadDropDownList.SelectedIndex = 0;

                if (dt.Rows.Count < 1)
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Account Head Data Not Found!!!"; msgDetailLabel.Text = "";
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
                chartOfAccount = null;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            CashOutBLL cashOut = new CashOutBLL();

            try
            {
                if (cashOutEntrySerialForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Cash Out Entry not found to update.";
                }
                else if (amountTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Amount field is required.";
                }
                else if (narrationTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Narration field is required.";
                }
                else if (accountHeadDropDownList.SelectedValue == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Account Head field is required.";
                }
                else
                {
                    cashOut.Serial = idLabel.Text.Trim();
                    cashOut.Amount = amountTextBox.Text.Trim();
                    cashOut.Narration = narrationTextBox.Text.Trim();
                    cashOut.EntryDate = LumexLibraryManager.ParseAppDate(entryDateTextBox.Text.Trim());
                    //cashOut.AccountHEad = accountHeadDropDownList.SelectedValue.Trim();
                    cashOut.Description = txtbxDescription.Text.Trim();
                    cashOut.AccountHEad = accountHeadDropDownList.SelectedValue;


                    cashOut.UpdateTodaysCashOutEntryBySerial();

                    cashOutEntrySerialForUpdateHiddenField.Value = "";

                    string message = "Cash Out Entry <span class='actionTopic'>Updated</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/TodaysCashOut/TodaysCashOutList.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                cashOut = null;
            }
        }
    }
}