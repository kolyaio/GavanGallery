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
    public partial class test1 : System.Web.UI.Page
    {
        internal protected SqlDataReader reader = null;
        internal protected int getView(int id)
        {
            db dbc = new db();
            int views = 0;
            string query = "SELECT views FROM pictures WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                views = Convert.ToInt32(reader["views"]);
            }
            reader.Close();
            dbc.dbCon.Close();
            return views;
        }
        internal protected void upView(int id)
        {
            db dbc = new db();
            int views = getView(id) + 1;
            string query = "UPDATE pictures SET views = @Views WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.Parameters.Add(new SqlParameter("Views", views));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
            reader.Close();
            dbc.dbCon.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 3;
            upView(id);
            views.Text = getView(id).ToString();
        }
    }
}