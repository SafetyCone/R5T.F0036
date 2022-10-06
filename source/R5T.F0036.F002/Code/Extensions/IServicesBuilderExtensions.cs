using System;

using R5T.T0147;

using R5T.F0036.T000;


namespace System
{
    public static class IServicesBuilderExtensions
    {
		public static IServicesBuilder ConfigureServices(this IServicesBuilder servicesBuilder,
			IServiceAction serviceAction)
		{
			serviceAction.Run(servicesBuilder.Services);

			return servicesBuilder;
		}
	}
}
