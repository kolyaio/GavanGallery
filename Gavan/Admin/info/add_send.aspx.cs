using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Gavan.Admin.info
{
    public partial class add_send : System.Web.UI.Page
    {
        protected void SendInfo(string name, string content)
        {
            db dbc = new db();
            string query = "INSERT INTO Info(name, content) VALUES(@Name, @Content)";
            dbc.cmd.Parameters.Add(new SqlParameter("Name", name));
            dbc.cmd.Parameters.Add(new SqlParameter("Content",content));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.Form["name"]) || !String.IsNullOrEmpty(Request.Form["content_area"]))
            {
                string name = Request.Form["name"];
                string content = Request.Form["content_area"];
                SendInfo(name, content);
                Response.Redirect("/Admin/info/");
            }
            else
            {
                Response.Redirect("/Admin/info/");
            }
        }
    }
}