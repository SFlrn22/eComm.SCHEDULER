using CsvHelper;
using eComm.APPLICATION.Contracts;
using System.Globalization;

namespace eComm.APPLICATION.Implementations
{
    public class OrchestrationService : IOrchestrationService
    {
        private readonly IDataRepository _repository;
        public OrchestrationService(IDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int, int, int)> OrchestrateAsync()
        {
            int productCount = await CreateProductsCSV();
            int userCount = await CreateUsersCSV();
            int ratingCount = await CreateRatingsCSV();

            return (productCount, userCount, ratingCount);
        }

        private async Task<int> CreateProductsCSV()
        {
            var products = await _repository.GetProducts();
            using (var writer = new StreamWriter("C:\\Users\\Florin\\Diseratie\\MLApi\\Datasets\\products.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(products);
            }

            return products.Count;
        }

        private async Task<int> CreateUsersCSV()
        {
            var ratings = await _repository.GetUsers();
            using (var writer = new StreamWriter("C:\\Users\\Florin\\Diseratie\\MLApi\\Datasets\\users.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ratings);
            }

            return ratings.Count;
        }

        private async Task<int> CreateRatingsCSV()
        {
            var users = await _repository.GetRatings();
            using (var writer = new StreamWriter("C:\\Users\\Florin\\Diseratie\\MLApi\\Datasets\\ratings.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(users);
            }

            return users.Count;
        }
    }
}
