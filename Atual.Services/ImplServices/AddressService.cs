using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Atual.Data.ImplRepositories
{
    public class AddressService : IAddressService
    {
        IAddress _address;
        public AddressService(IAddress address)
        {
            _address = address;
        }
        public Address Add(Address address)
        {
            return _address.Add(address);
        }

        public void Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public Address Get(Guid id)
        {
            return _address.Get(id);
        }

        public List<Address> GetAll(Guid Id)
        {
            return _address.GetAll(Id);
        }

        public Address Update(Address address)
        {
            _address.Update(address);
            return address;
        }
    }
}
