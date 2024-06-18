using Articulo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Articulo.Api.DAL;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options) { }

	public DbSet<Articulos> Articulos { get; set; }

    public DbSet<Ventas> Ventas { get; set; }
}
