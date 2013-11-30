using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Gavan
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                string[] data = this.LoadPageInfo(id);
                title.InnerHtml = data[0];
                content.InnerHtml = data[1];
            }
        }
        protected string[] LoadPageInfo(int id)
        {
            db dbc = new db();
            string query = "SELECT * FROM Info WHERE id = @ID";
            dbc.cmd.CommandText = query;
            dbc.cmd.Parameters.Add(new SqlParameter("ID", id));
            SqlDataReader reader = dbc.cmd.ExecuteReader();
            string[] data = { };
            if(reader.Read())
            {
                data = new string[2] 
                {
                    Convert.ToString(reader["name"]), 
                    Convert.ToString(reader["content"])
                };
            }
            return data;
        }
        protected void LoadData()
        {
            db dbc = new db();
            string query = "SELECT * FROM Info ORDER BY id DESC";
            dbc.cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(dbc.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PagedDataSource pgitems = new PagedDataSource();
            DataView dv = new DataView(dt);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 9;
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
            LoadData();
        }

        public string[] data { get; set; }

        public string[] DataArray { get; set; }
    }
}