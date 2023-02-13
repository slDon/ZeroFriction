using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZeroFriction.Context;
using ZeroFriction.DTO.Request;
using ZeroFriction.DTO.Response;
using ZeroFriction.Models;
using ZeroFriction.Services.Interface;

namespace ZeroFriction.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly APIDatabaseContext _context;
        private IMapper _mapper;

        public InvoiceService(APIDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceResponse> AddInvoiceAsync(InvoiceRequest invoiceRequest)
        {
            var entity = _mapper.Map<Invoice>(invoiceRequest);
            _context.Invoice.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<InvoiceResponse>(entity);
        }

        public async Task<List<InvoiceResponse>> GetAllInvoicesAsync()
        {
            var entities = new List<Invoice>();
            entities = await _context.Invoice
                .Include(a => a.InvoiceItem).ToListAsync();
            var result = _mapper.Map<List<InvoiceResponse>>(entities);

            return result;
        }

        public async Task<InvoiceResponse> UpdateInvoiceAsync(int id, InvoiceRequest invoiceRequest)
        {
            var entity = _mapper.Map<Invoice>(invoiceRequest);
            entity.Id = id;
            _context.InvoiceItem.RemoveRange(_context.InvoiceItem.Where(a => a.InvoiceId == id));
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var invoiceItems = _mapper.Map<ICollection<InvoiceItem>>(invoiceRequest.InvoiceItem);
            foreach (var item in invoiceItems)
            {
                item.InvoiceId = id;
            }
            await _context.InvoiceItem.AddRangeAsync(invoiceItems);
            await _context.SaveChangesAsync();

            return _mapper.Map<InvoiceResponse>(entity);
        }
    }
}
