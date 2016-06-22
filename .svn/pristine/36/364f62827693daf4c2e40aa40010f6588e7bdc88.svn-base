using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductPriceDAL
    {
        public DataTable GetProductPriceListByProductGroup(string productGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductGroupId", productGroupId);
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_PRODUCT_PRICE_LIST_BY_ACTIVE_PRODUCT_GROUP", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductPriceList(List<ProductPriceBLL> productPrices, LumexDBPlayer db)
        {
            try
            {
                for (int i = 0; i < productPrices.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@ProductId", productPrices[i].ProductId.Trim());
                    db.AddParameters("@RatePerUnit", productPrices[i].RatePerUnit);
                    db.AddParameters("@VATPercentage", productPrices[i].VATPercentage);
                    db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                    DataTable dt = db.ExecuteDataTable("UPDATE_PRODUCT_PRICE_BY_ID", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateOverallProductVAT(string vatPercentage, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@VATPercentage", vatPercentage);
                DataTable dt = db.ExecuteDataTable("UPDATE_OVERALL_PRODUCT_VAT", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetOverallProductVAT(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_OVERALL_PRODUCT_VAT", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
