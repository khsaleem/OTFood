using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTFood.Web.ViewModels
{
    public class Name
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class NameListViewModel
    {
        public List<Name> Names { get; set; }
    }
}