using API_rest.Contexts;
using Microsoft.AspNetCore.Mvc;
using ModelsSalarie;
using Microsoft.EntityFrameworkCore;

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
            return await _SalarieContext.Salaries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salaries>> GetSalarieById(int ID)
        {
            var salarie = await _SalarieContext.Salaries.Where(c => c.ID.Equals(ID)).FirstOrDefaultAsync();
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
            return CreatedAtAction(nameof(GetSalarieById), new { id = salarie.ID }, salarie);
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
            if (!ID.Equals(salarie.ID))
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
            salarieToUpdate.IDservice = salarie.IDservice;
            salarieToUpdate.IDsite = salarie.IDsite;
            await _SalarieContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
