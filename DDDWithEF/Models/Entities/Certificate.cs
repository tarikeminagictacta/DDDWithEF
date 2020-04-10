using DDDWithEF.Models.Identities;
using Tactical.DDD;

namespace DDDWithEF.Models.Entities
{
    public sealed class Certificate: Entity<CertificateId>
    {
        public int PersistenceId { get; private set; }
        public override CertificateId Id { get; protected set; }
        public string Data { get; private set; }


        public int DossierPersistenceId { get; private set; }
        public Dossier Dossier { get; private set; }

        private Certificate()
        {
            
        }

        public Certificate(CertificateId id, string data)
        {
            Id = id;
            Data = data;
        }
    }
}
