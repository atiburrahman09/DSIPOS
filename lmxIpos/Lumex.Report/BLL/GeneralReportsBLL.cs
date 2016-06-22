using System;
using Lumex.Report.DAL;
using Lumex.Tech;

namespace Lumex.Report.BLL
{
    public class GeneralReportsBLL
    {
        public void GetCustomerListByActivationStatus(string sortedBy, string sortingOrder, string isActive)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetCustomerListByActivationStatus(sortedBy, sortingOrder, isActive, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetVendorListByActivationStatus(string sortedBy, string sortingOrder, string isActive)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetVendorListByActivationStatus(sortedBy, sortingOrder, isActive, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSalesCenterListByActivationStatus(string sortedBy, string sortingOrder, string isActive)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetSalesCenterListByActivationStatus(sortedBy, sortingOrder, isActive, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSelectedCustomersDetails(string customersId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetSelectedCustomersDetails(customersId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSelectedVendorsDetails(string vendorsId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetSelectedVendorsDetails(vendorsId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSelectedSalesCentersDetails(string salesCentersId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetSelectedSalesCentersDetails(salesCentersId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetCustomerListByJoiningSalesCenter(string sortedBy, string sortingOrder, string isActive, string salesCenterId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetCustomerListByJoiningSalesCenter(sortedBy, sortingOrder, isActive, salesCenterId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetVendorListByProduct(string sortedBy, string sortingOrder, string isActive, string productBarcodeIdName)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetVendorListByProduct(sortedBy, sortingOrder, isActive, productBarcodeIdName, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetSalesCenterListByWarehouse(string sortedBy, string sortingOrder, string isActive, string warehouseId)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetSalesCenterListByWarehouse(sortedBy, sortingOrder, isActive, warehouseId, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetDeletedCustomerListByDateRangeAll(string sortedBy, string sortingOrder, string fromDate, string toDate, string search)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetDeletedCustomerListByDateRangeAll(sortedBy, sortingOrder, fromDate, toDate, search, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetDeletedVendorListByDateRangeAll(string sortedBy, string sortingOrder, string fromDate, string toDate, string search)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetDeletedVendorListByDateRangeAll(sortedBy, sortingOrder, fromDate, toDate, search, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetDeletedSalesCenterListByDateRangeAll(string sortedBy, string sortingOrder, string fromDate, string toDate, string search)
        {
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                GeneralReportsDAL generalReports = new GeneralReportsDAL();

                if (LumexSessionManager.Get("ReportData") != null)
                {
                    LumexSessionManager.Remove("ReportData");
                }

                LumexSessionManager.Add("ReportData", generalReports.GetDeletedSalesCenterListByDateRangeAll(sortedBy, sortingOrder, fromDate, toDate, search, db));
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
