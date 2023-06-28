using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class DbAppContext : DbContext
    {
        public DbSet<veterinarian> veterinarian { get; set; }
        public DbSet<petowner> petowner { get; set; }
        public DbSet<pet> pet { get; set; }
        public DbSet<medecine> medecine { get; set; }
        public DbSet<disease> disease { get; set; }
        public DbSet<card> card { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Username=postgres;Password=5556708;Database=vetkod"); // 22345621

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<pet>().HasOne(p => p.VeterinarianEntity)
                                        .WithMany(p => p.PetEntities)
                                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<pet>().HasOne(p => p.PetOwnerEntity)
                                        .WithMany(p => p.PetEntities)
                                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<pet>().HasOne(p => p.DiseaseEntity)
                                        .WithMany(p => p.PetEntities)
                                        .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<petowner>().HasOne(p => p.VeterinarianEntity)
                                        .WithMany(p => p.PetOwnerEntities)
                                        .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<disease>().HasOne(p => p.MedecineEntity)
                                        .WithMany(p => p.DiseaseEntities)
                                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<card>().HasOne(p => p.PetEntity)
                                       .WithMany(p => p.CardEntities)
                                       .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
