using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class UserMapper
    {
        public static UserDTO GetDto(this User entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new UserDTO
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Forms = entity.Forms.GetDtos()
            };
        }

        public static ICollection<UserDTO> GetDtos(this ICollection<User> entities)
        {
            return entities.Select(GetDto).ToList();
        }
    }
}
