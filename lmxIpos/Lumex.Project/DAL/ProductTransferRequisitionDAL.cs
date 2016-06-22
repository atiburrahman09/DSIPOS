using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductTransferRequisitionDAL
    {
        public string SaveProductTransferRequisition(List<ProductTransferRequisitionBLL> productTransferRequisitions, string transferType, string transferFrom, string transferTo, string narration, LumexDBPlayer db)
        {
            string transferRequisitionId = string.Empty;

            try
            {
                db.ClearParameters();
                db.AddParameters("@TransferType", transferType.Trim());
                db.AddParameters("@TransferFrom", transferFrom.Trim());
                db.AddParameters("@TransferTo", transferTo.Trim());
                db.AddParameters("@Narration", narration.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PRODUCT_TRANSFER_REQUISITION", true);

                if (dt.Rows.Count > 0)
                {
                    transferRequisitionId = dt.Rows[0][0].ToString();

                    for (int i = 0; i < productTransferRequisitions.Count; i++)
                    {
                        db.ClearParameters();
                        db.AddParameters("@TransferRequisitionId", transferRequisitionId.Trim());
                        db.AddParameters("@ProductId", productTransferRequisitions[i].ProductId.Trim());
                        db.AddParameters("@RequisitionQuantity", productTransferRequisitions[i].RequisitionQuantity.Trim());
                        db.AddParameters("@RequiredDate", productTransferRequisitions[i].RequiredDate.Trim());
                        db.AddParameters("@Narration", productTransferRequisitions[i].ProductNarration.Trim());

                        db.ExecuteNonQuery("INSERT_PRODUCT_TRANSFER_REQUISITION_PRODUCT", true);
                    }
                }
                else
                {
                    db.ExecuteDataTable("there_is_no_procedure_to_execute", false);
                }

                return transferRequisitionId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRequisitions = null;
            }
        }

        public DataTable GetProductTransferRequisitionsListByTransferTypeFromToDateRangeAndStatus(string transferType, string transferFrom, string transferTo, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferType", transferType.Trim());
                db.AddParameters("@TransferFrom", transferFrom.Trim());
                db.AddParameters("@TransferTo", transferTo.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_REQUISITIONS_BY_TRANSFER_TYPE_FROM_TO_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferRequisitionById(string transferRequisitionId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferRequisitionId", transferRequisitionId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_REQUISITION_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferRequisitionProductListById(string transferRequisitionId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferRequisitionId", transferRequisitionId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_REQUISITION_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferRequisitionsApprovalListByTransferTypeFromAndTo(string transferType, string transferFrom, string transferTo, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferType", transferType.Trim());
                db.AddParameters("@TransferFrom", transferFrom.Trim());
                db.AddParameters("@TransferTo", transferTo.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_REQUISITION_APPROVAL_LIST_BY_TRANSFER_TYPE_FROM_AND_TO", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ApproveTransferRequisitionAndCreateTransferOrder(DataTable dt, ProductTransferRequisitionBLL productTransferRequisition, LumexDBPlayer db)
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
                        db.AddParameters("@TransferRequisitionId", productTransferRequisition.TransferRequisitionId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", DBNull.Value);
                        db.AddParameters("@StatusNarration", dt.Rows[i]["Narration"].ToString().Trim());
                        db.AddParameters("@Status", dt.Rows[i]["Status"].ToString().Trim());

                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                    else if (dt.Rows[i]["Status"].ToString().Trim() == "A")
                    {
                        db.AddParameters("@TransferRequisitionId", productTransferRequisition.TransferRequisitionId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", dt.Rows[i]["ApprovedQuantity"].ToString().Trim());
                        db.AddParameters("@StatusNarration", dt.Rows[i]["Narration"].ToString().Trim());
                        db.AddParameters("@Status", dt.Rows[i]["Status"].ToString().Trim());
                    }

                    db.ExecuteNonQuery("UPDATE_PRODUCT_TRANSFER_REQUISITION_PRODUCT_BY_REQUISITION_AND_PRODUCT_ID", true);
                }

                approveProductCount = dt.Rows.Count;

                db.ClearParameters();
                db.AddParameters("@TransferRequisitionId", productTransferRequisition.TransferRequisitionId.Trim());
                if (approveProductCount == totalProductCount) { db.AddParameters("@Status", "A"); }
                else if (approveProductCount == 0) { db.AddParameters("@Status", "R"); }
                else { db.AddParameters("@Status", "PA"); }
                db.AddParameters("@OccuredBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@OccuredFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_TRANSFER_REQUISITION_STATUS_BY_ID", true);

                if (approveProductCount != 0)
                {
                    db.ClearParameters();
                    db.AddParameters("@Narration", "Aprv. Prd: " + approveProductCount.ToString() + ", Rej. Prd: " + (totalProductCount - approveProductCount).ToString());
                    db.AddParameters("@RequisitionId", productTransferRequisition.TransferRequisitionId.Trim());
                    db.AddParameters("@TransferFrom", productTransferRequisition.TransferFrom.Trim());
                    db.AddParameters("@TransferTo", productTransferRequisition.TransferTo.Trim());
                    db.AddParameters("@TransferType", productTransferRequisition.TransferType.Trim());
                    db.AddParameters("@Description", "Transfer Requisition");
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

                        db.ExecuteNonQuery("INSERT_PRODUCT_TRANSFER_ORDER_PRODUCT", true);
                    }

                    db.ClearParameters();
                    db.AddParameters("@TransferOrderId", transferOrderId.Trim());
                    db.AddParameters("@Description", "Transfer Requisition");
                    db.AddParameters("@TransferType", productTransferRequisition.TransferType.Trim());
                    db.AddParameters("@TransferFrom", productTransferRequisition.TransferFrom.Trim());
                    db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_TO_CREATE_PRODUCT_TRANSFER_ORDER", true);

                    return "This Product Transfer Order Created & Product Stock Updated Successfully.\\r\\nContaining [ " + transferOrderId.Trim() + " ] Transfer Order ID.";
                }
                else
                {
                    return "This Product Transfer Requisition[" + productTransferRequisition.TransferRequisitionId.Trim() + "] Rejected Successfully.";
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dt = null;
                productTransferRequisition = null;
            }
        }
    }
}
