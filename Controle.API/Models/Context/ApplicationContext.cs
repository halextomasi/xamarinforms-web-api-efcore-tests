using Microsoft.EntityFrameworkCore;

namespace Controle.API.Models.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) 
            : base(options)
        {
            
        }
        
        public DbSet<Contribuinte> Contribuintes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}