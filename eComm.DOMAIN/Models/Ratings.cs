namespace eComm.DOMAIN.Models
{
    public class Ratings
    {
        public int UserId { get; set; } = default!;
        public string ISBN { get; set; } = string.Empty;
        public int Rating { get; set; } = default!;
    }
}
