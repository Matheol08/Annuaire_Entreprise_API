using API_rest.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsService;

    namespace API_rest.Contrôleurs.Service
    {
        [ApiController]
        [Route("api/services")]

            public class ServiceEmployeController : ControllerBase
            {
                private readonly AnnuaireContext _contextService_Employes;

                public ServiceEmployeController(AnnuaireContext context)
                {
                    _contextService_Employes = context;
                }

                [HttpGet]
                public async Task<ActionResult<IEnumerable<Service_Employe>>> GetServiceEmployes()
                {
                    return await _contextService_Employes.Service_Employe.ToListAsync();
                }

                [HttpGet("{id}")]
                public async Task<ActionResult<Service_Employe>> GetServiceEmployeById(int ID)
                {
                    var serviceEmploye = await _contextService_Employes.Service_Employe.Where(c => c.ID.Equals(ID)).FirstOrDefaultAsync();
                    if (serviceEmploye == null)
                    {
                        return NotFound();
                    }
                    return Ok(serviceEmploye);
                }

                [HttpPost]
                public async Task<ActionResult<Service_Employe>> CreateServiceEmploye(Service_Employe serviceEmploye)
                {
                    _contextService_Employes.Service_Employe.Add(serviceEmploye);
                    await _contextService_Employes.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetServiceEmployeById), new { id = serviceEmploye.ID }, serviceEmploye);
                }

                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteServiceEmploye(int ID)
                {
                    var serviceEmploye = await _contextService_Employes.Service_Employe.FindAsync(ID);
                    if (serviceEmploye == null)
                    {
                        return NotFound();
                    }
                    _contextService_Employes.Service_Employe.Remove(serviceEmploye);
                    await _contextService_Employes.SaveChangesAsync();
                    return NoContent();
                }

                [HttpPut("{id}")]
                public async Task<IActionResult> UpdateServiceEmploye(int ID, Service_Employe serviceEmploye)
                {
                    if (!ID.Equals(serviceEmploye.ID))
                    {
                        return BadRequest("ID's are different");
                    }
                    var serviceEmployeToUpdate = await _contextService_Employes.Service_Employe.FindAsync(ID);
                    if (serviceEmployeToUpdate == null)
                    {
                        return NotFound($"Service Employe with Id ={ID} not found");
                    }
                    serviceEmployeToUpdate.Nom_Service = serviceEmploye.Nom_Service;
                    await _contextService_Employes.SaveChangesAsync();
                    return NoContent();
                }
            }
        }
