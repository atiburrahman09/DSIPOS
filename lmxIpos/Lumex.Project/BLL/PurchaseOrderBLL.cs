using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PurchaseOrderBLL
    {
        public string PurchaseRequisitionId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string VendorId { get; set; }
        public string ProductId { get; set; }
        public string ApprovedQuantity { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        public string StatusNarration { get; set; }

        public string SavePurchaseOrder(List<PurchaseOrderBLL> purchaseOrders, string warehouseId, string narration)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string purchaseOrderId = "";// purchaseOrder.SavePurchaseOrder(purchaseOrders, warehouseId, narration, db);
                db.Stop();

                return purchaseOrderId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public DataTable GetPurchaseOrdersListByWarehouseDateRangeAndStatus(string warehouseId, string fromDate, string toDate, string status)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.GetPurchaseOrdersListByWarehouseDateRangeAndStatus(warehouseId, fromDate, toDate, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public DataTable GetPendingPurchaseOrdersListByWarehouse(string warehouseId)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.GetPendingPurchaseOrdersListByWarehouse(warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public DataTable GetPurchaseOrderCancelRequestListByWarehouse(string warehouseId)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.GetPurchaseOrderCancelRequestListByWarehouse(warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public DataTable GetPurchaseOrderById(string purchaseOrderId)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.GetPurchaseOrderById(purchaseOrderId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public DataTable GetPendingPurchaseOrderByIdAndWarehouse(string purchaseOrderId, string warehouseId)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.GetPendingPurchaseOrderByIdAndWarehouse(purchaseOrderId, warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public DataTable GetPurchaseOrderProductListById(string purchaseOrderId, string purchaseRequisitionId)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.GetPurchaseOrderProductListById(purchaseOrderId, purchaseRequisitionId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public void UpdatePurchaseOrderStatusById(string purchaseOrderId, string status)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.UpdatePurchaseOrderStatusById(purchaseOrderId, status, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }

        public void UpdatePurchaseOrderCancelPendingStatusById(string purchaseOrderId, string status)
        {
            PurchaseOrderDAL purchaseOrder = new PurchaseOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = purchaseOrder.UpdatePurchaseOrderCancelPendingStatusById(purchaseOrderId, status, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrder = null;
            }
        }
    }
}
