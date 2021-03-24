using OTFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;

        /* GetAll() method is implemented in SqlRestaurantData.cs but defined in IRestaurantData.cs
         * In order to get data from GetAll(), we need to Inject (or make it available) in this controller by using Autofac:
         * STEP1: Create a container(class i.e. ContainerConfig.cs) under App_Start folder and add this code:
         * All we need is to provide implementor name i.e. <SqlRestaurantData>  and interface name <IRestaurantData>    
                builder.RegisterType<SqlRestaurantData>().As<IRestaurantData>().InstancePerRequest();
         * STEP2: In global.asax.cs register a container i.e. ContainerConfig.RegisterContainer();
         * In future if we would like to use different implementer then change the name of implementer in ContainerConfig.cs 
         * Line 23 dependency inject from ContainerConfig.cs file which is trigger by global.asax. It means IRestaurantData is implemented by
         * SqlRestaurantData and db is defined in this file to get data.
        */
        public HomeController(IRestaurantData _SqlRestaurantData)
        {
            //db = new InMemoryRestaurantData();
            this.db = _SqlRestaurantData;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}