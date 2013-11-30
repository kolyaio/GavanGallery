using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Gavan.Account
{
    public partial class login : System.Web.UI.Page
    {
        Utilities util = new Utilities();

        protected void loginCon(string email, string password)
        {
            String hashPass = util.hashSalt(password);
            if (util.loginMe(email, hashPass)){
                    Session["eid"] = email;
                    Session["dir"] = util.getDir(email);
                    if(util.isAdmin(Convert.ToString(Session["eid"]))) 
                    {
                        Session["lvl"] = 3;
                    }   
                    Session["lgin"] = true;
                    if (Session["curPath"] != null)
                        Response.Redirect(Session["curPath"].ToString());
                    else
                    {
                        Response.Redirect("../default.aspx");
                    }
            }
            else
            {
                Gavan.Global.error = "פרטי ההתחברות שגוים";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string email = Request.Form["email"].ToString();
                string password = Request.Form["password"].ToString();
                loginCon(email, password);
            }
        }
    }
}