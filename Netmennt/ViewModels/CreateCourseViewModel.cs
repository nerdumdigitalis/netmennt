using Netmennt.Entities;
using System.Collections.Generic;

namespace Netmennt.ViewModels
{
    public class CreateCourseViewModel
    {
        public Component Course { get; set; }
        public IEnumerable<Component> Topics { get; set; }

    }
}