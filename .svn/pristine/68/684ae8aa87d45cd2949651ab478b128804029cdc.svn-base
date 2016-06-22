using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class UserDAL
    {
        public DataTable SaveUser(UserBLL user, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", user.UserId.Trim());
                db.AddParameters("@SalesCenterId", user.SalesCenterId.Trim());
                db.AddParameters("@WareHouseId", user.warehouseId.Trim());
                db.AddParameters("@UserName", user.UserName.Trim());
                db.AddParameters("@EmployeeId", user.EmployeeId.Trim());
                db.AddParameters("@UserGroupId", user.UserGroupId.Trim());
                db.AddParameters("@Department", user.Department.Trim());
                db.AddParameters("@Designation", user.Designation.Trim());
                db.AddParameters("@Address", user.Address.Trim());
                db.AddParameters("@ContactNumber", user.ContactNumber.Trim());
                db.AddParameters("@Email", user.Email.Trim());
                db.AddParameters("@NationalId", user.NationalId.Trim());
                db.AddParameters("@PassportNumber", user.PassportNumber.Trim());
                db.AddParameters("@Password", ProtectPassword(user.Password.Trim()));
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_USER", true);

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

        public DataTable GetUserList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_USERS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedUserListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_USERS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveUserList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_USER_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUserById(string userId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                DataTable dt = db.ExecuteDataTable("GET_USER_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateUser(string userId, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@UserId", userId);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_USER", true);

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

        public DataTable GetTransactionBranchesByUser(string userId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                DataTable dt = db.ExecuteDataTable("GET_TRANSACTION_BRANCH_LIST_BY_USER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUserActivation(string userId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_USER_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUserPassword(string userId, string password, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@Password", ProtectPassword(password));
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_USER_PASSWORD_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUser(string userId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_USER_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUser(UserBLL user, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", user.UserId.Trim());
                db.AddParameters("@SalesCenterId", user.SalesCenterId.Trim());
                db.AddParameters("@WareHouseId", user.warehouseId.Trim());
                db.AddParameters("@UserName", user.UserName.Trim());
                db.AddParameters("@EmployeeId", user.EmployeeId.Trim());
                db.AddParameters("@UserGroupId", user.UserGroupId.Trim());
                db.AddParameters("@Department", user.Department.Trim());
                db.AddParameters("@Designation", user.Designation.Trim());
                db.AddParameters("@Address", user.Address.Trim());
                db.AddParameters("@ContactNumber", user.ContactNumber.Trim());
                db.AddParameters("@Email", user.Email.Trim());
                db.AddParameters("@NationalId", user.NationalId.Trim());
                db.AddParameters("@PassportNumber", user.PassportNumber.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_USER_BY_ID", true);
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

        protected static string ProtectPassword(string password)
        {
            return LumexLibraryManager.EncodeIntoMd5Hash("LTSsL[" + password.Trim() + "]0");
        }

        public static bool ValidateUser(UserBLL user, LumexDBPlayer db)
        {
            bool isValid = false;

            try
            {
                db.AddParameters("@UserId", user.UserId);
                DataTable dt = db.ExecuteDataTable("GET_USER_PASSWORD_BY_ID", true);

                DataTableReader dtr = dt.CreateDataReader();

                if (dtr.Read())
                {
                    if (ProtectPassword(user.Password) == dtr["Password"].ToString())
                    {
                        isValid = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }

            return isValid;
        }
    }
}
