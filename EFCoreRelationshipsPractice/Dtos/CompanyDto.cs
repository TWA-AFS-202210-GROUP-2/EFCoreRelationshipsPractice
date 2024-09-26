using System.Collections.Generic;
using EFCoreRelationshipsPractice.Model;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            Profile = companyEntity.Profile != null ? new ProfileDto(companyEntity.Profile) : null;
            Employees =companyEntity.Employees?.Select(i=>new EmployeeDto(i)).ToList();

        }

        public string Name { get; set; }

        public ProfileDto? Profile { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity()
            {
                Name = this.Name,
                Profile = this.Profile?.ToEntity(),
                Employees = this.Employees?.Select(i=>i.ToEntity()).ToList(),
            };
          
        }
    }
}