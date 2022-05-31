using Microsoft.Extensions.DependencyInjection;
using SimpleCQRSApp.Domain.Services;

namespace SimpleCQRSApp.BL
{
	public static class DependenciesInjectorExtensions
	{
		public static IServiceCollection AddProductService(this IServiceCollection services)
		{
			services.AddSingleton<IProductService, ProductService>();
			return services;
		}
	}
}
