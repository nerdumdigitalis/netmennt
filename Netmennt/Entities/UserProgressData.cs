using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netmennt.Entities
{
    public class UserProgressData
    {
        public int UserProgressDataId { get; set; }
        public int UserId { get; set; }
        public int DataReferenceId { get; set; }
        public int DataReferenceType { get; set; }
        public int Progress { get; set; }
        public int Result { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? DateStarted { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? DateCompleted { get; set; }
    }
}