using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models.Workflow;

namespace AtualAPI.Data.Mappings
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("activities");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");

            builder.Property(x => x.Script)
                //.HasColumnType("bytea")
                .HasColumnType("blob")
                .IsRequired(false)
                .HasColumnName("Script");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");

            /*
            builder
               .HasMany(x => x.WorkFlows)
               .WithMany(x => x.Activities)
               .UsingEntity<Dictionary<string, object>>(
                   "ActivityWorkflow",
                   workflow => workflow
                       .HasOne<WorkFlow>()
                       .WithMany()
                       .HasForeignKey("Workflow_Id")
                       .HasConstraintName("FK_WorkflowActivity_ActivityId1")
                       .OnDelete(DeleteBehavior.NoAction),
                   activity => activity
                       .HasOne<Activity>()
                       .WithMany()
                       .HasForeignKey("Activity_Id")
                       .HasConstraintName("FK_ActivityWorkflow_WorkflowId1")
                       .OnDelete(DeleteBehavior.NoAction));
            */

            builder
                .HasIndex(x=>x.Title, "IX_Activity_Title")
                .IsUnique();
                

        }
    }
}
