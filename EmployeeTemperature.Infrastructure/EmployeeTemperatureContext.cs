using EmployeeTemperature.Domain.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Infrastructure
{
    public partial class EmployeeTemperatureContext : DbContext
    {
        public EmployeeTemperatureContext()
        {
        }

        public EmployeeTemperatureContext(DbContextOptions<EmployeeTemperatureContext> options) : base(options)
        { 
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Temperature> Temperatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired();

                entity.HasIndex(e => e.EmployeeNumber).IsUnique();
                
            });

            modelBuilder.Entity<Temperature>(entity =>
            {
                entity.ToTable("Temperatures");

                entity.Property(e => e.Value)
                    .IsRequired();

                entity.Property(e => e.EmployeeId)
                    .IsRequired();

                entity.Property(e => e.RecordDate)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
