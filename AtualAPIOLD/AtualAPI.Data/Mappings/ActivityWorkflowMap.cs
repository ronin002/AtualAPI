using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Data.Mappings
{
    public class ActivityWorkflowMap : IEntityTypeConfiguration<ActivityWorkflow>
    {
        public void Configure(EntityTypeBuilder<ActivityWorkflow> builder)
        {
            builder.ToTable("activity_workflow");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.ActivityId)
                .IsRequired()
                .HasColumnName("activity_id");

            builder.Property(x => x.WorkflowId)
                .IsRequired()
                .HasColumnName("workflow_id");

            builder.Property(x => x.Enabled)
                .HasColumnName("enabled");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");               

        }
    }
}
