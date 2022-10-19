using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0036.T000;

using Instances = R5T.F0036.F000.Instances;


namespace System
{
    public static class IHasServicesExtensions
    {
        public static THasServices ConfigureServices<THasServices>(this THasServices hasServices,
            Action<IServiceCollection> configureServicesAction)
            where THasServices : IHasServices
        {
            Instances.HasServicesOperator.ConfigureServices(
                hasServices,
                configureServicesAction);

            return hasServices;
        }

        public static async Task<THasServices> ConfigureServices<THasServices>(this THasServices hasServices,
            Func<IServiceCollection, Task> configureServicesAction)
            where THasServices : IHasServices
        {
            await Instances.HasServicesOperator.ConfigureServices(
                hasServices,
                configureServicesAction);

            return hasServices;
        }

        public static THasServices ConfigureServices<THasServices>(this THasServices hasServices,
            Action<IServicesBuilder> servicesBuilderAction)
            where THasServices : IHasServices
        {
            Instances.HasServicesOperator.ConfigureServices(
                hasServices,
                servicesBuilderAction);

            return hasServices;
        }

        public static async Task<THasServices> ConfigureServices<THasServices>(this Task<THasServices> gettingHasServices,
            Action<IServicesBuilder> servicesBuilderAction)
            where THasServices : IHasServices
        {
            var hasServices = await gettingHasServices;

            return hasServices.ConfigureServices(servicesBuilderAction);
        }

        public static async Task<THasServices> ConfigureServices<THasServices>(this THasServices hasServices,
            Func<IServicesBuilder, Task> servicesBuilderAction)
            where THasServices : IHasServices
        {
            await Instances.HasServicesOperator.ConfigureServices(
                hasServices,
                servicesBuilderAction);

            return hasServices;
        }

        public static async Task<THasServices> ConfigureServices<THasServices>(this Task<THasServices> gettingHasServices,
            Func<IServicesBuilder, Task> servicesBuilderAction)
            where THasServices : IHasServices
        {
            var hasServices = await gettingHasServices;

            return await hasServices.ConfigureServices(servicesBuilderAction);
        }
    }
}
