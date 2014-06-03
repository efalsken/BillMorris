using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.Facebook;
using Newtonsoft.Json;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// http://go.microsoft.com/fwlink/?LinkId=301877

namespace BillMorris.Web.Models {
	public class FacebookUser {
		[Key]
		public string Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		[JsonProperty("picture")] // This renames the property to picture.
		[FacebookFieldModifier("type(large)")] // This sets the picture size to large.
		public FacebookConnection<FacebookPicture> ProfilePicture { get; set; }

		public FacebookGroupConnection<FacebookFriend> Friends { get; set; }
	}
}
