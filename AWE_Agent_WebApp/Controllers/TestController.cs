using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

public class TestController : Controller
{
    public string Index()
    {
        string connStr = ConfigurationManager.ConnectionStrings["AWEConn"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            return "SUCCESS! Connected to SQL Server.";
        }
    }
}
