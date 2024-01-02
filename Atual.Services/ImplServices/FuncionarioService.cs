using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{
    public class FuncionarioService : IFuncionarioService
    {
        IFuncionario _funcionario;
        public FuncionarioService(IFuncionario funcionario)
        {
            _funcionario = funcionario;
        }
        public Funcionario Add(Funcionario funcionario)
        {
            return _funcionario.Add(funcionario);
        }

        public void Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Funcionario Get(Guid id)
        {
            return _funcionario.Get(id);
        }

        public List<Funcionario> GetAll(Guid Id)
        {
            return _funcionario.GetAll(Id);
        }

        public Funcionario Update(Funcionario funcionario)
        {
            _funcionario.Update(funcionario);
            return funcionario;
        }
    }
}
