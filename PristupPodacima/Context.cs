using Domen;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PristupPodacima
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Trener> Treneri { get; set; }
        public DbSet<Grupa> Grupe { get; set; }
        public DbSet<Mesto> Mesta { get; set; }
        public DbSet<Obrazovanje> Obrazovanja { get; set; }
        public DbSet<Pol> Pol { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aplikacija.teretana;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trener>()
                .HasOne(t => t.Obrazovanje)
                .WithMany()
                .HasForeignKey(t => t.ObrazovanjeID);
            modelBuilder.Entity<Grupa>()
                .HasOne(g => g.Trener)
                .WithMany()
                .HasForeignKey(g => g.TrenerID);
            modelBuilder.Entity<Grupa>()
                .HasOne(g => g.Mesto)
                .WithMany()
                .HasForeignKey(g => g.MestoID);
            modelBuilder.Entity<Mesto>().ToTable("Mesto");
            modelBuilder.Entity<Obrazovanje>().ToTable("Obrazovanje");
            modelBuilder.Entity<Pol>().ToTable("Pol");
            modelBuilder.Entity<Klijent>()
                .HasOne(k => k.Grupa)
                .WithMany()
                .HasForeignKey(k => k.GrupaID);
            modelBuilder.Entity<Klijent>()
                .HasOne(k => k.Pol)
                .WithMany()
                .HasForeignKey(k => k.PolID);
            modelBuilder.Entity<User>().ToTable("User");
            base.OnModelCreating(modelBuilder);

        }

    }
}