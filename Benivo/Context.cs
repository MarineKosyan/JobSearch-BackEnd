using Benivo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Benivo
{
	public class Context : DbContext
	{

		public DbSet<Job> Jobs { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<EmploymentType> EmploymentTypes { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}