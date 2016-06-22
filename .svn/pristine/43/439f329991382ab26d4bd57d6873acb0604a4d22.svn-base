using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lumex.Project.DAL;
using System.Data;
using Lumex.Tech;
namespace Lumex.Project.BLL
{
    public class AutoIdGenerateBLL
    {
        public DataTable CreateId(string flag)
        {
            try
            {
               
                AutoIdGenerateDAL autoId = new AutoIdGenerateDAL();
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = autoId.CreateId(db, flag);
                db.Stop();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
       public void updateId(string flag)
        {
            try
            {
                AutoIdGenerateDAL autoId = new AutoIdGenerateDAL();
                LumexDBPlayer db = LumexDBPlayer.Start();
                autoId.updateId(db, flag);
                db.Stop();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
       public void deleteId(string id)
       {
           try
           {
               AutoIdGenerateDAL autoId = new AutoIdGenerateDAL();
               LumexDBPlayer db = LumexDBPlayer.Start();
               autoId.deleteId(db, id);
               db.Stop();

           }
           catch (Exception)
           {

               throw;
           }
       }
    }

}