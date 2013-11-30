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
    public partial class register : System.Web.UI.Page
    {
        Utilities util = new Utilities();

        // Registration of user to DB.
        protected void registration(String name, int studstaff, int grade, String email, String password)
        {
            db dbc = new db();
            try
            {
                dbc.cmd.CommandText = "INSERT INTO users VALUES(@Name,@Email,@Password,@Status, @Grade)";
                dbc.cmd.Parameters.Add(new SqlParameter("Name",name));
                dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
                dbc.cmd.Parameters.Add(new SqlParameter("Password", util.hashSalt(password)));
                dbc.cmd.Parameters.Add(new SqlParameter("Status", studstaff));
                dbc.cmd.Parameters.Add(new SqlParameter("Grade", grade));
                dbc.cmd.ExecuteNonQuery();
            } catch 
            {
                Response.Write("Coundn't to insert");
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
            string subPath = "Uploads\\" + util.hashPass(email + util.hashdir) + "\\";

            if (agree == 1 && password.Equals(confirmpass) && util.userExist(email)==false)
            {
                registration(name, studstaff, grade, email, password);
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                Session["name"] = name;
                Session["lgin"] = true;
                Session["eid"] = email;
                Session["nuser"] = true;
            }
            else
            {
                string str = "";
                if (util.userExist(email))
                {
                    str += "המשתמש כבר קיים!";
                }
                if (agree != 1)
                {
                    str += " לא הסכמת לתנאים!";
                }
                if (password.Equals(confirmpass))
                {
                    str += "הסיסמאות אינן תואמות ";
                }
                Response.Write(str);
            }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}