using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0036;
using R5T.F0036.T000;

using Instances = R5T.F0036.F000.Instances;


namespace System
{
    public static class IServicesBuilderExtensions
    {
		public static IServicesBuilder ConfigureServices(this IServicesBuilder servicesBuilder,
			Action<IServiceCollection> configureServicesAction)
        {
			return Instances.ServicesBuilderOperator.ConfigureServices(
				servicesBuilder,
				configureServicesAction);
        }

		public static Task<IServicesBuilder> ConfigureServices(this IServicesBuilder servicesBuilder,
			Func<IServiceCollection, Task> configureServicesAction)
		{
			return Instances.ServicesBuilderOperator.ConfigureServices(
				servicesBuilder,
				configureServicesAction);
		}
	}
}
