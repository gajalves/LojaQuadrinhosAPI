using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LojaQuadrinhos.Infra.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext()
        {
                    
        }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
            

        public DbSet<User> Users { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ComicBookMap());
            builder.ApplyConfiguration(new SalesMap());
        }
        
    }
}
