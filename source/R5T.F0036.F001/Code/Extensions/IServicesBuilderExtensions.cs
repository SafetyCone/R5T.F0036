using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0036.T000;
using R5T.F0036.F001;

using Instances = R5T.F0036.F001.Instances;


namespace System
{
    public static class IServicesBuilderExtensions
    {
		public static IServicesBuilder UseServicesConfigurerInstance_Synchronous<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurerInstance_Synchronous(
				servicesBuilder,
				servicesConfigurer);
		}

		public static Task<IServicesBuilder> UseServicesConfigurerInstance<TServiceConfigurer>(this IServicesBuilder servicesBuilder,
			TServiceConfigurer serviceConfigurer)
			where TServiceConfigurer : class, IAsynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurerInstance(
				servicesBuilder,
				serviceConfigurer);
		}

		public static IServicesBuilder UseServicesConfigurer_Synchronous<TServicesConfigurer>(this IServicesBuilder servicesBuilder)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurerSync<IServicesBuilder, TServicesConfigurer>(servicesBuilder);
		}

		public static Task<IServicesBuilder> UseServicesConfigurer<TServicesConfigurer>(this IServicesBuilder servicesBuilder)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurer<IServicesBuilder, TServicesConfigurer>(servicesBuilder);
		}

		public static IServicesBuilder UseServicesConfigurer_Synchronous<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			IServiceCollection servicesConfigurerServices)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurerSync<IServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				servicesConfigurerServices);
		}

		public static IServicesBuilder UseServicesConfigurer_Synchronous<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			Action<IServiceCollection> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurerSync<IServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				configureServicesConfigurerServicesAction);
		}

		public static Task<IServicesBuilder> UseServicesConfigurer_Synchronous<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			Func<IServiceCollection, Task> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurerSync<IServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				configureServicesConfigurerServicesAction);
		}

		public static Task<IServicesBuilder> UseServicesConfigurer<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			IServiceCollection servicesConfigurerServices)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurer<IServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				servicesConfigurerServices);
		}

		public static Task<IServicesBuilder> UseServicesConfigurer<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			Action<IServiceCollection> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurer<IServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				configureServicesConfigurerServicesAction);
		}

		public static Task<IServicesBuilder> UseServicesConfigurer<TServicesConfigurer>(this IServicesBuilder servicesBuilder,
			Func<IServiceCollection, Task> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
		{
			return Instances.ServicesConfigurerOperator.UseServicesConfigurer<IServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				configureServicesConfigurerServicesAction);
		}
	}
}
