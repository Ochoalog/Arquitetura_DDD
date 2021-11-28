using Api.Application.Controllers;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.User.CreateTest
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task CallCreate()
        {
            var serviceMock = new Mock<IUserService>();

            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow,
                });

            _controller = new UsersController(serviceMock.Object);

            _controller.ModelState.AddModelError("Name", "Mensagem de erro.");

            Mock<UrlHelper> url = new Mock<UrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>)).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(userDtoCreate);

            Assert.True(result is BadRequestObjectResult);
        }
    }
}
