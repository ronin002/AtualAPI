using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{
    public class FuncionarioRepo : IFuncionario
    {
        DataContext _context;
        public FuncionarioRepo(DataContext context)
        {
            _context = context;
        }
        public Funcionario Add(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        public void Delete(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }

        public Funcionario Get(Guid id)
        {
            return _context.Funcionarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Funcionario> GetAll(Guid companyId)
        {
            return _context.Funcionarios.Where(x => x.CompanyId == companyId).ToList();
        }

        public Funcionario Update(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
            return funcionario;
        }
    }
}
