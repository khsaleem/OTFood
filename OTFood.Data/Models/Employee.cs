using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTFood.Data.Models
{
    public class Employee
    {
        //If the property is named something other than Id, you need to add the [Key] attribute to it.
        [Key]
        public int EmpID { get; set; }
        public string Name { get; set; }

        public decimal PayRate { get; set; }
        public decimal BaseHours { get; set; }
        public bool isManager { get; set; }
        public virtual Restaurant Restaurants { get; set; }
        public int RestaurantID { get; set; }
    }
}
