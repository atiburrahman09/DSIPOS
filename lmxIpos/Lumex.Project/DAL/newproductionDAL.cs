using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lumex.Tech;
using Lumex.Project.BLL;

namespace Lumex.Project.DAL
{
    public class newproductionDAL
    {

        public bool SaveProductionDetails(LumexDBPlayer db, newproductionBLL newProduction, DataTable dtRawmetarial)
        {
            DataTable dt = new DataTable();
            bool st = false;
            try
            {
                db.AddParameters("@ProductionId", newProduction.productionId);
                db.AddParameters("@WarehouseId", newProduction.wareHouseID);
                db.AddParameters("@ProductId", newProduction.productID);
                db.AddParameters("@ProduceWight", newProduction.produceWeight);
                db.AddParameters("@ProduceBundle", newProduction.produceBundle);
                db.AddParameters("@ProduceDate", newProduction.produceDate);
                db.AddParameters("@UnitCost", newProduction.unitCost);
                db.AddParameters("@ProductionCost", newProduction.productionCost);
                db.AddParameters("@TotalQualnity", newProduction.totalQuantity);
                db.AddParameters("@RawMaterialCost", newProduction.rawMetarialCost);
                db.AddParameters("@OtherAmount", newProduction.otherAmmount);
                db.AddParameters("@WorkingCost", newProduction.workingCost);
                db.AddParameters("@DecreaseWeight", newProduction.decreaseWeight);
                db.AddParameters("@DecreaseRate", newProduction.decreaseRate);
                db.AddParameters("@DescripTions", newProduction.description);
                db.AddParameters("@CreatedBy", newProduction.createdBy);
                db.AddParameters("@CreatedDate", newProduction.createdDate);
                db.AddParameters("@ForStock", Convert.ToDecimal(newProduction.forStock));

                dt = db.ExecuteDataTable("INSERT_PRODUCTION", true);

                for (int i = 0; i < dtRawmetarial.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@ProductionId", newProduction.productionId);
                    db.AddParameters("@ProductId", dtRawmetarial.Rows[i]["productId"].ToString().Trim());
                    db.AddParameters("@ProductQuantity", dtRawmetarial.Rows[i]["quantity"].ToString().Trim());
                    //db.AddParameters("@ProductRate", dtRawmetarial.Rows[i]["rate"].ToString().Trim());
                    //db.AddParameters("@TotalCost", dtRawmetarial.Rows[i]["cost"].ToString().Trim());

                    db.ExecuteNonQuery("INSERT_PRODUCTION_RAW", true);
                }


                st = true;
            }
            catch (Exception)
            {
                throw;
            }
            return st;
        }

        public DataTable getApprovalProductList(LumexDBPlayer db, newproductionBLL newproductionBLL)
        {
            try
            {
                db.AddParameters("@WarehouseId", newproductionBLL.wareHouseID.Trim());
                db.AddParameters("@FromDate", newproductionBLL.formDate.Trim());
                db.AddParameters("@ToDate", newproductionBLL.toDate.Trim());
                db.AddParameters("@Status", newproductionBLL.status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_PRODUCTION_BY_WAREHOUSE_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable getProductionDetailsById(LumexDBPlayer db, string productionID)
        {
            try
            {
                db.AddParameters("@ProducrionId", productionID);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCTION_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable getRawmetarialsbyProductionID(LumexDBPlayer db, string productionID)
        {
            try
            {
                db.AddParameters("@ProducrionId", productionID);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCTION_RAW_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool rejectProduction(LumexDBPlayer db, string ProductionID)
        {
            bool status = false;
            try
            {
                string QueryCommand_Update = "update Production set ProduceStatus='R' where ProductionId=@productionID";
                db.AddParameters("@productionID", ProductionID.Trim());

                db.ExecuteNonQuery(QueryCommand_Update);
                status = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public bool approveProduction(LumexDBPlayer db, string productionId)
        {
            bool status = false;
            try
            {
                db.AddParameters("@ProductionId", productionId.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteDataTable("[APPROVE_PRODUCTTION_FOR_Warehouse]", true);
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }

        internal DataTable getProductDetails(LumexDBPlayer db, string productId, string whid)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@WarehouseId", whid.Trim());
                db.AddParameters("@ProductId", productId.Trim());
                string query_command = "select dbo.GetProductFreeQuantityByWarehouse(@WarehouseId,@ProductId) as FreeQuantity,dbo.GetProductLastUnitPrice(@ProductId) as lastUnitPrice";
                dt = db.ExecuteDataTable(query_command);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal bool saveNewProductInformation(newproductionBLL newProduction, LumexDBPlayer db, DataTable productTable)
        {
            bool st = false;
            DataTable dt = new DataTable();
            try
            {


                //Insert Into Raw
                db.AddParameters("@ProductionId", newProduction.productionId.Trim());
                db.AddParameters("@ProductId", newProduction.mainProductionID.Trim());
                db.AddParameters("@ProductQuantity", newProduction.usedWeightOfNewProduction.Trim());
                db.AddParameters("@ProductRate", newProduction.unitCost);
                db.AddParameters("@TotalCost", newProduction.totalCost);

                db.ExecuteNonQuery("INSERT_PRODUCTION_RAW", true);

                //Insert Produced Many Product


                for (int i = 0; i < productTable.Rows.Count; i++)
                {
                    db.ClearParameters();

                    db.AddParameters("@ProductionId", newProduction.productionId.Trim());
                    db.AddParameters("@WarehouseId", newProduction.wareHouseID);
                    db.AddParameters("@ProductId", productTable.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@ProduceWight", productTable.Rows[i]["NewQuantity"]);
                    db.AddParameters("@ProduceBundle", 0);
                    db.AddParameters("@ProduceDate", DateTime.Now);
                    db.AddParameters("@UnitCost", productTable.Rows[i]["NewUnitPrice"]);
                    db.AddParameters("@ProductionCost", 0);
                    db.AddParameters("@TotalQualnity", productTable.Rows[i]["NewQuantity"]);
                    db.AddParameters("@RawMaterialCost", 0);
                    db.AddParameters("@OtherAmount", 0);
                    db.AddParameters("@WorkingCost", 0);
                    db.AddParameters("@DecreaseWeight", 0);
                    db.AddParameters("@DecreaseRate", 0);
                    db.AddParameters("@DescripTions", "Multiple Product");
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                    db.AddParameters("@CreatedDate", DateTime.Now);
                    db.AddParameters("@ForStock", productTable.Rows[i]["NewQuantity"]);

                    dt = db.ExecuteDataTable("INSERT_PRODUCTION", true);
                }

                //approve New Product
                db.ClearParameters();

                db.AddParameters("@ProductionId", newProduction.productionId.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteDataTable("[APPROVE_PRODUCTTION_FOR_Warehouse]", true);

                st = true;
            }
            catch (Exception)
            {

                throw;
            }
            return st;
        }
    }
}
