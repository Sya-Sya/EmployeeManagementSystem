using EmployeeMS.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeMS.Model.EmployeeModel;

namespace EmployeeMS
{
    public class EMSContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection
            //optionsBuilder.UseSqlServer(@"Data Source=SHINIGAMI;Initial catalog=EMS;Integrated Security=true;Encrypt=True;");
            optionsBuilder.UseSqlServer(@"Data Source=SHINIGAMI;Initial catalog=EMS;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define foreign key relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionID);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentID);
        }
    }
}
