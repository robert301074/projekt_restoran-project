using projekt_restoran.Models;

namespace projekt_restoran.Mappers

{
    public static class MenuItemMapper
    {
        public static DTOs.MenuItemDTO ToMenuItemDTO(this MenuItem menuItem)
        {
            return new DTOs.MenuItemDTO()
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price
            };
        }

        public static DTOs.MenuItemDetailDTO ToInvoiceDetailsDTO(this MenuItem menuItem)
        {
            return new DTOs.MenuItemDetailDTO()
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price
            };
        }

        public static MenuItem ToMenuItem(this DTOs.MenuItemCreateDTO menuItemCreateDTO)
        {
            return new MenuItem()
            {
                Name = menuItemCreateDTO.Name,
                Price = menuItemCreateDTO.Price
            };
        }

        public static MenuItem ToMenuItem(this DTOs.MenuItemUpdateDTO menuItemUpdateDTO)
        {
            return new MenuItem()
            {
                Id = menuItemUpdateDTO.Id,
                Name = menuItemUpdateDTO.Name,
                Price = menuItemUpdateDTO.Price
            };
        }

    }
}
