﻿using eComm.APPLICATION.Contracts;
using eComm.PERSISTENCE.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace eComm.PERSISTENCE.Implementations
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value!;
        }
        public SqlConnection CreateConnection()
        {
            string decipheredConnectionString = AesDecryptHelper.Decrypt("supersecretKEYThatIsHardToGuesSS", _connectionString);
            return new SqlConnection(decipheredConnectionString);
        }
    }
}
