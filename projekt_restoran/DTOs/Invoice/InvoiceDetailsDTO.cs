using projekt_restoran.Models;

namespace projekt_restoran.DTOs
{
    public class InvoiceDetailsDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TableId { get; set; }

        public ICollection<MenuItemDTO> MenuItems { get; set; } = new List<MenuItemDTO>();

    }
}
