using EFCoreRelationshipsPractice.Model;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {

        }
        public ProfileDto(ProfileEntity? companyEntityProfile)
        {
            RegisteredCapital = companyEntityProfile.RegisteredCapital;
            CertId = companyEntityProfile.CertID;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }

        public ProfileEntity? ToEntity()
        {
            return new ProfileEntity()
            {
                RegisteredCapital = this.RegisteredCapital,
                CertID = this.CertId
            };
        }
    }
}