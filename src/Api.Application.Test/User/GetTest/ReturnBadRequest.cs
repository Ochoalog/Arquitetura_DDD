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

namespace Api.Application.Test.User.GetTest
{
    public class ReturnGBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task CallGetError()
        {
            var serviceMock = new Mock<IUserService>();

            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(mbox => mbox.Get(It.IsAny<Guid>())).ReturnsAsync(
                    new UserDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = nome,
                        Email = email,
                        CreateAt = DateTime.UtcNow,
                    }
                );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Erro", "Mensagem de erro");

            var result = await _controller.Get(Guid.NewGuid());

            Assert.True(result is BadRequestObjectResult);
        }
    }
}
