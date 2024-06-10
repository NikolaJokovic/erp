using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Korisnik> Korisnik { get; set; }

        public DbSet<Zaposleni> Zaposleni { get; set; }
        
        public DbSet<Artikal> Artikal { get; set; }

        public DbSet<Porudzbina> Porudzbina { get; set; }

        public DbSet<Kategorija> Kategorija { get; set; }

        public DbSet<ArtikalPorudzbina> ArtikalPorudzbina { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<Velicine> Velicine { get; set; }

        public DbSet<DostupnaVelicina> DostupnaVelicina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArtikalPorudzbina>().HasKey(ap => new { ap.porudzbina_id, ap.artikal_id });

            modelBuilder.Entity<DostupnaVelicina>().HasKey(dv => new { dv.artikal_id, dv.velicina_id });

            modelBuilder.Entity<Porudzbina>()
            .HasOne(p => p.Korisnik)
            .WithMany(k => k.Porudzbina)
            .HasForeignKey(p => p.korisnik_id);

            modelBuilder.Entity<Review>()
              .HasOne(r => r.Artikal)
              .WithMany(a => a.Review)
              .HasForeignKey(r => r.artikal_id)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Korisnik)
                .WithMany(a => a.Review)
                .HasForeignKey(r => r.korisnik_id)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<DostupnaVelicina>()
                .HasOne(r => r.Artikal)
                .WithMany(a => a.DostupneVelicine)
                .HasForeignKey(r => r.artikal_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DostupnaVelicina>()
                .HasOne(r => r.Velicine)
                .WithMany(a => a.DostupnaVelicina)
                .HasForeignKey(r => r.velicina_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArtikalPorudzbina>()
              .HasOne(r => r.Artikal)
              .WithMany(a => a.ArtikalPorudzbina)
              .HasForeignKey(r => r.artikal_id)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArtikalPorudzbina>()
              .HasOne(r => r.Porudzbina)
              .WithMany(a => a.ArtikalPorudzbina)
              .HasForeignKey(r => r.porudzbina_id)
              .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
