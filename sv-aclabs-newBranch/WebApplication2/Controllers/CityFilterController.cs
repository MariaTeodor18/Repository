using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CityFilterController : Controller
    {

        ApplicationDbContext dbContext = new ApplicationDbContext();

        // GET: CityFilter
        public ActionResult Index(CityFilterViewModel cityFilter)
        {
            IQueryable<City> query = dbContext.Cities;
            if(cityFilter.Name != null)
            {
                query = query.Where(u => u.ApplicationUser.UserName.Contains(cityFilter.Name));
                cityFilter.Results = query.ToList();
            }
            if(cityFilter.Email != null)
            {
                query = query.Where(u => u.ApplicationUser.Email.Contains(cityFilter.Email));
                cityFilter.Results = query.ToList();
            }

            if(cityFilter.MaxTroopCount != null)
            {
                query = query.Where(u => u.Troops.Sum(s => s.TroopCount) > cityFilter.MaxTroopCount);
                cityFilter.Results = query.ToList();
            }

            return View(cityFilter);
        }
    }
}