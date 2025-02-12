using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe_Bliss_api.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepos _categoryRepos;

        public CategoryController(CategoryRepos categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }
        [HttpGet]
        public IActionResult GetAllCategories() {
            return Ok(_categoryRepos.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            return Ok(_categoryRepos.GetCategoryByID(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            return Ok(_categoryRepos.DeleteCategory(id));
        }
        [HttpPost]
        public IActionResult InsertCategory([FromBody] CategoryModel category)
        { 
            return Ok(_categoryRepos.InsertCategory(category));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id,[FromBody] CategoryModel category)
        {
            return Ok(_categoryRepos.UpdateCategory(id,category));
        }        
    }
}
