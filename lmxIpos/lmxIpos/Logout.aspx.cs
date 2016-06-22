using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;


namespace lmxIpos.UI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Log Out";
            LumexSessionManager.RemoveAll();
            Response.Redirect("/Login.aspx", true);

        }
    }
}