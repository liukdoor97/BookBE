using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Book.Entities;
using Book.Models.AuthorModel;

namespace Book.Controllers
{
    // Controller di Author che deriva dal ControllerBase
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        // Chiamata del Servizio IAuthorService
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        // Operazioni di Lettura

        [HttpGet] // Metodo GetAll che restituisce una lista di Autori
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            List<Author> result = authorService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{Id}")] // Metodo GetById che restituisce un Autore con uno specifico Id
        public async Task<IActionResult> GetById(int Id)
        {
            Author result = authorService.GetById(Id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // Operazioni di scrittura

        [HttpPost] // Metodo Insert che inserisce un nuovo Autore da un AuthorModel
        public async Task<IActionResult> Insert([FromBody] AuthorModel authorModel)
        {
            var author = new Author
            {
               name = authorModel.name,
               lastName = authorModel.lastName,
               address = authorModel.address,
               country = authorModel.country
            };

            if (author == null)
            {
                return BadRequest();
            }
            authorService.Insert(author);
            return Ok(author);
        }

        [HttpPut("{Id}")] // Metodo Update che Modifica un Autore da un AuthorModel con uno specifico Id

        public async Task<IActionResult> Update(int Id, [FromBody]  AuthorModel authorModel)
        {
                var author = authorService.GetById(Id);
                if (author == null)
                {
                    return BadRequest();
                }
                author.name = authorModel.name;
                author.lastName = authorModel.lastName;
                author.address = authorModel.address;
                author.country = authorModel.country;
                authorService.Update(author);
                if (author == null)
                {
                    return BadRequest();
                }
                return Ok(author);
        }
        
        [HttpDelete("{Id}")] // Metodo Delete che Elimina un Autore con uno specifico Id

        public async Task<IActionResult> Delete(int Id)
        {
            var author = authorService.Delete(Id);
            if (author == null)
            {
                return BadRequest();
            }
            return Ok(author);
        }
    }
}