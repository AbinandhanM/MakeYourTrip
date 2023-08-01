using Image.Interfaces;
using Image.Models;
using Image.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactCors")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryService;

        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> AddCategory([FromBody] Category category)
        {
            var addedCategory = await _categoryService.AddCategory(category);
            if (addedCategory != null)
            {
                return Created("Home", addedCategory);
            }
            return BadRequest("Unable to add category at this moment");
        }


        [HttpGet]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var deletedCategory = await _categoryService.DeleteCategory(id);
            if (deletedCategory != null)
            {
                return Ok(deletedCategory);
            }
            return NotFound();
        }

    }
}
