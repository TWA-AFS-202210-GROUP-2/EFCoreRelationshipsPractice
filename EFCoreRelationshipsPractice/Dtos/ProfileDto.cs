using EFCoreRelationshipsPractice.Model;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(ProfileEntity profileEntity)
        {
            RegisteredCapital = profileEntity.RegisteredCapital;
            CertId = profileEntity.CertId;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }

        internal ProfileEntity ToEntity()
        {
            return new ProfileEntity()
            {
                RegisteredCapital = this.RegisteredCapital,
                CertId = this.CertId,
            };
        }
    }
}