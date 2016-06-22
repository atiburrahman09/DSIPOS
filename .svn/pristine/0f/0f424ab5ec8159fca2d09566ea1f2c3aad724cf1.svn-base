using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductGroupBLL
    {
        public string ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public string Description { get; set; }

        public DataTable SaveProductGroup()
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = productGroup.SaveProductGroup(this, db);
                db.Stop();

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

        public DataTable GetProductGroupList()
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productGroup.GetProductGroupList(db);
                db.Stop();

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

        public DataTable GetDeletedProductGroupListByDateRangeAll(string fromDate, string toDate, string search)
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productGroup.GetDeletedProductGroupListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

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

        public DataTable GetActiveProductGroupList()
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productGroup.GetActiveProductGroupList(db);
                db.Stop();

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

        public DataTable GetProductGroupById(string productGroupId)
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productGroup.GetProductGroupById(productGroupId, db);
                db.Stop();

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

        public bool CheckDuplicateProductGroup(string productGroupName,string warehouse,string salescenter)
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = productGroup.CheckDuplicateProductGroup(productGroupName,warehouse,salescenter, db);
                db.Stop();
                return status;
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

        public void UpdateProductGroupActivation(string productGroupId, string activationStatus)
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productGroup.UpdateProductGroupActivation(productGroupId, activationStatus, db);
                db.Stop();
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

        public string DeleteProductGroup(string productGroupId, string forceToDelete)
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string status = productGroup.DeleteProductGroup(productGroupId, forceToDelete, db);
                db.Stop();

                return status;
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

        public void UpdateProductGroup()
        {
            ProductGroupDAL productGroup = new ProductGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productGroup.UpdateProductGroup(this, db);
                db.Stop();
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

        public string salescenter { get; set; }

        public string warehouse { get; set; }
    }
}
