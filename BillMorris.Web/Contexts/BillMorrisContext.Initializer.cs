using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using BillMorris.Web.Models;

namespace BillMorris.Web.Contexts {
	public partial class BillMorrisContext : DbContext{
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			// put model configuration here.

			modelBuilder.Entity<Bill>().HasMany(t => t.Participants).WithRequired(t => t.Bill);
			modelBuilder.Entity<Bill>().HasOptional(t => t.Place);

			modelBuilder.Entity<Participant>().HasKey(t => new { ParticipantId = t.User.Id, BillId = t.Bill.Id });
		}
	}
}