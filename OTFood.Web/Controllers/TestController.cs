using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OTFood.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public class Task
         {
            public int Tid { get; set; }
            public string TaskName { get; set; }
            public string StartDate { get; set; }
            public string Schedule { get; set; }
        }
        public class TaskDetail
        {
            public int Tdid { get; set; }
            public int Tid { get; set; }
            public string DueDate { get; set; }
            
        }

        public class vmTask
        {
            public int Tdid { get; set; }
            public int Tid { get; set; }
            public string TaskName { get; set; }
            public string Schedule { get; set; }
            public string DueDate { get; set; }

        }
        public ActionResult Index()
        {
            // List<Task> TIDList; list of objects of this type
            var tasks = new List<Task>
            {
                new Task { Tid=100, TaskName = "Install OS", StartDate = "01/01/2020", Schedule="Every Year"},
                new Task { Tid=200, TaskName = "Clear Cache", StartDate = "02/02/2020", Schedule="Every Week"},
                new Task { Tid=300, TaskName = "Backup Harddisk", StartDate = "03/15/2020", Schedule="Every Day"}
            };
            var dtasks = new List<TaskDetail>
            {
                new TaskDetail { Tdid=1000, Tid=100, DueDate = "11/01/2020"},
                new TaskDetail { Tdid=1001, Tid=100, DueDate = "11/11/2020"},
                new TaskDetail { Tdid=2000, Tid=200, DueDate = "02/02/2020"},
                new TaskDetail { Tdid=3000, Tid=300, DueDate = "03/03/2020"}
            };
            //Find takes a predicate(delegate) as a parameter.
            Task TaskInfo = tasks.Find(x => x.Tid == 200);
            var TaskInfo2 = tasks.Find(x => x.Tid == 100);
            Task TaskInfo3 = tasks.FirstOrDefault();
            Task TaskInfo4 = tasks.LastOrDefault();
            IEnumerable<Task> result = tasks.Take(2);
            var tdetails = from d in dtasks
                            where d.Tdid > 1010
                            orderby d.DueDate descending
                            select new { TDID = d.Tdid, TaskID = d.Tid,  TaskDueDate= d.DueDate };
            var TQuery = from td in dtasks
                            join tm in tasks on td.Tid equals tm.Tid
                            select new { tm.Tid, td.Tdid, tm.TaskName, tm.Schedule,  td.DueDate };
            
            //Populate view model with two tables and pass them to view
            var vmTQuery = (from td in dtasks
                         join tm in tasks on td.Tid equals tm.Tid
                         select new vmTask() {
                           Tid  = tm.Tid
                          ,Tdid = td.Tdid
                          ,TaskName = tm.TaskName
                          ,Schedule = tm.Schedule
                          ,DueDate  = td.DueDate } );

            /*List<vmTask> listVM = new List<vmTask>();
            foreach (var vmT in TQuery)
               {
                   vmTask modelVM = new vmTask();
                   modelVM.Tdid = vmT.Tdid;
                   modelVM.Tid = vmT.Tid;
                   modelVM.TaskName = vmT.TaskName;
                   modelVM.Schedule = vmT.Schedule;
                   modelVM.DueDate = vmT.DueDate;
               }
            */
            List<int> ListTids = tasks.Select(i => i.Tid).ToList();
            string CommaTids = string.Join(",", tasks.Select(x => x.Tid));
            int[] ArrayTids = CommaTids.Split(',').Select(n => int.Parse(n.Trim())).ToArray();
            int t = 0;
            foreach (var i in ListTids){t = t + i;}

            int u = 0;
            foreach (var i in CommaTids){u = u + i;}

            int v = 0;
            foreach (var i in ArrayTids){v = v + i;}

            /* 
            A IEnumerable<T> after an interface name indicates that the interface is generic. 
            This means that it can be used with any data type, and the T is a placeholder for that data type. 
            An IEnumerable<int> contains a sequence of ints. 
            An IEnumerable<string> contains a sequence of strings. 
            An IEnumerable<object> contains (God help us) a sequence of objects, meaning it can hold, quite literally, anything.
            */
            IEnumerable<int> list = new List<int> { 1, 2, 3 };
            IEnumerable<int> array = new[] { 1, 2, 3 };
            int[] b = new List<int> { 1, 2, 3 }.ToArray();
            List<int> a = new[] { 1, 2, 3 }.ToList();
            

            List<string> animalNames = new List<string> {"fawn", "gibbon", "heron", "ibex", "jackalope"};
            IEnumerable<string> longAnimalNames =   from name in animalNames
                                                    where name.Length >= 5
                                                    orderby name.Length
                                                    select name;
            //The exact same instruction set can be written using method syntax like this
            IEnumerable<string> longAnimalNamesLM = animalNames
                                                 .Where(name => name.Length >= 5)
                                                 .OrderBy(name => name.Length);
            //return View(tasks);

            return View(vmTQuery.ToList());
        }
    }
}