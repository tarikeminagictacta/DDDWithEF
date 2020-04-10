using DDDWithEF.Models;
using DDDWithEF.Models.Entities;
using DDDWithEF.Persistence.Configurations.Comparers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDWithEF.Persistence.Configurations
{
    public class DossierConfiguration : IEntityTypeConfiguration<Dossier>
    {
        public void Configure(EntityTypeBuilder<Dossier> builder)
        {
            builder
                .HasKey(dossier => dossier.PersistenceId);

            builder
                .OwnsOne(dossier => dossier.Id, idBuilder =>
                {
                    idBuilder.Property(id => id.PersonSynergyId)
                        .HasColumnName("PersonSynergyId")
                        .IsRequired();
                    idBuilder.Property(id => id.Year)
                        .HasColumnName("Year")
                        .IsRequired();
                    idBuilder.HasIndex(id => new { id.PersonSynergyId, id.Year }).IsUnique();
                });

            builder
                .Property(dossier => dossier.Issuances)
                .HasColumnName("Issuances")
                .IsRequired()
                .HasJsonConversion()
                .Metadata.SetValueComparer(new CollectionValueComparer<Issuance>());
        }
    }
}
