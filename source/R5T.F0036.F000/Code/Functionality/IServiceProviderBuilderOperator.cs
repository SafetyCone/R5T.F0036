using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0036.F000
{
	[FunctionalityMarker]
	public partial interface IServiceProviderBuilderOperator : IFunctionalityMarker
	{
		public async Task<ServiceProvider> Build(
			Task<ServiceProviderBuilder> gettingServiceProviderBuilder)
		{
			var serviceProviderBuilder = await gettingServiceProviderBuilder;

			var serviceProvider = this.Build(serviceProviderBuilder);
			return serviceProvider;
		}

		public ServiceProvider Build(ServiceProviderBuilder serviceProviderBuilder)
		{
			var serviceProvider = serviceProviderBuilder.Services.BuildServiceProvider();
			return serviceProvider;
		}

		public void InServiceProviderContext(
			ServiceProviderBuilder serviceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			using var serviceProvider = this.Build(serviceProviderBuilder);

			serviceProviderContextAction(serviceProvider);
		}

		public async Task InServiceProviderContext(
			Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			var serviceProviderBuilder = await gettingServiceProviderBuilder;

			this.InServiceProviderContext(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public Task InServiceProviderContext(
			ServiceProviderBuilder serviceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			using var serviceProvider = this.Build(serviceProviderBuilder);

			// TODO, test if the task needs to be awaited due to 
			return serviceProviderContextAction(serviceProvider);
		}

		public async Task InServiceProviderContext(
			Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			var serviceProviderBuilder = await gettingServiceProviderBuilder;

			await this.InServiceProviderContext(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public async Task InServiceProviderContext_IAsyncDisposable(
			ServiceProviderBuilder serviceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			await using var serviceProvider = this.Build(serviceProviderBuilder);

			serviceProviderContextAction(serviceProvider);
		}

		public async Task InServiceProviderContext_IAsyncDisposable(
			Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			var serviceProviderBuilder = await gettingServiceProviderBuilder;

			await this.InServiceProviderContext_IAsyncDisposable(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public async Task InServiceProviderContext_IAsyncDisposable(
			ServiceProviderBuilder serviceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			await using var serviceProvider = this.Build(serviceProviderBuilder);

			await serviceProviderContextAction(serviceProvider);
		}

		public async Task InServiceProviderContext_IAsyncDisposable(
			Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			var serviceProviderBuilder = await gettingServiceProviderBuilder;

			await this.InServiceProviderContext_IAsyncDisposable(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public ServiceProviderBuilder New()
		{
			var serviceProviderBuilder = this.New(new ServiceCollection());
			return serviceProviderBuilder;
		}

		public ServiceProviderBuilder New(IServiceCollection services)
		{
			var serviceProviderBuilder = new ServiceProviderBuilder(services);
			return serviceProviderBuilder;
		}
	}
}