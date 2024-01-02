using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class MontagemMap : IEntityTypeConfiguration<Montagem>
    {
        public void Configure(EntityTypeBuilder<Montagem> builder)
        {
            builder.ToTable("montagems");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.ContratoId)
                .IsRequired()
                .HasColumnName("ContratoId");

            builder.Property(x => x.TimeMontagemId)
                .HasColumnName("TimeMontagemId");

            builder.Property(x => x.Details)
                .HasColumnName("Details");

            builder.Property(x => x.DataInicioPrev)
                .HasColumnName("DataInicioPrev");

            builder.Property(x => x.DataInicioReal)
                .HasColumnName("DataInicioReal");

            builder.Property(x => x.DataTerminoPrev)
                .HasColumnName("DataTerminoPrev");

            builder.Property(x => x.DataTerminoReal)
                .HasColumnName("DataTerminoReal");

            builder.Property(x => x.DataVistoria)
                .HasColumnName("DataVistoria");

            builder.Property(x => x.RelatorioVistoria)
                .HasColumnName("RelatorioVistoria");

            builder.Property(x => x.URLImgVistoria)
                .HasColumnName("URLImgVistoria");

            builder.Property(x => x.CreationDate)
                .HasColumnName("CreationDate");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("UpdatedDate");

       
            builder
                .HasIndex(x=>x.Id, "IX_Montagem_Id")
                .IsUnique();
                

        }
    }
}
