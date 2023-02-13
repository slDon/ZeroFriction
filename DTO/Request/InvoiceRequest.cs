namespace ZeroFriction.DTO.Request
{
    public class InvoiceRequest
    {
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public decimal? TotalAmount { get; set; }

        public ICollection<InvoiceItemDto> InvoiceItem { get; set; }
    }
}
