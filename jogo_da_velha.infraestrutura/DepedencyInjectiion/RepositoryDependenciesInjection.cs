using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace jogo_da_velha.infraestrutura.DepedencyInjectiion
{
  public static class RepositoryDependenciesInjection
  {
    public static IServiceCollection RepositoryAddDependencies(this IServiceCollection services)
    {
      if(services == null)
      {
        throw new ArgumentNullException(nameof(services));
      }

      services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "JogoDaVelha"));

      return services;
    }
  }
}
