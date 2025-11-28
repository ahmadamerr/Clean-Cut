using System.Configuration;

namespace CleanCut_DataAccess
{
    public class clsDataConnection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["CleanCutDB"].ConnectionString;
    }
}