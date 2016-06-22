using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ChartOfAccountDAL
    {
        public DataTable SaveChartOfAccount(ChartOfAccountBLL chartOfAccount, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountName", chartOfAccount.AccountName.Trim());
                db.AddParameters("@AccountType", chartOfAccount.AccountType.Trim());
                db.AddParameters("@TotallingAccountNumber", chartOfAccount.TotallingAccountNumber.Trim());
                db.AddParameters("@IsPosted", chartOfAccount.IsPosted.Trim());
                db.AddParameters("@UseAs", chartOfAccount.UseAs.Trim());
                db.AddParameters("@BankAccountNumber", chartOfAccount.BankAccountNumber.Trim());
                db.AddParameters("@Description", chartOfAccount.Description.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@OfficeBranchId", "");

                DataTable dt = db.ExecuteDataTable("INSERT_CHART_OF_ACCOUNT", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                chartOfAccount = null;
            }
        }

        public bool CheckDuplicateChartOfAccount(ChartOfAccountBLL chartOfAccount, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@AccountType", chartOfAccount.AccountType.Trim());
                db.AddParameters("@AccountName", chartOfAccount.AccountName.Trim());
                db.AddParameters("@TotallingAccountNumber", chartOfAccount.TotallingAccountNumber.Trim());

                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_CHART_OF_ACCOUNT", true);

                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                chartOfAccount = null;
            }

            return status;
        }

        public DataTable GetTotallingAccountList(string accountType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountType", accountType.Trim());
                DataTable dt = db.ExecuteDataTable("GET_TOTALLING_ACCOUNT_LIST", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetChartOfAccountListByAccountType(string accountType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountType", accountType.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CHART_OF_ACCOUNT_LIST_BY_TYPE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteChartOfAccountById(string accountId, string accountNumber, string forceToDelete, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", accountId.Trim());
                db.AddParameters("@AccountNumber", accountNumber.Trim());
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@ForceToDelete", forceToDelete);

                DataTable dt = db.ExecuteDataTable("DELETE_CHART_OF_ACCOUNT_BY_ID", true);

                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateChartOfAccountActivation(string accountId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", accountId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_CHART_OF_ACCOUNT_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetChartOfAccountById(string accountId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", accountId);
                DataTable dt = db.ExecuteDataTable("GET_CHART_OF_ACCOUNT_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateChartOfAccount(ChartOfAccountBLL chartOfAccount, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", chartOfAccount.AccountId.Trim());
                db.AddParameters("@AccountName", chartOfAccount.AccountName.Trim());
                db.AddParameters("@UseAs", chartOfAccount.UseAs.Trim());
                db.AddParameters("@BankAccountNumber", chartOfAccount.BankAccountNumber.Trim());
                db.AddParameters("@Description", chartOfAccount.Description.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_CHART_OF_ACCOUNT_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                chartOfAccount = null;
            }
        }

        public DataTable GetDeletedChartOfAccountListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_CHART_OF_ACCOUNTS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveAndPostedChartOfAccountsHeadList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_AND_POSTED_CHART_OF_ACCOUNT_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveAndPostedChartOfAccountsBankHeadList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_AND_POSTED_CHART_OF_ACCOUNT_BANK_HEAD", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveAndPostedChartOfAccountsCashAndBankHeadList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_AND_POSTED_CHART_OF_ACCOUNT_CASH_AND_BANK_HEAD", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveAndPostedChartOfAccountsCashHeadList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_AND_POSTED_CHART_OF_ACCOUNT_CASH_HEAD", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
