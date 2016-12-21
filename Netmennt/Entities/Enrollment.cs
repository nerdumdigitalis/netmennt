using Netmennt.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netmennt.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int EnrolleeId { get; set; }
        public int EnrolledId { get; set; }
        public ComponentType EnrolledType { get; set; }
        public ComponentType EnrolleeType { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? DateStart { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? DateEnd { get; set; }

        public int RoleId { get; set; }
    }
}