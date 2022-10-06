using System;
using System.Threading.Tasks;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F000
{
	[FunctionalityMarker]
	public partial interface IServiceCollectionOperator : IFunctionalityMarker
	{
		public ServiceCollectionBuilder ConfigureServices(
			Action<IServicesBuilder> servicesBuilderAction)
        {
			var serviceCollectionBuilder = this.New();

			serviceCollectionBuilder.ConfigureServices(servicesBuilderAction);

			return serviceCollectionBuilder;
        }

		public async Task<ServiceCollectionBuilder> ConfigureServices(
			Func<IServicesBuilder, Task> servicesBuilderAction)
		{
			var serviceCollectionBuilder = this.New();

			await serviceCollectionBuilder.ConfigureServices(servicesBuilderAction);

			return serviceCollectionBuilder;
		}

		public ServiceCollectionBuilder New()
        {
			var serviceCollectionBuilder = Instances.ServiceCollectionBuilderOperator.New();
			return serviceCollectionBuilder;
		}
	}
}