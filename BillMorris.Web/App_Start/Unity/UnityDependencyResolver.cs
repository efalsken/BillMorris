using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace Microsoft.Practices.Unity {
	/// <summary>
	/// An implementation of the <see cref="T:System.Web.Http.Dependencies.IDependencyResolver" /> interface that wraps a Unity container.
	/// </summary>
	public sealed class UnityDependencyResolver : IDependencyResolver, IDependencyScope, IDisposable {
		private readonly IUnityContainer container;

		private readonly UnityDependencyResolver.SharedDependencyScope sharedScope;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.WebApi.UnityDependencyResolver" /> class for a container.
		/// </summary>
		/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to wrap with the <see cref="T:System.Web.Http.Dependencies.IDependencyResolver" />
		/// interface implementation.</param>
		public UnityDependencyResolver(IUnityContainer container) {
			if (container == null) {
				throw new ArgumentNullException("container");
			}
			this.container = container;
			this.sharedScope = new UnityDependencyResolver.SharedDependencyScope(container);
		}

		/// <summary>
		/// Reuses the same scope to resolve all the instances.
		/// </summary>
		/// <returns>The shared dependency scope.</returns>
		public IDependencyScope BeginScope() {
			return this.sharedScope;
		}

		/// <summary>
		/// Disposes the wrapped <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />.
		/// </summary>
		public void Dispose() {
			this.container.Dispose();
			this.sharedScope.Dispose();
		}

		/// <summary>
		/// Resolves an instance of the default requested type from the container.
		/// </summary>
		/// <param name="serviceType">The <see cref="T:System.Type" /> of the object to get from the container.</param>
		/// <returns>The requested object.</returns>
		public object GetService(Type serviceType) {
			object obj;
			try {
				obj = this.container.Resolve(serviceType, new ResolverOverride[0]);
			}
			catch (ResolutionFailedException) {
				obj = null;
			}
			return obj;
		}

		public T GetService<T>() where T : class {
			return GetService(typeof(T)) as T;
		}

		/// <summary>
		/// Resolves multiply registered services.
		/// </summary>
		/// <param name="serviceType">The type of the requested services.</param>
		/// <returns>The requested services.</returns>
		public IEnumerable<object> GetServices(Type serviceType) {
			IEnumerable<object> objs;
			try {
				objs = this.container.ResolveAll(serviceType, new ResolverOverride[0]);
			}
			catch (ResolutionFailedException) {
				objs = null;
			}
			return objs;
		}

		public IEnumerable<T> GetServices<T>() where T: class {
			var ret = GetServices(typeof(T));
			if (ret == null) return null;
			return ret.Cast<T>();
		}

		private sealed class SharedDependencyScope : IDependencyScope, IDisposable {
			private IUnityContainer container;

			public SharedDependencyScope(IUnityContainer container) {
				this.container = container;
			}

			public void Dispose() {
			}

			public object GetService(Type serviceType) {
				return this.container.Resolve(serviceType, new ResolverOverride[0]);
			}

			public IEnumerable<object> GetServices(Type serviceType) {
				return this.container.ResolveAll(serviceType, new ResolverOverride[0]);
			}
		}
	}
}