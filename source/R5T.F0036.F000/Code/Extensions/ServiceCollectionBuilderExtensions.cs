using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0036.F000;

using Instances = R5T.F0036.F000.Instances;


namespace System
{
    public static class ServiceCollectionBuilderExtensions
    {
		public static ServiceCollection BuildAsServiceCollection(this ServiceCollectionBuilder serviceCollectionBuilder)
        {
			return Instances.ServiceCollectionBuilderOperator.BuildAsServiceCollection(serviceCollectionBuilder);
        }

		public static IServiceCollection BuildAsIServiceCollection(this ServiceCollectionBuilder serviceCollectionBuilder)
        {
			return Instances.ServiceCollectionBuilderOperator.BuildAsIServiceCollection(serviceCollectionBuilder);
		}

		public static IServiceCollection Build(this ServiceCollectionBuilder serviceCollectionBuilder)
        {
            return Instances.ServiceCollectionBuilderOperator.Build(serviceCollectionBuilder);
        }

		public static Task<ServiceCollection> BuildAsServiceCollection(this Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder)
		{
			return Instances.ServiceCollectionBuilderOperator.BuildAsServiceCollection(gettingServiceCollectionBuilder);
		}

		public static Task<IServiceCollection> BuildAsIServiceCollection(this Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder)
		{
			return Instances.ServiceCollectionBuilderOperator.BuildAsIServiceCollection(gettingServiceCollectionBuilder);
		}

		public static Task<IServiceCollection> Build(this Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder)
		{
			return Instances.ServiceCollectionBuilderOperator.Build(gettingServiceCollectionBuilder);
		}

		public static void InServicesContext(this ServiceCollectionBuilder serviceCollectionBuilder,
			Action<IServiceCollection> servicesAction)
		{
			Instances.ServiceCollectionBuilderOperator.InServicesContext(
				serviceCollectionBuilder,
				servicesAction);
		}

		public static Task InServicesContext(this ServiceCollectionBuilder serviceCollectionBuilder,
			Func<IServiceCollection, Task> servicesAction)
		{
			return Instances.ServiceCollectionBuilderOperator.InServicesContext(
				serviceCollectionBuilder,
				servicesAction);
		}

		public static Task InServicesContext(this Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder,
			Action<IServiceCollection> servicesAction)
		{
			return Instances.ServiceCollectionBuilderOperator.InServicesContext(
				gettingServiceCollectionBuilder,
				servicesAction);
		}

		public static Task InServicesContext(this Task<ServiceCollectionBuilder> gettingServiceCollectionBuilder,
			Func<IServiceCollection, Task> servicesAction)
		{
			return Instances.ServiceCollectionBuilderOperator.InServicesContext(
				gettingServiceCollectionBuilder,
				servicesAction);
		}
	}
}
