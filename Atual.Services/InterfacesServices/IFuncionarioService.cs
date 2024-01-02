using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.InterfacesRepo
{
    public interface IFuncionarioService
    {
        
        List<Funcionario> GetAll(Guid CompanyId);
        Funcionario Get(Guid id);
        Funcionario Add(Funcionario funcionario);
        Funcionario Update(Funcionario funcionario);
        void Delete(Funcionario funcionario);
        

    }
}
