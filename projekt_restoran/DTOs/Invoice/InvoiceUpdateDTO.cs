namespace projekt_restoran.DTOs
{
    public class InvoiceUpdateDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TableId { get; set; }

        public List<int> MenuItemsIds { get; set; }


    }
}
