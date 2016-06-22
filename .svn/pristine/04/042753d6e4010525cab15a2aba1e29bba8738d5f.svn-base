using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class JournalVoucherBLL
    {
        //public string SN { get; set; }
        //public string AccountHeadName { get; set; }
        //public string BankName { get; set; }
        //public string BankBranchName { get; set; }
        //public string PayToFromCompanyName { get; set; }
        public string JournalNumber { get; set; }
        public string TransactionNumber { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string AutoVoucherNumber { get; set; }
        public string ManualVoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string AccountId { get; set; }
        public string CounterAccountId { get; set; }
        public string Amount { get; set; }
        public string DebitCredit { get; set; }
        public string DrCrJrVoucherFlag { get; set; }
        public string CashCheque { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeDate { get; set; }
        public string Description { get; set; }
        public string PayToFromCompany { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        public string IsApprove { get; set; }
        public string OfficeBranchId { get; set; }

        public DataTable SaveJournalVoucher(string SalesCenter,DataTable dtJournalList)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = journalVoucher.SaveJournalVoucher(SalesCenter,dtJournalList, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public DataTable GetJournalVoucherApprovalListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string search)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = journalVoucher.GetJournalVoucherApprovalListByDateRangeAndAll(SalesCenter, fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public DataTable GetJournalVoucherListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string search)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = journalVoucher.GetJournalVoucherListByDateRangeAndAll(SalesCenter,fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public DataTable GetJournalVoucherApprovedListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string search)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = journalVoucher.GetJournalVoucherApprovedListByDateRangeAndAll(SalesCenter,fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public DataTable GetJournalVoucherEntryListByJournal(string journalNumber)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = journalVoucher.GetJournalVoucherEntryListByJournal(journalNumber, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public DataTable GetJournalVoucherEntryByJournalAndTransactionNumber(string journalNumber, string transactionNumber)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = journalVoucher.GetJournalVoucherEntryByJournalAndTransactionNumber(journalNumber, transactionNumber, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public void UpdateJournalVoucherEntryByJournalAndTransactionNumber()
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                journalVoucher.UpdateJournalVoucherEntryByJournalAndTransactionNumber(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public void UpdateJournalVoucherUpdateStatusByJournal(string journalNumber)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                journalVoucher.UpdateJournalVoucherUpdateStatusByJournal(journalNumber, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }

        public void ApproveJournalVoucherByJournal(string journalNumber)
        {
            JournalVoucherDAL journalVoucher = new JournalVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                journalVoucher.ApproveJournalVoucherByJournal(journalNumber, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                journalVoucher = null;
            }
        }
    }
}
