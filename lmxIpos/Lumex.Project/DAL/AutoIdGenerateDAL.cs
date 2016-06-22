using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Lumex.Tech;
using Lumex.Project.BLL;
namespace Lumex.Project.DAL
{
    public class AutoIdGenerateDAL
    {
        public DataTable CreateId(LumexDBPlayer db, string flag)
        {
            try
            {
                db.AddParameters("@HeadName",flag);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                DataTable dt = db.ExecuteDataTable("[GET_AUTO_GENERATE_NUMBER_FROM_IDCREATE]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal void updateId(LumexDBPlayer db, string flag)
        {
            try
            {
                db.AddParameters("@Flag",flag);

                db.ExecuteDataTable("[UPDATE_AUTO_SERIAL_BY_FLAG]", true);

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void deleteId(LumexDBPlayer db, string id)
        {
            try
            {
                db.AddParameters("@Id", id);

                db.ExecuteDataTable("[DELETE_AUTO_GENERATE_NUMBER_FROM_IDCREATE]", true);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}