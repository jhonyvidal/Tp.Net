using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Ventas
{
    public class VentaMap : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("CMP010009")
                .HasKey(v => v.idventa);
            builder.HasOne(v => v.categoria)
                .WithMany(p => p.ventas)
                .HasForeignKey(v => v.idcliente);
            builder.HasOne(i => i.usuario)
              .WithMany(p => p.ventas)
              .HasForeignKey(i => i.idusuario);
        }
    }
}
