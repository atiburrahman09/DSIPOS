using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductTransferRecordDAL
    {
        public string SaveProductTransferRecord(ProductTransferRecordBLL productTransferRecord, DataTable dtPrdList, LumexDBPlayer db)
        {
            string transferRecordId = "";

            try
            {
                db.AddParameters("@TransferOrderId", productTransferRecord.TransferOrderId.Trim());
                db.AddParameters("@TransferFrom", productTransferRecord.TransferFrom.Trim());
                db.AddParameters("@TransferTo", productTransferRecord.TransferTo.Trim());
                db.AddParameters("@TransferType", productTransferRecord.TransferType.Trim());
                db.AddParameters("@Description", productTransferRecord.Description.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PRODUCT_TRANSFER_RECORD", true);

                if (dt.Rows.Count > 0)
                {
                    transferRecordId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@TransferRecordId", transferRecordId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@ReceivedQuantity", dtPrdList.Rows[i]["ReceivedQuantity"].ToString());
                    db.AddParameters("@DisappearedQuantity", dtPrdList.Rows[i]["DisappearedQuantity"].ToString());
                    db.AddParameters("@Status", dtPrdList.Rows[i]["Status"].ToString());
                    db.AddParameters("@Narration", dtPrdList.Rows[i]["Narration"].ToString());

                    db.ExecuteNonQuery("INSERT_PRODUCT_TRANSFER_RECORD_PRODUCT", true);
                }

                db.ClearParameters();
                db.AddParameters("@TransferOrderId", productTransferRecord.TransferOrderId.Trim());
                db.AddParameters("@Status", productTransferRecord.Status.Trim());
                db.AddParameters("@CanceledBy", "");
                db.AddParameters("@CanceledFrom", "");

                db.ExecuteNonQuery("UPDATE_PRODUCT_TRANSFER_ORDER_STATUS_BY_ID", true);

                return transferRecordId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRecord = null;
            }
        }

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatus(ProductTransferRecordBLL productTransferRecord, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferDescription", productTransferRecord.Description.Trim());
                db.AddParameters("@TransferType", productTransferRecord.TransferType.Trim());
                db.AddParameters("@TransferTo", productTransferRecord.TransferTo.Trim());
                db.AddParameters("@FromDate", productTransferRecord.FromDate.Trim());
                db.AddParameters("@ToDate", productTransferRecord.ToDate.Trim());
                db.AddParameters("@Status", productTransferRecord.Status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECORDS_BY_TRANSFER_DESCRIPTION_TYPE_FROM_TO_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRecord = null;
            }
        }

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatusAll(ProductTransferRecordBLL productTransferRecord, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferDescription", productTransferRecord.Description.Trim());
                db.AddParameters("@TransferType", productTransferRecord.TransferType.Trim());
                db.AddParameters("@TransferFrom", productTransferRecord.TransferFrom.Trim());
                db.AddParameters("@TransferTo", productTransferRecord.TransferTo.Trim());
                db.AddParameters("@FromDate", productTransferRecord.FromDate.Trim());
                db.AddParameters("@ToDate", productTransferRecord.ToDate.Trim());
                db.AddParameters("@Status", productTransferRecord.Status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECORDS_BY_TRANSFER_DESCRIPTION_TYPE_FROM_TO_DATE_RANGE_AND_STATUS_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRecord = null;
            }
        }

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatus(ProductTransferRecordBLL productTransferRecord, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferDescription", productTransferRecord.Description.Trim());
                db.AddParameters("@TransferType", productTransferRecord.TransferType.Trim());
                db.AddParameters("@TransferTo", productTransferRecord.TransferTo.Trim());
                db.AddParameters("@Status", productTransferRecord.Status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECORDS_BY_TRANSFER_DESCRIPTION_TYPE_FROM_TO_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRecord = null;
            }
        }

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatusAll(ProductTransferRecordBLL productTransferRecord, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferDescription", productTransferRecord.Description.Trim());
                db.AddParameters("@TransferType", productTransferRecord.TransferType.Trim());
                db.AddParameters("@TransferFrom", productTransferRecord.TransferFrom.Trim());
                db.AddParameters("@TransferTo", productTransferRecord.TransferTo.Trim());
                db.AddParameters("@Status", productTransferRecord.Status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECORDS_BY_TRANSFER_DESCRIPTION_TYPE_FROM_TO_AND_STATUS_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRecord = null;
            }
        }

        public DataTable GetProductTransferRecordById(string transferRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferRecordId", transferRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECORD_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductTransferRecordProductListById(string transferRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferRecordId", transferRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_TRANSFER_RECORD_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ApproveProductTransferRecord(ProductTransferRecordBLL productTransferRecord, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@TransferRecordId", productTransferRecord.TransferRecordId.Trim());
                db.AddParameters("@Description", productTransferRecord.Description.Trim());
                db.AddParameters("@TransferType", productTransferRecord.TransferType.Trim());
                db.AddParameters("@TransferTo", productTransferRecord.TransferTo.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("APPROVE_PRODUCT_TRANSFER_RECORD", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productTransferRecord = null;
            }
        }
    }
}
