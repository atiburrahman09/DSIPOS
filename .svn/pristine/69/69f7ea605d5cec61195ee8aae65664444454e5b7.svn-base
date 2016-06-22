using System;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class UserBLL
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string PassportNumber { get; set; }
        public string Password { get; set; }
        public string UserGroupId { get; set; }
        public string SalesCenterId { get; set; }

        public DataTable SaveUser()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = user.SaveUser(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetUserList()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetDeletedUserListByDateRangeAll(string fromDate, string toDate, string search)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetDeletedUserListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetActiveUserList()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetActiveUserList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetUserById(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserById(userId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public bool CheckDuplicateSalesCenter(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = user.CheckDuplicateUser(userId, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetTransactionBranchesByUser(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetTransactionBranchesByUser(userId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public void UpdateUserActivation(string userId, string activationStatus)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.UpdateUserActivation(userId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public void UpdateUserPassword(string userId, string password)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.UpdateUserPassword(userId, password, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public void DeleteUser(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.DeleteUser(userId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public void UpdateUser()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.UpdateUser(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public bool ValidateUser()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                Boolean isValid = UserDAL.ValidateUser(this, db);
                db.Stop();

                return isValid;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public string warehouseId { get; set; }
    }
}
