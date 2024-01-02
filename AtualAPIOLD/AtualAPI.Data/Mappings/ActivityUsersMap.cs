using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

using AtualAPI.Models.Workflow;
using AtualAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Data.Mappings
{
    public class ActivityUsersMap : IEntityTypeConfiguration<ActivityUsers>
    {
        public void Configure(EntityTypeBuilder<ActivityUsers> builder)
        {
            builder.ToTable("activities_users");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.ActivityId)
                .IsRequired()
                .HasColumnName("ActivityId");

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");
           

        }
    }
}
