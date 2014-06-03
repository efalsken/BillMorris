﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillMorris.Web.Models {
	public class FacebookLocation {
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string Zip { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
	}
}