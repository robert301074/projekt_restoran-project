using projekt_restoran.Models;

namespace projekt_restoran.DTOs.Table
{
    public class TableDetailsDTO
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<InvoiceDTO> Invoices { get; internal set; }
        //public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
