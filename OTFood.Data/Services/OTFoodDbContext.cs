using OTFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTFood.Data.Services
{
    public class OTFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //Code to disable migration for code first approach.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OTFoodDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
