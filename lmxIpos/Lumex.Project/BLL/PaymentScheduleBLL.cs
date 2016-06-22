using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class PaymentScheduleBLL
    {

        public System.Data.DataTable GetPaymentScheduleList(string SCID)
        {
            PaymentScheduleDAL paymentScheduleDal = new PaymentScheduleDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = paymentScheduleDal.GetPaymentScheduleList(SCID,db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                paymentScheduleDal = null;
            }
        }

        public decimal ServiceAmount { get; set; }

        public string ScheduleDate { get; set; }
        public string SCWHId { get; set; }
        public string CustomerId { get; set; }


        public DataTable CheckSchduleEntry(string SCWHId, string CustomerId)
        {
            PaymentScheduleDAL paymentScheduleDal = new PaymentScheduleDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = paymentScheduleDal.CheckSchduleEntry(SCWHId,CustomerId,db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                paymentScheduleDal = null;
            }
        }

        public bool SavePaymentSchedule()
        {
            PaymentScheduleDAL paymentScheduleDal = new PaymentScheduleDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                status = paymentScheduleDal.SavePaymentSchedule(this, db);
                db.Stop();

                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                paymentScheduleDal = null;
            }
        }

        public void UpdatePaymentScheduleList(List<PaymentScheduleBLL> paymentSchedule)
        {
            PaymentScheduleDAL paymentScheduleBll = new PaymentScheduleDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                paymentScheduleBll.UpdatePaymentScheduleList(paymentSchedule, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                paymentScheduleBll = null;
            }
        }

        public bool CalculateServiceChargeBySCWHID()
        {
            PaymentScheduleDAL paymentScheduleBll = new PaymentScheduleDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                paymentScheduleBll.CalculateServiceChargeBySCWHID(this, db);
                db.Stop();
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                paymentScheduleBll = null;
            }
            return status;
        }

        public DataTable getServiceChargeCalculatedListByDateRange(string WHSCId,string fromDate, string toDate)
        {
            PaymentScheduleDAL paymentScheduleDal = new PaymentScheduleDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = paymentScheduleDal.getServiceChargeCalculatedListByDateRange(WHSCId,fromDate,toDate, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                paymentScheduleDal = null;
            }
        }
    }
}
