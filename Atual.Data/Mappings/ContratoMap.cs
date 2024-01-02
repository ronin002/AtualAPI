using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AtualAPI.Models;

namespace AtualAPI.Data.Mappings
{
    public class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("contratos");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                .IsRequired()
                .HasColumnName("CompanyId");

            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("ClienteId");

            builder.Property(x => x.Description)
                .HasColumnName("Description");

            builder.Property(x => x.URL_Contrato)
               .HasColumnName("URL_Contrato");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");

            /*s
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
                .HasIndex(x=>x.Id, "IX_Contrato_Id")
                .IsUnique();
                

        }
    }
}
