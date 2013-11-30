using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Account
{
    public partial class register : System.Web.UI.Page
    {
        Utilities util = new Utilities();

        // Registration of user to DB.
        protected bool registration(string name, int studstaff, int grade, string email, string password,string dir)
        {
            db dbc = new db();
            try
            {
                dbc.cmd.CommandText = "INSERT INTO users(name,email,password,status,grade,dir) VALUES(@Name,@Email,@Password,@Status,@Grade,@Dir)";
                dbc.cmd.Parameters.Add(new SqlParameter("Name",name));
                dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
                dbc.cmd.Parameters.Add(new SqlParameter("Password", util.hashSalt(password)));
                dbc.cmd.Parameters.Add(new SqlParameter("Status", studstaff));
                dbc.cmd.Parameters.Add(new SqlParameter("Grade", grade));
                dbc.cmd.Parameters.Add(new SqlParameter("Dir", dir));
                dbc.cmd.ExecuteNonQuery();
                return true;
            } catch 
            {
                Gavan.Global.error = "ההרשמה לא הצליחה, תנסה שוב.";
                return false;
            }
        }
        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            string name = Request.Form["name"].ToString();
            int studstaff = Convert.ToInt32(Request.Form["studstaff"].ToString());
            int grade = Convert.ToInt32(Request.Form["grade"].ToString());

            if (studstaff == 2 && grade == 1)
                grade = 0;

            string email = Request.Form["email"].ToString();
            string password = Request.Form["password"].ToString();
            string confirmpass = Request.Form["confirmpass"].ToString();
            int agree = Convert.ToInt32(Request.Form["agree"].ToString());
            string dir = util.hashPass(util.createDirName() + util.hashdir);
            string subPath = "../Uploads\\" + dir + "\\";

            if (agree == 1 && password.Equals(confirmpass) && util.userExist(email)==false)
            {
                if (registration(name, studstaff, grade, email, password, dir))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                    Session["name"] = name;
                    Session["lgin"] = true;
                    Session["eid"] = email;
                    Session["dir"] = dir;
                    Response.Redirect("/");
                }
            }
            else
            {
                string str = "";
                if (util.userExist(email))
                {
                    str += "המשתמש כבר קיים! <br>";
                }
                if (agree != 1)
                {
                    str += " לא הסכמת לתנאים!  <br>";
                }
                if (password.Equals(confirmpass))
                {
                    str += "הסיסמאות אינן תואמות  <br>";
                }
                Gavan.Global.error = str;
            }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}