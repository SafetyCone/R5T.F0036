using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F000
{
	[FunctionalityMarker]
	public partial interface IServiceProviderOperator : IFunctionalityMarker
	{
		public ServiceProviderBuilder ConfigureServices(
			Action<IServicesBuilder> servicesBuilderAction)
		{
			var serviceProviderBuilder = this.New();

			serviceProviderBuilder.ConfigureServices(servicesBuilderAction);

			return serviceProviderBuilder;
		}

		public async Task<ServiceProviderBuilder> ConfigureServices(
			Func<IServicesBuilder, Task> servicesBuilderAction)
		{
			var serviceProviderBuilder = this.New();

			await serviceProviderBuilder.ConfigureServices(servicesBuilderAction);

			return serviceProviderBuilder;
		}

		public ServiceProviderBuilder New()
		{
			var serviceProviderBuilder = Instances.ServiceProviderBuilderOperator.New();
			return serviceProviderBuilder;
		}

		public ServiceProviderBuilder New(IServiceCollection services)
		{
			var serviceProviderBuilder = Instances.ServiceProviderBuilderOperator.New(services);
			return serviceProviderBuilder;
		}
	}
}