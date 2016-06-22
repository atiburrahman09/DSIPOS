using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class BankChequeBookBLL
    {
        public string AccountId { get; set; }
        public string ChequeBookRefNo { get; set; }
        public string AutoRefNo { get; set; }
        public string EntryDate { get; set; }
        public string StartPageNo { get; set; }
        public string EndPageNo { get; set; }
        public string Status { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public DataTable SaveBankChequeBook()
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = bankChequeBook.SaveBankChequeBook(this, db);
                db.Stop();

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

        public bool CheckDuplicateBankChequeBook()
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = bankChequeBook.CheckDuplicateBankChequeBook(this, db);
                db.Stop();

                return status;
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

        public DataTable GetBankChequeBookEntryListByAccountIdDateRangeAndStatus()
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankChequeBook.GetBankChequeBookEntryListByAccountIdDateRangeAndStatus(this, db);
                db.Stop();

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

        public DataTable GetBankChequeBookEntryApprovalListByAccountIdAll(string accountId)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankChequeBook.GetBankChequeBookEntryApprovalListByAccountIdAll(accountId, db);
                db.Stop();

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

        public void RejectBankChequeBookEntryByAutoRefNo(string autoRefNo)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankChequeBook.RejectBankChequeBookEntryByAutoRefNo(autoRefNo, db);
                db.Stop();
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

        public void ApproveBankChequeBookEntryByAutoRefNo()
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankChequeBook.ApproveBankChequeBookEntryByAutoRefNo(this, db);
                db.Stop();
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

        public DataTable GetBankChequeBookEntryByAutoRefNo(string autoRefNo)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankChequeBook.GetBankChequeBookEntryByAutoRefNo(autoRefNo, db);
                db.Stop();

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

        public DataTable GetBankChequeBookPagesByAutoRefNo(string autoRefNo)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankChequeBook.GetBankChequeBookPagesByAutoRefNo(autoRefNo, db);
                db.Stop();

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

        public DataTable GetBankChequeBookAutoRefNosByAccountId(string accountId)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankChequeBook.GetBankChequeBookAutoRefNosByAccountId(accountId, db);
                db.Stop();

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

        public void ChequeVoidByAutoRefNoAndChequeNo(string autoRefNo, string chequeNo, string voidNarration)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankChequeBook.ChequeVoidByAutoRefNoAndChequeNo(autoRefNo, chequeNo, voidNarration, db);
                db.Stop();
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

        public void ChequeUsedByAutoRefNoAndChequeNo(string autoRefNo, string chequeNo, string usedDate, string usedVoucherNo, string usedJournalNo, string usedNarration)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bankChequeBook.ChequeUsedByAutoRefNoAndChequeNo(autoRefNo, chequeNo, usedDate, usedVoucherNo, usedJournalNo, usedNarration, db);
                db.Stop();
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

        public DataTable GetChequeVoidListByDateRangeAndAll(string fromDate, string toDate, string search)
        {
            BankChequeBookDAL bankChequeBook = new BankChequeBookDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bankChequeBook.GetChequeVoidListByDateRangeAndAll(fromDate, toDate, search, db);
                db.Stop();

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
    }
}
