using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FT
{
    internal class ChucVu
    {
        public static readonly string con_string = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);
        //
        public static bool IsValidUser(string user, string pass,int machucvu)
        {
            bool isValid = false;
            string qry = "select * from Login where machucvu = @machucvu ";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@machucvu", machucvu);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USERS = dt.Rows[0]["machucvu"].ToString();
            }
            return isValid;
        }
        public static string users;
        public static string USERS
        {
            get { return users; }
            private set { users = value; }
        }
    }
}
