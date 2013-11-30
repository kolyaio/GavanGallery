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
    public partial class edit_act : System.Web.UI.Page
    {
        protected void UpdateInfo(string name, string content,int id, string url)
        {
            db dbc = new db();
            string query = "UPDATE pages SET title=@Name, content=@Content,url = @URL WHERE id=@Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Name", name));
            dbc.cmd.Parameters.Add(new SqlParameter("URL",url));
            dbc.cmd.Parameters.Add(new SqlParameter("Content", content));
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(Request.Form["name"]) || !String.IsNullOrEmpty(Request.Form["content_area"])
                || !String.IsNullOrEmpty(Request.Form["id"]))
            {
                string name = Request.Form["name"];
                string content = Request.Form["content_area"];
                int id = Convert.ToInt32(Request.Form["id"]);
                string url = Request.Form["url"];
                UpdateInfo(name, content, id, url);
                Response.Redirect("/Admin/pages/");
            }
            else
            {
                Response.Redirect("/Admin/pages/");
            }
        }
    }
}