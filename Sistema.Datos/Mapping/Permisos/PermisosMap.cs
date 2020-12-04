using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Permisos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Permisos
{
    public class PermisosMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("REH010013")
               .HasKey(u => u.id_permiso);
            builder.Property(u => u.id_empleado);
            builder.Property(u => u.fecha_registro);
            builder.Property(u => u.estado);
            builder.Property(u => u.motivo_permiso);

        }

    }
}