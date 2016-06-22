using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PurchaseToWHBLL
    {
        public string AccountId { get; set; }
        public string WarehouseId { get; set; }
        public string PurchaseRequisitionId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string PurchaseRecordId { get; set; }
        public string VendorId { get; set; }
        public string VendorOrderDate { get; set; }
        public string VendorOrderNumber { get; set; }
        public string VendorInvoiceNumber { get; set; }
        public string ReceivedDate { get; set; }
        public string TotalAmount { get; set; }
        public string VAT { get; set; }
        public string DiscountAmount { get; set; }
        public string TotalPayable { get; set; }
        public string PaidAmount { get; set; }
        public string TransportCost { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        public string LCNumber { get; set; }
        public string TransportType { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentMode { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeDate { get; set; }

        public string SavePurchaseRecord(DataTable dtPrdList)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();

            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string Id = purchaseRecord.SavePurchaseRecord(this, dtPrdList, db);
                db.Stop();

                return Id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
                dtPrdList = null;
            }
        }

        public DataTable GetPurchaseRecordsListByWarehouseDateRangeAndStatus(string warehouseId, string fromDate, string toDate, string status)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordsListByWarehouseDateRangeAndStatus(warehouseId, fromDate, toDate, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        public DataTable GetPurchaseRecordById(string purchaseRecordId)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordById(purchaseRecordId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        public DataTable GetPurchaseRecordProductListById(string purchaseRecordId)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordProductListById(purchaseRecordId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        public DataTable GetPurchaseRecordsApprovalListByWarehouse(string warehouseId)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordsApprovalListByWarehouse(warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        public void ApprovePurchaseRecord(string warehouseId, string purchaseRecordId)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                purchaseRecord.ApprovePurchaseRecord(warehouseId, purchaseRecordId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }
        }

        public bool rejectPurchaseRecord(string warehouseId, string purchaseRecordId)
        {
            PurchaseToWHDAL purchaseRecord = new PurchaseToWHDAL();
            bool st = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                st= purchaseRecord.rejectPurchaseRecord(warehouseId, purchaseRecordId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }
            return st;
        }
    }
}
