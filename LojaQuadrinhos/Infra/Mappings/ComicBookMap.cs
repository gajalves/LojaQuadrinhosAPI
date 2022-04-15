using LojaQuadrinhos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaQuadrinhos.Infra.Mappings
{
    public class ComicBookMap : IEntityTypeConfiguration<ComicBook>
    {
        public void Configure(EntityTypeBuilder<ComicBook> builder)
        {
            builder.ToTable("comicbook");

            builder.HasKey(comicbook => comicbook.Id);

            builder.Property(comicbook => comicbook.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(comicbook => comicbook.Titulo)
                .IsRequired().HasMaxLength(50).HasColumnName("titulo").HasColumnType("VARCHAR(50)");

            builder.Property(comicbook => comicbook.Descricao)
                .IsRequired().HasMaxLength(180).HasColumnName("descricao").HasColumnType("VARCHAR(180)");

            builder.Property(comicbook => comicbook.Preco)
                .IsRequired().HasColumnName("preco").HasColumnType("NUMERIC(5,2)");

            builder.Property(comicbook => comicbook.DataPublicacao)
                .IsRequired().HasMaxLength(12).HasColumnName("datapublicacao").HasColumnType("VARCHAR(12)");

            builder.Property(comicbook => comicbook.Autor)
                .IsRequired().HasMaxLength(50).HasColumnName("autor").HasColumnType("VARCHAR(50)");

            builder.Property(comicbook => comicbook.Estoque)
                .IsRequired().HasColumnName("estoque").HasColumnType("INT");
        }
    }
}
