namespace projekt_restoran.DTOs
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
    }
}
