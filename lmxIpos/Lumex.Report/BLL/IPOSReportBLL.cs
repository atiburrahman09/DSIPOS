using System;
using Lumex.Report.DAL;
using Lumex.Tech;

namespace Lumex.Report.BLL
{
    public class IPOSReportBLL
    {
        public void GetCustomerReceivableListById(string customersId, string SalesCenterId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetCustomerReceivableListById(customersId, SalesCenterId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetAvailableProductBySaclesCenterId(string SalesCenterId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetAvailableProductBySaclesCenterId(SalesCenterId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetAvailableProductBySaclesCenterIdPRWise(string SalesCenterId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetAvailableProductBySaclesCenterIdPRWise(SalesCenterId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetPurchaseRecordbySC_Date_RANGE_STATUS(string SalesCenterId, string ToDate, string FromDate, string PrStatus)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetPurchaseRecordbySC_Date_RANGE_STATUS(SalesCenterId, ToDate, FromDate, PrStatus, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSalesRecordbySC_Date_RANGE_STATUS(string SalesCenterId, string ToDate, string FromDate, string SRStatus)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetSalesRecordbySC_Date_RANGE_STATUS(SalesCenterId, ToDate, FromDate, SRStatus, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetBalance_Sheet_Report_by_Date(string ReportType, string SCWHId, string Date)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetBalance_Sheet_Report_by_Date(ReportType, SCWHId, Date, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetFinancial_Ladger_Report_by_Date_and_AccountId(string ReportType, string SCWHId, string accountId, string toDate, string FromDate)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetFinancial_Ladger_Report_by_Date_and_AccountId(ReportType, SCWHId, accountId, toDate, FromDate, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetGeneral_ledger_Sheet_Report_by_Date(string ReportType, string SCWHId, string toDate, string FormDate)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetGeneral_ledger_Sheet_Report_by_Date(ReportType, SCWHId, toDate, FormDate, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Get_Income_Statement_by_Date(string ReportType, string SCWHId, string toDate, string fromDate)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.Get_Income_Statement_by_Date(ReportType, SCWHId, toDate, fromDate, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Get_Trial_Balance_by_Date(string ReportType, string SCWHId, string Date)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.Get_Trial_Balance_by_Date(ReportType, SCWHId, Date, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetCustomerReceivePaymentList(string SalesCenter, string CustomerId, string FromDate, string ToDate)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetCustomerReceivePaymentList(SalesCenter, CustomerId, FromDate, ToDate, db));
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetAvailableProductByWarehouseId(string WarehouseId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetAvailableProductByWarehouseId(WarehouseId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetAvailableProductByWarehouseIdPRWise(string WarehouseId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetAvailableProductByWarehouseIdPRWise(WarehouseId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSalesCenterVendorReceivePaymentList(string SalesCenterId, string VendorId, string FromDate, string ToDate, string status)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetSalesCenterVendorReceivePaymentList(SalesCenterId, VendorId, FromDate, ToDate, status, db));
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetWarehouseVendorReceivePaymentList(string SalesCenterId, string VendorId, string FromDate, string ToDate, string status)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                IPOSReportDAL iposReport = new IPOSReportDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", iposReport.GetWarehouseVendorReceivePaymentList(SalesCenterId, VendorId, FromDate, ToDate, status, db));
                db.Stop();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
