using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class JournalVoucherDAL
    {
        public DataTable SaveJournalVoucher(string SalesCenter,DataTable dtJournalList, LumexDBPlayer db)
        {
            try
            {
                decimal amt = -1;
                int transactionNo = 0;

                db.AddParameters("@Flag", "JV");
                DataTable dtJournalNumber = db.ExecuteDataTable("GET_AND_UPDATE_AUTO_SERIAL_NUMBER_BY_FLAG", true);

                string journalNumber = dtJournalNumber.Rows[0][0].ToString();

                for (int i = 0; i < dtJournalList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@JournalNumber", journalNumber.Trim());
                    db.AddParameters("@TransactionNumber", dtJournalList.Rows[i]["SN"].ToString());
                    db.AddParameters("@ManualVoucherNumber", dtJournalList.Rows[i]["VoucherNumber"].ToString());
                    db.AddParameters("@AccountId", dtJournalList.Rows[i]["AccountHead"].ToString());
                    db.AddParameters("@DebitCredit", dtJournalList.Rows[i]["DebitCredit"].ToString());
                    db.AddParameters("@Amount", dtJournalList.Rows[i]["Amount"].ToString());
                    db.AddParameters("@Bank", dtJournalList.Rows[i]["Bank"].ToString());
                    db.AddParameters("@BankBranch", dtJournalList.Rows[i]["BankBranch"].ToString());
                    db.AddParameters("@ChequeNumber", dtJournalList.Rows[i]["ChequeNumber"].ToString());
                    db.AddParameters("@ChequeDate", dtJournalList.Rows[i]["ChequeDate"].ToString());
                    db.AddParameters("@PayToFromCompany", dtJournalList.Rows[i]["PayToFromCompany"].ToString());
                    db.AddParameters("@Narration", dtJournalList.Rows[i]["Narration"].ToString());
                    db.AddParameters("@OfficeBranchId", SalesCenter);
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    DataTable dt = db.ExecuteDataTable("INSERT_JOURNAL_VOUCHER", true);

                    if (amt < decimal.Parse(dtJournalList.Rows[i]["Amount"].ToString()))
                    {
                        amt = decimal.Parse(dtJournalList.Rows[i]["Amount"].ToString());
                        transactionNo = int.Parse(dtJournalList.Rows[i]["SN"].ToString());
                    }
                }

                db.ClearParameters();
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.AddParameters("@TransactionNumber", transactionNo);
                db.ExecuteNonQuery("INSERT_JOURNAL_VOUCHER_INTO_GENERAL_LEDGER_APPROVAL_BY_JOURNAL", true);

                return dtJournalNumber;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dtJournalList = null;
            }
        }

        public DataTable GetJournalVoucherApprovalListByDateRangeAndAll(string SalesCenter, string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId", SalesCenter);
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_JOURNAL_VOUCHER_APPROVAL_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetJournalVoucherListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId",SalesCenter);
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_JOURNAL_VOUCHER_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetJournalVoucherApprovedListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId",SalesCenter);
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_JOURNAL_VOUCHER_APPROVED_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetJournalVoucherEntryListByJournal(string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                DataTable dt = db.ExecuteDataTable("GET_JOURNAL_VOUCHER_ENTRY_LIST_BY_JOURNAL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetJournalVoucherEntryByJournalAndTransactionNumber(string journalNumber, string transactionNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.AddParameters("@TransactionNumber", transactionNumber.Trim());
                DataTable dt = db.ExecuteDataTable("GET_JOURNAL_VOUCHER_ENTRY_BY_JOURNAL_AND_TRANSACTION_NUMBER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateJournalVoucherEntryByJournalAndTransactionNumber(JournalVoucherBLL journalVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalVoucher.JournalNumber.Trim());
                db.AddParameters("@TransactionNumber", journalVoucher.TransactionNumber.Trim());
                db.AddParameters("@Description", journalVoucher.Description.Trim());
                db.AddParameters("@ManualVoucherNumber", journalVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", journalVoucher.AccountId.Trim());
                db.AddParameters("@DebitCredit", journalVoucher.DebitCredit.Trim());
                db.AddParameters("@Amount", journalVoucher.Amount.Trim());
                db.AddParameters("@Bank", journalVoucher.Bank.Trim());
                db.AddParameters("@BankBranch", journalVoucher.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", journalVoucher.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", journalVoucher.ChequeDate.Trim());
                db.AddParameters("@PayToFromCompany", journalVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", journalVoucher.Narration.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_JOURNAL_VOUCHER_ENTRY", true);
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

        public void UpdateJournalVoucherUpdateStatusByJournal(string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.ExecuteNonQuery("UPDATE_JOURNAL_VOUCHER_UPDATE_STATUS", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ApproveJournalVoucherByJournal(string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("APPROVE_JOURNAL_VOUCHER_BY_JOURNAL", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
