using System.Data.Entity;
using VacationPlaner.DomainModel;

namespace VacationPlaner.DAL.EF
{
    public class VacationPlanerDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 

        private class VacationPlanerInitializer :
            System.Data.Entity.DropCreateDatabaseIfModelChanges<VacationPlanerDbContext>
        {
            protected override void Seed(VacationPlanerDbContext context)
            {
                //base.Seed(context);
                context.Addresses.Add(new Address()
                {
                    City = "Cluj",
                    Country = "Romania",
                    Street = "My Street",
                    Zip = "12345"
                });

                context.SaveChanges();
            }
        }

        static VacationPlanerDbContext()
        {
#if DEBUG
            System.Data.Entity.Database.SetInitializer(new VacationPlanerInitializer());
#endif
        }

        public VacationPlanerDbContext() : base("name=VacationPlanerDbContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
