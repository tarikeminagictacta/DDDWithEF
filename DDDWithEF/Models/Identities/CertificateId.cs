using Tactical.DDD;

namespace DDDWithEF.Models.Identities
{
    public class CertificateId : IEntityId
    {
        public int Year { get; }
        public string IssuanceUniqueIdentifier { get; }

        public CertificateId(int year, string issuanceUniqueIdentifier)
        {
            Year = year;
            IssuanceUniqueIdentifier = issuanceUniqueIdentifier;
        }
    }
}