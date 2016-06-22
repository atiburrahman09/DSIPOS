using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PurchaseToSCBLL
    {
        public string AccountId { get; set; }
        public string SalesCenterId { get; set; }
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
            PurchaseToSCDAL purchaseRecord = new PurchaseToSCDAL();

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

        public DataTable GetPurchaseRecordsListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status)
        {
            PurchaseToSCDAL purchaseRecord = new PurchaseToSCDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordsListBySalesCenterDateRangeAndStatus(salesCenterId, fromDate, toDate, status, db);
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
            PurchaseToSCDAL purchaseRecord = new PurchaseToSCDAL();

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
            PurchaseToSCDAL purchaseRecord = new PurchaseToSCDAL();

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

        public DataTable GetPurchaseRecordsApprovalListBySalesCenter(string salesCenterId)
        {
            PurchaseToSCDAL purchaseRecord = new PurchaseToSCDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRecord.GetPurchaseRecordsApprovalListBySalesCenter(salesCenterId, db);
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

        public bool ApprovePurchaseRecord(string salesCenterId, string purchaseRecordId)
        {
            PurchaseToSCDAL purchaseRecord = new PurchaseToSCDAL();
            bool status = false;

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                purchaseRecord.ApprovePurchaseRecord(salesCenterId, purchaseRecordId, db);
                db.Stop();

                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRecord = null;
            }

            return status;
        }
    }
}
