using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Requests.Auth;
using Requests.Robot;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("category/")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
        
        [HttpPost]
        [Authorize(Roles = "user,director")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddAsync(Category newCategory)
        {
            var category = await _categoryService.AddAsync(newCategory);
            return Ok(category);
        }
    }
}