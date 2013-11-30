using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Gavan.Pictures
{
    public partial class edit_act : System.Web.UI.Page
    {
        protected void UpdatePicture(int PictureID, string picname, string description)
        {
            db dbc = new db();
            dbc.cmd.Parameters.Add(new SqlParameter("Name", picname));
            dbc.cmd.Parameters.Add(new SqlParameter("Description", description));
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", PictureID));
            dbc.cmd.CommandText = "UPDATE pictures SET name = @Name, description = @Description WHERE id = @PictureID";
            dbc.cmd.ExecuteNonQuery();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities util = new Utilities();
            string eid = Convert.ToString(Session["eid"]);
            int id = Convert.ToInt32(Request.Form["id"]);
            if (Request.Form["id"] != null)
            {
                if (util.checkUsersPic(id, eid) || (int) Session["lvl"] == 3)
                {
                    int PictureID;
                    string picname, picdesc;
                    picname = Request.Form["picname"];
                    picdesc = Request.Form["description"];
                    PictureID = Convert.ToInt32(Request.Form["id"]);
                    this.UpdatePicture(PictureID, picname, picdesc);
                    Response.Redirect("default.aspx?id=" + PictureID);
                }
            }
            else if(!util.checkUsersPic(id, eid))
            {
                Gavan.Global.error = "התמונה איננה שלך.";
            }
            else 
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}