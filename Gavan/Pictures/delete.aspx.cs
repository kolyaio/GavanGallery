using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace Gavan.Pictures
{
    public partial class delete : System.Web.UI.Page
    {
        protected bool existRank(int pictureID) 
        {
            int counter = 0;
            db dbc = new db();
            string query = "SELECT * FROM rank WHERE pictureID = @PictureID";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            dbc.cmd.CommandText = query;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                counter++;
            }
            if (counter >= 1)
                return true;
            return false;
        }
        protected bool existComment(int pictureID)
        {
            int counter = 0;
            db dbc = new db();
            string query = "SELECT * FROM comments WHERE pictureID = @PictureID";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            dbc.cmd.CommandText = query;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                counter++;
            }
            if (counter >= 1)
                return true;
            return false;
        }
        protected void deleteFromPics(int pictureID)
        {
            db dbc = new db();
            try
            {
                string query = "DELETE FROM pictures WHERE id = @PictureID";
                dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                dbc.cmd.CommandText = query;
                dbc.cmd.ExecuteNonQuery();
            }
            catch
            {
                 Gavan.Global.error = "ישנה בעיה.";
            }
        }
        protected void delteFromRanks(int pictureID)
        {
            db dbc = new db();
            try
            {
                if (existRank(pictureID))
                {
                    string query = "DELETE FROM ranks WHERE pictureID = @PictureID";
                    dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                    dbc.cmd.CommandText = query;
                    dbc.cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                 Gavan.Global.error = "ישנה בעיה. ";
            }
        }
        protected void deleteFromComments(int pictureID)
        {
            db dbc = new db();
            try
            {
                if (existComment(pictureID))
                {
                    string query = "DELETE FROM comments WHERE pictureID = @PictureID";
                    dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                    dbc.cmd.CommandText = query;
                    dbc.cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Gavan.Global.error = "ישנה בעיה.";
            }

        }
        protected void DeletePicture(int pictureID)
        {
            Utilities util = new Utilities();
            string path = util.getFileName(pictureID);
            File.Delete(Server.MapPath(path));
            deleteFromPics(pictureID);
            delteFromRanks(pictureID);
            deleteFromComments(pictureID);
        }
        internal protected SqlDataReader reader = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities util = new Utilities();
            int pictureID = Convert.ToInt32(Request.QueryString["id"]);
            string eid = Convert.ToString(Session["eid"]);
            if (util.picExist(pictureID))
            {
                if (util.checkUsersPic(pictureID, eid) || (int)Session["lvl"] == 3)
                {

                    DeletePicture(pictureID);
                    Response.Redirect("../default.aspx");
                }
                else
                {
                     Gavan.Global.error = "אינך מורשה למחוק קובץ זה.";
                }
            }
            else if (!util.picExist(pictureID))
            {
                Gavan.Global.error = "התמונה אינה נמצאה";
            }
        }
    }
}