using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articulo.Api.Models;

public class VentasDetalle
{
    [Key]
    public int VentaDetalleId { get; set; }

    public int VentaId { get; set; }

    public int ArticuloId { get; set; }

    public decimal Cantidad { get; set; }
    public decimal Precio { get; set; }

}
