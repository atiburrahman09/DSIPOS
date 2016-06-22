using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductTransferRequisitionBLL
    {
        //Product Transfer Requisition Fields
        public string TransferRequisitionId { get; set; }
        public string RequsitionDate { get; set; }
        public string TransferType { get; set; }
        public string TransferFrom { get; set; }
        public string TransferTo { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        //Product Transfer Requisition Product List Fields
        public string ProductId { get; set; }
        public string RequisitionQuantity { get; set; }
        public string ApprovedQuantity { get; set; }
        public string RequiredDate { get; set; }
        public string ProductNarration { get; set; }
        public string ProductStatus { get; set; }

        public string SaveProductTransferRequisition(List<ProductTransferRequisitionBLL> productTransferRequisitions, string transferType, string transferFrom, string transferTo, string narration)
        {
            ProductTransferRequisitionDAL productTransferRequisition = new ProductTransferRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string productRequisitionId = productTransferRequisition.SaveProductTransferRequisition(productTransferRequisitions, transferType, transferFrom, transferTo, narration, db);
                db.Stop();

                return productRequisitionId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisition = null;
            }
        }

        public DataTable GetProductTransferRequisitionsListByTransferTypeFromToDateRangeAndStatus(string transferType, string transferFrom, string transferTo, string fromDate, string toDate, string status)
        {
            ProductTransferRequisitionDAL productTransferRequisition = new ProductTransferRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRequisition.GetProductTransferRequisitionsListByTransferTypeFromToDateRangeAndStatus(transferType, transferFrom, transferTo, fromDate, toDate, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisition = null;
            }
        }

        public DataTable GetProductTransferRequisitionById(string transferRequisitionId)
        {
            ProductTransferRequisitionDAL productTransferRequisition = new ProductTransferRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRequisition.GetProductTransferRequisitionById(transferRequisitionId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisition = null;
            }
        }

        public DataTable GetProductTransferRequisitionProductListById(string transferRequisitionId)
        {
            ProductTransferRequisitionDAL productTransferRequisition = new ProductTransferRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRequisition.GetProductTransferRequisitionProductListById(transferRequisitionId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisition = null;
            }
        }

        public DataTable GetProductTransferRequisitionsApprovalListByTransferTypeFromAndTo(string transferType, string transferFrom, string transferTo)
        {
            ProductTransferRequisitionDAL productTransferRequisition = new ProductTransferRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRequisition.GetProductTransferRequisitionsApprovalListByTransferTypeFromAndTo(transferType, transferFrom, transferTo, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisition = null;
            }
        }

        public string ApproveTransferRequisitionAndCreateTransferOrder(DataTable dt)
        {
            ProductTransferRequisitionDAL productTransferRequisition = new ProductTransferRequisitionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string msg = productTransferRequisition.ApproveTransferRequisitionAndCreateTransferOrder(dt, this, db);
                db.Stop();

                return msg;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisition = null;
            }
        }
    }
}
