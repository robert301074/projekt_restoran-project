using projekt_restoran.DTOs.Table;
using projekt_restoran.Models;

namespace projekt_restoran.Mappers
{
    public static class TableMapper
    {

        public static TableDTO ToTableDTO(this Table table)
        {
            return new TableDTO()
            {
                Id = table.Id,
                Name = table.Name
            };
        }

        public static TableDetailsDTO ToTableDetailDTO(this Table table)
        {
            return new TableDetailsDTO()
            {
                Id = table.Id,
                Name = table.Name,
                Invoices = table.Invoices
            };
        }

        public static Table ToTable(this TableCreateDTO dto)
        {
            return new Table()
            {
                Name = dto.Name
            };
        }

        public static Table ToTable(this TableUpdateDTO tableUpdateDTO)
        {
            return new Table()
            {
                Id = tableUpdateDTO.Id,
                Name = tableUpdateDTO.Name
            };
        }


    }
}
