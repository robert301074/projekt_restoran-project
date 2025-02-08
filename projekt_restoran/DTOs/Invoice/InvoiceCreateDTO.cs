using projekt_restoran.Models;
using System.ComponentModel.DataAnnotations;

namespace projekt_restoran.DTOs
{
    public class InvoiceCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TableId { get; set; }

        [Required]
        public List<int> MenuItemsIds { get; set; }

    }
}
