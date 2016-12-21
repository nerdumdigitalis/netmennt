using Netmennt.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netmennt.Entities
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Updated { get; set; }
        public ComponentType Type { get; set; }
        public string VideoUrl { get; set; }
        [NotMapped]
        public string ImagePath { get; set; }
        public int Order { get; set; }
        public string EnrollmentGuid { get; set; }
        public int CreatorId { get; set; }
        [NotMapped]
        public int EnrollmentId { get; set; }
    }
}