using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace projekt_restoran.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User? User{ get; set; }

        public int TableId { get; set; }
        public Table? Table { get; set; }

        public ICollection<MenuItem> Menuitems { get; set; } = new List<MenuItem>();
    }
}
