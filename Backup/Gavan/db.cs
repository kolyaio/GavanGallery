using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Gavan
{
    class db
    {
        public String conStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public SqlConnection dbCon = null;
        public SqlCommand cmd = null;
        public db()
        {
            this.dbCon = new SqlConnection(this.conStr);
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.dbCon;
            this.cmd.CommandType = CommandType.Text;
            this.dbCon.Open();
        }
    }
}