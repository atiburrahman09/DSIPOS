using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class DebitCreditVoucherBLL
    {
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

        public DataTable SaveCreditVoucherCheque()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = debitCreditVoucher.SaveCreditVoucherCheque(this, db);
                db.Stop();

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

        public DataTable SaveCreditVoucherCash()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = debitCreditVoucher.SaveCreditVoucherCash(this, db);
                db.Stop();

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

        public DataTable GetCreditVoucherApprovalListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetCreditVoucherApprovalListByDateRangeAndAll(SalesCenter,fromDate, toDate, cashCheque, search, db);
                db.Stop();

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

        public DataTable GetCreditVoucherApprovedListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetCreditVoucherApprovedListByDateRangeAndAll(SalesCenter,fromDate, toDate, cashCheque, search, db);
                db.Stop();

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

        public DataTable GetCreditVoucherApprovedByJournal(string cashCheque, string journalNumber)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetCreditVoucherApprovedByJournal(cashCheque, journalNumber, db);
                db.Stop();

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

        public DataTable GetCreditVoucherApprovalByJournal(string cashCheque, string journalNumber)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetCreditVoucherApprovalByJournal(cashCheque, journalNumber, db);
                db.Stop();

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

        public void UpdateCreditVoucherCheque()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.UpdateCreditVoucherCheque(this, db);
                db.Stop();
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

        public void UpdateCreditVoucherCash()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.UpdateCreditVoucherCash(this, db);
                db.Stop();
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

        public void ApproveCreditVoucherByJournal(string journalNumber, string cashCheque)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.ApproveCreditVoucherByJournal(journalNumber, cashCheque, db);
                db.Stop();
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

        /////////////////////////////////////////////////////////////////////////////////////////////

        public void RejectDebitCreditJournalVoucherByJournal(string journalNumber)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.RejectDebitCreditJournalVoucherByJournal(journalNumber, db);
                db.Stop();
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

        /////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable SaveDebitVoucherCheque()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = debitCreditVoucher.SaveDebitVoucherCheque(this, db);
                db.Stop();

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

        public DataTable SaveDebitVoucherCash()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = debitCreditVoucher.SaveDebitVoucherCash(this, db);
                db.Stop();

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

        public DataTable GetDebitVoucherApprovalListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetDebitVoucherApprovalListByDateRangeAndAll(SalesCenter,fromDate, toDate, cashCheque, search, db);
                db.Stop();

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

        public DataTable GetDebitVoucherApprovedListByDateRangeAndAll(string SalesCenter,string fromDate, string toDate, string cashCheque, string search)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetDebitVoucherApprovedListByDateRangeAndAll(SalesCenter,fromDate, toDate, cashCheque, search, db);
                db.Stop();

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

        public DataTable GetDebitVoucherApprovedByJournal(string cashCheque, string journalNumber)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetDebitVoucherApprovedByJournal(cashCheque, journalNumber, db);
                db.Stop();

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

        public DataTable GetDebitVoucherApprovalByJournal(string cashCheque, string journalNumber)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = debitCreditVoucher.GetDebitVoucherApprovalByJournal(cashCheque, journalNumber, db);
                db.Stop();

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

        public void UpdateDebitVoucherCheque()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.UpdateDebitVoucherCheque(this, db);
                db.Stop();
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

        public void UpdateDebitVoucherCash()
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.UpdateDebitVoucherCash(this, db);
                db.Stop();
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

        public void ApproveDebitVoucherByJournal(string journalNumber, string cashCheque)
        {
            DebitCreditVoucherDAL debitCreditVoucher = new DebitCreditVoucherDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                debitCreditVoucher.ApproveDebitVoucherByJournal(journalNumber, cashCheque, db);
                db.Stop();
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

        public object SalesCenterId { get; set; }
    }
}
