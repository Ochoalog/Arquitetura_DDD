using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.GetAllTest
{
    public class ReturnGetAll
    {
        private UsersController _controller;

        [Fact]
        public async Task CallGet()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(mbox => mbox.GetAll()).ReturnsAsync(
                new List<UserDto>()
                {
                    new UserDto()
                    {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    },
                    new UserDto()
                    {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    }
                }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetAll();

            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;

            Assert.True(resultValue.Count() == 2);
        }
    }
}
