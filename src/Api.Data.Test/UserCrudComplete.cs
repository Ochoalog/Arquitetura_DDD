using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Api.Data.Test.BaseTest;

namespace Api.Data.Test
{
    public class UserCrudComplete : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UserCrudComplete(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        
        [Fact]
        [Trait("CRUD", "UserEntity")]
        public async Task ShouldCRUDUser() 
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity 
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _register = await _repository.InsertAsync(_entity);

                Assert.NotNull(_register);
                Assert.Equal(_entity.Email, _register.Email);
                Assert.Equal(_entity.Name, _register.Name);
                Assert.False(_register.Id == Guid.Empty);


                _entity.Name = Faker.Name.First();
                var _registerUpdated = await _repository.UpdateAsync(_entity);

                Assert.NotNull(_registerUpdated);
                Assert.Equal(_entity.Email, _register.Email);
                Assert.Equal(_entity.Name, _registerUpdated.Name);

                var _registerExist = await _repository.ExistAsync(_registerUpdated.Id);

                Assert.True(_registerExist);

                var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
                Assert.NotNull(_registerSelected);

                Assert.Equal(_registerUpdated.Email, _registerSelected.Email);
                Assert.Equal(_registerUpdated.Name, _registerSelected.Name);

                var getAll = await _repository.SelectAsync();

                Assert.NotNull(getAll);
                Assert.True(getAll.Count() > 0);

                var remove = await _repository.DeleteAsync(_registerSelected.Id);

                Assert.True(remove);

                var user = await _repository.FindByLogin("VitorAdm@gmail.com");

                Assert.NotNull(user);
                Assert.Equal("Vitor Ochoa", user.Name);
                Assert.Equal("VitorAdm@gmail.com", user.Email);
            }
        }
    }
}