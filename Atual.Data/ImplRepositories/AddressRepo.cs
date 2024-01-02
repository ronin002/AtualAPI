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
    public class AddressRepo : IAddress
    {
        DataContext _context;
        public AddressRepo(DataContext context)
        {
            _context = context;
        }
        public Address Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public Address Get(Guid id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public List<Address> GetAll(Guid companyId)
        {
            return _context.Addresses.Where(x => x.CompanyId == companyId).ToList();
        }

        public Address Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
            return address;
        }
    }
}
