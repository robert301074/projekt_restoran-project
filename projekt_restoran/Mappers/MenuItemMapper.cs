using projekt_restoran.DTOs.MenuItem;
using projekt_restoran.Models;

namespace projekt_restoran.Mappers

{
    public static class MenuItemMapper
    {
        public static MenuItemDTO ToMenuItemDTO(this MenuItem menuItem)
        {
            return new MenuItemDTO()
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price
            };
        }

        public static MenuItemDetailDTO ToInvoiceDetailsDTO(this MenuItem menuItem)
        {
            return new MenuItemDetailDTO()
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price
            };
        }

        public static MenuItem ToMenuItem(this MenuItemCreateDTO menuItemCreateDTO)
        {
            return new MenuItem()
            {
                Name = menuItemCreateDTO.Name,
                Price = menuItemCreateDTO.Price
            };
        }

        public static MenuItem ToMenuItem(this MenuItemUpdateDTO menuItemUpdateDTO)
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
