using DDDWithEF.Models;
using DDDWithEF.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DDDWithEF.Controllers
{
    [Route("api/dossiers")]
    [ApiController]
    public class DossierController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DossierController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{year}/{personSynergyId}")]
        public async Task<IActionResult> GetDossier(int year, int personSynergyId)
        {
            var dossier = await _context.Dossiers.Include(x=>x.Certificates).FirstOrDefaultAsync(x =>
                x.Id.PersonSynergyId == personSynergyId && x.Id.Year == year);
            return Ok(dossier);
        }

        [HttpPost]
        public async Task<IActionResult> NewDossier(NewDossierDto newDossier)
        {
            var dossier = new Dossier(newDossier.PersonSynergyId, newDossier.Year);
            await _context.Dossiers.AddAsync(dossier);
            await _context.SaveChangesAsync();
            return Ok(dossier);
        }

        [HttpPost("{year}/{personSynergyId}/issuances")]
        public async Task<IActionResult> AddNewIssuance(int year, int personSynergyId, NewIssuanceDto newIssuance)
        {
            var dossier = await _context.Dossiers.FirstOrDefaultAsync(x =>
                x.Id.PersonSynergyId == personSynergyId && x.Id.Year == year);
            dossier.RegisterIssuance(newIssuance.IssuanceUniqueIdentifier, newIssuance.Amount);
            await _context.SaveChangesAsync();
            return Ok(dossier);
        }

        [HttpPost("{year}/{personSynergyId}/certificates")]
        public async Task<IActionResult> GenerateCertificateForIssuance(int year, int personSynergyId, GenerateCertificateDto certificate)
        {
            var dossier = await _context.Dossiers.FirstOrDefaultAsync(x =>
                x.Id.PersonSynergyId == personSynergyId && x.Id.Year == year);
            dossier.GenerateCertificate(certificate.IssuanceUniqueIdentifier);
            await _context.SaveChangesAsync();
            return Ok(dossier);
        }
    }

    public class GenerateCertificateDto
    {
        public string IssuanceUniqueIdentifier { get; set; }
    }

    public class NewIssuanceDto
    {
        public string IssuanceUniqueIdentifier { get; set; }
        public decimal Amount { get; set; }
    }

    public class NewDossierDto
    {
        public int PersonSynergyId { get; set; }
        public int Year { get; set; }
    }
}