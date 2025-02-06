namespace projekt_restoran.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }
        public double Price { get; set; }

        public ICollection<Invoice> Invoicess { get; set; } = new List<Invoice>();
    }
}
