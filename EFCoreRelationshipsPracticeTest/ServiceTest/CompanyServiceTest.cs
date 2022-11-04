using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsPracticeTest.ServiceTest
{
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_success_via_company_service()
        {
            //given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>()
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

            //when
            await companyService.AddCompany(companyDto);
            //then
            Assert.Equal(1,context.Companies.Count());
        }

        [Fact]
        public async Task Should_get_all_companies_success_via_company_service()
        {
            //given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>()
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
            await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto2);

            //when
            await companyService.GetAll();

            //then
            Assert.Equal(2, context.Companies.Count());
        }

        [Fact]
        public async Task Should_get_company_by_id_success_via_company_service()
        {
            //given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>()
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
            var id = await companyService.AddCompany(companyDto);

            //when
            var resultCompany = await companyService.GetById(id);
            //then
            Assert.Equal(companyDto.Name, resultCompany.Name);

        }

        [Fact]
        public async Task Should_delete_company_by_id_success_via_company_service()
        {
            //given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.EmployeeDtos = new List<EmployeeDto>()
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
            var id = await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto2);

            //when
            await companyService.DeleteCompany(id);
            var getCompaniesAfterDelete =await companyService.GetAll();

            //then
            Assert.Equal(1, context.Companies.Count());
            Assert.Equal(companyDto2.Name, getCompaniesAfterDelete[0].Name);
        }

        private CompanyDbContext GetCompanyDbContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopedService= scope.ServiceProvider;
            CompanyDbContext companyDbContext = scopedService.GetRequiredService<CompanyDbContext>();
            return companyDbContext;
        }
    }
}
