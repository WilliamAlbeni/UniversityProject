using Microsoft.EntityFrameworkCore;

namespace UniversityApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
