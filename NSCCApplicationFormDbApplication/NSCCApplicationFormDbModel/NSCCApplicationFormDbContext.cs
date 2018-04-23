namespace NSCCApplicationFormDbModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NSCCApplicationFormDbContext : DbContext
    {
        public NSCCApplicationFormDbContext()
            : base("name=NSCCApplicationFormDbContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Campu> Campus { get; set; }
        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<ProgramChoice> ProgramChoices { get; set; }
        public virtual DbSet<ProvinceState> ProvinceStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .Property(e => e.SIN)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.ProvinceStateCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.CountryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.PhoneHome)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.PhoneCell)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.NSCCStudentId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.CitizenshipOther)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .HasOptional(e => e.Application)
                .WithRequired(e => e.Applicant);

            modelBuilder.Entity<Application>()
                .Property(e => e.ApplicationFee)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Campu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Campu>()
                .HasMany(e => e.ProgramChoices)
                .WithRequired(e => e.Campu)
                .HasForeignKey(e => e.CampusId);

            modelBuilder.Entity<Campu>()
                .HasMany(e => e.Programs)
                .WithMany(e => e.Campus)
                .Map(m => m.ToTable("CampusProgram").MapLeftKey("CampusId").MapRightKey("ProgramId"));

            modelBuilder.Entity<Citizenship>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Citizenship>()
                .HasMany(e => e.Applicants)
                .WithRequired(e => e.Citizenship1)
                .HasForeignKey(e => e.Citizenship);

            modelBuilder.Entity<Country>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Applicants)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CitizenshipOther);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Applicants1)
                .WithRequired(e => e.Country1)
                .HasForeignKey(e => e.CountryCode);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Applicants)
                .WithOptional(e => e.Gender1)
                .HasForeignKey(e => e.Gender);

            modelBuilder.Entity<Program>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProvinceState>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProvinceState>()
                .Property(e => e.CountryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProvinceState>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProvinceState>()
                .HasMany(e => e.Applicants)
                .WithOptional(e => e.ProvinceState)
                .HasForeignKey(e => new { e.ProvinceStateCode, e.CountryCode });
        }
    }
}
