using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F000
{
	[FunctionalityMarker]
	public partial interface IServicesBuilderOperator : IFunctionalityMarker
	{
        public IServicesBuilder ConfigureServices(IServicesBuilder servicesBuilder,
			Action<IServiceCollection> configureServicesAction)
        {
			configureServicesAction(servicesBuilder.Services);

			return servicesBuilder;
        }

		public async Task<IServicesBuilder> ConfigureServices(IServicesBuilder servicesBuilder,
			Func<IServiceCollection, Task> configureServicesAction)
		{
			await configureServicesAction(servicesBuilder.Services);

			return servicesBuilder;
		}
	}
}