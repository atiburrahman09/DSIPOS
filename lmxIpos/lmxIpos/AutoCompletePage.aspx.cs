using System;
using System.Data;
using System.Text;
using System.Web.Services;
using Lumex.Project.BLL;
using Lumex.Tech;
using Newtonsoft.Json;

namespace lmxIpos
{
    public partial class AutoCompletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetProductVolumes()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetProductVolumes();

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    string volume = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        volume = dt.Rows[i]["ProductVolume"].ToString().Trim();
                        sb.Append(volume).Append(Environment.NewLine);
                    }

                    return sb.ToString();
                }
                else
                {
                    return "No Product Volume saved yet!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                product = null;
            }
        }

        [WebMethod]
        public static string GetProductUnits()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetProductUnits();

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    string volume = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        volume = dt.Rows[i]["Unit"].ToString().Trim();
                        sb.Append(volume).Append(Environment.NewLine);
                    }

                    return sb.ToString();
                }
                else
                {
                    return "No Product Unit saved yet!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                product = null;
            }
        }

        [WebMethod]
        public static string GetProductNames()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetProductNames();

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    string volume = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        volume = dt.Rows[i]["ProductName"].ToString().Trim();
                        sb.Append(volume).Append(Environment.NewLine);
                    }

                    return sb.ToString();
                }
                else
                {
                    return "No Product saved yet!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                product = null;
            }
        }

        [WebMethod]
        public static string GetProductNamesOnly()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetProductNamesOnly();

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    string volume = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        volume = dt.Rows[i]["ProductNameOnly"].ToString().Trim();
                        sb.Append(volume).Append(Environment.NewLine);
                    }

                    return sb.ToString();
                }
                else
                {
                    return "No Product saved yet!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                product = null;
            }
        }

        [WebMethod]
        public static string GetProductBarcodes()
        {
            ProductBLL product = new ProductBLL();

            try
            {
                DataTable dt = product.GetProductBarcodes();

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    string volume = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        volume = dt.Rows[i]["Barcode"].ToString().Trim();
                        sb.Append(volume).Append(Environment.NewLine);
                    }

                    return sb.ToString();
                }
                else
                {
                    return "No Product saved yet!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                product = null;
            }
        }

        [WebMethod]
        public static string GetBankChequeBookAutoRefNosByAccountId(string accountId)
        {
            BankChequeBookBLL bankChequeBook = new BankChequeBookBLL();

            try
            {
                DataTable dt = bankChequeBook.GetBankChequeBookAutoRefNosByAccountId(accountId);

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();

                    string volume = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        volume = dt.Rows[i]["AutoRefNo"].ToString().Trim();
                        sb.Append(volume).Append(Environment.NewLine);
                    }

                    return sb.ToString();
                }
                else
                {
                    return "No Cheque Book saved yet!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                bankChequeBook = null;
            }
        }

        //[WebMethod]
        //public static string GetActiveUserInfo()
        //{
        //    try
        //    {
        //        DataTable dt = (DataTable)LumexSessionManager.Get("ActiveUserInfo");

        //        string json = JsonConvert.SerializeObject(dt);
        //        json = json.Substring(1, json.Length - 2);

        //        return json;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}