using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Gavan.Admin.Pictures
{
    public partial class edit : System.Web.UI.Page
    {
        internal protected string[] getDetails(int PictureID)
        {
            db dbc = new db();
            dbc.cmd.CommandText = "SELECT name,description FROM pictures WHERE id = @PictureID";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", PictureID));

            SqlDataAdapter adapter = new SqlDataAdapter(dbc.cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            string[] pic = new string[2]; 
            DataTable dataTable = ds.Tables["pictures"];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                pic[0] = Convert.ToString(dr["name"]);
                pic[1] = Convert.ToString(dr["description"]);
            }
            return pic;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Session["eid"])) ||
                String.IsNullOrEmpty(Convert.ToString(Request.QueryString["id"])))
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}