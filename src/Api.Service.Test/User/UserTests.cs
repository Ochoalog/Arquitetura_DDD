using System;
using System.Collections.Generic;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTests
    {
        public static string NameUser { get; set; }
        public static string EmailUser { get; set; }
        public static string NameUserUpdated { get; set; }
        public static string EmailUserUpdated { get; set; }
        public Guid UserId { get; set; }

        public List<UserDto> ListUserDto = new List<UserDto>();
        public UserDto userDto { get; set; }
        public UserDtoCreate userDtoCreate { get; set; }
        public UserDtoCreateResult userDtoCreateResult { get; set; }
        public UserDtoUpdate userDtoUpdate { get; set; }
        public UserDtoUpdateResult userDtoUpdateResult { get; set; }

        public UserTests()
        {
            UserId = Guid.NewGuid();
            NameUser = Faker.Name.FullName();
            UserId = Guid.NewGuid();
            EmailUser = Faker.Internet.Email();
            NameUserUpdated = Faker.Name.FullName();
            EmailUserUpdated = Faker.Internet.Email();

            for(int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                ListUserDto.Add(dto);
            }

            userDto = new UserDto()
            {
                Id = UserId,
                Name = NameUser,
                Email = EmailUser
            };

            userDtoCreate = new UserDtoCreate()
            {
                Name = NameUser,
                Email = EmailUser
            };

            userDtoCreateResult = new UserDtoCreateResult()
            {
                Id = UserId,
                Name = NameUser,
                Email = EmailUser,
                CreateAt = DateTime.Now
            };

            userDtoUpdate = new UserDtoUpdate()
            {
                Id = UserId,
                Name = NameUserUpdated,
                Email = EmailUserUpdated,
            };

            userDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = UserId,
                Name = NameUserUpdated,
                Email = EmailUserUpdated,
                CreateAt = DateTime.Now
            };
        } 
    }
}