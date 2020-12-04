using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Almacen
{
    public class CategoriaComprasMap : IEntityTypeConfiguration<CategoriaCompras>
    {
        public void Configure(EntityTypeBuilder<CategoriaCompras> builder)
        {
            builder.ToTable("CMP010005")
               .HasKey(c => c.idcategoria);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.descripcion)
                .HasMaxLength(256);
        }
    }
}
