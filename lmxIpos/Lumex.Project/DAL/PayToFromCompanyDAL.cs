using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class PayToFromCompanyDAL
    {
        public DataTable SavePayToFromCompany(PayToFromCompanyBLL payToFromCompany, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CompanyName", payToFromCompany.CompanyName.Trim());
                db.AddParameters("@Description", payToFromCompany.Description.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PAY_TO_FROM_COMPANY", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                payToFromCompany = null;
            }
        }

        public DataTable GetPayToFromCompanyList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_PAY_TO_FROM_COMPANYS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedPayToFromCompanyListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_PAY_TO_FROM_COMPANY_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActivePayToFromCompanyList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_PAY_TO_FROM_COMPANY_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPayToFromCompanyById(string companyId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CompanyId", companyId);
                DataTable dt = db.ExecuteDataTable("GET_PAY_TO_FROM_COMPANY_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicatePayToFromCompany(string companyName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@CompanyName", companyName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_PAY_TO_FROM_COMPANY", true);

                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public void UpdatePayToFromCompanyActivation(string companyId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CompanyId", companyId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PAY_TO_FROM_COMPANY_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePayToFromCompany(string companyId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CompanyId", companyId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_PAY_TO_FROM_COMPANY_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePayToFromCompany(PayToFromCompanyBLL payToFromCompany, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CompanyId", payToFromCompany.CompanyId.Trim());
                db.AddParameters("@CompanyName", payToFromCompany.CompanyName.Trim());
                db.AddParameters("@Description", payToFromCompany.Description.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PAY_TO_FROM_COMPANY_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                payToFromCompany = null;
            }
        }
    }
}
