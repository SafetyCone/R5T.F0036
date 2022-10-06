using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0142;


namespace R5T.F0036.T000
{
    [UtilityTypeMarker]
    public class ServicesBuilder : IServicesBuilder
    {
        public IServiceCollection Services { get; }


        public ServicesBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
