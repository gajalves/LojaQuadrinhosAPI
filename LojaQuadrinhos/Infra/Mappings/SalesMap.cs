using LojaQuadrinhos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Infra.Mappings
{
    public class SalesMap : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.ToTable("sale");

            builder.HasKey(sale => sale.Id);

            builder.Property(sale => sale.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(user => user.ComicId)
                .IsRequired().HasColumnName("comidid").HasColumnType("INT");

            builder.Property(user => user.UserEmail)
                .IsRequired().HasMaxLength(180).HasColumnName("useremail").HasColumnType("VARCHAR(180)");

            builder.Property(user => user.Quantity)
                .IsRequired().HasColumnName("quantity").HasColumnType("INT");
        }
    }
}
