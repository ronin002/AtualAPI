using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{
    public class ContratoService : IContratoService
    {
        IContrato _contratoService;
        public ContratoService(IContrato contratoService)
        {
            _contratoService = contratoService;
        }
        public Contrato Add(Contrato contrato)
        {
            return _contratoService.Add(contrato);
        }

        public void Delete(Contrato contrato)
        {
            throw new NotImplementedException();
        }

        public Contrato Get(Guid id)
        {
            return _contratoService.Get(id);
        }

        public List<Contrato> GetAll(Guid Id)
        {
            return _contratoService.GetAll(Id);
        }

        public Contrato Update(Contrato contrato)
        {
            _contratoService.Update(contrato);
            return contrato;
        }
    }
}
