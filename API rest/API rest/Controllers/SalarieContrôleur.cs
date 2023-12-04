using API_rest.Contexts;
using Microsoft.AspNetCore.Mvc;
using ModelsSalarie;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Azure;

namespace SalarieContrôleur
{
    [ApiController]
    [Route("api/salaries")]

    public class SalariesController : ControllerBase
    {
        private readonly AnnuaireContext _SalarieContext;

        public SalariesController(AnnuaireContext context)
        {
            _SalarieContext = context;
        }

        [HttpGet]
            public async Task<ActionResult<IEnumerable<Salaries>>> GetSalaries()
        {
            var salariesWithSitesAndService = await _SalarieContext.Salaries
                .Include(s => s.Sites)
                .Include(s => s.Service_Employe)
                .ToListAsync();

            return Ok(salariesWithSitesAndService);
        }


        [HttpGet("rechercheByNameORFirstName")]
        public async Task<ActionResult<IEnumerable<Salaries>>> GetSalariesBySearchTerm(string searchTerm)
        {
            IQueryable<Salaries> query = _SalarieContext.Salaries;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(s => EF.Functions.Like(s.Nom, searchTerm + "%") || EF.Functions.Like(s.Prenom, searchTerm + "%"));
            }

            var result = await query.Include(s => s.Sites).Include(s => s.Service_Employe).ToListAsync();

            return Ok(result);
        }


        [HttpGet("rechercheSite")]
        public async Task<ActionResult<IEnumerable<Salaries>>> GetSalariesBySite(string ville)
        {
            IQueryable<Salaries> query = _SalarieContext.Salaries;

            
            if (!string.IsNullOrEmpty(ville))
            {
                query = query.Where(s => s.Sites.Ville == ville);
            }

            

               var result = await query.Include(s => s.Sites).Include(s => s.Service_Employe).ToListAsync();

            return Ok(result);
        }
        [HttpGet("rechercheSiteEtService")]
        public async Task<ActionResult<IEnumerable<Salaries>>> GetSalariesBySiteAndService(string ville, string nomService)
        {
            IQueryable<Salaries> query = _SalarieContext.Salaries;

            if (!string.IsNullOrEmpty(ville))
            {
                query = query.Where(s => s.Sites.Ville == ville);
            }

            if (!string.IsNullOrEmpty(nomService))
            {
                query = query.Where(s => s.Service_Employe.Nom_Service == nomService);
            }

            var result = await query.Include(s => s.Sites).Include(s => s.Service_Employe).ToListAsync();

            return Ok(result);
        }



        [HttpGet("rechercheService")]
        public async Task<ActionResult<IEnumerable<Salaries>>> GetSalariesByService(string Nom_Service)
        {
            IQueryable<Salaries> query = _SalarieContext.Salaries;


            if (!string.IsNullOrEmpty(Nom_Service))
            {
                query = query.Where(s => s.Service_Employe.Nom_Service == Nom_Service);
            }



            var result = await query.Include(s => s.Sites).Include(s => s.Service_Employe).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salaries>> GetSalarieById(int ID)
        {
            var salarie = await _SalarieContext.Salaries.Where(c => c.IDSalaries.Equals(ID)).FirstOrDefaultAsync();
            if (salarie == null)
            {
                return NotFound();
            }
            return Ok(salarie);
        }

        [HttpPost]
        public async Task<ActionResult<Salaries>> CreateSalarie(Salaries salarie)
        {
            _SalarieContext.Salaries.Add(salarie);
            await _SalarieContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSalarieById), new { id = salarie.IDSalaries }, salarie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalarie(int ID)
        {
            var salarie = await _SalarieContext.Salaries.FindAsync(ID);
            if (salarie == null)
            {
                return NotFound();
            }
            _SalarieContext.Salaries.Remove(salarie);
            await _SalarieContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalarie(int ID, Salaries salarie)
        {
            if (!ID.Equals(salarie.IDSalaries))
            {
                return BadRequest("ID's are different");
            }
            var salarieToUpdate = await _SalarieContext.Salaries.FindAsync(ID);
            if (salarieToUpdate == null)
            {
                return NotFound($"Salarie with Id ={ID} not found");
            }
            salarieToUpdate.Nom = salarie.Nom;
            salarieToUpdate.Prenom = salarie.Prenom;
            salarieToUpdate.Telephone_fixe = salarie.Telephone_fixe;
            salarieToUpdate.Telephone_portable = salarie.Telephone_portable;
            salarieToUpdate.Email = salarie.Email;
            salarieToUpdate.IDService = salarie.IDService;
            salarieToUpdate.IDSite = salarie.IDSite;
            await _SalarieContext.SaveChangesAsync();
            return NoContent();
        }
       
            
        
    }
}
