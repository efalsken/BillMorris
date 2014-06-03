using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Practices.Unity {
	public class PerRequestLifetimeManager : LifetimeManager {
		private readonly object key = new object();

		public override object GetValue() {
			lock (this) {
				if (HttpContext.Current != null &&
						HttpContext.Current.Items.Contains(key))
					return HttpContext.Current.Items[key];
				else
					return null;
			}
		}

		public override void RemoveValue() {
			lock (this) {
				if (HttpContext.Current != null)
					HttpContext.Current.Items.Remove(key);
			}
		}

		public override void SetValue(object newValue) {
			lock (this) {
				if (HttpContext.Current != null)
					HttpContext.Current.Items[key] = newValue;
			}
		}
	}
}