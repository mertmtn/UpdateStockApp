using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UpdateStockApp.DatabaseMethods
{
    public class DbConnect
    {
        private DbConnect()
        {
                
        }    

        private static SqlConnection _connect;

        public static  SqlConnection Connect
        {
            get
            {
                if (_connect == null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;
                    _connect = new SqlConnection(connectionString);                   
                }

                if (_connect.State != ConnectionState.Open)
                    _connect.Open();

                return _connect;
            }
        }

    }
}