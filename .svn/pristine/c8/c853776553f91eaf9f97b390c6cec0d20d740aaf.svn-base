using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductPriceBLL
    {
        public string ProductId { get; set; }
        public decimal RatePerUnit { get; set; }
        public float VATPercentage { get; set; }

        public DataTable GetProductPriceListByProductGroup(string productGroupId)
        {
            ProductPriceDAL productPrice = new ProductPriceDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productPrice.GetProductPriceListByProductGroup(productGroupId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productPrice = null;
            }
        }

        public void UpdateProductPriceList(List<ProductPriceBLL> productPrices)
        {
            ProductPriceDAL productPrice = new ProductPriceDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                productPrice.UpdateProductPriceList(productPrices, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productPrice = null;
            }
        }

        public void UpdateOverallProductVAT(string vatPercentage)
        {
            ProductPriceDAL productPrice = new ProductPriceDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                productPrice.UpdateOverallProductVAT(vatPercentage, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productPrice = null;
            }
        }

        public DataTable GetOverallProductVAT()
        {
            ProductPriceDAL productPrice = new ProductPriceDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = productPrice.GetOverallProductVAT(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productPrice = null;
            }
        }
    }
}
