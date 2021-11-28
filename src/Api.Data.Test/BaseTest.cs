using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            
        }

        public class DbTeste : IDisposable 
        {
            private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

            public ServiceProvider ServiceProvider { get; private set; }

            public DbTeste()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddDbContext<MyContext>( o => 
                    o.UseSqlServer(@$"Persist Security Info=True; Server=LAPTOP-F8SESO86\SQLEXPRESS;Database={dataBaseName}; Integrated Security=SSPI;"),
                    ServiceLifetime.Transient
                );

                ServiceProvider = serviceCollection.BuildServiceProvider();
                using(var context = ServiceProvider.GetService<MyContext>())
                {
                    context.Database.EnsureCreated();
                }
            }

            public void Dispose() 
            {
                using(var context = ServiceProvider.GetService<MyContext>())
                {
                    context.Database.EnsureDeleted();
                }
            }
        }
    }
}