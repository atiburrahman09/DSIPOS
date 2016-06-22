using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class PaymentScheduleDAL
    {
        internal System.Data.DataTable GetPaymentScheduleList(string SCID,Tech.LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WHSCId", SCID);
                DataTable dt = db.ExecuteDataTable("GET_PAYMENT_SCHEDULE_LIST", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable CheckSchduleEntry(string SCWHId, string CustomerId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SCWHId", SCWHId);
                db.AddParameters("@CustomerId", CustomerId);
                DataTable dt = db.ExecuteDataTable("GET_PAYMENT_SCHEDULE_LIST_BY_CUSTOMERId_AND_SCWHId", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool SavePaymentSchedule(BLL.PaymentScheduleBLL paymentScheduleBLL, LumexDBPlayer db)
        {
            try
            {
                bool status = false;
                db.AddParameters("@SCWHId", paymentScheduleBLL.SCWHId);
                db.AddParameters("@CustomerId", paymentScheduleBLL.CustomerId);
                db.AddParameters("@ServiceAmount", paymentScheduleBLL.ServiceAmount);
                db.AddParameters("@ScheduleDate", (paymentScheduleBLL.ScheduleDate));
                DataTable dt = db.ExecuteDataTable("INSERT_PAYMENT_SCHEDULE", true);
                status = true;
                return status;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void UpdatePaymentScheduleList(List<BLL.PaymentScheduleBLL> paymentSchedule, LumexDBPlayer db)
        {
            try
            {
                for (int i = 0; i < paymentSchedule.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@CustomerId", paymentSchedule[i].CustomerId.Trim());
                    db.AddParameters("@SCWHId", paymentSchedule[i].SCWHId);
                    db.AddParameters("@ServiceAmount", paymentSchedule[i].ServiceAmount);
                    db.AddParameters("@ScheduleDate", paymentSchedule[i].ScheduleDate);


                    DataTable dt = db.ExecuteDataTable("UPDATE_PAYMENT_SCHEDULE_BY_CUSTOMER_ID_AND_SCWH_ID", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void CalculateServiceChargeBySCWHID(BLL.PaymentScheduleBLL paymentScheduleBLL, LumexDBPlayer db)
        {
            db.AddParameters("@SCWHId", paymentScheduleBLL.SCWHId);
            db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());



            DataTable dt = db.ExecuteDataTable("[GET_CALCULATE_SERVICE_CHARGE__SCWH_ID]", true);
        }

        internal DataTable getServiceChargeCalculatedListByDateRange(String WHSCId,string fromDate, string toDate, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@fromDate", LumexLibraryManager.ParseAppDate(fromDate));
                db.AddParameters("@toDate", LumexLibraryManager.ParseAppDate(toDate));
                db.AddParameters("@WHSCId", WHSCId);

                DataTable dt = db.ExecuteDataTable("[GET_CALCULATED_SERVICE_CHARGE_LIST_BY_DATERANGE]", true);

                return dt;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
