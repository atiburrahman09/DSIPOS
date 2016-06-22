using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lumex.Project.DAL;
using Lumex.Tech;
using System.Data;

namespace Lumex.Project.BLL
{
    public class newproductionBLL
    {
        public string productionId { get; set; }
        public string productID { get; set; }
        public double produceWeight { get; set; }
        public double produceBundle { get; set; }
        public string produceDate { get; set; }
        public double unitCost { get; set; }
        public double productionCost { get; set; }
        public double totalQuantity { get; set; }
        public double rawMetarialCost { get; set; }
        public double otherAmmount { get; set; }
        public double workingCost { get; set; }
        public double decreaseWeight { get; set; }
        public double decreaseRate { get; set; }
        public string description { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public double productQuantity { get; set; }
        public double productRate { get; set; }
        public double totalCost { get; set; }
        public string wareHouseID { get; set; }
        public string formDate { get; set; }
        public string toDate { get; set; }
        public string status { get; set; }

        public bool SaveProductionDetails(DataTable dtMetarial)
        {
            bool st = false;
            newproductionDAL NewproductionDAL = new newproductionDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                st=NewproductionDAL.SaveProductionDetails(db,this,dtMetarial);
                db.Stop();

                return st;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                NewproductionDAL = null;
            }
        }

        public DataTable getApprovalProductList()
        {
            newproductionDAL newProductionDal = new newproductionDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = newProductionDal.getApprovalProductList(db, this);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable getProductionDetailsbyProductionID(string productionID)
        {
            newproductionDAL NewproductionDAL = new newproductionDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = NewproductionDAL.getProductionDetailsById(db, productionID);
                db.Stop();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                NewproductionDAL = null;
            }
        }

        public DataTable getRawmetarialsbyProductionID(string productionID)
        {
            newproductionDAL newProductionDll = new newproductionDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = newProductionDll.getRawmetarialsbyProductionID(db, productionID);
                db.Stop();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                newProductionDll = null;
            }
        }

        public bool rejectProduct(string ProductionID)
        {
            newproductionDAL newProductionDal = new newproductionDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                status = newProductionDal.rejectProduction(db,ProductionID);
                db.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public bool approveNewProductionwithProductionId(string productionId)
        {
            bool status = false;
            newproductionDAL newProductiondal = new newproductionDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                status = newProductiondal.approveProduction(db, productionId);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                newProductiondal = null;
            }
            return status;
        }



        public string forStock { get; set; }

       

        public DataTable getProductDetails(string productId,string WHid)
        {
            DataTable dt = new DataTable();
            newproductionDAL newproductionDal = new newproductionDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = newproductionDal.getProductDetails(db, productId,WHid);
                db.Stop();
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        public string mainProductionID { get; set; }

        

        public string typeOf { get; set; }

        public bool saveNewProcutToWarehouse(DataTable productTable)
        {
            bool status = false;
            
            newproductionDAL newproductionDal = new newproductionDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                status = newproductionDal.saveNewProductInformation(this,db,productTable);
                db.Stop();
            }
            catch (Exception)
            {
                
                throw;
            }
            return status;
        }

        public string usedWeightOfNewProduction { get; set; }
    }
}
