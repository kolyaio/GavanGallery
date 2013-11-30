using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gavan.Account
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Convert.ToString(Session["eid"])))
            {
                Response.Redirect("/Account/studio.aspx");
            }
            else
            {
                Response.Redirect("/Account/login.aspx");
            }
        }
    }
}