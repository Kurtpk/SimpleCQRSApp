using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleCQRSApp.Application.Validators.Base;
using System.Reflection;

namespace SimpleCQRSApp.Application
{
	public static class DependenciesInjectorExtensions
	{
		public static IServiceCollection AddMediatR(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			return services;
		}

		public static IServiceCollection AddValidator(this IServiceCollection services)
		{
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			return services;
		}
	}
}
