using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace Gavan
{
   
    public partial class upload : System.Web.UI.Page
    {
        const int maxFileSize = 5242880;
        Utilities util = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["lgin"] == null) || (Session["eid"] == null))
            {
                Session["curPath"] = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("/login.aspx");
            }
        }
        protected bool checkFileExt(string fileExt)
        {
            if (fileExt == ".jpg" || fileExt == ".png" || fileExt == ".gif" || fileExt == ".jpeg")
                return true;
            else
                return false;
        }

        protected void regDBImage(string[] info)
        {
            string name = info[0];
            string fn = info[1];
            string description = info[2];
            string email = info[3];
            string path = info[4];
            DateTime date = DateTime.Now;
            int UserID = util.getID(email);
            db dbc = new db();
            try
            {
                dbc.cmd.CommandText = "INSERT INTO pictures (name,filename,description,userID,date,path) VALUES(@Name,@FileName,@Description,@UserID,@Date,@Path)";
                dbc.cmd.Parameters.Add(new SqlParameter("Name", name));
                dbc.cmd.Parameters.Add(new SqlParameter("FileName", fn));
                dbc.cmd.Parameters.Add(new SqlParameter("Description", description));
                dbc.cmd.Parameters.Add(new SqlParameter("UserID", UserID));
                dbc.cmd.Parameters.Add(new SqlParameter("Date", date));
                dbc.cmd.Parameters.Add(new SqlParameter("Path", path));
                dbc.cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write("Coundn't to insert" + ex.Message);
            }
        }
        
        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            if ((fileload.PostedFile != null) && (fileload.PostedFile.ContentLength > 0) && (fileload.PostedFile.ContentLength < maxFileSize) && (Session["eid"] != null))
            {
                string namedir = util.hashPass(Session["eid"] + util.hashdir);
                string fn = Path.GetFileName(fileload.PostedFile.FileName);
                string subPath = "Uploads\\" + namedir + "\\";
                string SaveLocation = Server.MapPath(subPath) + fn;
                string picname = Request.Form["picname"];
                string description = Request.Form["description"];
                if (File.Exists(SaveLocation))
                {
                    Random rand = new Random();
                    int randnum = rand.Next(1, 1000);
                    fn = randnum + fn;
                    SaveLocation = Server.MapPath(subPath) + fn;
                }

                string fileExt = Path.GetExtension(fn);

                System.Drawing.Image Uploaded = System.Drawing.Image.FromStream(fileload.PostedFile.InputStream);
                double width = Convert.ToDouble(Uploaded.Width);
                double height = Convert.ToDouble(Uploaded.Height);
                
                if (checkFileExt(fileExt) && width >= 100 && height >= 100)
                {
                    try
                    {
                        fileload.PostedFile.SaveAs(SaveLocation);
                        Response.Write("The file has been uploaded.<br />");
                        Response.Write("<img src=\"" + subPath + fn + "\">");
                        string[] info = new string[5];
                        info[0] = picname;
                        info[1] = fn;
                        info[2] = description;
                        info[3] = Session["eid"].ToString();
                        info[4] = subPath + fn;
                        regDBImage(info);
                        Response.Write(width + " " + height);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
                else if(width < 100 || height < 100) {
                    Response.Write("The width and length of the file need be more than 100X100 pixels.");
                }
                else
                {
                    Response.Write("The file extension is not allowed.");
                }
            }
            else if(Session["eid"] == null) {
                Response.Write("You not allowed, please <a href\"=\\login.aspx\">login</a>.");
            }
            else if (fileload.PostedFile.ContentLength > maxFileSize)
            {
                Response.Write("You can't upload file size bigger than 5mb.");
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}