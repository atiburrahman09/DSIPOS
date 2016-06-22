using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PayToFromCompanyBLL
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }

        public DataTable SavePayToFromCompany()
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = payToFromCompany.SavePayToFromCompany(this, db);
                db.Stop();

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

        public DataTable GetPayToFromCompanyList()
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = payToFromCompany.GetPayToFromCompanyList(db);
                db.Stop();

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

        public DataTable GetDeletedPayToFromCompanyListByDateRangeAll(string fromDate, string toDate, string search)
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = payToFromCompany.GetDeletedPayToFromCompanyListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

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

        public DataTable GetActivePayToFromCompanyList()
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = payToFromCompany.GetActivePayToFromCompanyList(db);
                db.Stop();

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

        public DataTable GetPayToFromCompanyById(string companyId)
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = payToFromCompany.GetPayToFromCompanyById(companyId, db);
                db.Stop();

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

        public bool CheckDuplicatePayToFromCompany(string companyName)
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = payToFromCompany.CheckDuplicatePayToFromCompany(companyName, db);
                db.Stop();
                return status;
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

        public void UpdatePayToFromCompanyActivation(string companyId, string activationStatus)
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                payToFromCompany.UpdatePayToFromCompanyActivation(companyId, activationStatus, db);
                db.Stop();
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

        public void DeletePayToFromCompany(string companyId)
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                payToFromCompany.DeletePayToFromCompany(companyId, db);
                db.Stop();
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

        public void UpdatePayToFromCompany()
        {
            PayToFromCompanyDAL payToFromCompany = new PayToFromCompanyDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                payToFromCompany.UpdatePayToFromCompany(this, db);
                db.Stop();
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
