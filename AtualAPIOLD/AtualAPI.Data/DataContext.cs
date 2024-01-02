
using Microsoft.EntityFrameworkCore;
using AtualAPI.Models;
using System.Security.Cryptography;
using AtualAPI.Models.Workflow;
using AtualAPI.Data.Mappings;
using AtualAPI.Models.Dtos;

namespace AtualAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<WorkFlow> Workflows { get; set; }
        public DbSet<WorkFlowUsers> workflows_users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityUsers> activities_users { get; set; }
        public DbSet<FileScript> FileScripts { get; set; }
        public DbSet<ArrowDiagram> ArrowDiagrams { get; set; }
        public DbSet<Decision> Decisions { get; set; }
        //public DbSet<GroupRows> GroupRows { get; set; }
        
        public DbSet<Operation> Operations { get; set; }
        //public DbSet<Group> Groups { get; set; }
        public DbSet<ActivityWorkflow> activityWorkflows { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connString = "Server=localhost;Database=dbklango;User=userklango;Password=klangomlFodase1!";
            if (!options.IsConfigured)
            {
                options.UseMySql(connString, ServerVersion.AutoDetect(connString));
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ActivityMap());
            modelBuilder.ApplyConfiguration(new ActivityUsersMap());
            modelBuilder.ApplyConfiguration(new ActivityWorkflowMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new TriggerMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WorkflowMap());
            modelBuilder.ApplyConfiguration(new WorkFlowTriggersMap());
            modelBuilder.ApplyConfiguration(new WorkFlowUsersMap());
            
           
            //modelBuilder.ApplyConfiguration(new UserMap());
            //.UsingEntity<RoleUser>(
            //    ur => ur.HasOne(prop => prop.User).WithMany().HasForeignKey(prop => prop.userId),
            //    ur => ur.HasOne(prop => prop.Role).WithMany().HasForeignKey(prop => prop.roleId),
            //    ur =>
            //    {
            //        //ru.HasKey(prop => new { prop.userId, prop.roleId });
            //        ur.Property(prop => prop.CreationDate).HasDefaultValue("GETUTCDATE()");
            //    }
            //);


            //base.OnModelCreating(modelBuilder);
        }
    }
}
