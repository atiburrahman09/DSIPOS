using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductTransferRecordBLL
    {
        public string TransferOrderId { get; set; }
        public string TransferRecordId { get; set; }
        public string Status { get; set; }
        public string TransferFrom { get; set; }
        public string TransferTo { get; set; }
        public string TransferType { get; set; }
        public string Description { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string SaveProductTransferRecord(DataTable dtPrdList)
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string Id = productTransferRecord.SaveProductTransferRecord(this, dtPrdList, db);
                db.Stop();

                return Id;
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

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatus()
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRecord.GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatus(this, db);
                db.Stop();

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

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatusAll()
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRecord.GetProductTransferRecordsListByTransferDescriptionTypeFromToDateRangeAndStatusAll(this, db);
                db.Stop();

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

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatus()
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRecord.GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatus(this, db);
                db.Stop();

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

        public DataTable GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatusAll()
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRecord.GetProductTransferRecordsListByTransferDescriptionTypeFromToAndStatusAll(this, db);
                db.Stop();

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

        public DataTable GetProductTransferRecordById(string transferRecordId)
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRecord.GetProductTransferRecordById(transferRecordId, db);
                db.Stop();

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

        public DataTable GetProductTransferRecordProductListById(string transferRecordId)
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productTransferRecord.GetProductTransferRecordProductListById(transferRecordId, db);
                db.Stop();

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

        public void ApproveProductTransferRecord()
        {
            ProductTransferRecordDAL productTransferRecord = new ProductTransferRecordDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productTransferRecord.ApproveProductTransferRecord(this, db);
                db.Stop();
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
