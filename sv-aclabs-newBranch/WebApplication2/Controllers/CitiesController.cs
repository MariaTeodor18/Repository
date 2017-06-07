using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace WebApplication2.Controllers
{
    public class CitiesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Cities
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            
            return View(user);
        }

        [HttpPost]
        public ActionResult AddCity()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);

            user.Cities.Add(new City
            {
                Mines = new List<Mine>()
                           {
                               new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Clay,
                                   Description = "Clay is produced here. By increasing its level, you increase the clay production",
                                   MineStyle = "mine-clay-1",
                               },
                                new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Clay,
                                   Description = "Clay is produced here. By increasing its level, you increase the clay production",
                                   MineStyle = "mine-clay-2",
                               },
                                 new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Clay,
                                   Description = "Clay is produced here. By increasing its level, you increase the clay production",
                                   MineStyle = "mine-clay-3",
                               },
                                 new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wood,
                                   Description = "Wood is produced here. By increasing its level, you increase the wood production",
                                   MineStyle = "mine-wood-1",
                               },
                                new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wood,
                                   Description = "Wood is produced here. By increasing its level, you increase the wood production",
                                   MineStyle = "mine-wood-2",
                               },
                                 new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wood,
                                   Description = "Wood is produced here. By increasing its level, you increase the wood production",
                                   MineStyle = "mine-wood-3",
                               },
                                new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Iron,
                                   Description = "Iron is produced here. By increasing its level, you increase the iron production",
                                   MineStyle = "mine-iron-1",
                               },
                                 new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Iron,
                                   Description = "Iron is produced here. By increasing its level, you increase the iron production",
                                   MineStyle = "mine-iron-2",
                               },
                                new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wheat,
                                   Description = "Wheat is produced here. By increasing its level, you increase the wheat production",
                                   MineStyle = "mine-wheat-1",
                               },
                                 new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wheat,
                                   Description = "Wheat is produced here. By increasing its level, you increase the wheat production",
                                   MineStyle = "mine-wheat-2",
                               },
                                  new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wheat,
                                   Description = "Wheat is produced here. By increasing its level, you increase the wheat production",
                                   MineStyle = "mine-wheat-3",
                               },
                                   new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wheat,
                                   Description = "Wheat is produced here. By increasing its level, you increase the wheat production",
                                   MineStyle = "mine-wheat-4",
                               },
                                    new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wheat,
                                   Description = "Wheat is produced here. By increasing its level, you increase the wheat production",
                                   MineStyle = "mine-wheat-5",
                               },
                                     new Mine
                               {
                                   Level =0,
                                   Type = ResourceType.Wheat,
                                   Description = "Wheat is produced here. By increasing its level, you increase the wheat production",
                                   MineStyle = "mine-wheat-6",
                               },
                           },
                Resources = new List<Resource>
                           {
                               new Resource
                               {
                                   Type = ResourceType.Clay,
                                   LastUpdate = DateTime.Now,
                               },
                               new Resource
                               {
                                   Type = ResourceType.Iron,
                                   LastUpdate = DateTime.Now,
                               },
                               new Resource
                               {
                                   Type = ResourceType.Wheat,
                                   LastUpdate = DateTime.Now,
                               },
                               new Resource
                               {
                                   Type = ResourceType.Wood,
                                   LastUpdate = DateTime.Now,
                               },
                           },
                Buildings = new List<Building>
                            {
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                                new Building
                                {
                                    Level = 0,
                                    BuildingTypeId = null,
                                },
                            }
            });
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Cities");
        }
    }
}