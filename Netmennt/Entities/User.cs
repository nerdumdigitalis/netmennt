using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netmennt.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Nationality { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Registered { get; set; }
        public string Name { get; set; }
        public string ReferenceId { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}