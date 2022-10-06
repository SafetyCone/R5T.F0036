using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0036.F000;

using Instances = R5T.F0036.F000.Instances;


namespace System
{
    public static class ServiceProviderBuilderExtensions
    {
        public static ServiceProvider Build(this ServiceProviderBuilder serviceProviderBuilder)
        {
            return Instances.ServiceProviderBuilderOperator.Build(serviceProviderBuilder);
        }

        public static Task<ServiceProvider> Build(this Task<ServiceProviderBuilder> gettingServiceProviderBuilder)
        {
            return Instances.ServiceProviderBuilderOperator.Build(gettingServiceProviderBuilder);
        }

		public static void InServiceProviderContext(this ServiceProviderBuilder serviceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			Instances.ServiceProviderBuilderOperator.InServiceProviderContext(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext(this Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext(
				gettingServiceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext(this ServiceProviderBuilder serviceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext(this Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext(
				gettingServiceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext_IAsyncDisposable(this ServiceProviderBuilder serviceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext_IAsyncDisposable(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext_IAsyncDisposable(this Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Action<IServiceProvider> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext_IAsyncDisposable(
				gettingServiceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext_IAsyncDisposable(this ServiceProviderBuilder serviceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext_IAsyncDisposable(
				serviceProviderBuilder,
				serviceProviderContextAction);
		}

		public static Task InServiceProviderContext_IAsyncDisposable(this Task<ServiceProviderBuilder> gettingServiceProviderBuilder,
			Func<IServiceProvider, Task> serviceProviderContextAction)
		{
			return Instances.ServiceProviderBuilderOperator.InServiceProviderContext_IAsyncDisposable(
				gettingServiceProviderBuilder,
				serviceProviderContextAction);
		}
	}
}
