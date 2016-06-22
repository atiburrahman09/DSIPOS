
using System;
using System.Collections.Generic;
using Lumex.Project.DAL;
using Lumex.Tech;
using System.Data;
namespace Lumex.Project.BLL
{
    public class PurchaseReturnBLL
    {
        //Purchase Return Fields
        public string VendorId { get; set; }
        public string PurchaseRecordId { get; set; }
        public string ReturnId { get; set; }
        public string ReturnFrom { get; set; }
        public string WHSCId { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        public string ReturnDate { get; set; }
        //Purchase Return Product List Fields
        public string ProductId { get; set; }
        public string ReturnQuantity { get; set; }
        public string ApprovedQuantity { get; set; }
        public string ProductNarration { get; set; }
        public string ProductStatus { get; set; }

      
        public string SalesCenterId { get; set; }

        public string ReturnAmount { get; set; }

        public string ReturnVATAmount { get; set; }

        public string IsDuesAdjustforSalesReturn { get; set; }

        public string dueAmount { get; set; }

        public System.Data.DataTable SavePurchesReturn(System.Data.DataTable dtPrdList)
        {
            PurchaseReturnDAL purchaseReturn = new PurchaseReturnDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = purchaseReturn.SavePurchesReturn(this, dtPrdList, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseReturn = null;
                dtPrdList = null;
            }
        }

        public DataTable GetPurchaseReturnsListBySalesCenterDateRangeAndStatus(string CenterId, string fromDate, string toDate, string status)
        {
            PurchaseReturnDAL purchaseReturn = new PurchaseReturnDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseReturn.GetPurchaseReturnsListBySalesCenterDateRangeAndStatus(CenterId, fromDate, toDate, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseReturn = null;
            }
        }

        public DataTable GetPurchaseReturnById(string ReturnId)
        {
            PurchaseReturnDAL purchaseReturn = new PurchaseReturnDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseReturn.GetPurchaseReturnById(ReturnId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseReturn = null;
            }
        }

        public DataTable GetPurchaseReturnProductListById(string PReturnId)
        {
            PurchaseReturnDAL purchaseReturn = new PurchaseReturnDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseReturn.GetPurchaseReturnProductListById(PReturnId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseReturn = null;
            }
        }
    }
}
