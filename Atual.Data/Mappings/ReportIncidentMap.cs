using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class ReportIncidentMap : IEntityTypeConfiguration<ReportIncidente>
    {
        public void Configure(EntityTypeBuilder<ReportIncidente> builder)
        {
            builder.ToTable("incidentes");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.MontagemId)
                .IsRequired()
                .HasColumnName("MontagemId");

            builder.Property(x => x.AmbienteId)
                .HasColumnName("AmbienteId");

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao");

            builder.Property(x => x.DataOcorrencia)
                .HasColumnName("DataOcorrencia");

            builder.Property(x => x.RelatorioOcorrenciaSolucao)
                .HasColumnName("RelatorioOcorrenciaSolucao");

            builder.Property(x => x.URLImgOcorrencia)
                .HasColumnName("URLImgOcorrencia");

            builder.Property(x => x.DataSolucao)
                .HasColumnName("DataSolucao");

            builder.Property(x => x.RelatorioSolucao)
                .HasColumnName("RelatorioSolucao");

            builder.Property(x => x.URLImgSolucao)
                .HasColumnName("URLImgSolucao");

            builder.Property(x => x.CreationDate)
                .HasColumnName("CreationDate");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("UpdatedDate");

       
            builder
                .HasIndex(x=>x.Id, "IX_Incidentes_Id")
                .IsUnique();
                

        }
    }
}
