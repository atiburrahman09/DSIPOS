using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class WarehouseBLL
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public DataTable SaveWarehouse()
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = warehouse.SaveWarehouse(this, db);
                db.Stop();

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

        public void SaveUserWarehousesByUserId(string userId, List<string> warehouses)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                warehouse.SaveUserWarehousesByUserId(userId, warehouses, db);
                db.Stop();
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

        public DataTable GetWarehouseList()
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.GetWarehouseList(db);
                db.Stop();

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

        public DataTable GetDeletedWarehouseListByDateRangeAll(string fromDate, string toDate, string search)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.GetDeletedWarehouseListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

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

        public DataTable GetUserWarehousesByUserId(string userId)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.GetUserWarehousesByUserId(userId, db);
                db.Stop();

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

        public DataTable GetActiveWarehouseList()
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.GetActiveWarehouseList(db);
                db.Stop();

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

        public DataTable GetActiveWarehouseListByUser()
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.GetActiveWarehouseListByUser(db);
                db.Stop();

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

        public DataTable GetWarehouseById(string warehouseId)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.GetWarehouseById(warehouseId, db);
                db.Stop();

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

        public bool CheckDuplicateWarehouse(string warehouseName)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = warehouse.CheckDuplicateWarehouse(warehouseName, db);
                db.Stop();
                return status;
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

        public void UpdateWarehouseActivation(string warehouseId, string activationStatus)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                warehouse.UpdateWarehouseActivation(warehouseId, activationStatus, db);
                db.Stop();
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

        public void DeleteWarehouse(string warehouseId)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                warehouse.DeleteWarehouse(warehouseId, db);
                db.Stop();
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

        public void UpdateWarehouse()
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                warehouse.UpdateWarehouse(this, db);
                db.Stop();
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

        public DataTable getAvailableProductListbyWarehouseId(string warehouseId)
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.getAvailableProductListbyWarehouseId(warehouseId, db);
                db.Stop();

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

        public string StockLimit { get; set; }

        

        public DataTable getStockNotificationLimit()
        {
            WarehouseDAL warehouse = new WarehouseDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = warehouse.getStockNotificationLimit(db);
                db.Stop();

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

        public bool UpdateWareHouseNotificationLimit()
        {
            WarehouseDAL warehouse = new WarehouseDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                warehouse.UpdateWareHouseNotificationLimit(this, db);
                db.Stop();
                status = true;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                warehouse = null;
            }
            return status;
        }
    }
}
