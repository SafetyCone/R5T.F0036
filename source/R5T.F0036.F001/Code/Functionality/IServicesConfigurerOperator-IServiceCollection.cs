using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F001
{
	public partial interface IServicesConfigurerOperator : IFunctionalityMarker
	{
		public IServiceCollection UseServicesConfigurerInstance_Synchronous<TServicesConfigurer>(
			IServiceCollection services,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : ISynchronousServicesConfigurer
        {
			servicesConfigurer.ConfigureServices(services);

			return services;
        }

		public async Task<IServiceCollection> UseServicesConfigurerInstance<TServicesConfigurer>(
			IServiceCollection services,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : IAsynchronousServicesConfigurer
		{
			await servicesConfigurer.ConfigureServices(services);

			return services;
		}

		public Action<IServiceProvider> GetUseServicesConfigurer_Synchronous_ForServiceProvider<TServicesConfigurer>(IServiceCollection services)
			where TServicesConfigurer : ISynchronousServicesConfigurer
		{
			return servicesConfigurerServiceProvider =>
			{
				var servicesConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TServicesConfigurer>();

				this.UseServicesConfigurerInstance_Synchronous(
					services,
					servicesConfigurer);
			};
		}

		public Func<IServiceProvider, Task> GetUseServicesConfigurer_ForServiceProvider<TServicesConfigurer>(IServiceCollection services)
			where TServicesConfigurer : IAsynchronousServicesConfigurer
		{
			return async servicesConfigurerServiceProvider =>
			{
				var servicesConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TServicesConfigurer>();

				await this.UseServicesConfigurerInstance(
					services,
					servicesConfigurer);
			};
		}

		public IServiceCollection UseServicesConfigurer_Synchronous<TServicesConfigurer>(
			IServiceCollection services,
			IServiceCollection serviceConfigurerServices)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
        {
			Instances.ServiceProviderBuilderOperator.New(serviceConfigurerServices)
				.ConfigureServices(this.GetAddServicesConfigurer_Synchronous<TServicesConfigurer>())
				.InServiceProviderContext(this.GetUseServicesConfigurer_Synchronous_ForServiceProvider<TServicesConfigurer>(services))
				;

			return services;
        }

		public async Task<IServiceCollection> UseServicesConfigurer<TServicesConfigurer>(
			IServiceCollection services,
			IServiceCollection serviceConfigurerServices)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
		{
			await Instances.ServiceProviderBuilderOperator.New(serviceConfigurerServices)
				.ConfigureServices(this.GetAddServicesConfigurer<TServicesConfigurer>())
				.InServiceProviderContext(this.GetUseServicesConfigurer_ForServiceProvider<TServicesConfigurer>(services))
				;

			return services;
		}

		public IServiceCollection UseServicesConfigurer_Synchronous<TServicesConfigurer>(
			IServiceCollection services)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
		{
			var servicesConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			return this.UseServicesConfigurer_Synchronous<TServicesConfigurer>(
				services,
				servicesConfigurerServices);
		}

		public Task<IServiceCollection> UseServicesConfigurer<TServicesConfigurer>(
			IServiceCollection services)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
		{
			var servicesConfigurerServices = F0028.ServicesOperator.Instance.GetEmptyServiceCollection();

			return this.UseServicesConfigurer<TServicesConfigurer>(
				services,
				servicesConfigurerServices);
		}
	}
}