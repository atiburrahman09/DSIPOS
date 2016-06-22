using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Lumex.Tech;

namespace lmxIpos
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument reportDocument = (ReportDocument)LumexSessionManager.Get("ReportData");
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "IPOSReport");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}