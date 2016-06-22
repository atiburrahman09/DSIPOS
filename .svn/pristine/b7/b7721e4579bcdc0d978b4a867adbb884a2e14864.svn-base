using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductTransferOrderBLL
    {
        public DataTable GetProductTransferOrdersListByTransferDescriptionTypeFromToDateRangeAndStatus(string transferDescription, string transferType, string transferFrom, string transferTo, string fromDate, string toDate, string status)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferOrder.GetProductTransferOrdersListByTransferDescriptionTypeFromToDateRangeAndStatus(transferDescription, transferType, transferFrom, transferTo, fromDate, toDate, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public DataTable GetProductTransferReceivableListBySC(string salesCenterId, string reqType)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferOrder.GetProductTransferReceivableListBySC(salesCenterId,reqType, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public DataTable GetProductTransferOrdersListByTransferDescriptionTypeFromToAndStatus(string transferDescription, string transferType, string transferFrom, string transferTo, string status)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferOrder.GetProductTransferOrdersListByTransferDescriptionTypeFromToAndStatus(transferDescription, transferType, transferFrom, transferTo, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public void UpdateProductTransferOrderOnTransport(string transferOrderId)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productTransferOrder.UpdateProductTransferOrderOnTransport(transferOrderId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public DataTable GetProductTransferOrderById(string transferOrderId)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferOrder.GetProductTransferOrderById(transferOrderId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public DataTable GetProductTransferOrderProductListById(string transferOrderId, string requisitionId, string description)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferOrder.GetProductTransferOrderProductListById(transferOrderId, requisitionId, description, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public void UpdateProductTransferOrderStatusById(string transferOrderId, string status)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productTransferOrder.UpdateProductTransferOrderStatusById(transferOrderId, status, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public void ReceivedProductTransferBySC(string transferOrderId, string salesCenterId)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productTransferOrder.ReceivedProductTransferBySC(transferOrderId, salesCenterId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }

        public void ReceivedProductTransferByWH(string transferOrderId, string WarehouseId)
        {
            ProductTransferOrderDAL productTransferOrder = new ProductTransferOrderDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productTransferOrder.ReceivedProductTransferByWH(transferOrderId, WarehouseId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferOrder = null;
            }
        }
    }
}
