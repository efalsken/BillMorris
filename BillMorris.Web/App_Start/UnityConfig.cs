using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BillMorris.Web {
	/// <summary>
	/// Specifies the Unity configuration for the main container.
	/// </summary>
	public class UnityConfig {
		#region Unity Container
		private static Lazy<IUnityContainer> lazyContainer = new Lazy<IUnityContainer>(() => {
			var container = new UnityContainer();
			RegisterTypes(container);
			return container;
		});

		/// <summary>
		/// Gets the configured Unity container.
		/// </summary>
		public static IUnityContainer GetConfiguredContainer() {
			return lazyContainer.Value;
		}

		public static T GetService<T>(params ResolverOverride[] overrides) {
			return lazyContainer.Value.Resolve<T>(overrides);
		}
		#endregion

		public static void Configure(HttpConfiguration config) {
			config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
		}

		/// <summary>Registers the type mappings with the Unity container.</summary>
		/// <param name="container">The unity container to configure.</param>
		/// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
		/// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
		private static void RegisterTypes(IUnityContainer container) {
			// NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
			container.LoadConfiguration();

			//container.RegisterType<Contexts.BillMorrisContext>(new PerRequestLifetimeManager(), new InjectionConstructor("BillMorrisConnectionString"));

		}
	}
}