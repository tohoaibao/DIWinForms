using DIWinForms.Dto;
using DIWinForms.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIWinForms.Mappings
{
    public static class UserMapping
    {

        // IEnumerable<Entity> => IEnumerable<Dto>
        public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
        {
            return users?.Select(ToDto);
        }

        // Entity => Dto
        public static UserDto ToDto(this User user)
        {
            return user == null ? null : new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone
            };
        }
    }
}
