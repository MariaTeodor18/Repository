using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class MinesService: IMinesService
    {

        public City UpdateResources(string userId)
        {

            UserRepository userRepo = new UserRepository();
            ApplicationUser user = userRepo.GetUser(userId);
            MinesRepository minesRepo = new MinesRepository();

            var city = user.Cities.First();
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
            
            minesRepo.Updateresources();
            return city;
        }


    }
}
