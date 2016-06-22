using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class SalesCenterDAL
    {
        public DataTable SaveSalesCenter(SalesCenterBLL salesCenter, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterName", salesCenter.SalesCenterName.Trim());
                db.AddParameters("@Address", salesCenter.Address.Trim());
                db.AddParameters("@Country", salesCenter.Country.Trim());
                db.AddParameters("@City", salesCenter.City.Trim());
                db.AddParameters("@District", salesCenter.District.Trim());
                db.AddParameters("@PostalCode", salesCenter.PostalCode.Trim());
                db.AddParameters("@Phone", salesCenter.Phone.Trim());
                db.AddParameters("@Mobile", salesCenter.Mobile.Trim());
                db.AddParameters("@Fax", salesCenter.Fax.Trim());
                db.AddParameters("@Email", salesCenter.Email.Trim());
                db.AddParameters("@WarehouseId", salesCenter.WarehouseId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_SALES_CENTER", true);
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

        public void SaveUserSalesCentersByUserId(string userId, List<string> salesCenters, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.ExecuteNonQuery("DELETE_USER_SALES_CENTERS_BY_USER_ID", true);

                for (int i = 0; i < salesCenters.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@UserId", userId);
                    db.AddParameters("@SalesCenterId", salesCenters[i].ToString());
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteDataTable("INSERT_USER_SALES_CENTERS_BY_USER_ID", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesCenters = null;
            }
        }

        public DataTable GetSalesCenterList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_SALES_CENTERS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesCenterListByActivationStatus(string isActive, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@IsActive", isActive.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_CENTERS_BY_ACTIVATION_STATUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesCenterListByActivationStatusAndWH(string isActive, string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@IsActive", isActive.Trim());
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_CENTERS_BY_WH_AND_ACTIVATION_STATUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedSalesCenterListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_SALES_CENTERS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUserSalesCentersByUserId(string userId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                DataTable dt = db.ExecuteDataTable("GET_USER_SALES_CENTERS_BY_USER_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveSalesCenterList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_SALES_CENTER_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveSalesCenterListByUser(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId").ToString());
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_SALES_CENTER_LIST_BY_USER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesCenterById(string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId);
                DataTable dt = db.ExecuteDataTable("GET_SALES_CENTER_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateSalesCenter(string salesCenterName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@SalesCenterName", salesCenterName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_SALES_CENTER", true);

                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public void UpdateSalesCenterActivation(string salesCenterId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_SALES_CENTER_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSalesCenter(string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_SALES_CENTER_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSalesCenter(SalesCenterBLL salesCenter, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenter.SalesCenterId.Trim());
                db.AddParameters("@SalesCenterName", salesCenter.SalesCenterName.Trim());
                db.AddParameters("@Address", salesCenter.Address.Trim());
                db.AddParameters("@Country", salesCenter.Country.Trim());
                db.AddParameters("@City", salesCenter.City.Trim());
                db.AddParameters("@District", salesCenter.District.Trim());
                db.AddParameters("@PostalCode", salesCenter.PostalCode.Trim());
                db.AddParameters("@Phone", salesCenter.Phone.Trim());
                db.AddParameters("@Mobile", salesCenter.Mobile.Trim());
                db.AddParameters("@Fax", salesCenter.Fax.Trim());
                db.AddParameters("@Email", salesCenter.Email.Trim());
                db.AddParameters("@WarehouseId", salesCenter.WarehouseId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_SALES_CENTER_BY_ID", true);
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

        internal DataTable getAvailableProductListBySalesCenter(string SalesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", SalesCenterId);
                DataTable dt = db.ExecuteDataTable("[GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable UpdateSalesCenterNotificationLimit(SalesCenterBLL salesCenterBLL, LumexDBPlayer db)
        {  
            try
            {
                db.AddParameters("@Value", salesCenterBLL.StockLimit);
                db.AddParameters("@Key","SSL");
                DataTable dt = db.ExecuteDataTable("UPDATE_APP_SETTING_BY_KEY", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable getStockNotificationLimit(LumexDBPlayer db)
        {
            try
            {
              
                db.AddParameters("@Key", "SSL");
                DataTable dt = db.ExecuteDataTable("GET_APP_SETTING_VALUE_BY_KEY", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable getTotalCashCreditSalesByDateRange(string startdate, string EndDate, string UserId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(startdate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(EndDate));
               
                DataTable dt = db.ExecuteDataTable("[GET_SALES_RECORDS_TOTAL_CASH_DUE_BY_SALES_CENTER_DATE_RANGE_AND_STATUS]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
