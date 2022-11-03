using EFCoreRelationshipsPractice.Model;
using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        private CompanyEntity companyEntity;

        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            Name= companyEntity.Name;
            ProfileDto = companyEntity.Profile != null ? new ProfileDto(companyEntity.Profile) : null;
            EmployeeDtos = companyEntity.Employees?.Select(employeeEntity => new EmployeeDto(employeeEntity)).ToList();
        }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity
            {
                Name = this.Name,
                Profile = this.ProfileDto?.ToEntity(),
                Employees = this.EmployeeDtos?.Select(EmployeeDto => EmployeeDto.ToEntity()).ToList(),
            };
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? EmployeeDtos { get; set; }
    }
}