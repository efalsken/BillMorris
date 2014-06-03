using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BillMorris.Web.Models {
	public class User {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public string FacebookUserId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }
	}
}