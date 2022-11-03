using EFCoreRelationshipsPractice.Model;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }
        public EmployeeDto(EmployeeEntity entity)
        {
            Name = entity.Name;
            Age = entity.Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public EmployeeEntity? ToEntity()
        {
            return new EmployeeEntity()
            {
                Age = this.Age,
                Name = this.Name
            };
        }
    }
}