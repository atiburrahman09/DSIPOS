using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PurchaseRequisitionBLL
    {
        //Purchase Requisition Fields
        public string PurchaseRequisitionId { get; set; }
        public string RequsitionDate { get; set; }
        public string WarehouseId { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        //Purchase Requisition Product List Fields
        public string ProductId { get; set; }
        public string RequisitionQuantity { get; set; }
        public string ApprovedQuantity { get; set; }
        public string RequiredDate { get; set; }
        public string VendorId { get; set; }
        public string ProductNarration { get; set; }
        public string ProductStatus { get; set; }

        public string SavePurchaseRequisition(List<PurchaseRequisitionBLL> purchaseRequisitions, string warehouseId, string narration)
        {
            PurchaseRequisitionDAL purchaseRequisition = new PurchaseRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string purchaseRequisitionId = purchaseRequisition.SavePurchaseRequisition(purchaseRequisitions, warehouseId, narration, db);
                db.Stop();

                return purchaseRequisitionId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisition = null;
            }
        }

        public DataTable GetPurchaseRequisitionsListByWarehouseDateRangeAndStatus(string warehouseId, string fromDate, string toDate, string status)
        {
            PurchaseRequisitionDAL purchaseRequisition = new PurchaseRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionsListByWarehouseDateRangeAndStatus(warehouseId, fromDate, toDate, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisition = null;
            }
        }

        public DataTable GetPurchaseRequisitionById(string purchaseRequisitionId)
        {
            PurchaseRequisitionDAL purchaseRequisition = new PurchaseRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionById(purchaseRequisitionId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisition = null;
            }
        }

        public DataTable GetPurchaseRequisitionProductListById(string purchaseRequisitionId)
        {
            PurchaseRequisitionDAL purchaseRequisition = new PurchaseRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionProductListById(purchaseRequisitionId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisition = null;
            }
        }

        public DataTable GetPurchaseRequisitionsApprovalListByWarehouse(string warehouseId)
        {
            PurchaseRequisitionDAL purchaseRequisition = new PurchaseRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseRequisition.GetPurchaseRequisitionsApprovalListByWarehouse(warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisition = null;
            }
        }

        public string ApprovePurchaseRequisitionAndCreatePurchaseOrder(DataTable dt, string purchaseRequisitionId, string warehouseId)
        {
            PurchaseRequisitionDAL purchaseRequisition = new PurchaseRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string msg = purchaseRequisition.ApprovePurchaseRequisitionAndCreatePurchaseOrder(dt, purchaseRequisitionId, warehouseId, db);
                db.Stop();

                return msg;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisition = null;
            }
        }
    }
}
