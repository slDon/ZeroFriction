namespace ZeroFriction.DTO
{
    public class InvoiceItemDto
    {
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? LineAmount { get; set; }
    }
}
