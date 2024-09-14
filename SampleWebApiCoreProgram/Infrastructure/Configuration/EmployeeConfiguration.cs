using Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            const string TABLE_NAME = "Employee";
            builder.ToTable(TABLE_NAME);
            builder.HasKey(x => x.Id).HasName("PK_" + TABLE_NAME);
            builder.HasOne(x => x.Function);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.FunctionId).IsRequired();

            builder.HasData(new Employee() { Id = 1, Name = "Taj", FunctionId = 1 });
            builder.HasData(new Employee() { Id = 2, Name = "Rajneesh Kumar", FunctionId = 1 });
            builder.HasData(new Employee() { Id = 3, Name = "Sudhanshu Jain", FunctionId = 1 });

        }
    }
}
