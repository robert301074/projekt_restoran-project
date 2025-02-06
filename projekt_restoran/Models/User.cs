namespace projekt_restoran.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
            = new List<Invoice>();
    }
}
