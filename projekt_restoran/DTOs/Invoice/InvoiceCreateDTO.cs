using System.ComponentModel.DataAnnotations;

namespace projekt_restoran.DTOs.Invoice
{
    public class InvoiceCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TableId { get; set; }

    }
}
