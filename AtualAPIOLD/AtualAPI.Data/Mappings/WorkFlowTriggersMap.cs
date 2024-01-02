using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models.Workflow;
using AtualAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Data.Mappings
{
    public class WorkFlowTriggersMap : IEntityTypeConfiguration<WorkFlowTrigger>
    {
        public void Configure(EntityTypeBuilder<WorkFlowTrigger> builder)
        {
            builder.ToTable("workflow_triggers");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.WorkflowId)
                .IsRequired()
                .HasColumnName("WorkflowId");

            builder.Property(x => x.TriggerId)
                .IsRequired()
                .HasColumnName("TriggerId");


            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

    

        }
    }
}
