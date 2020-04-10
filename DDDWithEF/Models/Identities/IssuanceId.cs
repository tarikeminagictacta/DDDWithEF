using Tactical.DDD;

namespace DDDWithEF.Models.Identities
{
    public class IssuanceId : IEntityId
    {
        public int Year { get; }
        public string IssuanceUniqueIdentifier { get; }

        private IssuanceId()
        {
        }

        public IssuanceId(int year, string issuanceUniqueIdentifier)
        {
            Year = year;
            IssuanceUniqueIdentifier = issuanceUniqueIdentifier;
        }
    }
}