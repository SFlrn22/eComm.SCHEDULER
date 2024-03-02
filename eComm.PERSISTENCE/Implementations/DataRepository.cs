using Dapper;
using eComm.APPLICATION.Contracts;
using eComm.DOMAIN.Models;
using System.Data;

namespace eComm.PERSISTENCE.Implementations
{
    public class DataRepository : IDataRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly string GET_PRODUCTS = "SELECT * FROM tbl_Products";
        private readonly string GET_USERS = @"SELECT ID as UserId
                                              ,Firstname
                                              ,Lastname
                                              ,Username
                                              ,Password
                                              ,Email
                                              ,Country
                                          FROM [dbo].[tbl_Users]";
        private readonly string GET_RATINGS = "SELECT * FROM tbl_Ratings";
        public DataRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<List<Product>> GetProducts()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                IEnumerable<Product> products = await connection.QueryAsync<Product>(GET_PRODUCTS, commandType: CommandType.Text);
                return products.ToList();
            }
        }

        public async Task<List<Ratings>> GetRatings()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                IEnumerable<Ratings> ratings = await connection.QueryAsync<Ratings>(GET_RATINGS, commandType: CommandType.Text);
                return ratings.ToList();
            }
        }

        public async Task<List<Users>> GetUsers()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                IEnumerable<Users> users = await connection.QueryAsync<Users>(GET_USERS, commandType: CommandType.Text);
                return users.ToList();
            }
        }
    }
}
