using API_rest.Contexts;
using API_rest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Salarie;

public class AnnuaireContrôleur : ControllerBase
{
    [ApiController]
    [Route("api/salaries")]
    public class SalariesController : ControllerBase
    {
        private readonly SalarieService _salarieService;

        public SalariesController(SalarieService salarieService)
        {
            _salarieService = salarieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Salarie>> GetSalaries()
        {
            var salaries = _salarieService.GetSalaries();
            return Ok(salaries);
        }

        // Ajoutez d'autres actions pour d'autres opérations sur les salariés
    }


}