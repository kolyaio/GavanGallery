using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Gavan.Admin.pages
{
    public partial class add_send : System.Web.UI.Page
    {
        protected void SendInfo(string name, string content, string url)
        {
            db dbc = new db();
            string query = "INSERT INTO pages(title, content,url) VALUES(@Name, @Content, @URL)";
            dbc.cmd.Parameters.Add(new SqlParameter("Name", name));
            dbc.cmd.Parameters.Add(new SqlParameter("Content",content));
            dbc.cmd.Parameters.Add(new SqlParameter("URL",url));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.Form["name"]) || !String.IsNullOrEmpty(Request.Form["content_area"]))
            {
                string name = Request.Form["name"];
                string content = Request.Form["content_area"];
                string url = Request.Form["url"];
                SendInfo(name, content, url);
                Response.Redirect("/Admin/pages/");
            }
            else
            {
                Response.Redirect("/Admin/pages/");
            }
        }
    }
}