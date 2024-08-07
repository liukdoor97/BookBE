using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Book.Services;
using Book.Entities;
using Book.Models.CategoryModel;

namespace Book.Controllers
{
    // Controller di Category che deriva dal ControllerBase
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        // Chiamata del Servizio ICategoryService
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // Operazioni di Lettura

        [HttpGet] // Metodo GetAll che restituisce una lista di Categorie
        public async Task<ActionResult<List<Categories>>> GetAll()
        {
            List<Categories> result = categoryService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{Id}")] // Metodo GetById che restituisce una Categoria con uno specifico Id
        public async Task<IActionResult> GetById(int Id)
        {
            Categories result = categoryService.GetById(Id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // Operazioni di scrittura

        [HttpPost] // Metodo Insert che inserisce una nuova Categoria da un CategoryModel
        public async Task<IActionResult> Insert([FromBody] CategoryModel categoryModel)
        {
            var category = new Categories
            {
                name = categoryModel.name
            };

            if (category == null)
            {
                return BadRequest();
            }
            categoryService.Insert(category);
            return Ok(category);
        }

        [HttpPut("{Id}")] // Metodo Update che Modifica una Categoria da un CategoryModel con uno specifico Id

        public async Task<IActionResult> Update(int Id, [FromBody] CategoryModel categoryModel)
        {
            var category = categoryService.GetById(Id);
            if (category == null)
            {
                return BadRequest();
            }
            category.name = categoryModel.name;
            categoryService.Update(category);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }
        
        [HttpDelete("{Id}")] // Metodo Delete che Elimina una Categoria con uno specifico Id

        public async Task<IActionResult> Delete(int Id)
        {
            var category = categoryService.Delete(Id);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }

    }
}