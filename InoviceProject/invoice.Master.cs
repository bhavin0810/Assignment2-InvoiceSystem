using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference Owin
using Microsoft.Owin.Security;

namespace InoviceProject.Models
{
    public partial class invoice : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            //determine which nav to show
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("admin"))
                {
                    plhPublic.Visible = false;
                    plhPrivateAdmin.Visible = true;
                    plhPrivateAll.Visible = true;
                }
                else
                {
                    plhPublic.Visible = false;
                    plhPrivateAdmin.Visible = false;
                    plhPrivateAll.Visible = true;
                }
            }
            else
            {
                plhPublic.Visible = true;
                plhPrivateAdmin.Visible = false;
                plhPrivateAll.Visible = false;
            }
            
        }
    }
}