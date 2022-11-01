using System;
using System.Data.SqlClient;
using System.Data;
using DTO4;

namespace DAL4
{
    class DataBase
    {


        private const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True";
        private static SqlConnection conn;
        public DataBase(string a, string b)
        {

        }
        public static bool Connect()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static SqlConnection GetConnection()
        {
            if (conn == null)
                Connect();
            return conn;
        }
        public static void Disconect()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
        public static SqlCommand Cmd(string a)
        {
            SqlCommand cmd = new SqlCommand(a, DataBase.GetConnection());

            return cmd;
        }
        public static void ExeNonQuery(string a)
        {
            SqlCommand cmd = new SqlCommand(a, DataBase.GetConnection());
            cmd.ExecuteNonQuery();
           // return cmd;
        }

        public static SqlCommand Store(string a)
        {
            SqlCommand cmd = Cmd(a);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static SqlDataReader Reader(string a)
        {
            SqlCommand cmd = Cmd(a);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader;
        }
        public static SqlDataAdapter Adapt(string a)
        {
            SqlCommand cmd = Cmd(a);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            return adapter;
        }
        public static SqlDataAdapter AdaptStore(string a)
        {
            SqlCommand cmd = Store(a);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            return adapter;
        }

        public static DataTable data(string a)
        {
            SqlDataAdapter da = Adapt(a);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable dataStore(string a)
        {
            SqlDataAdapter da = AdaptStore(a);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static DataSet ds(string a)
        {
            SqlDataAdapter da = Adapt(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
       

    }
}
