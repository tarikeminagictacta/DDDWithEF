using Tactical.DDD;

namespace DDDWithEF.Models.Identities
{
    public class DossierId : IEntityId
    {
        public int PersonSynergyId { get; }
        public int Year { get; }

        private DossierId() {}

        public DossierId(int personSynergyId, int year)
        {
            PersonSynergyId = personSynergyId;
            Year = year;
        }
    }
}