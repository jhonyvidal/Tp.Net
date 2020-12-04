using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Logistica
{
    public class TurnoMap : IEntityTypeConfiguration<Turno>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Turno> builder)
        {
            builder.ToTable("LOG010002")
               .HasKey(r => r.idTurno);
        }
    }
}
