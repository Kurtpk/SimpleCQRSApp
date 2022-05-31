using Microsoft.Extensions.DependencyInjection;
using SimpleCQRSApp.Domain.Repositories;
using SimpleCQRSApp.Infra.DB.Repositories;

namespace SimpleCQRSApp.Infra.DB
{
	public static class DependenciesInjectorExtensions
	{
		public static IServiceCollection AddUnitOfWorkFactory(this IServiceCollection services)
		{
			services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
			return services;
		}
	}
}
