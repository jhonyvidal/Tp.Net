using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Logistica
{
    public class TareaMap : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable("LOG010001")
               .HasKey(r => r.idTarea);
        }
    }
}
