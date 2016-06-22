using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class SalesCenterBLL
    {
        public string SalesCenterId { get; set; }
        public string SalesCenterName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WarehouseId { get; set; }

        public DataTable SaveSalesCenter()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = salesCenter.SaveSalesCenter(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public void SaveUserSalesCentersByUserId(string userId, List<string> salesCenters)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesCenter.SaveUserSalesCentersByUserId(userId, salesCenters, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetSalesCenterList()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetSalesCenterList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetSalesCenterListByActivationStatus(string isActive)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetSalesCenterListByActivationStatus(isActive, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetSalesCenterListByActivationStatusAndWH(string isActive, string warehouseId)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetSalesCenterListByActivationStatusAndWH(isActive, warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetDeletedSalesCenterListByDateRangeAll(string fromDate, string toDate, string search)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetDeletedSalesCenterListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetUserSalesCentersByUserId(string userId)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetUserSalesCentersByUserId(userId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetActiveSalesCenterList()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetActiveSalesCenterList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetActiveSalesCenterListByUser()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetActiveSalesCenterListByUser(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable GetSalesCenterById(string salesCenterId)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.GetSalesCenterById(salesCenterId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public bool CheckDuplicateSalesCenter(string salesCenterName)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = salesCenter.CheckDuplicateSalesCenter(salesCenterName, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public void UpdateSalesCenterActivation(string salesCenterId, string activationStatus)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesCenter.UpdateSalesCenterActivation(salesCenterId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public void DeleteSalesCenter(string salesCenterId)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesCenter.DeleteSalesCenter(salesCenterId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public void UpdateSalesCenter()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                salesCenter.UpdateSalesCenter(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }



        public DataTable getAvailableProductListBySalesCenter(string SalesCenter)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.getAvailableProductListBySalesCenter(SalesCenter, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public string StockLimit { get; set; }

        public bool UpdateSalesCenterNotificationLimit()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
               salesCenter.UpdateSalesCenterNotificationLimit(this, db);
                db.Stop();

               status=true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
            return status;
        }

        public DataTable getStockNotificationLimit()
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.getStockNotificationLimit( db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }

        public DataTable getTotalCashCreditSalesByDateRange(string startdate, string EndDate, string UserId)
        {
            SalesCenterDAL salesCenter = new SalesCenterDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = salesCenter.getTotalCashCreditSalesByDateRange(startdate, EndDate, UserId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenter = null;
            }
        }
    }
}
