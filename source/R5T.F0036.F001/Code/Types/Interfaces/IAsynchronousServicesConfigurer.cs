using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0142;


namespace R5T.F0036.F001
{
    [UtilityTypeMarker]
    public interface IAsynchronousServicesConfigurer
    {
        Task ConfigureServices(IServiceCollection services);
    }
}
