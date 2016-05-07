namespace AirApi.Models
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RouteId { get; set; }
        public System.DateTime DatePurchased { get; set; }
        public string User { get; set; }
        public string Route { get; set; }
        public string Marshrut { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
    }
}