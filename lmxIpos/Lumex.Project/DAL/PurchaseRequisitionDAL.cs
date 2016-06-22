using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class PurchaseRequisitionDAL
    {
        public string SavePurchaseRequisition(List<PurchaseRequisitionBLL> purchaseRequisitions, string warehouseId, string narration, LumexDBPlayer db)
        {
            string purchaseRequisitionId = string.Empty;

            try
            {
                db.ClearParameters();
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                db.AddParameters("@Narration", narration.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PURCHASE_REQUISITION", true);

                if (dt.Rows.Count > 0)
                {
                    purchaseRequisitionId = dt.Rows[0][0].ToString();

                    for (int i = 0; i < purchaseRequisitions.Count; i++)
                    {
                        db.ClearParameters();
                        db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                        db.AddParameters("@ProductId", purchaseRequisitions[i].ProductId.Trim());
                        db.AddParameters("@RequisitionQuantity", purchaseRequisitions[i].RequisitionQuantity.Trim());
                        db.AddParameters("@RequiredDate", purchaseRequisitions[i].RequiredDate.Trim());
                        db.AddParameters("@Narration", purchaseRequisitions[i].ProductNarration.Trim());

                        db.ExecuteNonQuery("INSERT_PURCHASE_REQUISITION_PRODUCT", true);
                    }
                }
                else
                {
                    db.ExecuteDataTable("there_is_no_procedure_to_execute", false);
                }

                return purchaseRequisitionId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseRequisitions = null;
            }
        }

        public DataTable GetPurchaseRequisitionsListByWarehouseDateRangeAndStatus(string warehouseId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_REQUISITIONS_BY_WAREHOUSE_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPurchaseRequisitionById(string purchaseRequisitionId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_REQUISITION_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPurchaseRequisitionProductListById(string purchaseRequisitionId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_REQUISITION_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPurchaseRequisitionsApprovalListByWarehouse(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PURCHASE_REQUISITION_APPROVAL_LIST_BY_WAREHOUSE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ApprovePurchaseRequisitionAndCreatePurchaseOrder(DataTable dt, string purchaseRequisitionId, string warehouseId, LumexDBPlayer db)
        {
            string purchaseOrderId = "";
            string purchaseOrderIds = "";
            DataTable dtVendors = new DataTable();
            int totalProductCount = dt.Rows.Count;
            int approveProductCount = 0;

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    db.ClearParameters();

                    if (dt.Rows[i]["Status"].ToString().Trim() == "R")
                    {
                        db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", DBNull.Value);
                        db.AddParameters("@VendorId", DBNull.Value);
                        db.AddParameters("@StatusNarration", dt.Rows[i]["Narration"].ToString().Trim());
                        db.AddParameters("@Status", dt.Rows[i]["Status"].ToString().Trim());

                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                    else if (dt.Rows[i]["Status"].ToString().Trim() == "A")
                    {
                        db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                        db.AddParameters("@ProductId", dt.Rows[i]["ProductId"].ToString().Trim());
                        db.AddParameters("@ApprovedQuantity", dt.Rows[i]["ApprovedQuantity"].ToString().Trim());
                        db.AddParameters("@VendorId", dt.Rows[i]["VendorId"].ToString().Trim());
                        db.AddParameters("@StatusNarration", dt.Rows[i]["Narration"].ToString().Trim());
                        db.AddParameters("@Status", dt.Rows[i]["Status"].ToString().Trim());
                    }

                    db.ExecuteNonQuery("UPDATE_PURCHASE_REQUISITION_PRODUCT_BY_REQUISITION_AND_PRODUCT_ID", true);
                }

                approveProductCount = dt.Rows.Count;

                db.ClearParameters();
                db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                if (approveProductCount == totalProductCount) { db.AddParameters("@Status", "A"); }
                else if (approveProductCount == 0) { db.AddParameters("@Status", "R"); }
                else { db.AddParameters("@Status", "PA"); }
                db.AddParameters("@OccuredBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@OccuredFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PURCHASE_REQUISITION_STATUS_BY_ID", true);

                if (approveProductCount != 0)
                {
                    db.ClearParameters();
                    db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                    dtVendors = db.ExecuteDataTable("GET_APPROVED_PURCHASE_REQUISITION_PRODUCTS_VENDOR_LIST_BY_ID", true);

                    for (int i = 0; i < dtVendors.Rows.Count; i++)
                    {
                        db.ClearParameters();
                        db.AddParameters("@Narration", "Aprv. Prd: " + approveProductCount.ToString() + ", Rej. Prd: " + (totalProductCount - approveProductCount).ToString());
                        db.AddParameters("@PurchaseRequisitionId", purchaseRequisitionId.Trim());
                        db.AddParameters("@WarehouseId", warehouseId.Trim());
                        db.AddParameters("@VendorId", dtVendors.Rows[i]["VendorId"].ToString().Trim());
                        db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                        db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                        DataTable dtPO = db.ExecuteDataTable("INSERT_PURCHASE_ORDER", true);
                        purchaseOrderId = dtPO.Rows[0][0].ToString();
                        purchaseOrderIds += purchaseOrderId + ", ";

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dtVendors.Rows[i]["VendorId"].ToString().Trim() == dt.Rows[j]["VendorId"].ToString().Trim())
                            {
                                db.ClearParameters();
                                db.AddParameters("@PurchaseOrderId", purchaseOrderId.Trim());
                                db.AddParameters("@ProductId", dt.Rows[j]["ProductId"].ToString().Trim());
                                db.AddParameters("@Quantity", dt.Rows[j]["ApprovedQuantity"].ToString().Trim());

                                db.ExecuteNonQuery("INSERT_PURCHASE_ORDER_PRODUCT", true);

                                dt.Rows.RemoveAt(j);
                                j--;
                            }
                        }
                    }

                    purchaseOrderIds = purchaseOrderIds.Substring(0, purchaseOrderIds.Length - 2);
                    return dtVendors.Rows.Count.ToString() + " Purchase Order(s) Created Successfully.\\r\\nContaining [ " + purchaseOrderIds + " ] Purchase Order ID.";
                }
                else
                {
                    return "This Purchase Requisition[" + purchaseRequisitionId + "] Rejected Successfully.";
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
