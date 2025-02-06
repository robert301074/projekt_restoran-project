using projekt_restoran.DTOs.User;
using projekt_restoran.Models;

namespace projekt_restoran.Mappers
{
    public static class UserMapper
    {

        public static UserDTO ToUserDTO (this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public static UserDetailDTO ToUserDetailDTO(this User user)
        {
            return new UserDetailDTO()
            {
                Id = user.Id,
                Name = user.Name,
               Invoices = user.Invoices
            };
        }

        public static User ToUser(this UserCreateDTO dto)
        {
            return new User()
            {
                Name = dto.Name
            };
        }

        public static User ToUser(this UserUpdateDTO userUpdateDTO)
        {
            return new User()
            {
                Id = userUpdateDTO.Id,
                Name = userUpdateDTO.Name
            };
        }


    }
}
