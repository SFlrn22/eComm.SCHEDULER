using eComm.DOMAIN.Models;

namespace eComm.APPLICATION.Contracts
{
    public interface IDataRepository
    {
        Task<List<Product>> GetProducts();
        Task<List<Users>> GetUsers();
        Task<List<Ratings>> GetRatings();
    }
}
