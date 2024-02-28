namespace eComm.DOMAIN.Models
{
    public class Product
    {
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string PublicationYear { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string ImageUrlS { get; set; } = string.Empty;
        public string ImageUrlM { get; set; } = string.Empty;
        public string ImageUrlL { get; set; } = string.Empty;
    }
}
