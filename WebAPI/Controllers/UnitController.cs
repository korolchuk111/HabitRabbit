using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_unitService.GetAllUnits());
        }
    }
}