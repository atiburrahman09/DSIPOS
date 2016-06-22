using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using Lumex.Tech;
using System.Data;
using Lumex.Project.BLL;
using System.Text;
using Lumex.Tech;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for ProductSearch
    /// </summary>
    public class ProductSearch : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                //if (id[0] == 'W')
                //{
                //    dt = product.GetAllProductsByWareHouse(id);
                //}
                //else
                //{
                //    dt = product.GetAllProductsBySalesCenter(id);
                //}
                dt = product.GetActiveProductsByWareHouseorSalesCenter(id);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string productName = dt.Rows[i]["ProductId"].ToString() +"[ "+ dt.Rows[i]["ProductName"].ToString() +" ];";
                sb.Append(productName).Append(Environment.NewLine);
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