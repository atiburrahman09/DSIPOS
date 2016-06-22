using System;
using System.Data;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductTransferOrderDAL
    {
        public DataTable GetProductTransferOrdersListByTransferDescriptionTypeFromToDateRangeAndStatus(string transferDescription, string transferType, string transferFrom, string transferTo, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferDescription", transferDescription.Trim());
                db.AddParameters("@TransferType", transferType.Trim());
                db.AddParameters("@TransferFrom", transferFrom.Trim());
                db.AddParameters("@TransferTo", transferTo.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_ORDERS_BY_TRANSFER_DESCRIPTION_TYPE_FROM_TO_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferReceivableListBySC(string salesCenterId,string reqType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@reqType", reqType.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECEIVABLE_LIST_BY_SC", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferOrdersListByTransferDescriptionTypeFromToAndStatus(string transferDescription, string transferType, string transferFrom, string transferTo, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferDescription", transferDescription.Trim());
                db.AddParameters("@TransferType", transferType.Trim());
                db.AddParameters("@TransferFrom", transferFrom.Trim());
                db.AddParameters("@TransferTo", transferTo.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_ORDERS_BY_TRANSFER_DESCRIPTION_TYPE_FROM_TO_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductTransferOrderOnTransport(string transferOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                db.ExecuteNonQuery("UPDATE_PRODUCT_TRANSFER_ORDER_ON_TRANSPORT", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferOrderById(string transferOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_ORDER_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferOrderProductListById(string transferOrderId, string requisitionId, string description, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                db.AddParameters("@RequisitionId", requisitionId.Trim());
                db.AddParameters("@Description", description.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_ORDER_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductTransferOrderStatusById(string transferOrderId, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                db.AddParameters("@Status", status.Trim());
                db.AddParameters("@CanceledBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CanceledFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_TRANSFER_ORDER_STATUS_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReceivedProductTransferBySC(string transferOrderId, string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("RECEIVED_PRODUCT_TRANSFER_TO_SC", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void ReceivedProductTransferByWH(string transferOrderId, string WarehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WareHouseId", WarehouseId.Trim());
                db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("[RECEIVED_PRODUCT_TRANSFER_TO_WH]", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
