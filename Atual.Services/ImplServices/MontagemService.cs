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
    public class MontagemService : IMontagemService
    {
        IMontagem _Montagem;
        public MontagemService(IMontagem montagem)
        {
            _Montagem = montagem;
        }
        public Montagem Add(Montagem montagem)
        {
            return _Montagem.Add(montagem);
        }

        public void Delete(Montagem montagem)
        {
            throw new NotImplementedException();
        }

        public Montagem Get(Guid id)
        {
            return _Montagem.Get(id);
        }

        public List<Montagem> GetAll(Guid Id)
        {
            return _Montagem.GetAll(Id);
        }

        public Montagem Update(Montagem montagem)
        {
            _Montagem.Update(montagem);
            return montagem;
        }
    }
}
