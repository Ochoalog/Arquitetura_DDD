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
    public class ReturnBadRequest
    {
        private UsersController _controller;

        public async Task CallGetAllError()
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
            _controller.ModelState.AddModelError("Erro", "Mensagem de erro");

            var result = await _controller.GetAll();

            Assert.True(result is BadRequestObjectResult);
        }
    }
}
