using Atual.Data.InterfacesRepo;
using Atual.Services.Utils;
using AtualAPI.Dtos;
using AtualAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.ComponentModel.Design;

namespace Atual.Data.ImplRepositories
{
    public class CompanyService : ICompanyService
    {
        
        ICompanyRepo _companyRepo;
        public CompanyService(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public Company Add(CreateCompanyDto compDto, Guid Owner)
        {
            Company company = new Company();
            company.Id = Guid.NewGuid();
            company.OwnerId = Owner;
            company.Name = compDto.NameCompany;
            return _companyRepo.Add(company);
        }

        public void Delete(Company company)
        {
            throw new NotImplementedException();
        }

        public Company Get(Guid companyId)
        {
            return _companyRepo.Get(companyId);
        }

        public List<Company> GetAll(UserModel user)
        {
            //return _companyRepo.GetAll(user);
            return null;
        }

        public Company Update(Company company)
        {
            _companyRepo.Update(company);
            return company;
        }
    }
}
