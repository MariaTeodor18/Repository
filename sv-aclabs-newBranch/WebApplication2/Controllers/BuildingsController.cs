using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BuildingsController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Buildings

        public ActionResult Index()
        {
            var city = dbContext.Cities.FirstOrDefault();
          

            return View(city);
        }

        [HttpPost]
        public ActionResult Build(BuildViewModel build)
        {
            var building = this.dbContext.Buildings.Find(build.BuildingId);
            building.BuildingTypeId = build.SelectedBuildingType;
            building.Level = 1;
            dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

            public ActionResult Build(int buildingId)
        {
            return View(new BuildViewModel
            {
                BuildingId = buildingId,
                BuildingTypes = this.dbContext.BuildingTypes.Select(b => new SelectListItem
                {
                    Value = b.BuildingTypeId.ToString(),
                    Text = b.Name
                })
            });
        }
    }

    public class BuildViewModel
    {
        public int BuildingId { get; set; }
        public IEnumerable<SelectListItem> BuildingTypes { get; set; }
        public int? SelectedBuildingType { get; set; }
    }
}