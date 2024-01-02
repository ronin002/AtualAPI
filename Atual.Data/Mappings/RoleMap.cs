using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
                //.ValueGeneratedOnAdd()
                //.UseMySqlIdentityColumn();

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("company_id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(x => x.LevelCliente)
                .HasColumnName("LevelCliente");

            builder.Property(x => x.LevelContrato)
                .HasColumnName("LevelContrato");

            builder.Property(x => x.LevelFuncionarios)
                .HasColumnName("LevelFuncionarios");

            builder.Property(x => x.LevelMontagens)
                .HasColumnName("LevelMontagens");

            builder.Property(x => x.LevelUsers)
                .HasColumnName("level_users");

            builder.Property(x => x.LevelRoles)
                .HasColumnName("level_roles");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");

            /*
            builder
                    .HasMany(x => x.Companies)
                    .WithMany(x => x.Roles)
                    .UsingEntity<Dictionary<string, object>>( 
                        "CompanyRole",
                        company => company
                            .HasOne<Company>()
                            .WithMany()
                            .HasForeignKey("CompanyId")
                            .HasConstraintName("FK_CompanyRole_CompanyId")
                            .OnDelete(DeleteBehavior.Cascade),
                        role => role
                            .HasOne<Role>()
                            .WithMany()
                            .HasForeignKey("CompanyRoleId")
                            .HasConstraintName("FK_CompanyRole_RoleId")
                            .OnDelete(DeleteBehavior.Cascade)

                        );
                */
            /*
            builder
                .HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    user => user
                        .HasOne<UserModel>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    role => role
                        .HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .HasConstraintName("FK_UserRole_RoleId")
                        .OnDelete(DeleteBehavior.Cascade)

                    );
            */
        }
    }
}
