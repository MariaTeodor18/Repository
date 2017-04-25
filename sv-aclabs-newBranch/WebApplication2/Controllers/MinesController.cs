using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Scripts
{
    [Authorize]
    public class MinesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Mines
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            var city = user.Cities.First();
            this.UpdateResources(city);

            return View(city);
        }

        public ActionResult Details(int mineId)
        {
            //iei mina, pasezi la view si afisezi informatii : tipul mine, imagine, descriere a minei, prod curenta, productia pt level urmator
            var mine = dbContext.Mines.Find(mineId);
           
            return View(mine);
        }

        [HttpPost]
        public ActionResult Index(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            mine.Upgrade();
            dbContext.SaveChanges();
            return RedirectToAction("Index","Mines");

            /* return View(new MessageViewModel
            {
                Message = "Upgrade succsessful"
            });*/
        }

        private void UpdateResources(City city)
        {
            var start = DateTime.Now;
            foreach (var res in city.Resources)
            {
                foreach (var mine in city.Mines)
                {
                    if (mine.Type == res.Type)
                    {
                        res.Level += mine.GetProductionPerHour() * (start - res.LastUpdate).TotalHours;
                    }
                }
                res.LastUpdate = start;
            }
            dbContext.SaveChanges();

        }
    }
}
