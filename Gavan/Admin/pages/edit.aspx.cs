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
    public partial class edit : System.Web.UI.Page
    {
        internal protected string[] getDetails(int id)
        {
            db dbc = new db();
            dbc.cmd.CommandText = "SELECT title,content,url FROM pages WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            SqlDataAdapter adapter = new SqlDataAdapter(dbc.cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            string[] pgData = new string[3];
            DataTable dataTable = ds.Tables["pgData"];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                pgData[0] = Convert.ToString(dr["title"]);
                pgData[1] = Convert.ToString(dr["content"]);
                pgData[2] = Convert.ToString(dr["url"]);
            }
            return pgData;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Convert.ToString(Request.QueryString["id"])))
            {
               Response.Redirect("/Admin/info/");
            }
        }
    }
}