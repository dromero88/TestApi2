using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class ItemVenta
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VentaId { get; set; }

        public virtual Venta Venta { get; set; }

        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }

        public int Precio { get; set; }
    }
}
