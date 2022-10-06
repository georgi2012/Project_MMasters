using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;
using MonsterMasters.Data.Orbs;

namespace RegisterAndLoginApp.Api.Models
{
    public partial class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext()
        {

        }

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<Creature> Creatures { get; set; }

        public virtual DbSet<Orb> Orb { get; set; }
        public virtual DbSet<RateValue> Rates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MonsterMasters;Database=MonsterMasters;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
            //seed
            //modelBuilder.Seeder();
            modelBuilder.Entity<Creature>().Property<int>("Index");
            modelBuilder.Entity<Creature>().HasKey("Index");
            modelBuilder.Entity<Creature>()
                .HasOne(x => x.appUser).WithMany(x => x.Creatures);

            modelBuilder.Entity<RateValue>().Property<int>("Index");
            modelBuilder.Entity<RateValue>().HasKey("Index");

            modelBuilder.Entity<Orb>().Property<int>("Index");
            modelBuilder.Entity<Orb>().HasKey("Index");
            modelBuilder.Entity<Orb>()
                 .HasMany(x => x.Rates).WithOne(x => x.Orb);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[] {
            new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
            new IdentityRole { Name = "Customer", NormalizedName = "Customer".ToUpper() }});


            //modelBuilder.Entity<Orb>().HasData(new Orb[] {
            //new BasicOrb (),
            //new RareOrb(),
            //new LuckyOrb() });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
