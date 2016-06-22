using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductRequisitionDAL
    {
        public string SaveProductRequisition(List<ProductRequisitionBLL> productRequisitions, string salesCenterId,string warehouseId,string requisationType, string narration, LumexDBPlayer db)
        {
            string productRequisitionId = string.Empty;

            try
            {
                db.ClearParameters();
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                db.AddParameters("@RequisationType", requisationType.Trim());
                db.AddParameters("@Narration", narration.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PRODUCT_REQUISITION", true);

                if (dt.Rows.Count > 0)
                {
                    productRequisitionId = dt.Rows[0][0].ToString();

                    for (int i = 0; i < productRequisitions.Count; i++)
                    {
                        db.ClearParameters();
                        db.AddParameters("@ProductRequisitionId", productRequisitionId.Trim());
                        db.AddParameters("@ProductId", productRequisitions[i].ProductId.Trim());
                        db.AddParameters("@RequisitionQuantity", productRequisitions[i].RequisitionQuantity.Trim());
                        db.AddParameters("@RequiredDate", productRequisitions[i].RequiredDate.Trim());
                        db.AddParameters("@Narration", productRequisitions[i].ProductNarration.Trim());

                        db.ExecuteNonQuery("INSERT_PRODUCT_REQUISITION_PRODUCT", true);
                    }
                }
                else
                {
                   // db.ExecuteDataTable("there_is_no_procedure_to_execute", false);
                }

                return productRequisitionId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productRequisitions = null;
            }
        }

        public DataTable GetProductRequisitionsListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status, string reqType,  LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());
                db.AddParameters("@RequisationType",reqType);

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_REQUISITIONS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductRequisitionById(string productRequisitionId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductRequisitionId", productRequisitionId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_REQUISITION_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductRequisitionProductListById(string productRequisitionId,string reqTupe, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductRequisitionId", productRequisitionId.Trim());
                db.AddParameters("@RequisitionType",reqTupe);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_REQUISITION_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductRequisitionsApprovalListBySalesCenter(string salesCenterId,string reqType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@reqType",reqType);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_REQUISITION_APPROVAL_LIST_BY_SALES_CENTER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ApproveTransferRequisitionAndCreateTransferOrder(DataTable dt, string productRequisitionId, string transferFrom, string transferTo, string transferType, LumexDBPlayer db)
        {
            string transferOrderId = "";
            int totalProductCount = dt.Rows.Count;
            int approveProductCount = 0;

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    db.ClearParameters();

                    if (dt.Rows[i]["Status"].ToString().Trim() == "R")
                    {
                        db.AddParameters("@ProductRequisitionId", productRequisitionId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", DBNull.Value);
                        db.AddParameters("@StatusNarration", dt.Rows[i]["Narration"].ToString().Trim());
                        db.AddParameters("@Status", dt.Rows[i]["Status"].ToString().Trim());

                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                    else if (dt.Rows[i]["Status"].ToString().Trim() == "A")
                    {
                        db.AddParameters("@ProductRequisitionId", productRequisitionId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", dt.Rows[i]["ApprovedQuantity"].ToString().Trim());
                        db.AddParameters("@StatusNarration", dt.Rows[i]["Narration"].ToString().Trim());
                        db.AddParameters("@Status", dt.Rows[i]["Status"].ToString().Trim());
                    }

                    db.ExecuteNonQuery("UPDATE_PRODUCT_REQUISITION_PRODUCT_BY_REQUISITION_AND_PRODUCT_ID", true);
                }

                approveProductCount = dt.Rows.Count;

                db.ClearParameters();
                db.AddParameters("@ProductRequisitionId", productRequisitionId.Trim());
                if (approveProductCount == totalProductCount) { db.AddParameters("@Status", "A"); }
                else if (approveProductCount == 0) { db.AddParameters("@Status", "R"); }
                else { db.AddParameters("@Status", "PA"); }
                db.AddParameters("@OccuredBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@OccuredFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_REQUISITION_STATUS_BY_ID", true);

                if (approveProductCount != 0)
                {
                    db.ClearParameters();
                    db.AddParameters("@Narration", "Aprv. Prd: " + approveProductCount.ToString() + ", Rej. Prd: " + (totalProductCount - approveProductCount).ToString());
                    db.AddParameters("@RequisitionId", productRequisitionId.Trim());
                    db.AddParameters("@TransferFrom", transferFrom.Trim());
                    db.AddParameters("@TransferTo", transferTo.Trim());
                    db.AddParameters("@TransferType", transferType.Trim());
                    db.AddParameters("@Description", "Product Requisition");
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    DataTable dtPO = db.ExecuteDataTable("INSERT_PRODUCT_TRANSFER_ORDER", true);
                    transferOrderId = dtPO.Rows[0][0].ToString();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        db.ClearParameters();
                        db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@FreeQuantityWas", dt.Rows[i]["FreeQuantityWas"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", dt.Rows[i]["ApprovedQuantity"].ToString().Trim());
                        db.AddParameters("@TransferFrom", transferFrom.Trim());

                        db.ExecuteNonQuery("INSERT_PRODUCT_TRANSFER_ORDER_PRODUCT", true);
                    }

                    db.ClearParameters();
                    db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                    db.AddParameters("@Description", "Product Requisition");
                    db.AddParameters("@TransferType", transferType.Trim());
                    db.AddParameters("@TransferFrom", transferFrom.Trim());
                    db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_TO_CREATE_PRODUCT_TRANSFER_ORDER", true);

                    db.ClearParameters();
                    db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                    db.AddParameters("@TransferFrom", transferFrom.Trim());
                    db.AddParameters("@TransferTo", transferTo.Trim());
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteNonQuery("INSERT_PRODUCT_TRANSFER_ORDER_LEDGER_TRANSACTION", true);

                    return "Product Transfered & Stock Updated Successfully.\\r\\nContaining [ " + transferOrderId.Trim() + " ] Transfer ID.";
                }
                else
                {
                    return "Product Requisition[" + productRequisitionId.Trim() + "] Rejected Successfully.";
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dt = null;
            }
        }
    }
}
