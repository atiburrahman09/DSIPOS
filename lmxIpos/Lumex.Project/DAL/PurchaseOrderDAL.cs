using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class PurchaseOrderDAL
    {
        public string SavePurchaseOrder(List<PurchaseOrderBLL> purchaseOrders, string warehouseId, string narration, LumexDBPlayer db)
        {
            string purchaseOrderId = string.Empty;

            try
            {
                db.ClearParameters();
                //db.AddParameters("@WarehouseId", warehouseId.Trim());
                //db.AddParameters("@Narration", narration.Trim());
                //db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                //db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("", true);

                if (dt.Rows.Count > 0)
                {
                    purchaseOrderId = dt.Rows[0][0].ToString();

                    for (int i = 0; i < purchaseOrders.Count; i++)
                    {
                        db.ClearParameters();
                        //db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                        //db.AddParameters("@ProductId", purchaseOrders[i].ProductId.Trim());
                        //db.AddParameters("@OrderQuantity", purchaseOrders[i].OrderQuantity.Trim());
                        //db.AddParameters("@RequiredDate", purchaseOrders[i].RequiredDate.Trim());
                        //db.AddParameters("@Narration", purchaseOrders[i].ProductNarration.Trim());

                        db.ExecuteNonQuery("", true);
                    }
                }
                else
                {
                    db.ExecuteDataTable("there_is_no_procedure_to_execute", false);
                }

                return purchaseOrderId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseOrders = null;
            }
        }

        public DataTable GetPurchaseOrdersListByWarehouseDateRangeAndStatus(string warehouseId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_ORDERS_BY_WAREHOUSE_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPendingPurchaseOrdersListByWarehouse(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PENDING_PURCHASE_ORDERS_BY_WAREHOUSE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPurchaseOrderCancelRequestListByWarehouse(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_ORDER_CANCEL_REQUEST_LIST_BY_WAREHOUSE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPurchaseOrderById(string purchaseOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_ORDER_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPendingPurchaseOrderByIdAndWarehouse(string purchaseOrderId, string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                db.AddParameters("@WarehouseId", warehouseId);
                DataTable dt = db.ExecuteDataTable("GET_PENDING_PURCHASE_ORDER_BY_ID_AND_WAREHOUSE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPurchaseOrderProductListById(string purchaseOrderId, string purchaseRequisitionId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_ORDER_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable UpdatePurchaseOrderStatusById(string purchaseOrderId, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                db.AddParameters("@Status", status.Trim());
                DataTable dt = db.ExecuteDataTable("UPDATE_PURCHASE_ORDER_STATUS_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable UpdatePurchaseOrderCancelPendingStatusById(string purchaseOrderId, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                db.AddParameters("@Status", status.Trim());
                db.AddParameters("@StatusBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@StatusFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("UPDATE_PURCHASE_ORDER_CANCEL_PENDING_STATUS_BY_ID", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
