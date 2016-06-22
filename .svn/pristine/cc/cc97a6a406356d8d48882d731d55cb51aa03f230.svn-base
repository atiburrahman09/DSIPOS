using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.AccUI.ChartOfAccount
{
    public partial class ChartOfAccountTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    PopulateChartOfAccountTreeViewByAccountType(accountTypeDropDownList.SelectedValue.Trim());

                    accountTypeDropDownList.Focus();
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

        protected void accountListButton_Click(object sender, EventArgs e)
        {
            PopulateChartOfAccountTreeViewByAccountType(accountTypeDropDownList.SelectedValue.Trim());
            MyAlertBox("MyOverlayStop();");
        }

        protected void PopulateChartOfAccountTreeViewByAccountType(string accountType)
        {
            ChartOfAccountBLL chartOfAccount = new ChartOfAccountBLL();

            try
            {
                DataTable dt = chartOfAccount.GetChartOfAccountListByAccountType(accountType);

                if (dt.Rows.Count > 0)
                {
                    chartOfAccountTreeView.Nodes.Clear();
                    AddTopTreeViewNodes(dt);
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Chart Of Account List Data Not Found!!!"; msgDetailLabel.Text = "";
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

        private void AddTopTreeViewNodes(DataTable treeViewData)
        {
            DataView view = new DataView(treeViewData);
            view.RowFilter = "ParentSerial IS NULL";

            foreach (DataRowView row in view)
            {
                TreeNode newNode = new TreeNode(row["AccountName"].ToString(), row["Serial"].ToString());
                newNode.NavigateUrl = "javascript:void(0)";
                newNode.ToolTip = row["Description"].ToString() + " < ID:" + row["AccountId"].ToString() + " ~ ANo:" + row["AccountNumber"].ToString() + " ~ TANo:" + row["TotallingAccountNumber"].ToString() + " ~ Posted:" + row["IsPosted"].ToString() + " ~ Level:" + row["AccountLevel"].ToString() + " ~ Active:" + row["IsActive"].ToString() + " >";
                chartOfAccountTreeView.Nodes.Add(newNode);
                AddChildTreeViewNodes(treeViewData, newNode);
            }

        }

        private void AddChildTreeViewNodes(DataTable treeViewData, TreeNode parentTreeViewNode)
        {
            DataView view = new DataView(treeViewData);
            view.RowFilter = "ParentSerial=" + parentTreeViewNode.Value;

            foreach (DataRowView row in view)
            {
                TreeNode newNode = new TreeNode(row["AccountName"].ToString(), row["Serial"].ToString());
                newNode.NavigateUrl = "javascript:void(0)";
                newNode.ToolTip = row["Description"].ToString() + " < ID:" + row["AccountId"].ToString() + " ~ ANo:" + row["AccountNumber"].ToString() + " ~ TANo:" + row["TotallingAccountNumber"].ToString() + " ~ Posted:" + row["IsPosted"].ToString() + " ~ Level:" + row["AccountLevel"].ToString() + " ~ Active:" + row["IsActive"].ToString() + " >";
                parentTreeViewNode.ChildNodes.Add(newNode);
                AddChildTreeViewNodes(treeViewData, newNode);
            }
        }

        protected void expandAllLinkButton_Click(object sender, EventArgs e)
        {
            chartOfAccountTreeView.ExpandAll();
            MyAlertBox("MyOverlayStop();");
        }

        protected void collapseAllLinkButton_Click(object sender, EventArgs e)
        {
            chartOfAccountTreeView.CollapseAll();
            MyAlertBox("MyOverlayStop();");
        }
    }
}