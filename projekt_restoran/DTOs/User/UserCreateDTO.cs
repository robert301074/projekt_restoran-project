using System.ComponentModel.DataAnnotations;

namespace projekt_restoran.DTOs.User
{
    public class UserCreateDTO
    {
        [Required]
        [StringLength(40)]
        public required string Name { get; set; }
    }
}
