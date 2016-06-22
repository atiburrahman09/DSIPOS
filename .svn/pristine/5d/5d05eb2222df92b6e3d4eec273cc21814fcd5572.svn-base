using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class SalesPersonDAL
    {
        public DataTable SaveSalesPerson(SalesPersonBLL salesPerson, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesPersonName", salesPerson.SalesPersonName.Trim());
                db.AddParameters("@Address", salesPerson.Address.Trim());
                db.AddParameters("@PostalCode", salesPerson.PostalCode.Trim());
                db.AddParameters("@City", salesPerson.City.Trim());
                db.AddParameters("@District", salesPerson.District.Trim());
                db.AddParameters("@Country", salesPerson.Country.Trim());
                db.AddParameters("@NationalId", salesPerson.NationalId.Trim());
                db.AddParameters("@PassportNumber", salesPerson.PassportNumber.Trim());
                db.AddParameters("@ContactNumber", salesPerson.ContactNumber.Trim());
                db.AddParameters("@Email", salesPerson.Email.Trim());
                db.AddParameters("@JoiningSalesCenterId", salesPerson.JoiningSalesCenterId.Trim());
                db.AddParameters("@WorkingSalesCenterId", salesPerson.WorkingSalesCenterId.Trim());
                db.AddParameters("@JoinDate", salesPerson.JoinDate.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_SALES_PERSON", true);
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

        public DataTable GetSalesPersonList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_SALES_PERSONS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedSalesPersonListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_SALES_PERSONS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesPersonById(string salesPersonId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesPersonId", salesPersonId);
                DataTable dt = db.ExecuteDataTable("GET_SALES_PERSON_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSalesPersonActivation(string salesPersonId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesPersonId", salesPersonId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_SALES_PERSON_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSalesPerson(string salesPersonId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesPersonId", salesPersonId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_SALES_PERSON_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSalesPerson(SalesPersonBLL salesPerson, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesPersonId", salesPerson.SalesPersonId.Trim());
                db.AddParameters("@SalesPersonName", salesPerson.SalesPersonName.Trim());
                db.AddParameters("@Address", salesPerson.Address.Trim());
                db.AddParameters("@PostalCode", salesPerson.PostalCode.Trim());
                db.AddParameters("@City", salesPerson.City.Trim());
                db.AddParameters("@District", salesPerson.District.Trim());
                db.AddParameters("@Country", salesPerson.Country.Trim());
                db.AddParameters("@NationalId", salesPerson.NationalId.Trim());
                db.AddParameters("@PassportNumber", salesPerson.PassportNumber.Trim());
                db.AddParameters("@ContactNumber", salesPerson.ContactNumber.Trim());
                db.AddParameters("@Email", salesPerson.Email.Trim());
                db.AddParameters("@JoiningSalesCenterId", salesPerson.JoiningSalesCenterId.Trim());
                db.AddParameters("@WorkingSalesCenterId", salesPerson.WorkingSalesCenterId.Trim());
                db.AddParameters("@JoinDate", salesPerson.JoinDate.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_SALES_PERSON_BY_ID", true);
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

        public DataTable GetActiveSalesPersonListBySalesCenter(string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_SALES_PERSON_LIST_BY_SALES_CENTER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
