﻿using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsPracticeTest.CompanyServiceTest
{
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory)
            : base(factory)
        {
        }

        [Fact]
        public async void Should_create_company_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19,
                },
            };
            companyDto.ProfileDto = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            CompanyService companyService = new CompanyService(context);
            // when
            await companyService.AddCompany(companyDto);
            // then
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async void Should_get_company_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19,
                },
            };
            companyDto.ProfileDto = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            CompanyService companyService = new CompanyService(context);
            // when
            var createdCompanyId = await companyService.AddCompany(companyDto);
            var returnCompany = await companyService.GetById(createdCompanyId);
            // then
            Assert.Equal("IBM", returnCompany.Name);
        }

        [Fact]
        public async void Should_get_all_companies_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                EmployeeDtos = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };

            CompanyDto companyDto2 = new CompanyDto
            {
                Name = "MS",
                EmployeeDtos = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Jerry",
                        Age = 18,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100020,
                    CertId = "101",
                },
            };

            CompanyService companyService = new CompanyService(context);
            // when
            await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto2);
            var returnCompanies = await companyService.GetAll();
            // then
            Assert.Equal(2, returnCompanies.Count());
            Assert.Equal("IBM", returnCompanies[0].Name);
        }

        [Fact]
        public async void Should_delete_company_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19,
                },
            };
            companyDto.ProfileDto = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            CompanyService companyService = new CompanyService(context);
            // when
            var createdCompanyId = await companyService.AddCompany(companyDto);
            await companyService.DeleteCompany(createdCompanyId);
            var returnCompanies = context.Companies.FirstOrDefault(company => company.Id == createdCompanyId);
            // then
            Assert.Equal(null, returnCompanies);
        }

        private CompanyDbContext GetCompanyDbContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopedService = scope.ServiceProvider;
            CompanyDbContext context = scopedService.GetRequiredService<CompanyDbContext>();
            return context;
        }
    }
}
