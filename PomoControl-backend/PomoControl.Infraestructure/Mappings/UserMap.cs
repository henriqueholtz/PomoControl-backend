﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomoControl.Core.Enums.SQL;
using PomoControl.Domain;

namespace PomoControl.Infraestructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(prop => prop.Code);
            builder.Property(p => p.Name).HasColumnType(TypeName.VARCHAR075).IsRequired();
            builder.Property(p => p.Email).HasColumnType(TypeName.VARCHAR100).IsRequired();
            builder.Property(p => p.Password).HasColumnType(TypeName.VARCHAR500).IsRequired();
            builder.Property(p => p.PasswordVerify).HasColumnType(TypeName.VARCHAR500).IsRequired();
            builder.Property(p => p.Active).HasColumnType(TypeName.BIT).IsRequired();
            builder.Ignore(p => p.Erros);
        }
    }
}