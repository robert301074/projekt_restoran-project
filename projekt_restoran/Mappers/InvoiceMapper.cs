using projekt_restoran.DTOs.Invoice;
using projekt_restoran.Models;

namespace projekt_restoran.Mappers
{
    public static class InvoiceMapper
    {

        public static InvoiceDTO ToInvoiceDTO(this Invoice invoice)
        {
            return new InvoiceDTO()
            {
                Id = invoice.Id,
                UserId = invoice.UserId,
                TableId = invoice.TableId
            };
        }

        public static InvoiceDetailsDTO ToInvoiceDetailDTO(this Invoice invoice)
        {
            return new InvoiceDetailsDTO()
            {
                Id = invoice.Id,
                UserId = invoice.UserId,
                TableId = invoice.TableId
            };
        }

        public static Invoice ToInvoice(this InvoiceCreateDTO dto)
        {
            return new Invoice()
            {
                UserId = dto.UserId,
                TableId = dto.TableId
            };
        }

        public static Invoice ToInvoice(this InvoiceUpdateDTO invoiceUpdateDTO)
        {
            return new Invoice()
            {
                Id = invoiceUpdateDTO.Id,
                UserId = invoiceUpdateDTO.UserId,
                TableId = invoiceUpdateDTO.TableId
            };
        }
    }
}
