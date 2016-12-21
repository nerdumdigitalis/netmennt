using Netmennt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netmennt.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Component> MyComponents { get; set; }
        public IEnumerable<Component> EnrolledComponents { get; set; }
    }
}