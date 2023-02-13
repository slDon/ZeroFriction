using Microsoft.AspNetCore.Mvc;
using ZeroFriction.DTO.Request;
using ZeroFriction.DTO.Response;
using ZeroFriction.Services.Interface;

namespace ZeroFriction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private IInvoiceService invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceResponse>>> GetInvoice()
        {
            return await invoiceService.GetAllInvoicesAsync();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceResponse>> PostInvoice(InvoiceRequest invoice)
        {
            var value = await invoiceService.AddInvoiceAsync(invoice);

            return CreatedAtAction("GetInvoice", new { id = value.Id }, value);
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceResponse>> PutInvoice(int id, InvoiceRequest invoice)
        {
            var value = await invoiceService.UpdateInvoiceAsync(id, invoice);

            return CreatedAtAction("GetInvoice", new { id = value.Id }, value);
        }
    }
}
