using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Observacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Observacion
{
    public class ObservacionCallMap : IEntityTypeConfiguration<ObservacionCall>
    {
        public void Configure(EntityTypeBuilder<ObservacionCall> builder)
        {
            builder.ToTable("CALL010005")
                 .HasKey(d => d.idobservacion);
        }
    }
}
