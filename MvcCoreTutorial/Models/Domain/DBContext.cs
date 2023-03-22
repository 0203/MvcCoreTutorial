using Microsoft.EntityFrameworkCore;

namespace MvcCoreTutorial.Models.Domain
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> opts) : base(opts)
        {

        }

        //DbSet will create a database with the name of Person
        public DbSet <Person> Person { get; set; }    

    }
}
