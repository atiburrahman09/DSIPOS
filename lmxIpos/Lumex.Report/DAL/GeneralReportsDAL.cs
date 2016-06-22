using System;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using Lumex.Tech;

namespace Lumex.Report.DAL
{
    public class GeneralReportsDAL
    {
        string reportPath = HttpContext.Current.Server.MapPath("/ReportFiles/GeneralReports/");

        public ReportDocument GetCustomerListByActivationStatus(string sortedBy, string sortingOrder, string isActive, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@IsActive", isActive.Trim());

                if (isActive == "All")
                {
                    reportDocument.Load(reportPath + "GET_CUSTOMERS.rpt");
                }
                else
                {
                    reportDocument.Load(reportPath + "GET_CUSTOMERS_BY_ACTIVATION_STATUS.rpt");
                }

                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_CUSTOMERS_BY_ACTIVATION_STATUS", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetVendorListByActivationStatus(string sortedBy, string sortingOrder, string isActive, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@IsActive", isActive.Trim());

                if (isActive == "All")
                {
                    reportDocument.Load(reportPath + "GET_VENDORS.rpt");
                }
                else
                {
                    reportDocument.Load(reportPath + "GET_VENDORS_BY_ACTIVATION_STATUS.rpt");
                }

                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_VENDORS_BY_ACTIVATION_STATUS", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetSalesCenterListByActivationStatus(string sortedBy, string sortingOrder, string isActive, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@IsActive", isActive.Trim());

                if (isActive == "All")
                {
                    reportDocument.Load(reportPath + "GET_SALES_CENTERS.rpt");
                }
                else
                {
                    reportDocument.Load(reportPath + "GET_SALES_CENTERS_BY_ACTIVATION_STATUS.rpt");
                }

                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_SALES_CENTERS_BY_ACTIVATION_STATUS", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetSelectedCustomersDetails(string customersId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@CustomersId", customersId.Trim());

                reportDocument.Load(reportPath + "GET_CUSTOMERS_FOR_DETAILS.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_CUSTOMERS_FOR_DETAILS", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetSelectedVendorsDetails(string vendorsId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@VendorsId", vendorsId.Trim());

                reportDocument.Load(reportPath + "GET_VENDORS_FOR_DETAILS.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_VENDORS_FOR_DETAILS", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetSelectedSalesCentersDetails(string salesCentersId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SalesCentersId", salesCentersId.Trim());

                reportDocument.Load(reportPath + "GET_SALES_CENTERS_FOR_DETAILS.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_SALES_CENTERS_FOR_DETAILS", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetCustomerListByJoiningSalesCenter(string sortedBy, string sortingOrder, string isActive, string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@IsActive", isActive.Trim());
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());

                reportDocument.Load(reportPath + "GET_CUSTOMERS_BY_JOINING_SALES_CENTER.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_CUSTOMERS_BY_JOINING_SALES_CENTER", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetVendorListByProduct(string sortedBy, string sortingOrder, string isActive, string productBarcodeIdName, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@IsActive", isActive.Trim());
                db.AddParameters("@ProductBarcodeIdName", productBarcodeIdName.Trim());

                reportDocument.Load(reportPath + "GET_VENDORS_BY_PRODUCT.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_VENDORS_BY_PRODUCT", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetSalesCenterListByWarehouse(string sortedBy, string sortingOrder, string isActive, string warehouseId, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@IsActive", isActive.Trim());
                db.AddParameters("@WarehouseId", warehouseId.Trim());

                reportDocument.Load(reportPath + "GET_SALES_CENTERS_BY_WAREHOUSE.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_SALES_CENTERS_BY_WAREHOUSE", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetDeletedCustomerListByDateRangeAll(string sortedBy, string sortingOrder, string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                reportDocument.Load(reportPath + "GET_DELETED_CUSTOMERS_BY_DATE_RANGE_ALL.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_DELETED_CUSTOMERS_BY_DATE_RANGE_ALL", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetDeletedVendorListByDateRangeAll(string sortedBy, string sortingOrder, string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                reportDocument.Load(reportPath + "GET_DELETED_VENDORS_BY_DATE_RANGE_ALL.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_DELETED_VENDORS_BY_DATE_RANGE_ALL", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReportDocument GetDeletedSalesCenterListByDateRangeAll(string sortedBy, string sortingOrder, string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                ReportDocument reportDocument = new ReportDocument();

                db.AddParameters("@SortedBy", sortedBy.Trim());
                db.AddParameters("@SortingOrder", sortingOrder.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                reportDocument.Load(reportPath + "GET_DELETED_SALES_CENTERS_BY_DATE_RANGE_ALL.rpt");
                reportDocument.SetDataSource(db.ExecuteDataTable("REPORT_GET_DELETED_SALES_CENTERS_BY_DATE_RANGE_ALL", true));

                return reportDocument;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
