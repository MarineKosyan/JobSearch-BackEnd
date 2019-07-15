using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Benivo.Controllers
{
    public class DefaultController : ApiController
    {
		private Context db = new Context();

		[HttpGet]
		public IHttpActionResult GetDataByType(string Type)
		{
			try
			{
				switch (Type)
				{
					case "categories":
						return Ok(db.Categories);
					case "locations":
						return Ok(db.Locations);
					case "employmentTypes":
						return Ok(db.EmploymentTypes);
					case "jobs":
						return Ok(db.Jobs);
					default:
						return Ok(db.Jobs);
				}

			}
			catch (Exception)
			{ 
				return InternalServerError();
			}
		}

		[HttpGet]
		public IHttpActionResult GetFilteredjobs( string location = null, string category = null, string title = null)
		{
			try
			{
				var result = db.Jobs.Join(db.Categories, j => j.CategoryId, c => c.Id, (j, c) => new { j, c })
					.Join(db.Locations, jc => jc.j.LocationId, l => l.Id, (jc, l) => new { jc, l })
					.Join(db.EmploymentTypes, jcl => jcl.jc.j.EmploymentTypeId, e => e.Id, (jcl, e) => new { jcl, e })
					.Select(r => new
					{
						title = r.jcl.jc.j.Title,
						src = r.jcl.jc.j.Company,
						category = r.jcl.jc.c.Name,
						location = r.jcl.l.Name,
						employmentType = r.e.Name,
						bookmarked = r.jcl.jc.j.IsBooked,

					}).Where(x => x.title==title  && x.location==location && x.category == category) ;


				return Ok(result);
			}
			catch (Exception)
			{ 
				return InternalServerError();
			}
		}
	}
}
