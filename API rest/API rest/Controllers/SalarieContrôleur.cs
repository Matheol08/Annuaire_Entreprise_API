using InterfaceSalarieService;
using Microsoft.AspNetCore.Mvc;
using ModelsSalarie;


namespace SalarieContrôleur
{
    [ApiController]
    [Route("api/salaries")]

        public class SalariesController : ControllerBase
        {


            private readonly ISalarieService _SalarieService;

            public SalariesController(ISalarieService salarieService)
            {
                _SalarieService = salarieService;
            }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Salaries>>> GetSalaries(int id)
        {
            var salarie = await _SalarieService.GetSalaries(id);

            if (salarie == null)
            {
                return NotFound(); 
            }

            return Ok(salarie);
        }

    }


}