using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class BankBranchBLL
    {
        public string BankId { get; set; }
        public string BankBranchId { get; set; }
        public string BankBranchName { get; set; }
        public string Description { get; set; }

        public DataTable SaveBankBranch()
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = bankBranch.SaveBankBranch(this, db);
                db.Stop();

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

        public DataTable GetBankBranchList()
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankBranch.GetBankBranchList(db);
                db.Stop();

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

        public DataTable GetDeletedBankBranchListByDateRangeAll(string fromDate, string toDate, string search)
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankBranch.GetDeletedBankBranchListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

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

        public DataTable GetActiveBankBranchList(string bankId)
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankBranch.GetActiveBankBranchList(bankId, db);
                db.Stop();

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

        public DataTable GetBankBranchById(string bankId)
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankBranch.GetBankBranchById(bankId, db);
                db.Stop();

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

        public bool CheckDuplicateBankBranch(string bankId, string bankBranchName)
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = bankBranch.CheckDuplicateBankBranch(bankId, bankBranchName, db);
                db.Stop();
                return status;
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

        public void UpdateBankBranchActivation(string bankBranchId, string activationStatus)
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankBranch.UpdateBankBranchActivation(bankBranchId, activationStatus, db);
                db.Stop();
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

        public void DeleteBankBranch(string bankBranchId)
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankBranch.DeleteBankBranch(bankBranchId, db);
                db.Stop();
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

        public void UpdateBankBranch()
        {
            BankBranchDAL bankBranch = new BankBranchDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankBranch.UpdateBankBranch(this, db);
                db.Stop();
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
