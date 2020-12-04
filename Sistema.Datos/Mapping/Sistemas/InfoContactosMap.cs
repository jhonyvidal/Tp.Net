using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Sistemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Sistemas
{
    public class InfoContactosMap : IEntityTypeConfiguration<InfoContactos>
    {
        public void Configure(EntityTypeBuilder<InfoContactos> builder)
        {
            builder.ToTable("Vw_Contactos")
               .HasKey(u => u.id_contactostp);
            builder.Property(u => u.id_empleado);
            builder.Property(u => u.extension);
            builder.Property(u => u.numero);
            builder.Property(u => u.correo);
            builder.Property(u => u.estado);
            builder.Property(u => u.nombre);
            builder.Property(u => u.cargo);
            builder.Property(u => u.regional);
            builder.Property(u => u.correo_empleado);
        }
    }
}


