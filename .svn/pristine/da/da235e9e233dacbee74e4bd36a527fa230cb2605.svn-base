using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class DebitCreditVoucherDAL
    {
        public DataTable SaveCreditVoucherCheque(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@Bank", debitCreditVoucher.Bank.Trim());
                db.AddParameters("@BankBranch", debitCreditVoucher.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", debitCreditVoucher.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", debitCreditVoucher.ChequeDate.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", debitCreditVoucher.SalesCenterId);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_CREDIT_VOUCHER_CHEQUE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public DataTable SaveCreditVoucherCash(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId",debitCreditVoucher.SalesCenterId);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_CREDIT_VOUCHER_CASH", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public DataTable GetCreditVoucherApprovalListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId", SalesCenter.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_CREDIT_VOUCHER_APPROVAL_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCreditVoucherApprovedListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId",SalesCenter);
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_CREDIT_VOUCHER_APPROVED_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCreditVoucherApprovedByJournal(string cashCheque, string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@JournalNumber", journalNumber.Trim());

                DataTable dt = db.ExecuteDataTable("GET_CREDIT_VOUCHER_APPROVED_BY_JOURNAL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCreditVoucherApprovalByJournal(string cashCheque, string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@JournalNumber", journalNumber.Trim());

                DataTable dt = db.ExecuteDataTable("GET_CREDIT_VOUCHER_APPROVAL_BY_JOURNAL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCreditVoucherCheque(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", debitCreditVoucher.JournalNumber.Trim());
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@Bank", debitCreditVoucher.Bank.Trim());
                db.AddParameters("@BankBranch", debitCreditVoucher.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", debitCreditVoucher.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", debitCreditVoucher.ChequeDate.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", LumexSessionManager.Get("UserSalesCenterId").ToString());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_CREDIT_VOUCHER_CHEQUE", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public void UpdateCreditVoucherCash(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", debitCreditVoucher.JournalNumber.Trim());
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", LumexSessionManager.Get("UserSalesCenterId").ToString());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_CREDIT_VOUCHER_CASH", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public void ApproveCreditVoucherByJournal(string journalNumber, string cashCheque, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("APPROVE_CREDIT_VOUCHER_BY_JOURNAL", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        public void RejectDebitCreditJournalVoucherByJournal(string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.AddParameters("@RejectedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@RejectedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("REJECT_DEBIT_CREDIT_JOURNAL_VOUCHER_BY_JOURNAL", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable SaveDebitVoucherCheque(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@Bank", debitCreditVoucher.Bank.Trim());
                db.AddParameters("@BankBranch", debitCreditVoucher.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", debitCreditVoucher.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", debitCreditVoucher.ChequeDate.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", debitCreditVoucher.SalesCenterId);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_DEBIT_VOUCHER_CHEQUE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public DataTable SaveDebitVoucherCash(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", debitCreditVoucher.SalesCenterId);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_DEBIT_VOUCHER_CASH", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public DataTable GetDebitVoucherApprovalListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId", SalesCenter);
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DEBIT_VOUCHER_APPROVAL_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDebitVoucherApprovedListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@OfficeBranchId",SalesCenter);
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DEBIT_VOUCHER_APPROVED_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDebitVoucherApprovedByJournal(string cashCheque, string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@JournalNumber", journalNumber.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DEBIT_VOUCHER_APPROVED_BY_JOURNAL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDebitVoucherApprovalByJournal(string cashCheque, string journalNumber, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@JournalNumber", journalNumber.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DEBIT_VOUCHER_APPROVAL_BY_JOURNAL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDebitVoucherCheque(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", debitCreditVoucher.JournalNumber.Trim());
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@Bank", debitCreditVoucher.Bank.Trim());
                db.AddParameters("@BankBranch", debitCreditVoucher.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", debitCreditVoucher.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", debitCreditVoucher.ChequeDate.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", LumexSessionManager.Get("UserSalesCenterId").ToString());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_DEBIT_VOUCHER_CHEQUE", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public void UpdateDebitVoucherCash(DebitCreditVoucherBLL debitCreditVoucher, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", debitCreditVoucher.JournalNumber.Trim());
                db.AddParameters("@ManualVoucherNumber", debitCreditVoucher.ManualVoucherNumber.Trim());
                db.AddParameters("@AccountId", debitCreditVoucher.AccountId.Trim());
                db.AddParameters("@CounterAccountId", debitCreditVoucher.CounterAccountId.Trim());
                db.AddParameters("@Amount", debitCreditVoucher.Amount.Trim());
                db.AddParameters("@PayToFromCompany", debitCreditVoucher.PayToFromCompany.Trim());
                db.AddParameters("@Narration", debitCreditVoucher.Narration.Trim());
                db.AddParameters("@OfficeBranchId", LumexSessionManager.Get("UserSalesCenterId").ToString());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_DEBIT_VOUCHER_CASH", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                debitCreditVoucher = null;
            }
        }

        public void ApproveDebitVoucherByJournal(string journalNumber, string cashCheque, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@JournalNumber", journalNumber.Trim());
                db.AddParameters("@CashCheque", cashCheque.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("APPROVE_DEBIT_VOUCHER_BY_JOURNAL", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
