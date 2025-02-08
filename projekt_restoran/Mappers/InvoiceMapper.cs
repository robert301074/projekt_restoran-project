using projekt_restoran.Models;

namespace projekt_restoran.Mappers
{
    public static class InvoiceMapper
    {

        public static DTOs.InvoiceDTO ToInvoiceDTO(this Invoice invoice)
        {
            return new DTOs.InvoiceDTO()
            {
                Id = invoice.Id,
                UserId = invoice.UserId,
                TableId = invoice.TableId
            };
        }

        public static DTOs.InvoiceDetailsDTO ToInvoiceDetailDTO(this Invoice invoice)
        {
            return new DTOs.InvoiceDetailsDTO()
            {
                Id = invoice.Id,
                UserId = invoice.UserId,
                TableId = invoice.TableId
            };
        }

        public static Invoice ToInvoice(this DTOs.InvoiceCreateDTO dto)
        {
            return new Invoice()
            {
                UserId = dto.UserId,
                TableId = dto.TableId
            };
        }

        public static Invoice ToInvoice(this DTOs.InvoiceUpdateDTO invoiceUpdateDTO)
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
