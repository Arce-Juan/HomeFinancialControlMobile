using HomeFinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HomeFinancialControl.Infraestructure.Context
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Movement> Movements { get; set; }

        private readonly string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HomeFinancialControl_Database_1.db3");

        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Config Persona
            modelBuilder.Entity<Concept>()
                        .HasKey(v => v.Id);
            modelBuilder.Entity<Concept>()
                        .Property(v => v.Name)
                        .IsRequired();
            modelBuilder.Entity<Concept>()
                        .HasIndex(m => m.Category);
            modelBuilder.Entity<Concept>()
                        .ToTable("Concepts");

            //Config Movement
            modelBuilder.Entity<Movement>()
                        .HasKey(v => v.Id);
            modelBuilder.Entity<Movement>()
                        .Property(v => v.MovementType)
                        .IsRequired();
            modelBuilder.Entity<Movement>()
                        .Property(v => v.Date)
                        .IsRequired();
            modelBuilder.Entity<Movement>()
                        .Property(v => v.Amount)
                        .IsRequired();
            modelBuilder.Entity<Movement>()
                        .HasOne(v => v.Concept)
                        .WithMany()
                        .HasForeignKey(v => v.ConceptId)
                        .IsRequired();
            modelBuilder.Entity<Movement>()
                        .ToTable("Movements");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
