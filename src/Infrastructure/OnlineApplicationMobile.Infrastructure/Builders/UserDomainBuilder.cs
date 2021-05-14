using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.Builders
{
    public class UserDomainBuilder
    {
        public User Build(UserDto userDto)
        {
            if (userDto == null)
                return null;

            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                MiddleName = userDto.MiddleName,
                BirthDate = userDto.BirthDate,
                Telephone = userDto.Telephone
            };
        }

        public UserDto Rebuild(User user)
        {
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Telephone = user.Telephone
            };
        }
    }
}
