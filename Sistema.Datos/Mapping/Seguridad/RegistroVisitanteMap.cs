using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Visitantes;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sistema.Datos.Mapping.Visitantes
{
    public class VisitanteMap : IEntityTypeConfiguration<Visitante>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Visitante> builder)
        {
            builder.ToTable("SEG010007")
               .HasKey(r => r.id_visitante);
        }
    }
}

