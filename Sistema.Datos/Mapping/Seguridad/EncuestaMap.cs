using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Visitantes;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sistema.Datos.Mapping.Visitantes
{
    public class EncuestaMap : IEntityTypeConfiguration<Encuesta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Encuesta> builder)
        {
            builder.ToTable("ENC010001")
               .HasKey(r => r.id_encuesta);
        }
    }
}

