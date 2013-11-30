using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Admin.Pictures
{
    public partial class _default : System.Web.UI.Page
    {
        internal protected string getName(int userID)
        {
            string name = "";
            db dbc = new db();
            string query = "SELECT name FROM users WHERE id = @UserID";
            dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
            dbc.cmd.CommandText = query;
            reader = dbc.cmd.ExecuteReader();
            if(reader.Read())
            {   
                name = reader["name"].ToString();
                reader.Close();
                dbc.dbCon.Close();
                return name;
            }
            return "";
        }
        internal protected void getComments(int pictureID)
        {
            db dbc = new db();
            string query = "SELECT * FROM comments WHERE pictureID = @PictureID ORDER BY id DESC ";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            dbc.cmd.CommandText = query;
            
            SqlDataAdapter da = new SqlDataAdapter(dbc.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PagedDataSource pgitems = new PagedDataSource();
            DataView dv = new DataView(dt);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 5;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPages.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < pgitems.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
                rptPages.Visible = false;
            rptContent.DataSource = pgitems;
            rptContent.DataBind();
        }
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }
        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            getComments(Convert.ToInt32(Request.QueryString["id"]));
        }

        protected int getRankVotes(int pictureID)
        {
            try
            {
                int votes = 0;
                db dbc = new db();
                string query = "SELECT rank FROM rank WHERE pictureID = @PictureID";
                dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                dbc.cmd.CommandText = query;
                reader = dbc.cmd.ExecuteReader();
                while (reader.Read())
                {
                    votes += Convert.ToInt32(reader["rank"]);
                }
                reader.Close();
                return votes;
            }
            catch
            {
                return 0;
            }
        }

        protected int getRankAmount(int pictureID)
        {
            try
            {
                int amount = 0;
                db dbc = new db();
                string query = "SELECT rank FROM pictures WHERE id = @PictureID";
                dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
                dbc.cmd.CommandText = query;
                reader = dbc.cmd.ExecuteReader();
                while (reader.Read())
                {
                    amount = Convert.ToInt32(reader["rank"]);
                }
                reader.Close();
                return amount;
            }
            catch
            {
                return 0;
            }
        }

        internal protected double totalRank(int pictureID)
        {
            try
            {
                int rankVotes = this.getRankVotes(pictureID);
                int rankAmount = this.getRankAmount(pictureID);
                if (rankVotes == 0 || rankAmount == 0)
                    return 0;
                else
                    return (double)rankVotes / rankAmount;
            }
            catch
            {
                return 0;
            }
        }
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
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (Session["eid"] != null)
                    Session["usrID"] = util.getID(Session["eid"].ToString());
                Session["picID"] = Request.QueryString["id"];

                int id = Convert.ToInt32(Request.QueryString["id"]);
                Session["PictureID"] = id;
                dbc.cmd.Parameters.Add(new SqlParameter("id", id));
                dbc.cmd.CommandText = query;
                reader = dbc.cmd.ExecuteReader();

                if (reader.Read())
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
                    rank.Text = Convert.ToString(Math.Round(totalRank(Convert.ToInt32(Request.QueryString["id"])),1));
                }

                reader.Close();
                getComments(Convert.ToInt32(Request.QueryString["id"]));
                dbc.dbCon.Close();
            }
            else
            {
                Response.Redirect("../default.aspx");
            }
        }
    }
}