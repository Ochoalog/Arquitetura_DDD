using Api.Application.Controllers;
using Api.Domain.Dtos;
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

namespace Api.Application.Test.User.DeleteTest
{
    public class ReturnDelete
    {
        private UsersController _controller;

        [Fact]
        public async Task CallDelete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());

            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;

            Assert.NotNull(resultValue);
            Assert.True((bool)resultValue);
        }
    }
}
