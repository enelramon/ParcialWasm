using Articulo.Api.DAL;
using Articulo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Articulo.Api.Services;

public class VentasService(Contexto contexto)
{
    public async Task<Ventas> Guardar(Ventas venta)
    {
        contexto.Ventas.Add(venta);
        foreach (var detalle in venta.Detalle)
        {
            var articulo = await contexto.Articulos.FindAsync(detalle.ArticuloId);
            if (articulo is not null)
                articulo.Existencia -= detalle.Cantidad;
        }
        var cantidad= await contexto.SaveChangesAsync();
        return venta;
    }
}
