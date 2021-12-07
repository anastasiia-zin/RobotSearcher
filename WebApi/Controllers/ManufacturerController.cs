using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize(Roles = "user,director")]
    [Route("manufacturer/")]
    public class ManfacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManfacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Manufacturer>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync()
        {
            var categories = await _manufacturerService.GetAllAsync();
            return Ok(categories);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Manufacturer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddAsync(Manufacturer manufacturer)
        {
            var category = await _manufacturerService.AddAsync(manufacturer);
            return Ok(category);
        }
    }
}