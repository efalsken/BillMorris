using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BillMorris.Web.Models;

namespace BillMorris.Web.Contexts {
	public partial class BillMorrisContext : DbContext {
		public BillMorrisContext() : this("BillMorrisConnectionString") { }
		public BillMorrisContext(string nameOrConnectionString) : base (nameOrConnectionString) {
			Configuration.AutoDetectChangesEnabled = true;
			Configuration.LazyLoadingEnabled = true;
		}

		public DbSet<FacebookUser> Users { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<Participant> Participant { get; set; }
	}
}