using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Mvc.Facebook;
using Newtonsoft.Json;

namespace BillMorris.Web.Models {
	public class FacebookPlace {
		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("category_list")]
		public IEnumerable<FacebookGraphObjectReference> Categories { get; set; }

		public string Id { get; set; }

		public string Name { get; set; }

		public FacebookLocation Location { get; set; }

	}
}