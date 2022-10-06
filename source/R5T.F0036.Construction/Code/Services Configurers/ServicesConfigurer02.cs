using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.F0036.Construction
{
    public class ServicesConfigurer02 : F001.IAsynchronousServicesConfigurer
    {
        public Task ConfigureServices(IServiceCollection services)
        {
            // Do nothing.

            return Task.CompletedTask;
        }
    }

}