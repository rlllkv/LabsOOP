using Microsoft.EntityFrameworkCore;
using BazaGRUD.Models;

namespace BazaGRUD.Data
{
    public class ApplicationDbContext: DbContext
    {
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; } 
        public DbSet<ID_card> ID_cards { get; set; } 
        public DbSet<Group> Groups { get; set; } 
        public DbSet<StudentToGroup> StudentToGroups { get; set; } 
    }
}
