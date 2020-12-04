using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("REH010001")
             .HasKey(c => c.id_empleado);
            builder.Property(c => c.nombre_empleado)
             .HasMaxLength(256);

            builder.Property(c => c.id_estado)
             .HasMaxLength(4);
            builder.Property(c => c.id_cargo);

            builder.HasOne(i => i.estado)
             .WithMany(p => p.categoria)
             .HasForeignKey(i => i.id_estado);

            builder.HasOne(i => i.estadocivil)
             .WithMany(p => p.categoria)
             .HasForeignKey(i => i.id_estado_civil);

        }
    }
}
