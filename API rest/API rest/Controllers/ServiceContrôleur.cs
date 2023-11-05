using InterfaceServiceService;
using Microsoft.AspNetCore.Mvc;
using ModelsService;
using ServiceService;


namespace API_rest.Contrôleurs
{

    [ApiController]
    [Route("api/services")]

    public class ServicesController : ControllerBase
    {


        private readonly IServiceService _ServiceService;

        public ServicesController(IServiceService serviceservice)
        {
            _ServiceService = serviceservice;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Service_Employe>>> GetAllServices()
        {
            return await _ServiceService.GetAllServices();
        }

        // Ajoutez d'autres actions pour d'autres opérations sur les salariés
    }


}