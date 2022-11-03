namespace EFCoreRelationshipsPractice.models
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileEntity Profile { get; internal set; }
    }
}
