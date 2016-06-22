using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class UserGroupBLL
    {
        public string UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public string Description { get; set; }

        public DataTable SaveUserGroup()
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = userGroup.SaveUserGroup(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public DataTable GetUserGroupList()
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = userGroup.GetUserGroupList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public DataTable GetDeletedUserGroupListByDateRangeAll(string fromDate, string toDate, string search)
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = userGroup.GetDeletedUserGroupListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public DataTable GetActiveUserGroupList()
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = userGroup.GetActiveUserGroupList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public DataTable GetUserGroupById(string userGroupId)
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = userGroup.GetUserGroupById(userGroupId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public bool CheckDuplicateUserGroup(string userGroupName)
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = userGroup.CheckDuplicateUserGroup(userGroupName, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public void UpdateUserGroupActivation(string userGroupId, string activationStatus)
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                userGroup.UpdateUserGroupActivation(userGroupId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public string DeleteUserGroup(string userGroupId, string forceToDelete)
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                string status = userGroup.DeleteUserGroup(userGroupId, forceToDelete, db);
                db.Stop();

                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public void UpdateUserGroup()
        {
            UserGroupDAL userGroup = new UserGroupDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                userGroup.UpdateUserGroup(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }
    }
}
