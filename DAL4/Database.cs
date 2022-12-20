using System.Data.SqlClient;
using System.Data;

namespace DAL4
{
    public class DataBase
    {
        private static SqlConnection con;
        public static SqlConnection conn(string a, string b)
        {

            string constr = @"Data source = " + a + "; Initial Catalog=" + b + "; Integrated Security=True";

            try
            {
                con = new SqlConnection(constr);
                con.Open();
            }
            catch
            {
                con.Close();
            }
            return con;
        }
        public static SqlCommand Cmd(string a)
        {
            SqlCommand cmd = new SqlCommand(a, conn(@".\SQLEXPRESS", @"QLKS"));
            return cmd;
        }
        public static SqlCommand Store(string a)
        {
            SqlCommand cmd = Cmd(a);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public static SqlDataAdapter Adapt(string a)
        {
            SqlCommand cmd = Cmd(a);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            return adapt;
        }
        public static SqlDataAdapter AdaptStore(string a)
        {
            SqlCommand cmd = Store(a);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            return adapt;
        }
        public static SqlDataReader Reader (string a)
        {
            SqlCommand cmd = Cmd(a);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public static DataTable dt(string a)
        {
            SqlDataAdapter adapt = Adapt(a);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            return dt;
        }
        public static DataTable dtStore(string a)
        {
            SqlDataAdapter adapt = AdaptStore(a);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            return dt;
        }
          
    }
}
