using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductGroupDAL
    {
        public DataTable SaveProductGroup(ProductGroupBLL productGroup, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductGroupName", productGroup.ProductGroupName.Trim());
                db.AddParameters("@Description", productGroup.Description.Trim());
                db.AddParameters("@WareHouse", productGroup.warehouse.Trim());
                db.AddParameters("@SalesCenter", productGroup.salescenter.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PRODUCT_GROUP", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productGroup = null;
            }
        }

        public DataTable GetProductGroupList(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId").ToString());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_GROUPS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedProductGroupListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_PRODUCT_GROUPS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveProductGroupList(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId").ToString());
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_PRODUCT_GROUP_LIST", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductGroupById(string productGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductGroupId", productGroupId);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_GROUP_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateProductGroup(string productGroupName,string warehouse, string salescenter, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@ProductGroupName", productGroupName);
                db.AddParameters("@WareHouse", warehouse);
                db.AddParameters("@SalesCenter",salescenter);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_PRODUCT_GROUP", true);

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

        public void UpdateProductGroupActivation(string productGroupId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductGroupId", productGroupId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_GROUP_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteProductGroup(string productGroupId, string forceToDelete, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductGroupId", productGroupId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@ForceToDelete", forceToDelete);

                DataTable dt = db.ExecuteDataTable("DELETE_PRODUCT_GROUP_BY_ID", true);

                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductGroup(ProductGroupBLL productGroup, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductGroupId", productGroup.ProductGroupId.Trim());
                db.AddParameters("@ProductGroupName", productGroup.ProductGroupName.Trim());
                db.AddParameters("@Description", productGroup.Description.Trim());
                db.AddParameters("@WareHouse", productGroup.warehouse.Trim());
                db.AddParameters("@SalesCenter", productGroup.salescenter.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());


                db.ExecuteNonQuery("UPDATE_PRODUCT_GROUP_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productGroup = null;
            }
        }
    }
}
