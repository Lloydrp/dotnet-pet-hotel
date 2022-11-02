   using Microsoft.EntityFrameworkCore;

/*
    This class sets up the link between your Plain Old C# Object (POCO) and
    the Database. Entity Framework is the name of the system that facilitaes
    this linkage.

    This class inherits from the `DbContext` class. To make a POCO database
    aware, simply create a method on this class that returns a DbSet object
    that accepts the appropriate class. Entity will use the function name
    to find the appropriate table in the database (including on creation 
    with migrations). So `public DbSet<Humans> Humans { get; set; }` will 
    direct Entity to look in your database for a table with the name `Humans`

    Each project by default has only a single context. Add all of your db-aware
    classes to this class.

    This class gets added to Entity during the system setup. See Startup.cs.
*/
namespace pet_hotel.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
        // public DbSet<MyClass> MyClassTable { get; set; }
    }
}