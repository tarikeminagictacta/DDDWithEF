using System;
using System.Collections.Generic;
using System.Linq;
using DDDWithEF.Models.Entities;
using DDDWithEF.Models.Identities;
using Newtonsoft.Json;
using Tactical.DDD;

namespace DDDWithEF.Models
{
    public sealed class Dossier:AggregateRoot<DossierId>
    {
        public int PersistenceId { get; }
        public override DossierId Id { get; protected set; }

        /// <summary>
        /// List of entities that we want to save as json
        /// </summary>
        public ICollection<Issuance> Issuances { get; private set; }

        /// <summary>
        /// List of entities that we want to save to relational db
        /// </summary>
        public ICollection<Certificate> Certificates { get; private set; }


        private Dossier()
        {
            Issuances = new List<Issuance>();
            Certificates = new List<Certificate>();
        }

        public Dossier(int peronSynergyId, int year): this()
        {
            Id = new DossierId(peronSynergyId, year);
        }

        public void RegisterIssuance(string issuanceUniqueIdentifier, decimal amount)
        {
            if ( Issuances.FirstOrDefault(x => x.Id.IssuanceUniqueIdentifier == issuanceUniqueIdentifier) != null)
            {
                throw new Exception("Issuance already registered");
            }

            var issuanceId = new IssuanceId(Id.Year, issuanceUniqueIdentifier);
            var issuance = new Issuance(issuanceId, amount);
            Issuances.Add(issuance);
        }

        public void GenerateCertificate(string issuanceUniqueIdentifier)
        {
            var issuance = Issuances.FirstOrDefault(x => x.Id.IssuanceUniqueIdentifier == issuanceUniqueIdentifier);
            if ( issuance == null)
            {
                throw new Exception("No issuance found");
            }
            
            var certificateId = new CertificateId(Id.Year, issuanceUniqueIdentifier);
            var data = new {issuance.Amount, Id.Year, Id.PersonSynergyId, issuanceUniqueIdentifier};
            var certificate = new Certificate(certificateId, JsonConvert.SerializeObject(data));
            Certificates.Add(certificate);
        }
    }
}
