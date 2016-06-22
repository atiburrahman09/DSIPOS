using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class BankBLL
    {
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }

        public DataTable SaveBank()
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = bank.SaveBank(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public DataTable GetBankList()
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bank.GetBankList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public DataTable GetDeletedBankListByDateRangeAll(string fromDate, string toDate, string search)
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bank.GetDeletedBankListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public DataTable GetActiveBankList()
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bank.GetActiveBankList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public DataTable GetBankById(string bankId)
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = bank.GetBankById(bankId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public bool CheckDuplicateBank(string bankName)
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = bank.CheckDuplicateBank(bankName, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public void UpdateBankActivation(string bankId, string activationStatus)
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bank.UpdateBankActivation(bankId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public void DeleteBank(string bankId)
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bank.DeleteBank(bankId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }

        public void UpdateBank()
        {
            BankDAL bank = new BankDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                bank.UpdateBank(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bank = null;
            }
        }
    }
}
