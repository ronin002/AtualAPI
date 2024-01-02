using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class MontadoresMap : IEntityTypeConfiguration<Montadores>
    {
        public void Configure(EntityTypeBuilder<Montadores> builder)
        {
            builder.ToTable("montadores");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.FuncionarioId)
                .IsRequired()
                .HasColumnName("FuncionarioId");

            builder.Property(x => x.Details)
                .HasColumnName("Details");

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
