[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LudwigRecipe.Api.Boot.NinjectBootStrapper), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LudwigRecipe.Api.Boot.NinjectBootStrapper), "Stop")]

namespace LudwigRecipe.Api.Boot
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using Ninject.Web.Common.WebHost;

	public class NinjectBootStrapper
	{
		private static readonly Bootstrapper _bootStrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			_bootStrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			_bootStrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			StandardKernel kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);
				return kernel;
			}
			catch (Exception exception)
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here. The current code loads all NinjectModules from all Assemblies.
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			string[] assemblyNames = { "LudwigRecipe.*.dll"};
			kernel.Load(assemblyNames);
		}
	}

}
