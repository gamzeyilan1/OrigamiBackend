using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrigamiBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {  
            
        }
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskCategory> TaskCategory { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<User> User { get; set; }


    }
}