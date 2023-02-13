using AutoMapper;
using ZeroFriction.DTO;
using ZeroFriction.DTO.Request;
using ZeroFriction.DTO.Response;
using ZeroFriction.Models;

namespace ZeroFriction.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<Invoice, InvoiceResponse>();
            CreateMap<InvoiceResponse, Invoice>();

            CreateMap<Invoice, InvoiceRequest>();
            CreateMap<InvoiceRequest, Invoice>();

            CreateMap<InvoiceItem, InvoiceItemDto>();
            CreateMap<InvoiceItemDto, InvoiceItem>();

            CreateMap<InvoiceItem, InvoiceItemDto>();
            CreateMap<InvoiceItemDto, InvoiceItem>();


        }
    }
}
