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
            Assert.Equal(1,companyService.GetAll().Result.Count);
        }

    }
}
