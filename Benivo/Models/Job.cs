using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benivo.Models
{
	public class Job
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Company { get; set; }
		public int CategoryId { get; set; }
		public int EmploymentTypeId { get; set; }
		public int LocationId { get; set; }
		public bool IsBooked { get; set; }

		public virtual Category Category { get; set; }
		public virtual Location Location { get; set; }
		public virtual EmploymentType EmploymentType { get; set; }
	}
}