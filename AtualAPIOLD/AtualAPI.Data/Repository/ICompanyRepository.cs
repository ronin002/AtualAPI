using AtualAPI.Models;

namespace AtualAPI.Repository
{
    public interface ICompanyRepository
    {
        public bool CreateCompany(Company company);
        public Company GetCompanyById(Guid id);
        public Company GetCompany();
        
        public List<Company> GetCompanyByName(string name);
        public Company GetCompanyByOwner(int idOwner);
        public void Update(Company company);
        public void DeleteCompanyById(Company company);

    }
}
