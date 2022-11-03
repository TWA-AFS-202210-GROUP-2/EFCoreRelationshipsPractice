using EFCoreRelationshipsPractice.Model;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        private EmployeeEntity employeeEntity;

        public EmployeeDto() { }

        public EmployeeDto(EmployeeEntity employeeEntity)
        {
            this.Age = employeeEntity.Age;
            this.Name = employeeEntity.Name;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public EmployeeEntity ToEntity()
        {
            return new EmployeeEntity
            {
                Name = this.Name,
                Age = this.Age,
            };
        }
    }
}