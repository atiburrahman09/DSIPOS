using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class CustomerDAL
    {
        public DataTable SaveCustomer(CustomerBLL customer, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CustomerName", customer.CustomerName.Trim());
                db.AddParameters("@ContactNumber", customer.ContactNumber.Trim());
                db.AddParameters("@Email", customer.Email.Trim());
                db.AddParameters("@Country", customer.Country.Trim());
                db.AddParameters("@City", customer.City.Trim());
                db.AddParameters("@District", customer.District.Trim());
                db.AddParameters("@PostalCode", customer.PostalCode.Trim());
                db.AddParameters("@Address", customer.Address.Trim());
                db.AddParameters("@NationalId", customer.NationalId.Trim());
                db.AddParameters("@PassportNumber", customer.PassportNumber.Trim());
                db.AddParameters("@JoiningSalesCenterId", customer.JoiningSalesCenterId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_CUSTOMER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                customer = null;
            }
        }

        public DataTable GetCustomerList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_CUSTOMERS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCustomerListByActivationStatus(string isActive, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@IsActive", isActive.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CUSTOMERS_BY_ACTIVATION_STATUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCustomerListByActivationStatusAndJoiningSC(string isActive, string joiningSalesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@IsActive", isActive.Trim());
                db.AddParameters("@SalesCenterId", joiningSalesCenterId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CUSTOMERS_BY_SC_AND_ACTIVATION_STATUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedCustomerListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_CUSTOMERS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCustomerById(string customerId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CustomerId", customerId);
                DataTable dt = db.ExecuteDataTable("GET_CUSTOMER_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCustomerActivation(string customerId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CustomerId", customerId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_CUSTOMER_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCustomer(string customerId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CustomerId", customerId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_CUSTOMER_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCustomer(CustomerBLL customer, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CustomerId", customer.CustomerId.Trim());
                db.AddParameters("@CustomerName", customer.CustomerName.Trim());
                db.AddParameters("@ContactNumber", customer.ContactNumber.Trim());
                db.AddParameters("@Email", customer.Email.Trim());
                db.AddParameters("@Country", customer.Country.Trim());
                db.AddParameters("@City", customer.City.Trim());
                db.AddParameters("@District", customer.District.Trim());
                db.AddParameters("@PostalCode", customer.PostalCode.Trim());
                db.AddParameters("@Address", customer.Address.Trim());
                db.AddParameters("@NationalId", customer.NationalId.Trim());
                db.AddParameters("@PassportNumber", customer.PassportNumber.Trim());
                db.AddParameters("@JoiningSalesCenterId", customer.JoiningSalesCenterId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_CUSTOMER_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                customer = null;
            }
        }

        public DataTable GetActiveCustomerList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_CUSTOMER_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetCustomerWisePaymentList(string customerId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                /*Need To ADD the query or Procedure*/

                db.AddParameters("@CustomerId", customerId);
                db.AddParameters("@FromDate", fromDate);
                db.AddParameters("@ToDate", toDate);
                db.AddParameters("@Status", status);


                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[JournalNumber],[AutoVoucherNumber],[ManualVoucherNumber],[VoucherDate],[ReceivePaymentDate],[RecordDate],[RecordId],[ReceivePaymentFlag],[VendorId],[WarehouseId],[CustomerId],[SalesCenterId],[Amount],[DueAmount],[PaymentMode],[Bank],[BankBranch],[ChequeNumber],[ChequeDate],[Description],[Narration],[Status],[CreatedBy],[CreatedFrom],[CreatedDateTime],[ModifiedBy],[ModifiedFrom],[ModifiedDateTime],[ApprovedBy],[ApprovedFrom],[ApprovedDateTime] FROM [dbo].[ReceivePayment] WHERE CustomerId=@CustomerId AND CAST(@FromDate AS DATE) <= CAST(CreatedDateTime AS DATE) AND CAST(@ToDate AS DATE) >= CAST(CreatedDateTime AS DATE) AND Status=@Status");
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
