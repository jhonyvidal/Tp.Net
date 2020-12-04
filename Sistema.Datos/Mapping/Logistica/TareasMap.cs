using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Logistica
{
    public class TareasMap : IEntityTypeConfiguration<Tareas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tareas> builder)
        {
            builder.ToTable("LOG010003")
               .HasKey(r => r.idTareas);
        }
    }
}
