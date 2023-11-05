
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_rest.Contexts;
using ModelsSite;

namespace SiteContrôleur
{
    [ApiController]
    [Route("api/sites")]

    public class SiteContrôleur : ControllerBase
    {


        private readonly AnnuaireContext _Sitecontext;

        public SiteContrôleur(AnnuaireContext context)
        {
            _Sitecontext = context;
        }


        [HttpGet("/api/Sites")]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            //var sites = await _Sitecontext.Sites.ToListAsync();
            //return Ok(sites);
            return await _Sitecontext.Sites.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSitesById(int ID)
        {
              var site = await _Sitecontext.Sites.Where(c => c.ID.Equals(ID)).FirstOrDefaultAsync();
            if (site ==null) 
            {
                return NotFound();
            }
            return Ok(site);
        }

        [HttpPost]

        public async Task<ActionResult<Site>> CreateSite(Site site)
        {
            _Sitecontext.Sites.Add(site);
            await _Sitecontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSitesById), new { id = site.ID }, site);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteSite(int ID)
        {
            var site = await _Sitecontext.Sites.FindAsync(ID);   
            if (site == null)
            {
                return NotFound();
            }
            _Sitecontext.Sites.Remove(site);
            await _Sitecontext.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut]
        //il faut que je mette à jour les sites cest pas le code en dessous mais celui-ci peut aider

        //public async Task<ActionResult<Site>> CreateSite(Site site)
        //{
        //    _Sitecontext.Sites.Add(site);
        //    await _Sitecontext.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetSitesById), new { id = site.ID }, site);
        //}
        'POUSH LE DANS GIT COMME CA IL Y A DE LEVOLUTION DANS LE PROJET GIT COMME DEMAND2 DANS LE CAHIOER DES CHARGES.'
    }
}