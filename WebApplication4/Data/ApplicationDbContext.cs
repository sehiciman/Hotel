using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WebApplication4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<Soba> Sobe { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Ponuda> Ponude { get; set; }
        public DbSet<Obavijest> Obavijesti { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Lokacija>().ToTable("Lokacije");
            modelBuilder.Entity<Soba>().ToTable("Sobe");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnici");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacije");
            modelBuilder.Entity<Ponuda>().ToTable("Ponude");
            modelBuilder.Entity<Obavijest>().ToTable("Obavijesti");
            base.OnModelCreating(modelBuilder);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}