using Microsoft.EntityFrameworkCore;

namespace GroupBy.Controllers {
    public class AppContext : DbContext {
        public AppContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Student1> Student11 { set; get; }
        public DbSet<Student2> Student22 { set; get; }
    }
}