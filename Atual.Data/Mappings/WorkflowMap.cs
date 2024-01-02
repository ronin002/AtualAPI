using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using AtualAPI.Models.Workflow;

namespace AtualAPI.Data.Mappings
{
    /*
    public class WorkflowMap : IEntityTypeConfiguration<WorkFlow>
    {
        public void Configure(EntityTypeBuilder<WorkFlow> builder)
        {
            builder.ToTable("workflows");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");

            /*
            builder
               .HasMany(x => x.Activities)
               .WithMany(x => x.WorkFlows)
               .UsingEntity<Dictionary<string, object>>(
                   "WorkflowActivity",
                   activity => activity
                       .HasOne<Activity>()
                       .WithMany()
                       .HasForeignKey("ActivityW_Id")
                       .HasConstraintName("FK_WorkflowActivity_ActivityId")
                       .OnDelete(DeleteBehavior.NoAction),
                   workflow => workflow
                       .HasOne<WorkFlow>()
                       .WithMany()
                       .HasForeignKey("WorkflowA_Id")
                       .HasConstraintName("FK_ActivityWorkflow_WorkflowId")
                       .OnDelete(DeleteBehavior.NoAction));
            ///

            builder
                .HasIndex(x=>x.Name, "IX_Workflow_Name")
                .IsUnique();
                

        }
    }
    */
}
