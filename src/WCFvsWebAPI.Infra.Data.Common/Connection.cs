using System.Configuration;
using System.Data.SqlClient;

namespace WCFvsWebAPI.Infra.Data.Common
{
    public class Connection
    {
        protected SqlConnection DefaultConnection => new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
}
