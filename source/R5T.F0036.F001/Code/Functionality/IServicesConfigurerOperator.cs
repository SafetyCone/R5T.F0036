using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;

using R5T.F0036.T000;


namespace R5T.F0036.F001
{
	[FunctionalityMarker]
	public partial interface IServicesConfigurerOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Add the synchronous services configurer as a service.
		/// </summary>
		public void AddServicesConfigurer_Synchronous<T>(IServiceCollection services)
			where T : class, ISynchronousServicesConfigurer
		{
			// Choose transient, since services configurer instance will only be used once.
			services.AddTransient<T>();
		}

		/// <summary>
		/// Get the action that will add the synchronous services configurer as a service.
		/// </summary>
		public Action<IServiceCollection> GetAddServicesConfigurer_Synchronous<T>()
			where T : class, ISynchronousServicesConfigurer
		{
			return services => this.AddServicesConfigurer_Synchronous<T>(services);
		}

		/// <summary>
		/// Add the asynchronous services configurer as a service.
		/// </summary>
		public void AddServicesConfigurer<T>(IServiceCollection services)
			where T : class, IAsynchronousServicesConfigurer
		{
			// Choose transient, since services configurer instance will only be used once.
			services.AddTransient<T>();
		}

		/// <summary>
		/// Get the action that will add the asynchronous services configurer as a service.
		/// </summary>
		public Action<IServiceCollection> GetAddServicesConfigurer<T>()
			where T : class, IAsynchronousServicesConfigurer
		{
			return services => this.AddServicesConfigurer<T>(services);
		}

		public Action<IServiceProvider> GetUseServicesConfigurer_Synchronous_ForServiceProvider<TServicesBuilder, TServicesConfigurer>(TServicesBuilder servicesBuilder)
			where TServicesConfigurer : ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			return servicesConfigurerServiceProvider =>
			{
				var servicesConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TServicesConfigurer>();

				this.UseServicesConfigurerInstance_Synchronous(
					servicesBuilder,
					servicesConfigurer);
			};
		}

		public Func<IServiceProvider, Task> GetUseServicesConfigurer_ForServiceProvider<TServicesBuilder, TServicesConfigurer>(TServicesBuilder servicesBuilder)
			where TServicesConfigurer : IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			return async servicesConfigurerServiceProvider =>
			{
				var servicesConfigurer = servicesConfigurerServiceProvider.GetRequiredService<TServicesConfigurer>();

				await this.UseServicesConfigurerInstance(
					servicesBuilder,
					servicesConfigurer);
			};
		}

		public Action<IServiceCollection> GetUseServicesConfigurer_Synchronous_ForServiceCollection<TServicesBuilder, TServicesConfigurer>(TServicesBuilder servicesBuilder)
			where TServicesConfigurer : class, ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			return servicesConfigurerServices =>
			{
				this.UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
					servicesBuilder,
					servicesConfigurerServices);
			};
		}

		public Func<IServiceCollection, Task> GetUseServicesConfigurer_ForServiceCollection<TServicesBuilder, TServicesConfigurer>(TServicesBuilder servicesBuilder)
			where TServicesConfigurer : class, IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			return servicesConfigurerServices =>
			{
				return this.UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
					servicesBuilder,
					servicesConfigurerServices);
			};
		}

		public TServicesBuilder UseServicesConfigurerInstance_Synchronous<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			servicesConfigurer.ConfigureServices(servicesBuilder.Services);

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurerInstance<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			TServicesConfigurer servicesConfigurer)
			where TServicesConfigurer : F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await servicesConfigurer.ConfigureServices(servicesBuilder.Services);

			return servicesBuilder;
		}

		public TServicesBuilder UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			IServiceCollection servicesConfigurerServices)
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			Instances.ServiceProviderBuilderOperator.New(servicesConfigurerServices)
				.ConfigureServices(this.GetAddServicesConfigurer_Synchronous<TServicesConfigurer>())
				.InServiceProviderContext(this.GetUseServicesConfigurer_Synchronous_ForServiceProvider<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			IServiceCollection servicesConfigurerServices)
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await Instances.ServiceProviderBuilderOperator.New(servicesConfigurerServices)
				.ConfigureServices(this.GetAddServicesConfigurer<TServicesConfigurer>())
				.InServiceProviderContext(this.GetUseServicesConfigurer_ForServiceProvider<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			Task<IServiceCollection> gettingServicesConfigurerServices)
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			var servicesConfigurerServices = await gettingServicesConfigurerServices;

			return this.UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				servicesConfigurerServices);
		}

		public async Task<TServicesBuilder> UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			Task<IServiceCollection> gettingServicesConfigurerServices)
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			var servicesConfigurerServices = await gettingServicesConfigurerServices;

			var output = await this.UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				servicesConfigurerServices);

			return output;
		}

		public async Task<TServicesBuilder> UseServicesConfigurerSync_IAsyncDisposable<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			IServiceCollection servicesConfigurerServices)
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await Instances.ServiceProviderBuilderOperator.New(servicesConfigurerServices)
				.ConfigureServices(this.GetAddServicesConfigurer_Synchronous<TServicesConfigurer>())
				.InServiceProviderContext_IAsyncDisposable(
					this.GetUseServicesConfigurer_Synchronous_ForServiceProvider<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurer_IAsyncDisposable<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder serviceProviderBuilder,
			IServiceCollection servicesConfigurerServices)
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await Instances.ServiceProviderBuilderOperator.New(servicesConfigurerServices)
				.ConfigureServices(this.GetAddServicesConfigurer<TServicesConfigurer>())
				.InServiceProviderContext_IAsyncDisposable(
					this.GetUseServicesConfigurer_ForServiceProvider<TServicesBuilder, TServicesConfigurer>(serviceProviderBuilder))
				;

			return serviceProviderBuilder;
		}

		public TServicesBuilder UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder)
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			return this.UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				F0028.ServiceCollectionOperator.Instance.New());
		}

		public async Task<TServicesBuilder> UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder)
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await this.UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
				servicesBuilder,
				F0028.ServiceCollectionOperator.Instance.New());

			return servicesBuilder;
		}

		public TServicesBuilder UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			Action<IServiceCollection> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			Instances.ServiceCollectionBuilderOperator.New()
				.ConfigureServices(configureServicesConfigurerServicesAction)
				.InServicesContext(this.GetUseServicesConfigurer_Synchronous_ForServiceCollection<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurerSync<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			Func<IServiceCollection, Task> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, F001.ISynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await Instances.ServiceCollectionBuilderOperator.New()
				.ConfigureServices(configureServicesConfigurerServicesAction)
				.InServicesContext(this.GetUseServicesConfigurer_Synchronous_ForServiceCollection<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			Action<IServiceCollection> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await Instances.ServiceCollectionBuilderOperator.New()
				.ConfigureServices(configureServicesConfigurerServicesAction)
				.InServicesContext(this.GetUseServicesConfigurer_ForServiceCollection<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}

		public async Task<TServicesBuilder> UseServicesConfigurer<TServicesBuilder, TServicesConfigurer>(
			TServicesBuilder servicesBuilder,
			Func<IServiceCollection, Task> configureServicesConfigurerServicesAction)
			where TServicesConfigurer : class, F001.IAsynchronousServicesConfigurer
			where TServicesBuilder : IServicesBuilder
		{
			await Instances.ServiceCollectionBuilderOperator.New()
				.ConfigureServices(configureServicesConfigurerServicesAction)
				.InServicesContext(this.GetUseServicesConfigurer_ForServiceCollection<TServicesBuilder, TServicesConfigurer>(servicesBuilder))
				;

			return servicesBuilder;
		}
	}
}