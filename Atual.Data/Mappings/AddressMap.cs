using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("enderecos");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.ElementId)
                .IsRequired()
                .HasColumnName("ElementId");

            builder.Property(x => x.Phone1)
                .HasColumnName("Phone1");

            builder.Property(x => x.Phone2)
                .HasColumnName("Phone2");

            builder.Property(x => x.Email)
                .HasColumnName("Email");

            builder.Property(x => x.Endereco)
                .HasColumnName("Endereco");

            builder.Property(x => x.Complemento)
                .HasColumnName("Complemento");

            builder.Property(x => x.CEP)
                .HasColumnName("CEP");

            builder.Property(x => x.Bairro)
                .HasColumnName("Bairro");

            builder.Property(x => x.Estado)
                .HasColumnName("Estado");

            builder.Property(x => x.Pais)
                .HasColumnName("Pais");
 

            builder
                .HasIndex(x=>x.Id, "IX_Address_Id")
                .IsUnique();
                

        }
    }
}
