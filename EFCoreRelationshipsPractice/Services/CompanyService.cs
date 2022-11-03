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
            var companies = companyDbContext.CompanyEntities.Include(entity => entity.Profile).ToList();
            return companies.Select(e => new CompanyDto(e)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            //1 convert dto to entity
            //2 save to db context
            var companyEntity = companyDto.ToEntity();
            companyDbContext.CompanyEntities.AddAsync(companyEntity);
            companyDbContext.SaveChanges();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}