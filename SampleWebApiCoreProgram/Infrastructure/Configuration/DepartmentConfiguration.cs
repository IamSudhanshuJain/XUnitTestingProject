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
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            const string TABLE_NAME = "Department";
            const int NAME_MAX_LENGTH = 50;
            const int DESCRIPTION_MAX_LENGTH = 200;

            builder.ToTable(TABLE_NAME);
            builder.HasKey(x => x.Id).HasName("PK_" + TABLE_NAME);
            builder.HasMany(x => x.Functions);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(NAME_MAX_LENGTH).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(DESCRIPTION_MAX_LENGTH);

            builder.HasData(new Department() { Id = 1, Name = "Engineering", Description = "Engineering" });
            builder.HasData(new Department() { Id = 2, Name = "Finance", Description = "Finance" });
            builder.HasData(new Department() { Id = 3, Name = "Marketing", Description = "Marketing" });
        }
    }
}
