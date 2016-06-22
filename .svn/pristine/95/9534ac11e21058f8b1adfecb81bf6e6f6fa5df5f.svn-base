using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductRequisitionBLL
    {
        //Product Requisition Fields
        public string ProductRequisitionId { get; set; }
        public string RequsitionDate { get; set; }
        public string SalesCenterId { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        //Product Requisition Product List Fields
        public string ProductId { get; set; }
        public string RequisitionQuantity { get; set; }
        public string ApprovedQuantity { get; set; }
        public string RequiredDate { get; set; }
        public string ProductNarration { get; set; }
        public string ProductStatus { get; set; }

        public string SaveProductRequisition(List<ProductRequisitionBLL> productRequisitions, string salesCenterId, string warehouseid, string requisationType, string narration)
        {
            ProductRequisitionDAL productRequisition = new ProductRequisitionDAL();
            WarehouseBLL salesCenter = new WarehouseBLL();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string productRequisitionId = productRequisition.SaveProductRequisition(productRequisitions, salesCenterId, warehouseid, requisationType, narration, db);
                db.Stop();

                return productRequisitionId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisition = null;
            }
        }

        public DataTable GetProductRequisitionsListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status,string reqType)
        {
            ProductRequisitionDAL productRequisition = new ProductRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productRequisition.GetProductRequisitionsListBySalesCenterDateRangeAndStatus(salesCenterId, fromDate, toDate, status,reqType, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisition = null;
            }
        }

        public DataTable GetProductRequisitionById(string purchaseRequisitionId)
        {
            ProductRequisitionDAL productRequisition = new ProductRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productRequisition.GetProductRequisitionById(purchaseRequisitionId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisition = null;
            }
        }

        public DataTable GetProductRequisitionProductListById(string productRequisitionId, string reqType)
        {
            ProductRequisitionDAL productRequisition = new ProductRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productRequisition.GetProductRequisitionProductListById(productRequisitionId,reqType, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisition = null;
            }
        }

        public DataTable GetProductRequisitionsApprovalListBySalesCenter(string salesCenterId,string reqType)
        {
            ProductRequisitionDAL productRequisition = new ProductRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productRequisition.GetProductRequisitionsApprovalListBySalesCenter(salesCenterId,reqType, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisition = null;
            }
        }

        public string ApproveTransferRequisitionAndCreateTransferOrder(DataTable dt, string productRequisitionId, string transferFrom, string transferTo, string transferType)
        {
            ProductRequisitionDAL productRequisition = new ProductRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string msg = productRequisition.ApproveTransferRequisitionAndCreateTransferOrder(dt, productRequisitionId, transferFrom, transferTo, transferType, db);
                db.Stop();

                return msg;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisition = null;
            }
        }
    }
}
