using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Gavan
{
    public partial class login : System.Web.UI.Page
    {
        Utilities util = new Utilities();

        protected void loginCon(string email, string password)
        {
            String hashPass = util.hashSalt(password);
            if (util.loginMe(email, hashPass))
            {
                Session["eid"] = email;
                Session["lgin"] = true;
                Response.Write(Session["name"]);
                if (Session["curPath"] != null)
                    Response.Redirect(Session["curPath"].ToString());
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx?error=failed");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["error"] == "failed")
            {
                Response.Write("The login is failed.");
            }
            if (IsPostBack)
            {
                string email = Request.Form["email"].ToString();
                string password = Request.Form["password"].ToString();
                loginCon(email, password);
            }
        }
    }
}