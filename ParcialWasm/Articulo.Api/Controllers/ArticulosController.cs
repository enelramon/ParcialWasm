using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Articulo.Api.DAL;
using Articulo.Api.Models;

namespace Articulo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticulosController(Contexto _context) : ControllerBase
{
	// GET: api/Articulos
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos() {
		return await _context.Articulos.ToListAsync();
	}

	// GET: api/Articulos/5
	[HttpGet("{id}")]
	public async Task<ActionResult<Articulos>> GetArticulos(int id) {
		var articulos = await _context.Articulos.FindAsync(id);

		if (articulos == null) {
			return NotFound();
		}

		return articulos;
	}

	// POST: api/Articulos
	[HttpPost]
	public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos) {
		_context.Articulos.Add(articulos);
		await _context.SaveChangesAsync();

		return CreatedAtAction("GetArticulos", new { id = articulos.ArticuloId }, articulos);
	}

	// PUT: api/Articulos/5
	[HttpPut("{id}")]
	public async Task<IActionResult> PutArticulos(int id, Articulos articulos) {
		if (id != articulos.ArticuloId) {
			return BadRequest();
		}

		_context.Entry(articulos).State = EntityState.Modified;

		try {
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException) {
			if (!ArticulosExists(id)) {
				return NotFound();
			}
			else {
				throw;
			}
		}

		return NoContent();
	}

	// DELETE: api/Articulos/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteArticulos(int id) {
		var articulos = await _context.Articulos.FindAsync(id);
		if (articulos == null) {
			return NotFound();
		}

		_context.Articulos.Remove(articulos);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ArticulosExists(int id) {
		return _context.Articulos.Any(e => e.ArticuloId == id);
	}
}