using Netmennt.Entities;
using System.Data.Entity;

namespace Netmennt.Models
{
    public class Context : DbContext
    {
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<UserProgressData> UserProgressData { get; set; }
        public DbSet<User> Users { get; set; }
    }
}