﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.Facebook;
using Newtonsoft.Json;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// http://go.microsoft.com/fwlink/?LinkId=301877

namespace BillMorris.Web.Models {
	public class FacebookFriend {
		[Key]
		public string Id { get; set; }

		public string Name { get; set; }
		public string Link { get; set; }

		[FacebookFieldModifier("height(100).width(100)")] // This sets the picture height and width to 100px.
		public FacebookConnection<FacebookPicture> Picture { get; set; }

	}
}
