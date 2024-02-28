using Microsoft.Data.SqlClient;

namespace eComm.APPLICATION.Contracts
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
