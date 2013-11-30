using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Pictures.Comments
{
    public partial class delete : System.Web.UI.Page
    {
        protected bool existComment(int commentID)
        {
            int counter = 0;
            db dbc = new db();
            string query = "SELECT * FROM comments WHERE id = @CommentID";
            dbc.cmd.Parameters.Add(new SqlParameter("CommentID", commentID));
            dbc.cmd.CommandText = query;
            SqlDataReader reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                counter++;
            }
            if (counter == 1)
                return true;
            return false;
        }
        protected void deleteComment(int commentID)
        {
            try
            {

                db dbc = new db();
                string query = "DELETE FROM comments WHERE id = @CommentID";
                dbc.cmd.Parameters.Add(new SqlParameter("CommentID", commentID));
                dbc.cmd.CommandText = query;
                dbc.cmd.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("ישנה בעיה..");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities util = new Utilities();
            string eid = Convert.ToString(Session["eid"]);
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (existComment(id) && util.checkUsersComment(id, eid))
                {
                    deleteComment(id);
                    Response.Redirect("/Pictures/?id=" + Session["PictureID"]);
                }
                else
                {
                    Response.Write("התגובה אינה נמצאה.");
                }
            }
            else
            {
                Response.Redirect("../default.aspx");
            }
        }
    }
}