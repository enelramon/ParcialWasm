using Articulo.Api.DAL;
using Articulo.Api.Models;
using Articulo.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articulo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController(
        Contexto context,
        VentasService ventasService) : ControllerBase
    {
        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            return await context.Ventas.ToListAsync();
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ventas>> GetVentas(int id)
        {
            var ventas = await context.Ventas.FindAsync(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return ventas;
        }

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVentas(Ventas ventaRecibida)
        {
            var venta = await ventasService.Guardar(ventaRecibida);
            return CreatedAtAction("GetVentas", new { id = venta.VentaId }, ventaRecibida);
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentas(int id, Ventas ventas)
        {
            if (id != ventas.VentaId)
            {
                return BadRequest();
            }

            context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
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

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            var ventas = await context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            context.Ventas.Remove(ventas);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentasExists(int id)
        {
            return context.Ventas.Any(e => e.VentaId == id);
        }
    }
}
