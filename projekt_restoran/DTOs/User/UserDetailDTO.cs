using projekt_restoran.Models;

namespace projekt_restoran.DTOs.User
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
       public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();


    }
}
