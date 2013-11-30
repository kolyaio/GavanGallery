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
    public partial class pictures : System.Web.UI.Page
    {
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
            int views = getView(id)+1;
            string query = "UPDATE pictures SET views = @Views WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.Parameters.Add(new SqlParameter("Views", views));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
            reader.Close();
            dbc.dbCon.Close();
        }
        internal protected string getAuthor(int id) {
            SqlDataReader reader = null;
            db dbc = new db();
            string author = "";
            string query = "SELECT name FROM users WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                author = reader["name"].ToString();
                reader.Close();
                dbc.dbCon.Close();
                return author;
            }
            reader.Close();
            dbc.dbCon.Close();
            return author;
        }
        internal protected SqlDataReader reader = null;
        db dbc = new db();
        string query = "SELECT * FROM pictures WHERE id = @id";
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities util = new Utilities();
            if (Request.QueryString["id"] != null)
            {
                if (IsPostBack)
                {
                    int rank = Convert.ToInt32(Request.Form["rank"]);
                    int pictureID = Convert.ToInt32(Request.QueryString["id"]);
                    int userID = util.getID(Session["eid"].ToString());
                    string insquery = "INSERT INTO rank(userID,rank,pictureID) VALUES(@userId, @Rank, @PictureID)";
                    dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
                    dbc.cmd.Parameters.Add(new SqlParameter("Rank", rank));
                    dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                    dbc.cmd.CommandText = insquery;
                    dbc.cmd.ExecuteNonQuery();
                }
                int id = Convert.ToInt32(Request.QueryString["id"]);
                dbc.cmd.Parameters.Add(new SqlParameter("id", id));
                dbc.cmd.CommandText = query;
                reader = dbc.cmd.ExecuteReader();
                if(reader.Read())
                {
                    picture.ImageUrl = reader["path"].ToString();
                    picture.AlternateText = reader["name"].ToString();
                    header.Text = reader["name"].ToString();
                    int userID = Convert.ToInt32(reader["userID"]);
                    author.Text = this.getAuthor(userID);
                    description.Text = reader["description"].ToString();
                    if (Session["eid"] != null && (bool)Session["lgin"] == true)
                    {
                        upView(id);
                    }
                    views.Text = this.getView(id).ToString();
                }
                reader.Close();
                dbc.dbCon.Close();
            }
        }
    }
}