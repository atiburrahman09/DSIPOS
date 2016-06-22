using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.Services
{
    /// <summary>
    /// Summary description for BookName
    /// </summary>
    public class BookName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           
            DataTable dt = new DataTable();
            BookBLL bookBll = new BookBLL();
            dt = bookBll.GetBookNamesOnly();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["BookName"].ToString() + ";";
                sb.Append(name).Append(Environment.NewLine);
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