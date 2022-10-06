using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0036.F000
{
	[FunctionalityMarker]
	public partial interface IServiceCollectionBuilderOperator : IFunctionalityMarker
	{
		public IServiceCollection BuildAsIServiceCollection(ServiceCollectionBuilder serviceCollectionBuilder)
		{
			var serviceCollection = this.BuildAsServiceCollection(serviceCollectionBuilder);
			return serviceCollection;
		}

		public ServiceCollection BuildAsServiceCollection(ServiceCollectionBuilder serviceCollectionBuilder)
		{
			// Create a copy of the service collection and return that.
			var serviceCollection = new ServiceCollection();

			foreach (var item in serviceCollectionBuilder.Services)
			{
				serviceCollection.Insert(serviceCollection.Count, item);
			}

			return serviceCollection;
		}

		/// <summary>
		/// Chooses <see cref="BuildAsIServiceCollection(ServiceCollectionBuilder)"/> as the default.
		/// </summary>
		public IServiceCollection Build(ServiceCollectionBuilder serviceCollectionBuilder)
		{
			var serviceCollection = this.BuildAsIServiceCollection(serviceCollectionBuilder);
			return serviceCollection;
		}

		public async Task<ServiceCollection> BuildAsServiceCollection(Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder)
		{
			var serviceCollectionBuilder = await gettingServiceCollectionBuilder;

			var serviceCollection = this.BuildAsServiceCollection(serviceCollectionBuilder);
			return serviceCollection;
		}

		public async Task<IServiceCollection> BuildAsIServiceCollection(Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder)
		{
			var serviceCollection = await this.BuildAsServiceCollection(gettingServiceCollectionBuilder);
			return serviceCollection;
		}

		/// <summary>
		/// Chooses <see cref="BuildAsIServiceCollection(Task{ServiceCollectionBuilder})"/> as the default.
		/// </summary>
		public Task<IServiceCollection> Build(Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder)
		{
			return this.BuildAsIServiceCollection(gettingServiceCollectionBuilder);
		}

		public async Task<ServiceCollectionBuilder> ConfigureServices(
			ServiceCollectionBuilder serviceCollectionBuilder,
			Func<IServiceCollection, Task> configureServicesAction)
		{
			await configureServicesAction(serviceCollectionBuilder.Services);

			return serviceCollectionBuilder;
		}

		public ServiceCollectionBuilder ConfigureServices(
			ServiceCollectionBuilder serviceCollectionBuilder,
			Action<IServiceCollection> configureServicesAction)
		{
			configureServicesAction(serviceCollectionBuilder.Services);

			return serviceCollectionBuilder;
		}

		public void InServicesContext(
			ServiceCollectionBuilder serviceCollectionBuilder,
			Action<IServiceCollection> servicesAction)
		{
			var services = serviceCollectionBuilder.Build();

			servicesAction(services);
		}

		public Task InServicesContext(
			ServiceCollectionBuilder serviceCollectionBuilder,
			Func<IServiceCollection, Task> servicesAction)
		{
			var services = serviceCollectionBuilder.Build();

			return servicesAction(services);
		}

		public async Task InServicesContext(
			Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder,
			Action<IServiceCollection> servicesAction)
		{
			var serviceCollectionBuilder = await gettingServiceCollectionBuilder;

			this.InServicesContext(
				serviceCollectionBuilder,
				servicesAction);
		}

		public async Task InServicesContext(
			Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder,
			Func<IServiceCollection, Task> servicesAction)
		{
			var serviceCollectionBuilder = await gettingServiceCollectionBuilder;

			await this.InServicesContext(
				serviceCollectionBuilder,
				servicesAction);
		}

		public ServiceCollectionBuilder New()
		{
			var serviceCollection = F0028.ServiceCollectionOperator.Instance.New();

			var serviceCollectionBuilder = this.New(serviceCollection);
			return serviceCollectionBuilder;
		}

		public ServiceCollectionBuilder New(IServiceCollection services)
		{
			var serviceCollectionBuilder = new ServiceCollectionBuilder(services);
			return serviceCollectionBuilder;
		}
	}
}