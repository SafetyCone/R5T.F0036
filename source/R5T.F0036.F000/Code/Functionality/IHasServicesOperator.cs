using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F000
{
	[FunctionalityMarker]
	public partial interface IHasServicesOperator : IFunctionalityMarker
	{
		public void ConfigureServices(
			IHasServices hasServices,
			Action<IServiceCollection> configureServicesAction)
		{
			configureServicesAction(hasServices.Services);
		}

		public Task ConfigureServices(
			IHasServices hasServices,
			Func<IServiceCollection, Task> servicesBuilderAction)
		{
			return servicesBuilderAction(hasServices.Services);
		}

		public void ConfigureServices(
			IHasServices hasServices,
			Action<IServicesBuilder> servicesBuilderAction)
        {
			var servicesBuilder = new ServicesBuilder(hasServices.Services);

			servicesBuilderAction(servicesBuilder);
        }

		public Task ConfigureServices(
			IHasServices hasServices,
			Func<IServicesBuilder, Task> servicesBuilderAction)
		{
			var servicesBuilder = new ServicesBuilder(hasServices.Services);

			return servicesBuilderAction(servicesBuilder);
		}
	}
}
