using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PurchaseRecordBLL
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
        public string TransportCost { get; set; }

        public string SavePurchaseRecord(DataTable dtPrdList)
        {
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

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
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

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

        public DataTable GetPurchaseRecordsApprovalListByWarehouse(string warehouseId)
        {
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

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

        public DataTable GetPurchaseRecordById(string purchaseRecordId)
        {
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

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
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

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

        public void ApprovePurchaseRecord(string warehouseId, string purchaseRecordId)
        {
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

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

        public DataTable GetPurchaseRecordProductListByIdForReturn(string purchaseRecordId)
        {
            PurchaseRecordDAL purchaseRecord = new PurchaseRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordProductListByIdForReturn(purchaseRecordId, db);
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
    }
}
