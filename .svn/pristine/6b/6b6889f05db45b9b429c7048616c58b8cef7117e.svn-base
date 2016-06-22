using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;

namespace lmxIpos.UI.Product
{
    public partial class ManageProductVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;
                productTextBox.Attributes.Add("autocomplete", "off");

                if (!IsPostBack)
                {
                    GetVendorList();
                    productTextBox.Focus();
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

        protected void GetVendorList()
        {
            VendorBLL vendor = new VendorBLL();

            try
            {
                DataTable dt = vendor.GetVendorList();

                if (dt.Rows.Count > 0)
                {
                    vendorListListBox.Items.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vendorListListBox.Items.Add(new ListItem(dt.Rows[i]["VendorName"].ToString(), dt.Rows[i]["VendorId"].ToString()));
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Vendor Data Not Found!!!"; msgDetailLabel.Text = "";
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
                vendor = null;
                countVendorLabel.Text = "Total: " + vendorListListBox.Items.Count.ToString();
            }
        }

        protected void productVendorButton_Click(object sender, EventArgs e)
        {
            ProductBLL product = new ProductBLL();
            VendorBLL vendor = new VendorBLL();

            try
            {
                string productBarcodeIdName = "";
                string[] pid = productTextBox.Text.Trim().Split('[');
                if (pid.Length > 1)
                {
                    productBarcodeIdName = pid[0];
                }
                else
                {
                    productBarcodeIdName = productTextBox.Text.Trim();
                }
                DataTable dt = product.GetProductByBarcodeIdName(productBarcodeIdName);

                if (dt.Rows.Count > 0)
                {
                    barcodeLabel.Text = dt.Rows[0]["Barcode"].ToString();
                    productIdLabel.Text = dt.Rows[0]["ProductId"].ToString();
                    productNameLabel.Text = dt.Rows[0]["ProductName"].ToString();
                    productGroupNameLabel.Text = dt.Rows[0]["ProductGroupName"].ToString();

                    productVendorListListBox.Items.Clear();
                    DataTable dtVendor = vendor.GetProductVendorsByProductId(productIdLabel.Text.Trim());

                    for (int i = 0; i < dtVendor.Rows.Count; i++)
                    {
                        productVendorListListBox.Items.Add(new ListItem(dtVendor.Rows[i]["VendorName"].ToString(), dtVendor.Rows[i]["VendorId"].ToString()));
                    }

                    productVendorPane.Visible = true;
                }
                else
                {
                    productVendorPane.Visible = false;
                    msgbox.Visible = true; msgTitleLabel.Text = "Product Data Not Found!!!"; msgDetailLabel.Text = "";
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
                product = null;
                vendor = null;
                countProductVendorLabel.Text = "Total: " + productVendorListListBox.Items.Count.ToString();
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void removeAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productVendorListListBox.Items.Count > 0)
                {
                    productVendorListListBox.Items.Clear();
                    countProductVendorLabel.Text = "Total: " + productVendorListListBox.Items.Count.ToString();
                }
                else
                {
                    string message = "No item(s) is found from Product's Vendor List.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
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
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void addAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (vendorListListBox.Items.Count > 0)
                {
                    productVendorListListBox.Items.Clear();

                    for (int i = 0; i < vendorListListBox.Items.Count; i++)
                    {
                        productVendorListListBox.Items.Add(new ListItem(vendorListListBox.Items[i].Text, vendorListListBox.Items[i].Value));
                    }
                }
                else
                {
                    string message = "No item(s) is found from Vendor List.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countProductVendorLabel.Text = "Total: " + productVendorListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productVendorListListBox.SelectedIndex > -1)
                {
                    productVendorListListBox.Items.RemoveAt(productVendorListListBox.SelectedIndex);
                }
                else
                {
                    string message = "Select an item from Product's Vendor List to remove.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countProductVendorLabel.Text = "Total: " + productVendorListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (vendorListListBox.SelectedIndex > -1)
                {
                    for (int i = 0; i < productVendorListListBox.Items.Count; i++)
                    {
                        if (productVendorListListBox.Items[i].Value == vendorListListBox.SelectedValue) { return; }
                    }

                    productVendorListListBox.Items.Add(new ListItem(vendorListListBox.SelectedItem.Text, vendorListListBox.SelectedItem.Value));
                    productVendorListListBox.SelectedIndex = productVendorListListBox.Items.Count - 1;
                }
                else
                {
                    string message = "Select an item from Vendor List to add.";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
                }

                countProductVendorLabel.Text = "Total: " + productVendorListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            VendorBLL vendor = new VendorBLL();
            List<string> vendors = new List<string>();

            try
            {
                if (productVendorListListBox.Items.Count > 0)
                {
                    for (int i = 0; i < productVendorListListBox.Items.Count; i++)
                    {
                        vendors.Add(productVendorListListBox.Items[i].Value.Trim());
                    }

                    vendor.SaveProductVendorsByProductId(productIdLabel.Text.Trim(), vendors);

                    string message = "Product's Vendor List <span class='actionTopic'>Saved</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/UI/Product/ManageProductVendor.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                }
                else
                {
                    string message = "No Vendor is added for this product, must be added one or more vendor(s).";
                    MyAlertBox("ErrorAlert(\"" + "Process Failed" + "\", \"" + message + "\");");
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
                vendor = null;
                vendors = null;
            }
        }
    }
}