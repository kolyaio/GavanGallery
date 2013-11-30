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
    public partial class mydefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            string query;
            db dbc = new db();
            query = "SELECT * FROM pictures ORDER BY date DESC";
            if (Request.QueryString["sort"] == "oldest")
                query = "SELECT * FROM pictures ORDER BY date ASC";
            else if (Request.QueryString["sort"] == "byalphaup")
                query = query = "SELECT * FROM pictures ORDER BY id DESC";
            else if (Request.QueryString["sort"] == "byalphadown")
                query = query = "SELECT * FROM pictures ORDER BY id ASC";
            dbc.cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(dbc.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PagedDataSource pgitems = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(dt);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 9;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPages.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
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
    }
}