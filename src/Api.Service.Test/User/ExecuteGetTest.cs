using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecuteGetTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact]
        public async Task Should_Execute_Get_ReturnValidUser()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);

            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(NameUser, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            var record = await _service.Get(UserId); 
            Assert.Null(record);
        }
    }
}
