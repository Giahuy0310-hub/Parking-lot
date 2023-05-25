using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT
{
    internal class Mainclass
    {
        public static readonly string con_string = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);
        //
        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;
            string qry = "select * from Login where Username = @username and Password = @password";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["Username"].ToString();
            }
            return isValid;
        }
        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

    }
}
