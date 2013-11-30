using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Pictures
{
    public partial class ranking : System.Web.UI.Page
    {
        protected void insertRank(int rank, int userID, int pictureID)
        {
            db dbc = new db();
            dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
            dbc.cmd.Parameters.Add(new SqlParameter("Rank", rank));
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            string query = "INSERT INTO rank(userID,rank,pictureID) VALUES(@UserID, @Rank, @PictureID)";
            try
            {
                dbc.cmd.CommandText = query;
                dbc.cmd.ExecuteNonQuery();
            }
            catch
            {
                 Gavan.Global.error = "משהו השתבש...";
            }
        }
        protected void updateRankPics(int rank, int userID, int pictureID)
        {
            db dbc = new db();
            dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
            dbc.cmd.Parameters.Add(new SqlParameter("Rank", rank));
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            try
            {
                string query = "UPDATE pictures SET rank = rank+1 WHERE id = @PictureID";
                dbc.cmd.CommandText = query;
                dbc.cmd.ExecuteNonQuery();
            }
            catch
            {
                 Gavan.Global.error = "משהו פה לא בסדר.";
            }
        }
        protected void Rank(int rank, int userID, int pictureID)
        {
            this.updateRankPics(rank, userID, pictureID);
            this.insertRank(rank, userID, pictureID);
        }
        Utilities util = new Utilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Session["picID"].ToString()) && !String.IsNullOrEmpty(Session["usrID"].ToString()))
            {
                int rank, pictureID, userID;
                rank = Convert.ToInt32(Request.Form["ranking"]);
                pictureID = Convert.ToInt32(Session["picID"]);
                userID = Convert.ToInt32(Session["usrID"]);
                Session["picID"] = null;
                Session["usrID"] = null;
                Rank(rank, userID, pictureID);
                Response.Redirect("/Pictures/?id=" + pictureID);
            }
        }
    }
}