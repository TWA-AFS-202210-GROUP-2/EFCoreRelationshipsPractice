using EFCoreRelationshipsPractice.models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
        public ProfileEntity ToEntity()
        {
            return new ProfileEntity()
            {
                RegisteredCapital = this.RegisteredCapital,
                CertId = this.CertId,
            };
        }
    }
}