using Abstracciones.Agentes;
using Abstracciones.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Agentes
{
    public class AgenteConfiguracion
    {
        public void Configure(EntityTypeBuilder<Agente> b)
        {
            b.ToTable("Agentes");
            b.HasKey(a => a.ID);

            // Sin esto EF crea nvarchar(max) para todo: lento, sin índice posible
            // y sin protección. Los límites de aquí deben coincidir con las anotaciones de los DTOs.
            b.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            b.Property(a => a.Correo).IsRequired().HasMaxLength(150);
            b.Property(a => a.Telefono).IsRequired().HasMaxLength(20);
            b.Property(a => a.CapacidadMaxima).IsRequired();
            b.Property(a => a.Estado).IsRequired();
            b.Property(a => a.FechaIngreso).HasDefaultValueSql("SYSUTCDATETIME()");

            // Índice único: garantiza que no existan dos agentes con el mismo correo AUNQUE dos
            // peticiones lleguen al mismo tiempo. La validación en Flujo da el mensaje amable; el índice es la red de seguridad.
            b.HasIndex(a => a.Correo).IsUnique();
        }
    }
}
