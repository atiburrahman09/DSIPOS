using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class BankBranchDAL
    {
        public DataTable SaveBankBranch(BankBranchBLL bankBranch, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankId", bankBranch.BankId.Trim());
                db.AddParameters("@BankBranchName", bankBranch.BankBranchName.Trim());
                db.AddParameters("@Description", bankBranch.Description.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_BANK_BRANCH", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bankBranch = null;
            }
        }

        public DataTable GetBankBranchList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_BANK_BRANCHS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedBankBranchListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_BANK_BRANCH_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveBankBranchList(string bankId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankId", bankId);
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_BANK_BRANCH_LIST", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBankBranchById(string bankBranchId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankBranchId", bankBranchId);
                DataTable dt = db.ExecuteDataTable("GET_BANK_BRANCH_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateBankBranch(string bankId, string bankBranchName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@BankId", bankId);
                db.AddParameters("@BankBranchName", bankBranchName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_BANK_BRANCH", true);

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

        public void UpdateBankBranchActivation(string bankBranchId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankBranchId", bankBranchId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_BANK_BRANCH_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBankBranch(string bankBranchId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankBranchId", bankBranchId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_BANK_BRANCH_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateBankBranch(BankBranchBLL bankBranch, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BankBranchId", bankBranch.BankBranchId.Trim());
                db.AddParameters("@BankBranchName", bankBranch.BankBranchName.Trim());
                db.AddParameters("@Description", bankBranch.Description.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_BANK_BRANCH_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bankBranch = null;
            }
        }
    }
}
