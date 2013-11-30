using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gavan
{
    public partial class welcome : System.Web.UI.Page
    {
        public string name;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["name"] = "Nikolai";
            this.name = Session["name"].ToString();
            /*if (Session["nuser"] == null)
                Response.Redirect("/"); */
        }
    }
}