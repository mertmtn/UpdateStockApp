using System.Data;
using System.Data.SqlClient;
using UpdateStockApp.DatabaseMethods;

namespace UpdateStockApp.Methods.DatabaseMethods
{
    public class ExecuteMethods
    {
        
        public static int ExecuteNonQuery(string sqlKod)
        {

            SqlCommand cmd = new SqlCommand(sqlKod, DbConnect.Connect);
            cmd.Connection = DbConnect.Connect;

            int durum = cmd.ExecuteNonQuery();
            DbConnect.Connect.Close();
            return durum;
        }

        public static int ExecuteNonQuery(string sqlKod, string[] veri, string[] parametre)
        {
            SqlCommand cmd = new SqlCommand(sqlKod, DbConnect.Connect);
            cmd.Connection = DbConnect.Connect;
             
            for (int i = 0; i < veri.Length; i++)
            {
                cmd.Parameters.AddWithValue(parametre[i], veri[i]);
            }

            int durum = cmd.ExecuteNonQuery();
            DbConnect.Connect.Close();
            return durum;
        }

        public static object ExecuteScalar(string sqlKod)
        {
            SqlCommand kod = new SqlCommand(sqlKod, DbConnect.Connect);
            kod.Connection = DbConnect.Connect; 
            object durum = kod.ExecuteScalar();
            kod.Connection.Close();
            return durum;
        }

        public static DataTable ExecuteReader(string sqlKod)
        {
            SqlCommand cmd = new SqlCommand(sqlKod, DbConnect.Connect);
            cmd.Connection = DbConnect.Connect;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}