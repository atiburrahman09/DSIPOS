using Lumex.Project.BLL;
using Lumex.Tech;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for ProductSearchByWH
    /// </summary>
    public class ProductSearchByWH : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request.QueryString["id"];
            LumexDBPlayer db = LumexDBPlayer.Start();
            DataTable dt = new DataTable();
            ProductBLL product = new ProductBLL();
            dt = product.GetProductNamesByWareHouse(id);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string employee = dt.Rows[i]["ProductName"].ToString() + ";";
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