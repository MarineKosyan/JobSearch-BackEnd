namespace Benivo.Migrations
{
	using Benivo.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Benivo.Context>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Benivo.Context context)
		{
			
			Category category1 = new Category { Name = "Software Development" };
			Category category2 = new Category { Name = "Marketing" };
			Category category3 = new Category { Name = "Finance Managment" };
			Category category4 = new Category { Name = "Economics" };
			Category category5 = new Category { Name = "Art/Design" };

			Location location1 = new Location { Name = "San Francisco,CA,US" };
			Location location2 = new Location { Name = "Yerevan, Armenia" };
			Location location3 = new Location { Name = "Panama City, Florida Area" };
			Location location4 = new Location { Name = "Vienna, Australia" };
			Location location5 = new Location { Name = "Helsinki, Finland" };

			EmploymentType emp1 = new EmploymentType() { Name = "Full Time" };
			EmploymentType emp2 = new EmploymentType() { Name = "Part Time" };
			EmploymentType emp3 = new EmploymentType() { Name = "Contractor" };
			EmploymentType emp4 = new EmploymentType() { Name = "Intern" };
			EmploymentType emp5 = new EmploymentType() { Name = "Seasonal/Temp" };

			Job job1 = new Job
			{
				Title = "Full-stack developer",
				Company = "Benivo",
				EmploymentType = new EmploymentType() { Name = "Full Time" },
				Category = new Category() { Name = "Software Development" },
				Location = new Location() { Name = "Yerevan, Armenia" },
				IsBooked = true

			};
			Job job2 = new Job
			{
				Title = "Marketolog",
				Company = "Deel",
				EmploymentType = new EmploymentType() { Name = "Full Time" },
				Category = new Category() { Name = "Marketingt" },
				Location = new Location() { Name = "San Francisco,CA,US" },
				IsBooked = false
			};

			context.Categories.AddOrUpdate(category1, category2, category3, category4, category5);
			context.Locations.AddOrUpdate(location1, location2, location3, location4, location5);
			context.EmploymentTypes.AddOrUpdate(emp1, emp2, emp3, emp4, emp5);
			context.Jobs.AddOrUpdate(job1, job2);
		}
	}
}


