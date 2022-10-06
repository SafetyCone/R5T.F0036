using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0142;

using R5T.F0036.T000;


namespace R5T.F0036.F000
{
    [UtilityTypeMarker]
    public class ServiceProviderBuilder : IHasServices
    {
        public IServiceCollection Services { get; }


        public ServiceProviderBuilder(
            IServiceCollection services)
        {
            this.Services = services;
        }
    }
}
