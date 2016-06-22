using System;
using CrystalDecisions.CrystalReports.Engine;
using Lumex.Tech;
using CrystalDecisions.Shared;

namespace lmxIpos
{
    public partial class ReportExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                crViewer.AllowedExportFormats = (int)(ViewerExportFormats.ExcelFormat | ViewerExportFormats.PdfFormat | ViewerExportFormats.CsvFormat | ViewerExportFormats.EditableRtfFormat | ViewerExportFormats.ExcelRecordFormat | ViewerExportFormats.NoFormat | ViewerExportFormats.RtfFormat | ViewerExportFormats.WordFormat);
      
                ReportDocument reportDocument = (ReportDocument)LumexSessionManager.Get("ReportData");
                crViewer.ReportSource = reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}