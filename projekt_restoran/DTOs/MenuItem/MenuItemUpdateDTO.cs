using System.ComponentModel.DataAnnotations;

namespace projekt_restoran.DTOs
{
    public class MenuItemUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
