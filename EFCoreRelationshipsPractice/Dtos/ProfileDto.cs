using EFCoreRelationshipsPractice.Repository;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(ProfileEntity profileEntity)
        {
            RegisteredCapital= profileEntity.RegisteredCapital;
            CertId = profileEntity.CertlId;
        }

        public int RegisteredCapital { get; set; }

        public string CertId { get; set; }

        public ProfileEntity ToEntity()
        {
            return new ProfileEntity()
            {
                RegisteredCapital = this.RegisteredCapital,
                CertlId = this.CertId
            };
        }
    }
}