using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using onlinetools.Models;

namespace onlinetools.Data
{
    public class OnlineToolsDbContext : DbContext
    {
        public OnlineToolsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<SubTool> SubTools { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToolConfiguration());
            modelBuilder.ApplyConfiguration(new SubToolConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


        }
    }

}
