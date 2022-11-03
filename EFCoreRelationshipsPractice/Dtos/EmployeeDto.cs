using EFCoreRelationshipsPractice.models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(EmployeeEntity employEntity)
        {
            Name = employEntity.Name;
            Age = employEntity.Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}