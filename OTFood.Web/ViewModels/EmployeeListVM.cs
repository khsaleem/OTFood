using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTFood.Data.Models;

namespace OTFood.Web.ViewModels
{
    public class EmployeeListVM
    {
        public IEnumerable<EmployeeVM> VmEmployees { get; set; }
    }

    public class EmployeeVM
    {
        public const decimal overTime = 40;
        [HiddenInput]
        public int EmpID { get; set; }
        
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal PayRate { get; set; }
        public decimal BaseHours { get; set; }
        public bool isManager { get; set; }
        public decimal? gross 
        { 
            get { return (PayRate * BaseHours); } 
        }
        public bool HasOvertime
        {
            get { return BaseHours > overTime; }
        }

        [DisplayName("Restaurant Name")]
        public string RestaurantName { get; set; }
    }
}