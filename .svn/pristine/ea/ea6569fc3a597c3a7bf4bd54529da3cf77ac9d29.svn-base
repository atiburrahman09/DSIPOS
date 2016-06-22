using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class BankChequeBookDAL
    {
        public DataTable SaveBankChequeBook(BankChequeBookBLL bankChequeBook, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", bankChequeBook.AccountId.Trim());
                db.AddParameters("@ChequeBookRefNo", bankChequeBook.ChequeBookRefNo.Trim());
                db.AddParameters("@StartPageNo", bankChequeBook.StartPageNo.Trim());
                db.AddParameters("@EndPageNo", bankChequeBook.EndPageNo.Trim());
                db.AddParameters("@OfficeBranchId", "");
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_CHEQUE_BOOK_ENTRY", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bankChequeBook = null;
            }
        }

        public bool CheckDuplicateBankChequeBook(BankChequeBookBLL bankChequeBook, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@AccountId", bankChequeBook.AccountId.Trim());
                db.AddParameters("@StartPageNo", bankChequeBook.StartPageNo.Trim());
                db.AddParameters("@EndPageNo", bankChequeBook.EndPageNo.Trim());

                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_CHEQUE_BOOK_ENTRY", true);

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
                bankChequeBook = null;
            }

            return status;
        }

        public DataTable GetBankChequeBookEntryListByAccountIdDateRangeAndStatus(BankChequeBookBLL bankChequeBook, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", bankChequeBook.AccountId.Trim());
                db.AddParameters("@FromDate", bankChequeBook.FromDate.Trim());
                db.AddParameters("@ToDate", bankChequeBook.ToDate.Trim());
                db.AddParameters("@Status", bankChequeBook.Status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_CHEQUE_BOOK_ENTRY_BY_ACCOUNT_ID_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bankChequeBook = null;
            }
        }

        public DataTable GetBankChequeBookEntryApprovalListByAccountIdAll(string accountId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", accountId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CHEQUE_BOOK_ENTRY_APPROVAL_LIST_BY_ACCOUNT_ID_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RejectBankChequeBookEntryByAutoRefNo(string autoRefNo, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AutoRefNo", autoRefNo.Trim());
                db.AddParameters("@RejectedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@RejectedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("REJECT_CHEQUE_BOOK_ENTRY_BY_AUTO_REF_NO", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ApproveBankChequeBookEntryByAutoRefNo(BankChequeBookBLL bankChequeBook, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", bankChequeBook.AccountId.Trim());
                db.AddParameters("@ChequeBookRefNo", bankChequeBook.ChequeBookRefNo.Trim());
                db.AddParameters("@AutoRefNo", bankChequeBook.AutoRefNo.Trim());
                db.AddParameters("@StartPageNo", bankChequeBook.StartPageNo.Trim());
                db.AddParameters("@EndPageNo", bankChequeBook.EndPageNo.Trim());
                db.AddParameters("@OfficeBranchId", "");
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("APPROVE_CHEQUE_BOOK_ENTRY_BY_AUTO_REF_NO", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bankChequeBook = null;
            }
        }

        public DataTable GetBankChequeBookEntryByAutoRefNo(string autoRefNo, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AutoRefNo", autoRefNo.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CHEQUE_BOOK_ENTRY_BY_AUTO_REF_NO", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBankChequeBookPagesByAutoRefNo(string autoRefNo, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AutoRefNo", autoRefNo.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CHEQUE_BOOK_PAGES_BY_AUTO_REF_NO", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBankChequeBookAutoRefNosByAccountId(string accountId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AccountId", accountId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CHEQUE_BOOK_AUTO_REF_NOS_BY_ACCOUNT_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ChequeVoidByAutoRefNoAndChequeNo(string autoRefNo, string chequeNo, string voidNarration, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AutoRefNo", autoRefNo.Trim());
                db.AddParameters("@ChequeNo", chequeNo.Trim());
                db.AddParameters("@VoidNarration", voidNarration.Trim());
                db.AddParameters("@VoidBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@VoidFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("CHEQUE_VOID_BY_AUTO_REF_NO_AND_CHEQUE_NO", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ChequeUsedByAutoRefNoAndChequeNo(string autoRefNo, string chequeNo, string usedDate, string usedVoucherNo, string usedJournalNo, string usedNarration, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@AutoRefNo", autoRefNo.Trim());
                db.AddParameters("@ChequeNo", chequeNo.Trim());
                db.AddParameters("@UsedDate", usedDate.Trim());
                db.AddParameters("@UsedVoucherNo", usedVoucherNo.Trim());
                db.AddParameters("@UsedJournalNo", usedJournalNo.Trim());
                db.AddParameters("@UsedNarration", usedNarration.Trim());

                db.ExecuteNonQuery("CHEQUE_USED_BY_AUTO_REF_NO_AND_CHEQUE_NO", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetChequeVoidListByDateRangeAndAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CHEQUE_VOID_LIST_BY_DATE_RANGE_ALL", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
