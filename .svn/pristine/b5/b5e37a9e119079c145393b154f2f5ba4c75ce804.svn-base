using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class WarehouseDAL
    {
        public DataTable SaveWarehouse(WarehouseBLL warehouse, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseName", warehouse.WarehouseName.Trim());
                db.AddParameters("@Address", warehouse.Address.Trim());
                db.AddParameters("@Country", warehouse.Country.Trim());
                db.AddParameters("@City", warehouse.City.Trim());
                db.AddParameters("@District", warehouse.District.Trim());
                db.AddParameters("@PostalCode", warehouse.PostalCode.Trim());
                db.AddParameters("@Phone", warehouse.Phone.Trim());
                db.AddParameters("@Mobile", warehouse.Mobile.Trim());
                db.AddParameters("@Fax", warehouse.Fax.Trim());
                db.AddParameters("@Email", warehouse.Email.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_WAREHOUSE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                warehouse = null;
            }
        }

        public void SaveUserWarehousesByUserId(string userId, List<string> warehouses, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.ExecuteNonQuery("DELETE_USER_WAREHOUSES_BY_USER_ID", true);

                for (int i = 0; i < warehouses.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@UserId", userId);
                    db.AddParameters("@WarehouseId", warehouses[i].ToString());
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteDataTable("INSERT_USER_WAREHOUSES_BY_USER_ID", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                warehouses = null;
            }
        }

        public DataTable GetWarehouseList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_WAREHOUSES", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedWarehouseListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_WAREHOUSES_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUserWarehousesByUserId(string userId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                DataTable dt = db.ExecuteDataTable("GET_USER_WAREHOUSES_BY_USER_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveWarehouseList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_WAREHOUSE_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveWarehouseListByUser(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId").ToString());
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_WAREHOUSE_LIST_BY_USER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetWarehouseById(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId);
                DataTable dt = db.ExecuteDataTable("GET_WAREHOUSE_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateWarehouse(string warehouseName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@WarehouseName", warehouseName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_WAREHOUSE", true);

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

        public void UpdateWarehouseActivation(string warehouseId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_WAREHOUSE_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWarehouse(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_WAREHOUSE_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWarehouse(WarehouseBLL warehouse, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouse.WarehouseId.Trim());
                db.AddParameters("@WarehouseName", warehouse.WarehouseName.Trim());
                db.AddParameters("@Address", warehouse.Address.Trim());
                db.AddParameters("@Country", warehouse.Country.Trim());
                db.AddParameters("@City", warehouse.City.Trim());
                db.AddParameters("@District", warehouse.District.Trim());
                db.AddParameters("@PostalCode", warehouse.PostalCode.Trim());
                db.AddParameters("@Phone", warehouse.Phone.Trim());
                db.AddParameters("@Mobile", warehouse.Mobile.Trim());
                db.AddParameters("@Fax", warehouse.Fax.Trim());
                db.AddParameters("@Email", warehouse.Email.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_WAREHOUSE_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                warehouse = null;
            }
        }

        internal DataTable getAvailableProductListbyWarehouseId(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId);
                DataTable dt = db.ExecuteDataTable("[GET_AVAILABLE_PRODUCT_LIST_BY_WAREHOUSE]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable UpdateWareHouseNotificationLimit(WarehouseBLL warehouseBLL, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@Value", warehouseBLL.StockLimit);
                db.AddParameters("@Key", "WSL");
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
    }
}
