using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AtualAPI.Data.Mappings
{
    public class TriggerMap : IEntityTypeConfiguration<TriggerDateTime>
    {
        public void Configure(EntityTypeBuilder<TriggerDateTime> builder)
        {
            builder.ToTable("triggers");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);
            //.ValueGeneratedOnAdd()
            //.UseMySqlIdentityColumn();

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");
            
            builder.Property(x => x.Description)
                .HasColumnName("Description");
            
            builder.Property(x => x.Enabled)
                .HasColumnName("Enabled");

            builder.Property(x => x.Status)
                .HasColumnName("Status");

            builder.Property(x => x.DateExecutions)
               .HasColumnName("DateExecutions");

            builder.Property(x => x.DateExceptions)
               .HasColumnName("DateExceptions");

            builder.Property(x => x.Status)
               .HasColumnName("Status");
            /*
            builder.OwnsOne(x => x.DateExecutions, options =>
            {
                options.ToJson();
            });

            builder.OwnsOne(x => x.DateExceptions, options =>
            {
                options.ToJson();
            });
            */
            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");



        builder
                .HasIndex(x=>x.Title, "IX_Trigger_Title")
                .IsUnique();
                

        }
    }
}
