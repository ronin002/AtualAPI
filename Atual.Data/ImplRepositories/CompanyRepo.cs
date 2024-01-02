using Atual.Data.InterfacesRepo;
using AtualAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atual.Data.ImplRepositories
{
    public class CompanyRepo : ICompanyRepo
    {
        DataContext _context;
        public CompanyRepo(DataContext context)
        {
            _context = context;
        }
        public Company Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company;
        }

        public void Delete(Company company)
        {
            //_context.Companies.Remove(company);
            //_context.SaveChanges();
        }

        public Company Get(Guid id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public Company Update(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
            return company;
        }
    }
}
