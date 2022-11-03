using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreRelationshipsPracticeTest.ServiceTest
{
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory)
            : base(factory)
        {
        }

        private CompanyDbContext GetCompanyDbContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopedService = scope.ServiceProvider;
            CompanyDbContext context = scopedService.GetRequiredService<CompanyDbContext>();
            return context;
        }
        [Fact]
        public async Task Should_create_company_success_via_service()
        {

            //given
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100"
                },
            };
            var context = GetCompanyDbContext();
            //when
            CompanyService companyService = new CompanyService(context);
            companyService.AddCompany(companyDto);
            //then
            Assert.Equal(1,context.CompanyEntities.Count());
        }
        [Fact]
        public async Task Should_return_all_companies_when_getall()
        {

            //given
            CompanyDto companyDto1 = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100"
                },
            };
            CompanyDto companyDto2 = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100"
                },
            };
            var context = GetCompanyDbContext();
            //when
            CompanyService companyService = new CompanyService(context);
            companyService.AddCompany(companyDto1);
            companyService.AddCompany(companyDto2);
            //then
            Assert.Equal(2, companyService.GetAll().Result.Count);
        }
        [Fact]
        public async Task Should_get_company_by_id_success_via_service()
        {

            //given
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100"
                },
            };
            var context = GetCompanyDbContext();
            CompanyService companyService = new CompanyService(context);
            companyService.AddCompany(companyDto);
            //when
            var company = companyService.GetById(1);
            //then
            Assert.Equal(companyDto.Name,company.Result.Name);
        }
        [Fact]
        public async Task Should_delete_company_success_via_service()
        {

            //given
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                Profile = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100"
                },
            };
            var context = GetCompanyDbContext();
            CompanyService companyService = new CompanyService(context);
            companyService.AddCompany(companyDto);
            //when
            companyService.DeleteCompany(1);
            //then
            Assert.Equal(0, context.CompanyEntities.Count());
        }
    }
}
