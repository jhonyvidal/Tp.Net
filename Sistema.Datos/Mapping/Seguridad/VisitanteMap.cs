using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Visitantes;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sistema.Datos.Mapping.Visitantes
{
    public class RegistroVisitanteMap : IEntityTypeConfiguration<RegistroVisitante>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RegistroVisitante> builder)
        {
            builder.ToTable("SEG010008")
               .HasKey(r => r.idRegVisitante);
        }
    }
}

