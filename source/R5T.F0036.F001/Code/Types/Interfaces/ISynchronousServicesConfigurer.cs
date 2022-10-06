using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0142;


namespace R5T.F0036.F001
{
    [UtilityTypeMarker]
    public interface ISynchronousServicesConfigurer
    {
        void ConfigureServices(IServiceCollection services);
    }
}
