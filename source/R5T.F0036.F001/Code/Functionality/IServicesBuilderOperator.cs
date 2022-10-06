using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F001
{
	[FunctionalityMarker]
	public partial interface IServicesBuilderOperator : IFunctionalityMarker,
		F000.IServicesBuilderOperator
	{
		public Action<IServicesBuilder> GetUseServicesConfigurer_Synchronous<TServicesConfigurer>()
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
        {
			return servicesBuilder => servicesBuilder.UseServicesConfigurer_Synchronous<TServicesConfigurer>();
        }

		public Func<IServicesBuilder, Task> GetUseServicesConfigurer<TServicesConfigurer>()
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
		{
			return servicesBuilder => servicesBuilder.UseServicesConfigurer<TServicesConfigurer>();
		}
	}
}