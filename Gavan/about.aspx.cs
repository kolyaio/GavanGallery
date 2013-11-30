using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan
{
    public partial class about : System.Web.UI.Page
    {
        internal protected string[] getDetails(int id)
        {
            db dbc = new db();
            string query = "SELECT * FROM pages WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(dbc.cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            string[] terms = new string[2];
            DataTable dataTable = ds.Tables["terms"];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                terms[0] = Convert.ToString(dr["title"]);
                terms[1] = Convert.ToString(dr["content"]);
            }
            return terms;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}