using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Data.Mappings
{
    /*
    public class WorkFlowUsersMap : IEntityTypeConfiguration<WorkFlowUsers>
    {s
        public void Configure(EntityTypeBuilder<WorkFlowUsers> builder)
        {
            builder.ToTable("workflow_users");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.WorkflowId)
                .IsRequired()
                .HasColumnName("WorkflowId");

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.LevelAccess)
                .IsRequired()
                .HasColumnName("LevelAccess");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");

        }
    }
    */
}
