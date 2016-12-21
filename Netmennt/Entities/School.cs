using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Netmennt.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? DateCreated { get; set; }
        public string Logo { get; set; }
    }
}