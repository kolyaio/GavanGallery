using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Gavan
{
    public class Utilities
    {
        
        internal protected string hashdir = "5saBntkm=#";
        // Hash password
        internal protected string hashPass(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        // Add salt to password
        internal protected string hashSalt(string password)
        {
            string salt = "feexNaN_1%";
            string hashSalt = this.hashPass(password + salt);
            return hashSalt;
        }
        // Get Email
        internal protected string getEmail(int id)
        {
            db dbc = new db();
            string query = "SELECT email FROM users WHERE id = @Id";
            dbc.cmd.Parameters.Add(new SqlParameter("Id", id));
            dbc.cmd.CommandText = query;
            string email = "";
            try
            {
                SqlDataReader dr;
                dr = dbc.cmd.ExecuteReader();
                while (dr.Read())
                {
                    email = dr.GetString(0);
                }
            }
            catch
            {
                Console.WriteLine("בעיה בחיבור.");
            }
                return email;
        }
        // get Directory
        internal protected string getDir(string email)
        {
            db dbc = new db();
            string query = "SELECT dir FROM users WHERE email = @Email";
            dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
            dbc.cmd.CommandText = query;
            int counter = 0;
            string dir = "";
            try
            {
                SqlDataReader dr;
                dr = dbc.cmd.ExecuteReader();
                while (dr.Read())
                {
                    dir = dr[0].ToString();
                    counter++;
                }
            }
            catch
            {
                Console.WriteLine("בעיה בחיבור.");
            }
            if (counter == 1)
                return dir;
            return "";
        }

        // Gets ID 

        internal protected int getID(string email)
        {
            db dbc = new db();
            string query = "SELECT id FROM users WHERE email = @Email";
            dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
            dbc.cmd.CommandText = query;
            int counter = 0;
            int id = 0;
            try
            {
                SqlDataReader dr;
                dr = dbc.cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    counter++;
                }
            }
            catch
            {
                Console.WriteLine("בעיה בחיבור.");
            }
                if (counter == 1)
                return id; 
            return 0; 
        }

        internal protected bool isAdmin(string email)
        {
            db dbc = new db();
            string query = "SELECT status,email FROM users WHERE email = @Email AND status = 3";
            dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
            dbc.cmd.CommandText = query;
            int counter = 0;
            try
            {
                SqlDataReader dr;
                dr = dbc.cmd.ExecuteReader();
                while (dr.Read())
                {
                    counter++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                counter = -1;
            }

            if (counter >= 1)
                return true;
            return false;
        }

        // Checks if user exist.
        internal protected bool userExist(string email)
        {
            db dbc = new db();
            String query = "SELECT * FROM users WHERE email  = @Email";
            dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
            dbc.cmd.CommandText = query;
            int counter = 0;
            try
            {
                SqlDataReader dr;
                dr = dbc.cmd.ExecuteReader();
                while (dr.Read())
                {
                    counter++;
                }
                dr.Close();
                dbc.dbCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                counter = -1;
            }

            if(counter >= 1)
                return true;
            return false;
        }
        internal protected string getFileName(int pictureID)
        {
            db dbc = new db();
            string query = "SELECT * FROM pictures WHERE id = @PictureID";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            dbc.cmd.CommandText = query;
            SqlDataReader reader;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                return Convert.ToString(reader["path"]);
            }
            return "";
        }

        internal protected bool picExist(int pictureID)
        {
            int counter = 0;
            db dbc = new db();
            string query = "SELECT * FROM pictures WHERE id = @PictureID";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            dbc.cmd.CommandText = query;
            SqlDataReader reader;
            reader = dbc.cmd.ExecuteReader();
            while (reader.Read())
            {
                counter++;
            }
            if (counter == 1)
                return true;
            return false;
        }
        internal protected bool checkUsersPic(int pictureID, string eid)
        {
            Utilities util = new Utilities();
            int userID = util.getID(eid);
            int counter = 0;
            db dbc = new db();
            string query = "SELECT * FROM pictures WHERE id = @PictureID AND userID = @UserID";
            dbc.cmd.Parameters.Add(new SqlParameter("PictureID", pictureID));
            dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
            dbc.cmd.CommandText = query;
            SqlDataReader reader;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                counter++;
            }
            if (counter >= 1)
                return true;
            return false;
        }
        internal protected bool checkUsersComment(int commentID, string eid)
        {
            Utilities util = new Utilities();
            int userID = util.getID(eid);
            int counter = 0;
            db dbc = new db();
            string query = "SELECT * FROM comments WHERE id = @CommentID AND userID = @UserID";
            dbc.cmd.Parameters.Add(new SqlParameter("CommentID", commentID));
            dbc.cmd.Parameters.Add(new SqlParameter("UserID", userID));
            dbc.cmd.CommandText = query;
            SqlDataReader reader;
            reader = dbc.cmd.ExecuteReader();
            if (reader.Read())
            {
                counter++;
            }
            if (counter >= 1)
                return true;
            return false;
        }
        internal protected string createDirName()
        {
            string[] letters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                                "A","B","C","D","E","F","G","H","I","J","K","L","M","M","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                                "0","1","2","3","4","5","6","7","8","9","!","=","$",".",",","*","^","#","&","(",")"};
            Random rand = new Random();
            int randNum;
            string str = "";
            for (int i = 0; i <= 10; i++)
            {
                randNum = rand.Next(0, letters.Length);
                str += letters[randNum];
            }
            return str;
        }

        internal protected bool loginMe(string email, string password)
        {
            db dbc = new db();
            String query = "SELECT * FROM users WHERE email  = @Email AND password=@Password";
            dbc.cmd.Parameters.Add(new SqlParameter("Email", email));
            dbc.cmd.Parameters.Add(new SqlParameter("Password", password));
            dbc.cmd.CommandText = query;
            int counter = 0;
            try
            {
                SqlDataReader dr;
                dr = dbc.cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    counter++;
                }
                dr.Close();
                dbc.dbCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (counter == 1)
                return true;
            return false;
        }
    }
}