using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ReceivePaymentBLL
    {
        public string AccountId { get; set; }
        public string SalesCenterId { get; set; }
        public string WarehouseId { get; set; }
        public string VendorId { get; set; }
        public string CustomerId { get; set; }
        public string PurchaseRecordId { get; set; }
        public string CurrentPayable { get; set; }
        public string CurrentReceivable { get; set; }
        public string Amount { get; set; }
        public string CashCheque { get; set; }

        public DataTable GetVendorPayments(string vendorId, string recordId, string status)
        {
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = receivePayment.GetVendorPayments(vendorId, recordId, status, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public DataTable GetVendorPayableList(string vendorId, string accountOn, string whscId)
        {
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = receivePayment.GetVendorPayableList(vendorId, accountOn, whscId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public DataTable GetCustomerReceivableList(string customerId, string centerId)
        {
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = receivePayment.GetCustomerReceivableList(customerId,centerId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public DataTable SaveVendorPaymentBySC()
        {
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = receivePayment.SaveVendorPaymentBySC(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public DataTable SaveVendorPayment(string accountOn, string whscId, DataTable adata)
        {
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = receivePayment.SaveVendorPayment(this, accountOn, whscId, adata, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public DataTable SaveCustomerPayment(string acountOn, DataTable adata)
        {
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = receivePayment.SaveCustomerPayment(this, acountOn, adata, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public DataTable GetCustomerTotalReceivable(string Cid, string centerId)
        {
            //GET_CUSTOMER_TOTAL_RECEIVABLE_BY_ID
            ReceivePaymentDAL receivePayment = new ReceivePaymentDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = receivePayment.GetCustomerTotalReceivable(Cid,centerId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                receivePayment = null;
            }
        }

        public string ChequeNo { get; set; }

        public string BankBrach { get; set; }

        public string Bank { get; set; }

        public string ChequeDate { get; set; }
    }
}
