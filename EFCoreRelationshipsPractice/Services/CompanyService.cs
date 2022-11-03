using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companies = companyDbContext.Companies.Include(company => company.Profile).Include(company => company.Employee).ToList();

            return companies.Select(CompanyEntity => new CompanyDto(CompanyEntity)).ToList();

        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            // convert dto to entity
            CompanyEntity companyEntity = companyDto.ToEntity();

            // save entity to db
            await companyDbContext.Companies.AddAsync(companyEntity);
            await companyDbContext.SaveChangesAsync();

            // return company id
            return companyEntity.Id;
        }

        public async Task<CompanyDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCompany(int id)
        {
            var foundCompany = companyDbContext.Companies
                .Include(company => company.Employee)
                .Include(company => company.Profile)
                .FirstOrDefault(_ => _.Id == id);

            companyDbContext.Companies.Remove(foundCompany);
            await companyDbContext.SaveChangesAsync();

        }
    }
}