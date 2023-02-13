using ZeroFriction.DTO.Request;
using ZeroFriction.DTO.Response;

namespace ZeroFriction.Services.Interface
{
    public interface IInvoiceService
    {
        public Task<List<InvoiceResponse>> GetAllInvoicesAsync();
        public Task<InvoiceResponse> AddInvoiceAsync(InvoiceRequest invoiceRequest);
        public Task<InvoiceResponse> UpdateInvoiceAsync(int id, InvoiceRequest invoiceRequest);
    }
}
