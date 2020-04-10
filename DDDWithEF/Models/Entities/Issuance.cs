using DDDWithEF.Models.Identities;
using Tactical.DDD;

namespace DDDWithEF.Models.Entities
{
    public sealed class Issuance: Entity<IssuanceId>
    {
        public override IssuanceId Id { get; protected set; }
        public decimal Amount { get; private set; }

        public Issuance(IssuanceId id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}