using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook;
using Microsoft.AspNet.Mvc.Facebook.Client;
using BillMorris.Web.Models;
using BillMorris.Web.Extensions;

namespace BillMorris.Web.Controllers {
	public class HomeController : Controller {
		//[FacebookAuthorize("public_profile", "email", "user_friends")]
		//public async Task<ActionResult> Home(FacebookContext context) {
		//	if (ModelState.IsValid) {
		//		var user = await context.Client.GetCurrentUserAsync<BillMorrisUser>();
		//	}

		//	return View("Error");
		//}

		[AllowAnonymous]
		public async Task<ActionResult> Index(FacebookContext context) {
			if (ModelState.IsValid) {
				var user = await context.Client.GetCurrentUserAsync<FacebookUser>();
				if (string.IsNullOrEmpty(user.Id))
					return RedirectToAction("Anonymous");



				return View(user);
			}

			return Redirect("https://apps.facebook.com/billmorris");
		}

		[AllowAnonymous]
		public ActionResult Anonymous(FacebookContext context) {
			return View("Anonymous");
		}

		// This action will handle the redirects from FacebookAuthorizeFilter when
		// the app doesn't have all the required permissions specified in the FacebookAuthorizeAttribute.
		// The path to this action is defined under appSettings (in Web.config) with the key 'Facebook:AuthorizationRedirectPath'.
		public ActionResult Permissions(FacebookRedirectContext context) {
			if (ModelState.IsValid) {
				return View(context);
			}

			return View("Error");
		}
	}
}
