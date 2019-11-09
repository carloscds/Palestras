using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Dominio;
using RH.WebApi.Services;

namespace RH.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly Contexto _context;

        public FuncionarioController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Funcionario
        [HttpGet]
        public IEnumerable<Funcionario> GetFuncionario()
        {
            return _context.Funcionario.OrderBy(o => o.Nome);
        }

        // GET: api/Funcionario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionario = await _context.Funcionario.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        // PUT: api/Funcionario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario([FromRoute] int id, [FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionario.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Funcionario
        [HttpPost]
        public async Task<IActionResult> PostFuncionario([FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Codigo }, funcionario);
        }

        // DELETE: api/Funcionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();

            return Ok(funcionario);
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Codigo == id);
        }
    }
}