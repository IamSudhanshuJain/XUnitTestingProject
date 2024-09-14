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
    class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            const int NAME_MAX_LENGTH = 50;
            const int DESCRIPTION_MAX_LENGTH = 200;
            const string TABLE_NAME = "Function";

            builder.ToTable(TABLE_NAME);
            builder.HasKey(x => x.Id).HasName("PK_" + TABLE_NAME);
            builder.HasOne(x => x.Department);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(NAME_MAX_LENGTH);
            builder.Property(x => x.Description).HasMaxLength(DESCRIPTION_MAX_LENGTH);

            builder.HasData(new Function() { Id = 1, Name = "Associate Software Engineer", Description = "Associate Software Engineer", DepartmentId = 1 });
            builder.HasData(new Function() { Id = 2, Name = "Software Engineer", Description = "Associate Software Engineer", DepartmentId = 1 });
            builder.HasData(new Function() { Id = 3, Name = "Senior Software Engineer", Description = "Associate Software Engineer", DepartmentId = 1 });
        }
    }
}
