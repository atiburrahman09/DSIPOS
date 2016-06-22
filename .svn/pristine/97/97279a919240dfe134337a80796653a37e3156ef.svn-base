using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ChartOfAccountBLL
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string TotallingAccountNumber { get; set; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public string Group3 { get; set; }
        public string Group4 { get; set; }
        public string Group5 { get; set; }
        public string IsPosted { get; set; }
        public string AccountLevel { get; set; }
        public string UseAs { get; set; }
        public string BankAccountNumber { get; set; }
        public string Description { get; set; }

        public DataTable SaveChartOfAccount()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = chartOfAccount.SaveChartOfAccount(this, db);
                db.Stop();

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

        public bool CheckDuplicateChartOfAccount()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = chartOfAccount.CheckDuplicateChartOfAccount(this, db);
                db.Stop();
                return status;
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

        public DataTable GetTotallingAccountList(string accountType)
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetTotallingAccountList(accountType, db);
                db.Stop();

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

        public DataTable GetChartOfAccountListByAccountType(string accountType)
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetChartOfAccountListByAccountType(accountType, db);
                db.Stop();

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

        public string DeleteChartOfAccountById(string accountId, string accountNumber, string forceToDelete)
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string status = chartOfAccount.DeleteChartOfAccountById(accountId, accountNumber, forceToDelete, db);
                db.Stop();

                return status;
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

        public void UpdateChartOfAccountActivation(string accountId, string activationStatus)
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                chartOfAccount.UpdateChartOfAccountActivation(accountId, activationStatus, db);
                db.Stop();
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

        public DataTable GetChartOfAccountById(string accountId)
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetChartOfAccountById(accountId, db);
                db.Stop();

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

        public void UpdateChartOfAccount()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                chartOfAccount.UpdateChartOfAccount(this, db);
                db.Stop();
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

        public DataTable GetDeletedChartOfAccountListByDateRangeAll(string fromDate, string toDate, string search)
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetDeletedChartOfAccountListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

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

        public DataTable GetActiveAndPostedChartOfAccountsHeadList()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsHeadList(db);
                db.Stop();

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

        public DataTable GetActiveAndPostedChartOfAccountsBankHeadList()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsBankHeadList(db);
                db.Stop();

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

        public DataTable GetActiveAndPostedChartOfAccountsCashAndBankHeadList()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashAndBankHeadList(db);
                db.Stop();

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

        public DataTable GetActiveAndPostedChartOfAccountsCashHeadList()
        {
            ChartOfAccountDAL chartOfAccount = new ChartOfAccountDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = chartOfAccount.GetActiveAndPostedChartOfAccountsCashHeadList(db);
                db.Stop();

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
    }
}
