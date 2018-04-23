using NSCCApplicationFormDataLayer.Models;
using System.Data.Entity;

namespace NSCCApplicationFormDataLayer
{
    public class NSCCApplicationDbContext : DbContext
    {

        public NSCCApplicationDbContext() : base("name=NSCCApplicationFormDb")
        {

            //Database.SetInitializer(new DropCreateDatabaseAlways<NSCCApplicationDbContext>());

        }


        //define the collections of object
        //in the database....tables
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Citizenship> Citizenship { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<ProvinceState> ProvinceState { get; set; }
        public DbSet<Campus> Campuss { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ProgramChoice> ProgramChoice { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

                    modelBuilder.Entity<Campus>()
                   .HasMany(s => s.Programs)
                   .WithMany(c => c.Campuss)
                   .Map(cp =>
                   {
                       cp.MapLeftKey("CampusId");
                       cp.MapRightKey("ProgramId");
                       cp.ToTable("CampusProgram");
                   });


        }







    }
}
