using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace _020101125.DTO
{
    public static class CSDL
    {
        static SqlConnection connection;
        public static void Connect()
        {
            string con = @"Data Source=DOWNFALL;Initial Catalog=QLNV28_09;Integrated Security=True";
            connection = new SqlConnection(con);

            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static DataTable Query(string sqlquery)
        {
            Connect();
            DataTable tb = new DataTable();
            SqlCommand cm = new SqlCommand(sqlquery, connection);
            tb.Load( cm.ExecuteReader());
            return tb;
        }
        public static void exxcute(string command)
        {
            SqlCommand cm=new SqlCommand(command, connection);
            cm.ExecuteNonQuery();

        }
    }
}
