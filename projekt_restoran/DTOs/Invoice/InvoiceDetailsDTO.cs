using projekt_restoran.Models;

namespace projekt_restoran.DTOs.Invoice
{
    public class InvoiceDetailsDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TableId { get; set; }

        //public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    }
}
