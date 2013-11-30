using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
                Console.WriteLine("Problem with connection.");
            }
                if (counter == 1)
                return id; 
            return 0; 
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