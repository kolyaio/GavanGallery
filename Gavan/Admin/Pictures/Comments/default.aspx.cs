using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Admin.Pictures.Comments
{
    public partial class _default : System.Web.UI.Page
    {
        protected void sendComment(int pictureID,int userID, string message)
        {
            try
            {
                db dbc = new db();
                string query = "INSERT INTO comments(userID ,pictureID, message) VALUES(@UserID, @PictureID, @Message)";
                dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
                dbc.cmd.Parameters.Add(new SqlParameter("Message", message));
                dbc.cmd.CommandText = query;
                dbc.cmd.ExecuteNonQuery();
            }
            catch
            {
                Response.Write("יש פה בעיה..");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["act"] == "send" && !String.IsNullOrEmpty(Session["picID"].ToString()) && !String.IsNullOrEmpty(Session["usrID"].ToString()))
            {
                int pictureID, userID;
                string message;
                message = Request.Form["message"];
                pictureID = Convert.ToInt32(Session["picID"]);
                userID = Convert.ToInt32(Session["usrID"]);
                Session["picID"] = null;
                Session["usrID"] = null;
                sendComment(pictureID, userID, message);
                Response.Redirect("../default.aspx?id=" + pictureID);
            }
            else
            {
                Response.Redirect("../../default.aspx");
            }
        }
    }
}