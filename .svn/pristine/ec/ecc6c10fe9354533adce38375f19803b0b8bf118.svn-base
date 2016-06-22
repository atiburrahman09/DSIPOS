using System;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using Lumex.Tech;

namespace Lumex.Report.DAL
{
    public class IPOSReportDAL
    {
        string reportPath = HttpContext.Current.Server.MapPath("/RptFiles/");

        public ReportDocument GetCustomerReceivableListById(string customerId, string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@CustomerId", customerId.Trim());
                db.AddParameters("@SalesCenterId", SalesCenterId);

                reportDocument.Load(reportPath + "REPORT_GET_CUSTOMER_RECEIVABLE_LIST_BY_ID.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_CUSTOMER_RECEIVABLE_LIST_BY_ID", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetAvailableProductBySaclesCenterId(string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "S");

                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetAvailableProductBySaclesCenterIdPRWise(string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "S");

                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetPurchaseRecordbySC_Date_RANGE_STATUS(string SalesCenterId, string ToDate, string FromDate, string PrStatus, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", PrStatus.Trim());
                if (SalesCenterId.Substring(0, 1) == "S")
                {
                    db.AddParameters("Type", "S");
                }
                else
                {
                    db.AddParameters("Type", "W");
                }

                reportDocument.Load(reportPath + "REPORT_GET_PURCHASE_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_PURCHASE_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetSalesRecordbySC_Date_RANGE_STATUS(string SalesCenterId, string ToDate, string FromDate, string SRStatus, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", SRStatus.Trim());

                reportDocument.Load(reportPath + "REPORT_GET_SALES_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_SALES_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetBalance_Sheet_Report_by_Date(string ReportType, string SCWHId, string Date, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@TransactionDate", LumexLibraryManager.ParseAppDate(Date.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_BALANCE_SHEET_BY_DATE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_BALANCE_SHEET_BY_DATE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetFinancial_Ladger_Report_by_Date_and_AccountId(string ReportType, string SCWHId, string accountId, string toDate, string FromDate, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@AccountId", accountId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(toDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_FINANCIAL_LEDGER_BY_DATE_RANGE_AND_ACCOUNT.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_FINANCIAL_LEDGER_BY_DATE_RANGE_AND_ACCOUNT", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetGeneral_ledger_Sheet_Report_by_Date(string ReportType, string SCWHId, string toDate, string FromDate, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(toDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_GENERAL_LEDGER_BY_DATE_RANGE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_GENERAL_LEDGER_BY_DATE_RANGE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object Get_Income_Statement_by_Date(string ReportType, string SCWHId, string toDate, string fromDate, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(fromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(toDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_INCOME_STATEMENT_BY_DATE_RANGE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_INCOME_STATEMENT_BY_DATE_RANGE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object Get_Trial_Balance_by_Date(string ReportType, string SCWHId, string Date, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@ReportType", ReportType);
                db.AddParameters("@OfficeBranchId", SCWHId);
                db.AddParameters("@TransactionDate", LumexLibraryManager.ParseAppDate(Date.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_TRIAL_BALANCE_BY_DATE.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_TRIAL_BALANCE_BY_DATE", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetCustomerReceivePaymentList(string SalesCenter, string CustomerId, string FromDate, string ToDate, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();
                db.AddParameters("@SalesCenterId", SalesCenter);
                db.AddParameters("@CustomerId", CustomerId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));

                reportDocument.Load(reportPath + "REPORT_GET_CUSTOMER_WISE_RECEIVE_PAYMENT_LIST.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_CUSTOMER_WISE_RECEIVE_PAYMENT_LIST", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal object GetAvailableProductByWarehouseId(string WarehouseId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", WarehouseId.Trim());
                db.AddParameters("@Rtype", "W");
                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetAvailableProductByWarehouseIdPRWise(string WarehouseId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCenterId", WarehouseId.Trim());
                db.AddParameters("@Rtype", "W");

                reportDocument.Load(reportPath + "REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_AVAILABLE_PRODUCT_LIST_PR_WISE_BY_SALES_CENTER", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal object GetSalesCenterVendorReceivePaymentList(string SalesCenterId, string VendorId, string FromDate, string ToDate, string status, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@VendorId", VendorId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", status);
                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "S");

                reportDocument.Load(reportPath + "REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal object GetWarehouseVendorReceivePaymentList(string SalesCenterId, string VendorId, string FromDate, string ToDate, string status, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@VendorId", VendorId.Trim());
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate.Trim()));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate.Trim()));
                db.AddParameters("@Status", status);
                db.AddParameters("@SalesCenterId", SalesCenterId.Trim());
                db.AddParameters("@Rtype", "W");

                reportDocument.Load(reportPath + "REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST.rpt");
                DataTable dt = db.ExecuteDataTable("REPORT_GET_VENDOR_WISE_RECEIVE_PAYMENT_LIST", true);
                reportDocument.SetDataSource(dt);

                return reportDocument;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
