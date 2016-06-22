using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using Lumex.Tech;
using System.Data;
using Lumex.Project.BLL;
using System.Text;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for ProductSearch
    /// </summary>
    public class ProductSearch : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            var id = context.Request.QueryString["id"];
            LumexDBPlayer db = LumexDBPlayer.Start();
            DataTable dt = new DataTable();
            ProductBLL product = new ProductBLL();
            dt = product.GetProductNamesBySalesCenter(id); 

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string employee = dt.Rows[i]["ProductName"].ToString()+";";
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