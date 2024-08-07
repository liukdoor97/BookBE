using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Services;
using Book.Entities;
using Book.Models.PublisherModel;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    // Controller di Publisher che deriva dal ControllerBase
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        // Chiamata del Servizio IPublisherService
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        // Operazioni di Lettura

        [HttpGet] // Metodo GetAll che restituisce una lista di Case Editrici
        public async Task<IActionResult> GetAll()
        {
            List<Publisher> result = publisherService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{Id}")] // Metodo GetById che restituisce una Casa Editrice con uno specifico Id
        public async Task<IActionResult> GetById(int Id)
        {
            Publisher result = publisherService.GetById(Id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // Operazioni di scrittura

        [HttpPost] // Metodo Update che Modifica una Casa Editrice da un PublisherModel con uno specifico Id
        public async Task<IActionResult> Insert([FromBody] PublisherModel publisherModel)
        {
            var publisher = new Publisher
            {
                name = publisherModel.name,
                address = publisherModel.address,
                country = publisherModel.country
            };

            if (publisher == null)
            {
                return BadRequest();
            }
            publisherService.Insert(publisher);
            return Ok(publisher);
        }

        [HttpPut("{Id}")] // Metodo Update che Modifica una Casa Editrice da un PublisherModel con uno specifico Id

        public async Task<IActionResult> Update(int Id, [FromBody] PublisherModel publisherModel)
        {
            var publisher = publisherService.GetById(Id);
            if (publisher == null)
            {
                return BadRequest();
            }
            publisher.name = publisherModel.name;
            publisher.address = publisherModel.address;
            publisher.country = publisherModel.country;
            publisherService.Update(publisher);
            if (publisher == null)
            {
                return BadRequest();
            }
            return Ok(publisher);
        }
        [HttpDelete("{Id}")] // Metodo Delete che Elimina una Casa Editrice con uno specifico Id

        public async Task<IActionResult> Delete(int Id)
        {
            var publisher = publisherService.Delete(Id);
            if (publisher == null)
            {
                return BadRequest();
            }
            return Ok(publisher);
        }
    }
}