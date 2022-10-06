using System;

using R5T.T0132;
using R5T.T0147;

using R5T.F0036.T000;


namespace R5T.F0036.F002
{
	[FunctionalityMarker]
	public partial interface IServicesBuilderOperator : IFunctionalityMarker
	{
		public IServicesBuilder ConfigureServices(IServicesBuilder servicesBuilder,
			IServiceAction serviceAction)
        {
			serviceAction.Run(servicesBuilder.Services);

			return servicesBuilder;
        }
	}
}