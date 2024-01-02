using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);
                //.ValueGeneratedOnAdd()
                //.UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name");
            
            builder.Property(x => x.OwnerId)
                .IsRequired()
                .HasColumnName("owner_Id");

            builder.Property(x => x.BussinesPlan)
                .HasColumnName("bssines_plan")
                .HasDefaultValue("");

            builder.Property(x => x.BussinesPlanStatus)
                .HasColumnName("bussines_planStatus")
                .HasDefaultValue("");

            builder.Property(x => x.CreationDate)
            .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");
            /*
            builder
               .HasMany(x => x.Roles)
               .WithMany(x => x.Companies)
               .UsingEntity<Dictionary<string, object>>(
                   "CompanyRole",
                   role => role
                       .HasOne<Role>()
                       .WithMany()
                       .HasForeignKey("Role_Id")
                       .HasConstraintName("FK_CompanyRole_RoleId")
                       .OnDelete(DeleteBehavior.Cascade),
                   company => company
                       .HasOne<Company>()
                       .WithMany()
                       .HasForeignKey("Company_Id")
                       .HasConstraintName("FK_RoleCompany_CompanyId")
                       .OnDelete(DeleteBehavior.Cascade));
            */

            builder
               .HasMany(x => x.Users);
               




        }
    }
}
