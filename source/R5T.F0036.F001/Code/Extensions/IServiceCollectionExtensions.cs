using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0036.F001;


public static class IServiceCollectionExtensions
{
	public static IServiceCollection UseServicesConfigurerInstance_Synchronous<TServicesConfigurer>(this IServiceCollection services,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
	{
		return Instances.ServicesConfigurerOperator.UseServicesConfigurerInstance_Synchronous(
			services,
			servicesConfigurer);
	}

	public static Task<IServiceCollection> UseServicesConfigurerInstance<TServicesConfigurer>(this IServiceCollection services,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
	{
		return Instances.ServicesConfigurerOperator.UseServicesConfigurerInstance(
			services,
			servicesConfigurer);
	}

	public static IServiceCollection UseServicesConfigurer_Synchronous<TServicesConfigurer>(this IServiceCollection services)
        where TServicesConfigurer : class, ISynchronousServicesConfigurer
    {
		return Instances.ServicesConfigurerOperator.UseServicesConfigurer_Synchronous<TServicesConfigurer>(services);
	}

	public static Task<IServiceCollection> UseServicesConfigurer<TServicesConfigurer>(this IServiceCollection services)
		where TServicesConfigurer : class, IAsynchronousServicesConfigurer
	{
		return Instances.ServicesConfigurerOperator.UseServicesConfigurer<TServicesConfigurer>(services);
	}
}

