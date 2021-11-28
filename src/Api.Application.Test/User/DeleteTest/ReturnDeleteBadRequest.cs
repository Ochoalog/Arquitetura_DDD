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
    public class ReturnDeleteBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task CallUpdate()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "Mensagem de Erro");

            var result = await _controller.Delete(default(Guid));

            Assert.True(result is BadRequestObjectResult);
        }
    }
}
