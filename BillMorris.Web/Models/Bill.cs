using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.AspNet.Mvc.Facebook;
using Newtonsoft.Json;

namespace BillMorris.Web.Models {
	public class Bill {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public double BillTotal { get; set; }

		public string PlaceName { get; set; }

		public FacebookConnection<FacebookPlace> Place { get; set; }

		public IList<Participant> Participants { get; set; }

		public double BillTip { get; set; }
	}
}