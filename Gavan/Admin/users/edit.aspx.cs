using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Admin.users
{
    public partial class edit : System.Web.UI.Page
    {
        internal protected string[] getDataFromDB(int id)
        {
            
            db dbc = new db();
            string query  = "SELECT * FROM users WHERE id = @ID";
            dbc.cmd.Parameters.Add(new SqlParameter("ID", id));
            dbc.cmd.CommandText = query;
            SqlDataReader reader = dbc.cmd.ExecuteReader();
            string[] Data = new string[4];
            while (reader.Read())
            {
                Data[0] = reader[1].ToString(); // Name
                Data[1] = reader[2].ToString(); // Email
                Data[2] = reader[4].ToString(); // Status
                Data[3] = reader[5].ToString(); // Grade
            }
            return Data;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Request.QueryString["id"])))
            {
                Response.Redirect("/Admin/users/");
            }
        }
    }
}