using AtualAPI.Data.Mappings;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Montadores> Montadores { get; set; }
        public DbSet<TimeMontadores> TimesMontadores { get; set; }
        public DbSet<Montagem> Montagems { get; set; }
        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<ReportIncidente> ReportIncidentes { get; set; }

        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connString = "Server=localhost;Database=atualdb;User=root;Password=mlFodase1!";
            
            if (!options.IsConfigured)
            {
                options.UseMySql(connString, ServerVersion.AutoDetect(connString));
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AmbienteMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new ContratoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new MontadoresMap());
            modelBuilder.ApplyConfiguration(new MontagemMap());
            modelBuilder.ApplyConfiguration(new ReportIncidentMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new TimeMontadoresMap());
            modelBuilder.ApplyConfiguration(new UserMap());


        }
        
    }
}
