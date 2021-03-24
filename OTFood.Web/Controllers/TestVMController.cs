//using OTFood.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTFood.Web.Controllers
{
    public class TestVMController : Controller
    {
        public class StudentInfo
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Course { get; set; }
        }

        public class NameListViewModel
        {
            public List<StudentInfo> InfoList { get; set; }
        }

        public ActionResult Index()
        {
            NameListViewModel viewModel = new NameListViewModel();
            viewModel.InfoList = new List<StudentInfo>();
            viewModel.InfoList.Add(new StudentInfo { Id = 1, FullName = "Test Name1", Course = "" });
            viewModel.InfoList.Add(new StudentInfo { Id = 2, FullName = "Test Name2", Course = "" });
            viewModel.InfoList.Add(new StudentInfo { Id = 3, FullName = "Test Name3", Course = "" });
            viewModel.InfoList.Add(new StudentInfo { Id = 4, FullName = "Test Name4", Course = "" });

            /*List<StudentInfo> NameListViewModel;
            NameListViewModel = new List<StudentInfo>()
            {
                new StudentInfo { Id = 1, FullName = "Test Name1", Course = "" },
                new StudentInfo { Id = 2, FullName = "Test Name2", Course = "" },
                new StudentInfo { Id = 3, FullName = "Test Name3", Course = "" },
                new StudentInfo { Id = 4, FullName = "Test Name4", Course = "" }
            };
            return View(NameListViewModel);*/

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(NameListViewModel viewModel)
        {
            // All the values should still be in viewModel
            // Do whatever you need to do
            return View(viewModel);
        }

    }
}