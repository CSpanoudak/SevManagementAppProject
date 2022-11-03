using System.Data.SqlClient;

namespace SevManagementApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        //Non instanceable class
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            try 
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("DefaultConnection");
                conn = new SqlConnection(url);
                return conn;
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        //May not be needed-we will implement auto-resource management
        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
