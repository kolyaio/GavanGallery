using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Gavan.Admin.users
{
    public partial class delete : System.Web.UI.Page
    {
        protected void deleteUserCommentsFromDB(int id)
        {
            db dbc = new db();
            string query = "DELETE FROM comments WHERE userID = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void deleteUserPicturesFromDB(int id)
        {
            db dbc = new db();
            string query = "DELETE FROM pictures WHERE userID = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void deleteUserFromDB(int id)
        {
            db dbc = new db();
            string query = "DELETE FROM users WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected void deleteUserFolderAndFiles(int id)
        {
            Utilities util = new Utilities();
            string email = util.getEmail(id);
            string hashName = util.hashPass(email + util.hashdir);
            string parent = "../../Uploads\\";
            string subPath = parent + hashName + "\\";
            if (Directory.Exists(Server.MapPath(subPath)))
            {
                Directory.Delete(Server.MapPath(subPath),true);
            }
            else
            {
                Gavan.Admin.Admin.error  = "היתה בעיה למחוק את התקייה.";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                deleteUserFolderAndFiles(id);
                deleteUserFromDB(id);
                deleteUserPicturesFromDB(id);
                Gavan.Admin.Admin.ok  = "המשתמש נמחק בהצלחה!";
            }
            else
            {
               Gavan.Admin.Admin.error = "לא הצלחתי למחוק את המשתמש!";
            }
        }
    }
}