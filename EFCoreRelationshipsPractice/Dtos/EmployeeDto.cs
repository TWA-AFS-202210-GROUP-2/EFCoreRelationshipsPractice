using EFCoreRelationshipsPractice.Repository;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }
        public EmployeeDto(EmployeeEntity employeeEntity)
        {
            Name = employeeEntity.Name;
            Age = employeeEntity.age;

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public EmployeeEntity ToEntity()
        {
            return new EmployeeEntity()
            {
                Name = Name,
                age = Age,
            };
        }
    }
}