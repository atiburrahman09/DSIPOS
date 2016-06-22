using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class SalesPersonBLL
    {
        public string SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string NationalId { get; set; }
        public string PassportNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string JoiningSalesCenterId { get; set; }
        public string WorkingSalesCenterId { get; set; }
        public string JoinDate { get; set; }

        public DataTable SaveSalesPerson()
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = salesPerson.SaveSalesPerson(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public DataTable GetSalesPersonList()
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesPerson.GetSalesPersonList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public DataTable GetDeletedSalesPersonListByDateRangeAll(string fromDate, string toDate, string search)
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesPerson.GetDeletedSalesPersonListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public DataTable GetSalesPersonById(string customerId)
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesPerson.GetSalesPersonById(customerId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public void UpdateSalesPersonActivation(string salesPersonId, string activationStatus)
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesPerson.UpdateSalesPersonActivation(salesPersonId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public void DeleteSalesPerson(string customerId)
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesPerson.DeleteSalesPerson(customerId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public void UpdateSalesPerson()
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesPerson.UpdateSalesPerson(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }

        public DataTable GetActiveSalesPersonListBySalesCenter(string salesCenterId)
        {
            SalesPersonDAL salesPerson = new SalesPersonDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesPerson.GetActiveSalesPersonListBySalesCenter(salesCenterId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesPerson = null;
            }
        }
    }
}
