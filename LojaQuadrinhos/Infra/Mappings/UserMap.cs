using LojaQuadrinhos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(user => user.Nome)
                .IsRequired().HasMaxLength(50).HasColumnName("nome").HasColumnType("VARCHAR(50)");

            builder.Property(user => user.Email)
                .IsRequired().HasMaxLength(180).HasColumnName("email").HasColumnType("VARCHAR(180)");

            builder.Property(user => user.Senha)
                .IsRequired().HasMaxLength(80).HasColumnName("senha").HasColumnType("VARCHAR(80)");

            builder.Property(user => user.Role)
                .IsRequired().HasMaxLength(15).HasColumnName("role").HasColumnType("VARCHAR(15)");

        }
    }
}
