using OTFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        //private OTFoodDbContext db = new OTFoodDbContext();
        private readonly OTFoodDbContext db;
        //DI and Autofac use SqlRestaurantData(OTFoodDbContext db)
        public SqlRestaurantData(OTFoodDbContext db)
        {
            this.db = db;
        }
        
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants orderby r.Name select r;
             /*return from r in db.Restaurants 
                    join e in db.Employees on r.Id equals e.RestaurantID
                    orderby r.Name select r;*/
        }

        public void Update(Restaurant restaurant)
        {
            /*var r = Get(restaurant.Id);
            r.Name = "xyz";*/

            //optimastic concurrency allows multiple users work simultaneouly
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
