using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0036.Construction
{
	[FunctionalityMarker]
	public partial interface IExamples : IFunctionalityMarker
	{
		public async Task ConfigureServiceProvider_Asynchronous()
		{
			using var serviceProvider = await F0036.Instances.ServiceProvider
				.ConfigureServices(async servicesBuilder =>
				{
					await servicesBuilder.UseServicesConfigurer<ServicesConfigurer02>();
				})
				.ConfigureServices(F0036.Instances.ServicesBuilderOperator.GetUseServicesConfigurer_Synchronous<ServicesConfigurer01>())
				.ConfigureServices(F0036.Instances.ServicesBuilderOperator.GetUseServicesConfigurer<ServicesConfigurer02>())
				.Build();
		}

		public void ConfigureServiceProvider_Synchronous()
        {
			using var serviceProvider = F0036.Instances.ServiceProvider
				.ConfigureServices(servicesBuilder =>
				{
					servicesBuilder.UseServicesConfigurer_Synchronous<ServicesConfigurer01>();
				})
				.Build();
        }

		public void ConfigureServices_Asynchronous()
		{
			var services = F0036.Instances.Services
				.ConfigureServices(async servicesBuilder =>
				{
					servicesBuilder.ConfigureServices(services =>
					{

					});

					await servicesBuilder.ConfigureServices(services =>
                    {
						return Task.CompletedTask;
                    });
				})
				.Build();
		}

		public void ConfigureServices_Synchronous()
        {
			var services = F0036.Instances.Services
				.ConfigureServices(servicesBuilder =>
				{
					servicesBuilder.ConfigureServices(services =>
					{

					});
				})
				.Build();
        }
	}
}