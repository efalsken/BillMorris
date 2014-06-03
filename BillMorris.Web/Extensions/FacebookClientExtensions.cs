using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BillMorris.Web.Models;
using Facebook;
using Microsoft.AspNet.Mvc.Facebook.Client;
using Microsoft.AspNet.Mvc.Facebook.Authorization;

namespace BillMorris.Web.Extensions {
	public static class FacebookClientExtensions {
		public static async Task<bool> HasPermissions(this FacebookClient client, params string[] permissions) {
			var current = await client.GetCurrentUserPermissionsAsync();
			foreach (var s in permissions)
				if (!current.Contains(s))
					return false;
			return true;
		}
	}
}