using AtualAPI.Data;
using AtualAPI.Models;

namespace AtualAPI.Repository.Impl
{
    public class CompanyRepositoryImpl : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepositoryImpl(DataContext context)
        {
            _context = context;
        }
        public bool CreateCompany(Company company)
        {
            var comp = _context.Companies.Where(x => x.Name.ToLower() == company.Name.ToLower() || x.OwnerId == company.OwnerId).FirstOrDefault();

            if (comp == null)
            {
                company.CreationDate = DateTime.UtcNow;
                _context.Companies.Add(company);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public Company GetCompanyById(Guid id)
        {
            var company = new Company();
            company = _context.Companies.FirstOrDefault(x => x.Id == id);

            return company;
        }

        public Company GetCompany()
        {
            var company = new Company();
            company = _context.Companies.FirstOrDefault();

            return company;
        }

        public List<Company> GetCompanyByName(string name)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyByOwner(int idOwner)
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompanyById(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
    }
}
