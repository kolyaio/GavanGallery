using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gavan.Admin.users
{
    public partial class edit_act : System.Web.UI.Page
    {
        Utilities util = new Utilities();
        protected void UpdateUser(string[] data)
        {
            db dbc = new db();
            string query = "UPDATE users SET name = @Name, email = @Email, password = @Password, status = @Status, grade = @Grade WHERE id = @ID";
            if(String.IsNullOrEmpty(data[2]) && data[2] == data[3])
                query = "UPDATE users SET name = @Name, email=@Email, status = @Status, grade = @Grade WHERE id = @ID";

            dbc.cmd.Parameters.Add(new SqlParameter("Name", data[0]));
            dbc.cmd.Parameters.Add(new SqlParameter("Email", data[1]));
            dbc.cmd.Parameters.Add(new SqlParameter("Password", util.hashSalt(data[2])));
            dbc.cmd.Parameters.Add(new SqlParameter("Status", data[4]));
            dbc.cmd.Parameters.Add(new SqlParameter("Grade", data[5]));
            dbc.cmd.Parameters.Add(new SqlParameter("ID", data[6]));
            dbc.cmd.CommandText = query;
            dbc.cmd.ExecuteNonQuery();
        }
        protected bool notempty(string[] data)
        {
            int counter = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 2)
                {
                    if (data[i] == data[i + 1])
                    {
                        if (String.IsNullOrEmpty(data[i]))
                            counter++;
                        else if (!String.IsNullOrEmpty(data[i]))
                            counter++;
                    }
                }
                else if (i == 3)
                {
                    if (data[i] == data[i - 1])
                    {
                        if (String.IsNullOrEmpty(data[i]))
                            counter++;
                        else if (!String.IsNullOrEmpty(data[i]))
                            counter++;
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(data[i]))
                        counter++;
                }
            }
            if (counter == data.Length)
                return true;
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] data = { Request.Form["name"], Request.Form["email"], Request.Form["password"], Request.Form["confirmpass"], Request.Form["studstaff"], Request.Form["grade"], Request.Form["id"] };

            if (notempty(data))
            {
                if (Convert.ToInt32(data[4]) == 2 || Convert.ToInt32(data[4]) == 3) data[5] = "0";
                this.UpdateUser(data);
            } 
            Response.Redirect("/Admin/users/");
        }
    }
}