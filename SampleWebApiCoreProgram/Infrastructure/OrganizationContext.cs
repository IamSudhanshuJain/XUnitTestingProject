using Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrganizationContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<Department> Department { get; set; }
        public OrganizationContext(DbContextOptions<OrganizationContext> options):base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationContext).Assembly);
        }
    }
}
