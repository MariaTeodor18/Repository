using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using DataAccess;
using BusinessLogic;

namespace WebApplication2.Scripts
{
    [Authorize]
    public class MinesController : Controller
    {
        private MinesService minesService;

        public MinesController()
        {
            minesService = new MinesService();
        }

        // GET: Mines
        public ActionResult Index(int? cityId)
        {  
            var userId = this.User.Identity.GetUserId();
            var city = minesService.UpdateResources(userId);

            return View(city);
        }

       /* public ActionResult Details(int mineId)
        {
            //iei mina, pasezi la view si afisezi informatii : tipul mine, imagine, descriere a minei, prod curenta, productia pt level urmator
            var mine = dbContext.Mines.Find(mineId);
           
            return View(mine);
        }*/

       /// [HttpPost]
        /*public ActionResult Index(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            mine.Upgrade();
            dbContext.SaveChanges();
            return RedirectToAction("Index","Mines");

            /* return View(new MessageViewModel
            {
                Message = "Upgrade succsessful"
            });*/
        //}

      /*  private void UpdateResources(City city)
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

        }*/

      /*  [HttpPost]
        public ActionResult Upgrade(int mineId, int cityId, bool fastUpgrade)
        {
            var mine = this.dbContext.Mines.Find(mineId);
            var city = mine.City;
            var needed = mine.GetUpgradeRequirements();
            var have = city.Resources;

            if (fastUpgrade)
            {
                needed = needed.Select(n => (ammount: n.amount * 10, type: n.type)).ToArray();
            }

            /*  var amounts = needed.Select(m => m.amount);*/

         /*   var r = needed.Join(have, n => n.type, h => h.Type, (n, h) => (needed: n, have: h));

            if(!r.All(_ => _.needed.amount < _.have.Level))
            {
                return View(new MessageViewModel
                {
                    Message = $"You do not have enough resources"
                });
            }

            foreach (var item in r)
            {
                item.have.Level -= item.needed.amount;
            }

            mine.Level++;
            mine.UpgradeCompletion = DateTime.Now.AddHours(0.5 * mine.Level);
            this.dbContext.SaveChanges();

            return RedirectToAction("Index", "Mines", new { cityId });
        }*/
    }
}
