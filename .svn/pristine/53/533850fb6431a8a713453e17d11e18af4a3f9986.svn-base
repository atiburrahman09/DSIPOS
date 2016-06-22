using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class BankDAL
    {
        public DataTable SaveBank(BankBLL bank, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankName", bank.BankName.Trim());
                db.AddParameters("@Description", bank.Description.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_BANK", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public DataTable GetBankList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_BANKS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedBankListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_BANK_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveBankList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_BANK_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBankById(string bankId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankId", bankId);
                DataTable dt = db.ExecuteDataTable("GET_BANK_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateBank(string bankName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@BankName", bankName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_BANK", true);

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

        public void UpdateBankActivation(string bankId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankId", bankId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_BANK_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBank(string bankId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankId", bankId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_BANK_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateBank(BankBLL bank, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankId", bank.BankId.Trim());
                db.AddParameters("@BankName", bank.BankName.Trim());
                db.AddParameters("@Description", bank.Description.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_BANK_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }
    }
}
