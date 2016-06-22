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
    /// Summary description for ProductsUnits
    /// </summary>
    public class ProductsUnits : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           // LumexDBPlayer db = LumexDBPlayer.Start();
            DataTable dt = new DataTable();
            ProductBLL product = new ProductBLL();
            dt = product.GetProductUnits();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string employee = dt.Rows[i]["Unit"].ToString() + ";";
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