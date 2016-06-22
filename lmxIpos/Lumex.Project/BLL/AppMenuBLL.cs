using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class AppMenuBLL
    {
        public string MenuGroupId { get; set; }
        public string MenuGroupName { get; set; }
        public string DisplayName { get; set; }
        public string MenuTarget { get; set; }
        public string ImageUrl { get; set; }
        public string MenuForApp { get; set; }
        public string MenuType { get; set; }
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string ToolTipDescription { get; set; }
        public string ParentMenuId { get; set; }
        public string URL { get; set; }
        public string MenuSorting { get; set; }
        public string IsActive { get; set; }
        public string IsGroupActive { get; set; }
        public string MenuLevel { get; set; }
        public string IsDefault { get; set; }
        public string IsDisplay { get; set; }
        public string UserMenuSorting { get; set; }
        public string UserId { get; set; }
        public string IsSubParent { get; set; }

        public DataTable SaveMenuGroup()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = appMenu.SaveMenuGroup(this, db);
                db.Stop();

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

        public DataTable SaveMenu()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = appMenu.SaveMenu(this, db);
                db.Stop();

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

        public bool CheckDuplicateMenuGroup(string menuGroupName)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = appMenu.CheckDuplicateMenuGroup(menuGroupName, db);
                db.Stop();
                return status;
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

        public bool CheckDuplicateMenu(string menuName)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = appMenu.CheckDuplicateMenu(menuName, db);
                db.Stop();
                return status;
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

        public DataTable GetMenuGroupList()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuGroupList(db);
                db.Stop();

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

        public DataTable GetMenuList()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuList(db);
                db.Stop();

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

        public void UpdateMenuGroupActivation(string menuGroupId, string activationStatus)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                appMenu.UpdateMenuGroupActivation(menuGroupId, activationStatus, db);
                db.Stop();
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

        public void UpdateMenuActivation(string menuId, string activationStatus)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                appMenu.UpdateMenuActivation(menuId, activationStatus, db);
                db.Stop();
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

        public DataTable GetMenuGroupById(string menuGroupId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuGroupById(menuGroupId, db);
                db.Stop();

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

        public DataTable GetMenuById(string menuId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuById(menuId, db);
                db.Stop();

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

        public void UpdateMenuGroup()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                appMenu.UpdateMenuGroup(this, db);
                db.Stop();
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

        public void UpdateMenu()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                appMenu.UpdateMenu(this, db);
                db.Stop();
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

        public DataTable GetMenuApps()
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuApps(db);
                db.Stop();

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

        public DataTable GetMenuTypesByApp(string menuForApp)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuTypesByApp(menuForApp, db);
                db.Stop();

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

        public DataTable GetMenuGroupsByMenuAppAndType(string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuGroupsByMenuAppAndType(menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetMenuLevelsByMenuAppTypeAndGroup(string menuForApp, string menuType, string menuGroupId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuLevelsByMenuAppTypeAndGroup(menuForApp, menuType, menuGroupId, db);
                db.Stop();

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

        public DataTable GetParentMenusByMenuAppTypeGroupAndLevel(string menuForApp, string menuType, string menuGroupId, string menuLevel)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetParentMenusByMenuAppTypeGroupAndLevel(menuForApp, menuType, menuGroupId, menuLevel, db);
                db.Stop();

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

        public DataTable GetOnlyParentMenusByMenuAppTypeGroupAndLevel(string menuForApp, string menuType, string menuGroupId, string menuLevel)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetOnlyParentMenusByMenuAppTypeGroupAndLevel(menuForApp, menuType, menuGroupId, menuLevel, db);
                db.Stop();

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

        public DataTable GetMenusByMenuAppTypeGroupAndLevel(string menuForApp, string menuType, string menuGroupId, string menuLevel)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenusByMenuAppTypeGroupAndLevel(menuForApp, menuType, menuGroupId, menuLevel, db);
                db.Stop();

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

        public DataTable GetTestMenuData(string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetTestMenuData(menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetAllMenusForMappingUserMenu(string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetAllMenusForMappingUserMenu(menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetPrivilegedMenuByUserGroup(string userGroupId, string menuForApp, string menuType, string menuGroupId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetPrivilegedMenuByUserGroup(userGroupId, menuForApp, menuType, menuGroupId, db);
                db.Stop();

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

        public void SaveUserGroupPrivilegeMenu(string userGroupId, string menuForApp, string menuType, string menuGroupId, List<string> userPrivilegeMenus)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                appMenu.SaveUserGroupPrivilegeMenu(userGroupId, menuForApp, menuType, menuGroupId, userPrivilegeMenus, db);
                db.Stop();
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

        public DataTable GetUserGroupMenuData(string userGroupId, string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetUserGroupMenuData(userGroupId, menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetUserMenuData(string userId, string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetUserMenuData(userId, menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetAllMenuData(string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetAllMenuData(menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetMenuListToPrivilegeUser(string userId, string menuForApp, string menuType, string menuGroupId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetMenuListToPrivilegeUser(userId, menuForApp, menuType, menuGroupId, db);
                db.Stop();

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

        public DataTable GetPrivilegedMenuByUser(string userId, string menuForApp, string menuType, string menuGroupId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetPrivilegedMenuByUser(userId, menuForApp, menuType, menuGroupId, db);
                db.Stop();

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

        public void SaveUserPrivilegeMenu(string userId, string menuForApp, string menuType, string menuGroupId, List<string> userPrivilegeMenus)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                appMenu.SaveUserPrivilegeMenu(userId, menuForApp, menuType, menuGroupId, userPrivilegeMenus, db);
                db.Stop();
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

        public string DeleteMenuGroupById(string menuGroupId, string forceToDelete)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                string status = appMenu.DeleteMenuGroupById(menuGroupId, forceToDelete, db);
                db.Stop();

                return status;
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

        public string DeleteMenuById(string menuId, string forceToDelete)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                string status = appMenu.DeleteMenuById(menuId, forceToDelete, db);
                db.Stop();

                return status;
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

        public DataTable LoadParentMenusByMenuAppAndType(string menuForApp, string menuType)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.LoadParentMenusByMenuAppAndType(menuForApp, menuType, db);
                db.Stop();

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

        public DataTable GetChildMenusByParentMenuId(string parentMenuId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = appMenu.GetChildMenusByParentMenuId(parentMenuId, db);
                db.Stop();

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

        public void UpdateMenuSorting(ListBox groupWiseUserMenuListListBox, string parentMenuId)
        {
            AppMenuDAL appMenu = new AppMenuDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                appMenu.UpdateMenuSorting(groupWiseUserMenuListListBox, parentMenuId, db);
                db.Stop();
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
    }
}
