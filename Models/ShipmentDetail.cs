namespace RIS_p2_LR5.Models
{
    public class ShipmentDetail
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
