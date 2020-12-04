using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class RetiroMap : IEntityTypeConfiguration<Retiro>
    {
        public void Configure(EntityTypeBuilder<Retiro> builder)
        {
            builder.ToTable("REH010030")
             .HasKey(c => c.id_empleado);
          

        }
    }
}
