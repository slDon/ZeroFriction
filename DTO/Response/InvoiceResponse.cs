namespace ZeroFriction.DTO.Response
{
    public class InvoiceResponse
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public decimal? TotalAmount { get; set; }

        public ICollection<InvoiceItemDto> InvoiceItem { get; set; }
    }
}
