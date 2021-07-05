using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservice.CRUD.Interface;
using PruebaMicroservice.CRUD.Models;

namespace prueba_microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaBipRetailsController : ControllerBase
    {
        private readonly IRepository<CargaBipRetail> _repository;

        public CargaBipRetailsController(IRepository<CargaBipRetail> repository)
        {
            _repository = repository;
        }

        // GET: api/CargaBipRetails
        [HttpGet("GetCargaBipRetails")]
        public async Task<ActionResult> GetCargaBipRetails()
        {
            var cargaBips = await _repository.GetAll();

            return Ok(cargaBips);
        }

        // GET: api/CargaBipRetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargaBipRetail>> GetCargaBipRetailById(int id)
        {
            var cargaBipRetail = await _repository.GetById(id);

            if (cargaBipRetail == null)
            {
                return NotFound();
            }

            return cargaBipRetail;
        }

        // POST: api/CargaBipRetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CargaBipRetail>> PostCargaBipRetail(CargaBipRetail cargaBipRetail)
        {
            try
            {
                var cargaBip = await _repository.Add(cargaBipRetail);

                return CreatedAtAction("GetCargaBipRetailById", new { id = cargaBip.Id }, cargaBipRetail);
            }
            catch (Exception e)
            {

                return NotFound(e);
            }

        }

        // DELETE: api/CargaBipRetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargaBipRetail(int id)
        {
            if (await _repository.Delete(id))
                return NoContent();
                            
            return NotFound();

        }

        // PUT: api/CargaBipRetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargaBipRetail(int id, CargaBipRetail cargaBipRetail)
        {
            if (id != cargaBipRetail.Id)
            {
                return BadRequest();
            }

           if( await _repository.Update(cargaBipRetail))
                return NoContent();


            return NotFound();
        }
    }
}
