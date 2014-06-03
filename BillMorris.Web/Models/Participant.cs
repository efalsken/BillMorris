using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BillMorris.Web.Models {
	public class Participant {
		[Required]
		public FacebookUser User { get; set; }

		[Required]
		public Bill Bill { get; set; }

		public double Amount { get; set; }
	}
}