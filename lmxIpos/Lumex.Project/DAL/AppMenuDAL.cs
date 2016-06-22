using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class AppMenuDAL
    {
        public DataTable SaveMenuGroup(AppMenuBLL appMenu, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuGroupName", appMenu.MenuGroupName.Trim());
                db.AddParameters("@DisplayName", appMenu.DisplayName.Trim());
                db.AddParameters("@MenuTarget", appMenu.MenuTarget.Trim());
                db.AddParameters("@ImageUrl", appMenu.ImageUrl.Trim());
                db.AddParameters("@ToolTipDescription", appMenu.ToolTipDescription.Trim());
                db.AddParameters("@URL", appMenu.URL.Trim());
                db.AddParameters("@MenuType", appMenu.MenuType.Trim());
                db.AddParameters("@MenuForApp", appMenu.MenuForApp.Trim());

                DataTable dt = db.ExecuteDataTable("INSERT_MENU_GROUP", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                appMenu = null;
            }
        }

        public DataTable SaveMenu(AppMenuBLL appMenu, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuName", appMenu.MenuName.Trim());
                db.AddParameters("@DisplayName", appMenu.DisplayName.Trim());
                db.AddParameters("@MenuTarget", appMenu.MenuTarget.Trim());
                db.AddParameters("@ImageUrl", appMenu.ImageUrl.Trim());
                db.AddParameters("@ToolTipDescription", appMenu.ToolTipDescription.Trim());
                db.AddParameters("@ParentMenuId", appMenu.ParentMenuId.Trim());
                db.AddParameters("@URL", appMenu.URL.Trim());
                db.AddParameters("@MenuGroupId", appMenu.MenuGroupId.Trim());
                db.AddParameters("@MenuType", appMenu.MenuType.Trim());
                db.AddParameters("@MenuForApp", appMenu.MenuForApp.Trim());
                db.AddParameters("@MenuLevel", appMenu.MenuLevel.Trim());
                db.AddParameters("@IsDefault", appMenu.IsDefault.Trim());
                db.AddParameters("@IsDisplay", appMenu.IsDisplay.Trim());
                db.AddParameters("@IsSubParent", appMenu.IsSubParent.Trim());

                DataTable dt = db.ExecuteDataTable("INSERT_MENU", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                appMenu = null;
            }
        }

        public bool CheckDuplicateMenuGroup(string menuGroupName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@MenuGroupName", menuGroupName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_MENU_GROUP", true);

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

        public bool CheckDuplicateMenu(string menuName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@MenuName", menuName);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_MENU", true);

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

        public DataTable GetMenuGroupList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_MENU_GROUPS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_MENUS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMenuGroupActivation(string menuGroupId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuGroupId", menuGroupId);
                db.AddParameters("@IsActive", activationStatus);

                db.ExecuteNonQuery("UPDATE_MENU_GROUP_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMenuActivation(string menuId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuId", menuId);
                db.AddParameters("@IsActive", activationStatus);

                db.ExecuteNonQuery("UPDATE_MENU_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuGroupById(string menuGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuGroupId", menuGroupId);
                DataTable dt = db.ExecuteDataTable("GET_MENU_GROUP_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuById(string menuId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuId", menuId);
                DataTable dt = db.ExecuteDataTable("GET_MENU_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMenuGroup(AppMenuBLL appMenu, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuGroupId", appMenu.MenuGroupId.Trim());
                db.AddParameters("@MenuGroupName", appMenu.MenuGroupName.Trim());
                db.AddParameters("@DisplayName", appMenu.DisplayName.Trim());
                db.AddParameters("@MenuTarget", appMenu.MenuTarget.Trim());
                db.AddParameters("@ImageUrl", appMenu.ImageUrl.Trim());
                db.AddParameters("@ToolTipDescription", appMenu.ToolTipDescription.Trim());
                db.AddParameters("@URL", appMenu.URL.Trim());
                db.AddParameters("@MenuType", appMenu.MenuType.Trim());
                db.AddParameters("@MenuForApp", appMenu.MenuForApp.Trim());

                db.ExecuteNonQuery("UPDATE_MENU_GROUP_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                appMenu = null;
            }
        }

        public void UpdateMenu(AppMenuBLL appMenu, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuId", appMenu.MenuId.Trim());
                db.AddParameters("@MenuName", appMenu.MenuName.Trim());
                db.AddParameters("@DisplayName", appMenu.DisplayName.Trim());
                db.AddParameters("@MenuTarget", appMenu.MenuTarget.Trim());
                db.AddParameters("@ImageUrl", appMenu.ImageUrl.Trim());
                db.AddParameters("@ToolTipDescription", appMenu.ToolTipDescription.Trim());
                db.AddParameters("@ParentMenuId", appMenu.ParentMenuId.Trim());
                db.AddParameters("@URL", appMenu.URL.Trim());
                db.AddParameters("@MenuGroupId", appMenu.MenuGroupId.Trim());
                db.AddParameters("@MenuType", appMenu.MenuType.Trim());
                db.AddParameters("@MenuForApp", appMenu.MenuForApp.Trim());
                db.AddParameters("@MenuLevel", appMenu.MenuLevel.Trim());
                db.AddParameters("@IsDefault", appMenu.IsDefault.Trim());
                db.AddParameters("@IsDisplay", appMenu.IsDisplay.Trim());
                db.AddParameters("@IsSubParent", appMenu.IsSubParent.Trim());

                DataTable dtMGL = db.ExecuteDataTable("UPDATE_MENU_BY_ID", true);

                if (dtMGL.Rows.Count > 0 && dtMGL.Rows[0][0].ToString() != "Done")
                {
                    DataTable dt = new DataTable();
                    DataRow dr = null;

                    for (int i = 0; i < dtMGL.Rows.Count; i++)
                    {
                        dt = null;

                        db.ClearParameters();
                        db.AddParameters("@MenuId", dtMGL.Rows[i]["MenuId"].ToString());
                        dt = db.ExecuteDataTable("GET_CHILD_MENUS_BY_MENU_ID", true);

                        if (dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                dr = dtMGL.NewRow();
                                dr["MenuId"] = dt.Rows[j]["MenuId"].ToString();
                                dr["MenuLevel"] = (int.Parse(dtMGL.Rows[i]["MenuLevel"].ToString()) + 1).ToString();
                                dr["MenuGroupId"] = dtMGL.Rows[i]["MenuGroupId"].ToString();
                                dtMGL.Rows.Add(dr);
                            }
                        }
                    }

                    for (int i = 0; i < dtMGL.Rows.Count; i++)
                    {
                        db.ClearParameters();
                        db.AddParameters("@MenuId", dtMGL.Rows[i]["MenuId"].ToString());
                        db.AddParameters("@MenuLevel", dtMGL.Rows[i]["MenuLevel"].ToString());
                        db.AddParameters("@MenuGroupId", dtMGL.Rows[i]["MenuGroupId"].ToString());

                        dt = db.ExecuteDataTable("UPDATE_CHILD_MENUS_GROUP_AND_LEVEL_BY_MENU_ID", true);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                appMenu = null;
            }
        }

        public DataTable GetMenuApps(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_MENU_APPS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuTypesByApp(string menuForApp, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                DataTable dt = db.ExecuteDataTable("GET_MENU_TYPES_BY_APP", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuGroupsByMenuAppAndType(string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);

                DataTable dt = db.ExecuteDataTable("GET_MENU_GROUPS_BY_MENU_APP_AND_TYPE", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuLevelsByMenuAppTypeAndGroup(string menuForApp, string menuType, string menuGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);

                DataTable dt = db.ExecuteDataTable("GET_MENU_LAVELS_BY_MENU_APP_TYPE_AND_GROUP", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetParentMenusByMenuAppTypeGroupAndLevel(string menuForApp, string menuType, string menuGroupId, string menuLevel, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);
                db.AddParameters("@MenuLevel", menuLevel);

                DataTable dt = db.ExecuteDataTable("GET_PARENT_MENUS_BY_MENU_APP_TYPE_GROUP_AND_LEVEL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetOnlyParentMenusByMenuAppTypeGroupAndLevel(string menuForApp, string menuType, string menuGroupId, string menuLevel, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);
                db.AddParameters("@MenuLevel", menuLevel);

                DataTable dt = db.ExecuteDataTable("GET_ONLY_PARENT_MENUS_BY_MENU_APP_TYPE_GROUP_AND_LEVEL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenusByMenuAppTypeGroupAndLevel(string menuForApp, string menuType, string menuGroupId, string menuLevel, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);
                db.AddParameters("@MenuLevel", menuLevel);

                DataTable dt = db.ExecuteDataTable("GET_MENUS_BY_MENU_APP_TYPE_GROUP_AND_LEVEL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetTestMenuData(string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                DataTable dt = db.ExecuteDataTable("GET_TEST_ALL_MENUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAllMenusForMappingUserMenu(string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                DataTable dt = db.ExecuteDataTable("GET_ALL_MENUS_FOR_MAPPING_USER_MENU", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPrivilegedMenuByUserGroup(string userGroupId, string menuForApp, string menuType, string menuGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroupId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);

                DataTable dt = db.ExecuteDataTable("GET_PRIVILEGED_MENU_BY_USER_GROUP", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveUserGroupPrivilegeMenu(string userGroupId, string menuForApp, string menuType, string menuGroupId, List<string> userPrivilegeMenus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroupId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);

                db.ExecuteNonQuery("DELETE_USER_GROUP_PRIVILEGE_MENU", true);

                for (int i = 0; i < userPrivilegeMenus.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@UserGroupId", userGroupId);
                    db.AddParameters("@MenuId", userPrivilegeMenus[i].ToString());

                    db.ExecuteNonQuery("INSERT_USER_GROUP_PRIVILEGE_MENU", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUserGroupMenuData(string userGroupId, string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroupId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);

                DataTable dt = db.ExecuteDataTable("GET_USER_MENUS_BY_USER_GROUP", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUserMenuData(string userId, string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);

                DataTable dt = db.ExecuteDataTable("GET_USER_MENUS_BY_USER", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAllMenuData(string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                //db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                DataTable dt = db.ExecuteDataTable("GET_ALL_MENUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetMenuListToPrivilegeUser(string userId, string menuForApp, string menuType, string menuGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);

                DataTable dt = db.ExecuteDataTable("GET_MENU_LIST_TO_PRIVILEGE_USER", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPrivilegedMenuByUser(string userId, string menuForApp, string menuType, string menuGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);

                DataTable dt = db.ExecuteDataTable("GET_PRIVILEGED_MENU_BY_USER", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveUserPrivilegeMenu(string userId, string menuForApp, string menuType, string menuGroupId, List<string> userPrivilegeMenus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", userId);
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                db.AddParameters("@MenuGroupId", menuGroupId);

                db.ExecuteNonQuery("DELETE_USER_PRIVILEGE_MENU", true);

                for (int i = 0; i < userPrivilegeMenus.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@UserId", userId);
                    db.AddParameters("@MenuId", userPrivilegeMenus[i].ToString());

                    db.ExecuteNonQuery("INSERT_USER_PRIVILEGE_MENU", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteMenuGroupById(string menuGroupId, string forceToDelete, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuGroupId", menuGroupId);
                db.AddParameters("@ForceToDelete", forceToDelete);

                DataTable dt = db.ExecuteDataTable("DELETE_MENU_GROUP_BY_ID", true);

                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteMenuById(string menuId, string forceToDelete, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuId", menuId);
                db.AddParameters("@ForceToDelete", forceToDelete);

                DataTable dt = db.ExecuteDataTable("DELETE_MENU_BY_ID", true);

                return dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable LoadParentMenusByMenuAppAndType(string menuForApp, string menuType, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@MenuForApp", menuForApp);
                db.AddParameters("@MenuType", menuType);
                DataTable dt = db.ExecuteDataTable("GET_PARENT_MENUS_BY_MENU_APP_AND_TYPE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetChildMenusByParentMenuId(string parentMenuId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ParentMenuId", parentMenuId);
                DataTable dt = db.ExecuteDataTable("GET_CHILD_MENUS_BY_PARENT_MENU_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMenuSorting(ListBox groupWiseUserMenuListListBox, string parentMenuId, LumexDBPlayer db)
        {
            try
            {
                for (int i = 0; i < groupWiseUserMenuListListBox.Items.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@MenuId", groupWiseUserMenuListListBox.Items[i].Value.Trim());
                    db.AddParameters("@MenuSorting", parentMenuId + "0" + (i + 1).ToString());

                    db.ExecuteNonQuery("UPDATE_MENU_SORTING_BY_MENU_ID", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
