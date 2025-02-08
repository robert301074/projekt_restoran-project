using System.ComponentModel.DataAnnotations;

namespace projekt_restoran.DTOs.User
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public required string Name { get; set; }

    }
}
