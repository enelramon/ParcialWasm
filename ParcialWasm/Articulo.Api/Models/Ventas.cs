using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articulo.Api.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }

    public string Cliente { get; set; }

    public decimal Monto { get; set; }

    [ForeignKey("VentaId")]
    public  ICollection<VentasDetalle> Detalle { get; set; } 
        = new List<VentasDetalle>();

}