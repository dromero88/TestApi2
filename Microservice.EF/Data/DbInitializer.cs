using System;
using System.Linq;
using Domain.Entities;
namespace Microservice.EF.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EntitiesContext context)
        {
            context.Database.EnsureCreated();
            {
                var product = context.Productos.FirstOrDefault(b => b.Id == 1);
                if (product == null)
                {
                    context.Productos.Add(new Producto { Nombre = "Producto 1" });
                }

                var venta = context.Ventas.FirstOrDefault(b => b.Id == 1);
                if (venta == null)
                {
                    context.Ventas.Add(new Venta { Fecha = DateTime.Now, MontoTotal = 4578  });
                }

                context.SaveChanges();
            }
        }

    }
}
