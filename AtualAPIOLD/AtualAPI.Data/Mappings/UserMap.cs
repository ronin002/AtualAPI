using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;
using AtualAPI.Models.Dtos;

namespace AtualAPI.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("users");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);
            //.ValueGeneratedOnAdd()
            //.UseMySqlIdentityColumn();
            /*
            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");
            */
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name");
            
            builder.Property(x => x.LastName)
                .HasColumnName("last_name");

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");

            builder
                .HasIndex(x=>x.Email, "IX_User_Email")
                .IsUnique();
                

        }
    }
}
