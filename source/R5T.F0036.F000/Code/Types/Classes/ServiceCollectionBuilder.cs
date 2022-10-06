using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0142;

using R5T.F0036.T000;


namespace R5T.F0036.F000
{
    [UtilityTypeMarker]
    public class ServiceCollectionBuilder : IHasServices
    {
        /// Use an <see cref="IServiceCollection"/>, not a <see cref="ServiceCollection"/> since we are building one. (The action of building is copying all items from the interface to the class.)
        public IServiceCollection Services { get; }


        public ServiceCollectionBuilder(
            IServiceCollection services)
        {
            this.Services = services;
        }
    }
}
