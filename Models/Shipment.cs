namespace RIS_p2_LR5.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string ShipmentNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<ShipmentDetail> Details { get; set; } = new List<ShipmentDetail>();
    }
}
