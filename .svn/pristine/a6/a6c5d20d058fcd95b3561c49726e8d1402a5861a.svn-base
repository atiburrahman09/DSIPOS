using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class CustomerBLL
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string NationalId { get; set; }
        public string PassportNumber { get; set; }
        public string JoiningSalesCenterId { get; set; }

        public DataTable SaveCustomer()
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = customer.SaveCustomer(this, db);
                db.Stop();

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

        public DataTable GetCustomerList()
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetCustomerList(db);
                db.Stop();

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

        public DataTable GetCustomerListByActivationStatus(string isActive)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetCustomerListByActivationStatus(isActive, db);
                db.Stop();

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

        public DataTable GetCustomerListByActivationStatusAndJoiningSC(string isActive, string joiningSalesCenterId)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetCustomerListByActivationStatusAndJoiningSC(isActive, joiningSalesCenterId, db);
                db.Stop();

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

        public DataTable GetDeletedCustomerListByDateRangeAll(string fromDate, string toDate, string search)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetDeletedCustomerListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

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

        public DataTable GetCustomerById(string customerId)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetCustomerById(customerId, db);
                db.Stop();

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

        public void UpdateCustomerActivation(string customerId, string activationStatus)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                customer.UpdateCustomerActivation(customerId, activationStatus, db);
                db.Stop();
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

        public void DeleteCustomer(string customerId)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                customer.DeleteCustomer(customerId, db);
                db.Stop();
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

        public void UpdateCustomer()
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                customer.UpdateCustomer(this, db);
                db.Stop();
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

        public DataTable GetActiveCustomerList()
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetActiveCustomerList(db);
                db.Stop();

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

        public DataTable GetCustomerWisePaymentList(string customerId, string fromDate, string toDate, string status)
        {
            CustomerDAL customer = new CustomerDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = customer.GetCustomerWisePaymentList(customerId, fromDate, toDate, status, db);
                db.Stop();

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
    }
}
