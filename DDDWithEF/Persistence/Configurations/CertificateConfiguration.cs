using DDDWithEF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDWithEF.Persistence.Configurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder
                .HasKey(certificate => certificate.PersistenceId);

            builder
                .OwnsOne(certificate => certificate.Id, idBuilder =>
                {
                    idBuilder.Property(id => id.IssuanceUniqueIdentifier)
                        .HasColumnName("IssuanceUniqueIdentifier")
                        .IsRequired();
                    idBuilder.Property(id => id.Year)
                        .HasColumnName("Year")
                        .IsRequired();
                });

            builder
                .HasOne(certificate => certificate.Dossier)
                .WithMany(dossier => dossier.Certificates)
                .HasForeignKey(certificate => certificate.DossierPersistenceId);
        }
    }
}
