using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thuc_tap_tuan2.Dtos;
using Thuc_tap_tuan2.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Thuc_tap_tuan2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhNghiepController : ControllerBase
    {
    
        // GET: api/<DoanhNghiepController>
        private readonly IDoanhNghiepService _service;
        public DoanhNghiepController(IDoanhNghiepService service)
        {
             _service = service;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateDoanhNghiepDto input)
        {
            
          _service.Create(input);
          return Ok();
          
        }
        [HttpGet]
        public IActionResult Getall()
        {
            var dn = _service.GetAll();
            return Ok(dn);
        }
    }
}
