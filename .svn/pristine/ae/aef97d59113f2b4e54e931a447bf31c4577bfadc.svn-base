using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lumex.Tech;
using System.Data;
using Lumex.Project.BLL;
using System.Text;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for ProductSearchforSale
    /// </summary>
    public class ProductSearchforSale : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            DataTable dt = new DataTable();
            ProductBLL product = new ProductBLL();
            //context.Response.ContentType = "text/plain";
            var id = context.Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                id = LumexSessionManager.Get("ActiveUserId").ToString();
                dt = product.GetActiveProductListByUser(id);
            }
            else
            {
                if (id[0] == 'W')
                {
                    dt = product.GetAllProductsByWareHouse(id);
                }
                else
                {
                    dt = product.GetAllProductsBySalesCenter(id);
                }
                
            }

           // LumexDBPlayer db = LumexDBPlayer.Start();
           
            //dt = product.GetProductNamesForSales();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string employee = dt.Rows[i]["ProductId"].ToString()+"["+ dt.Rows[i]["ProductName"].ToString()+"]" + ";";
                sb.Append(employee).Append(Environment.NewLine);
            }

            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}