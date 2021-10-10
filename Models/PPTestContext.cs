using Microsoft.EntityFrameworkCore;

namespace pp_test
{
public class PPTestContext: DbContext{
        public DbSet<Order> Orders{get;set;}
        public DbSet<Status> Statuses{get;set;}
        public DbSet<Postamat> Postamats{get;set;}
        public DbSet<Product> Products{get;set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=pp.db");
    }
        

        

}
}
