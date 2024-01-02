using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class TimeMontadoresMap : IEntityTypeConfiguration<TimeMontadores>
    {
        public void Configure(EntityTypeBuilder<TimeMontadores> builder)
        {
            builder.ToTable("time_montadores");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.NameTime)
                .IsRequired()
                .HasColumnName("NameTime");

            builder.Property(x => x.FuncionarioId)
                .HasColumnName("FuncionarioId");

            builder.Property(x => x.LevelMontador)
                .HasColumnName("LevelMontador");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");


            builder
                .HasIndex(x=>x.Id, "IX_Client_Id")
                .IsUnique();
                

        }
    }
}
