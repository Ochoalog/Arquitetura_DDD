using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependencyRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
      serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer("Persist Security Info=True;Initial Catalog=dbAPI;Data Source=SQO-036\\SQLEXPRESS;User Id=sa;Password=Chocolatra0$;"));
    }
  }
}