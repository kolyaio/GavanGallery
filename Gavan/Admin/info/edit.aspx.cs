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
    public partial class edit : System.Web.UI.Page
    {
        internal protected string[] getDetails(int id)
        {
            db dbc = new db();
            dbc.cmd.CommandText = "SELECT name,content FROM Info WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            SqlDataAdapter adapter = new SqlDataAdapter(dbc.cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            string[] info = new string[2];
            DataTable dataTable = ds.Tables["info"];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                info[0] = Convert.ToString(dr["name"]);
                info[1] = Convert.ToString(dr["content"]);
            }
            return info;
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