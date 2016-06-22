
using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class PurchaseReturnDAL
    {
       
        internal DataTable SavePurchesReturn(PurchaseReturnBLL purchaseReturnBLL, DataTable dtPrdList, LumexDBPlayer db)
        {
            string purchesReturnId = "";

            try
            {
                db.AddParameters("@RecordId", purchaseReturnBLL.PurchaseRecordId.Trim());
                db.AddParameters("@ReturnAmount", purchaseReturnBLL.ReturnAmount.Trim());
                db.AddParameters("@CenterId", purchaseReturnBLL.SalesCenterId.Trim());
                db.AddParameters("@DueAmount", purchaseReturnBLL.dueAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("[INSERT_PURCHASE_RETURN_RECORD]", true);

                if (dt.Rows.Count > 0)
                {
                    purchesReturnId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                     
                    db.ClearParameters();
                    db.AddParameters("@PurchaseRecordId", purchaseReturnBLL.PurchaseRecordId);
                    db.AddParameters("@ReturnId", purchesReturnId.ToString());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@PurchaseRate", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@ReturnQuantity", dtPrdList.Rows[i]["ReturnQuantity"].ToString());
                    db.AddParameters("@ReturnAmount", dtPrdList.Rows[i]["ReturnAmount"].ToString());
                   // db.AddParameters("@VATPercentage", dtPrdList.Rows[i]["VATPercentage"].ToString());

                    db.ExecuteNonQuery("[INSERT_PURCHASE_RETURN_RECORD_PRODUCT]", true);
                }

                db.ClearParameters();
                db.AddParameters("@CenterId", purchaseReturnBLL.SalesCenterId.Trim());
                db.AddParameters("@ReturnId", purchesReturnId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("[UPDATE_PRODUCT_STOCK_FOR_PURCHASE_RETURN]", true);

                db.ClearParameters();
              
                db.AddParameters("@PurchaseRecordId", purchaseReturnBLL.PurchaseRecordId.Trim());
                db.AddParameters("@CenterId", purchaseReturnBLL.SalesCenterId.Trim());
                db.AddParameters("@ReturnId", purchesReturnId.Trim());
                db.AddParameters("@DueAmount", purchaseReturnBLL.dueAmount.Trim());
                db.AddParameters("@ReturnAmount", purchaseReturnBLL.ReturnAmount.Trim());
                db.AddParameters("@VendorId", purchaseReturnBLL.VendorId.Trim());
                db.AddParameters("@IsDueAdjust", purchaseReturnBLL.IsDuesAdjustforSalesReturn);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                dt = db.ExecuteDataTable("[INSERT_PURCHASE_RETURN_RECEIVE_PAYMENT_LEDGER_TRANSACTION]", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                purchaseReturnBLL = null;
                dtPrdList = null;
            }
        }

        internal DataTable GetPurchaseReturnsListBySalesCenterDateRangeAndStatus(string CenterId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CenterId", CenterId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("[GET_PURCHASE_RETURN_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS]", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetPurchaseReturnById(string ReturnId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ReturnId", ReturnId.Trim());
                DataTable dt = db.ExecuteDataTable("[GET_PURCHASE_RETURN_RECORD_BY_ID]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetPurchaseReturnProductListById(string ReturnId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ReturnId", ReturnId.Trim());
                DataTable dt = db.ExecuteDataTable("[GET_PURCHASE_RETURN_RECORD_PRODUCT_LIST_BY_ID]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
