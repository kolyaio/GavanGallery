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
    public partial class delete : System.Web.UI.Page
    {
        protected void DeleteInfo(int id)
        {
            db dbc = new db();
            string query = "DELETE FROM pages WHERE id=@Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                DeleteInfo(id);
                Response.Redirect("/Admin/pages/");
            }
            else
            {
               Response.Redirect("/Admin/pages/");
            }
        }
    }
}