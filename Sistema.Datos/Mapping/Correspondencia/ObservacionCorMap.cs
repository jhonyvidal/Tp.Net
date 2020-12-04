using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Correspondencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Correspondencia
{
    public class ObservacionCorMap : IEntityTypeConfiguration<ObservacionCor>
    {
        public void Configure(EntityTypeBuilder<ObservacionCor> builder)
        {
            builder.ToTable("CRP010004")
                .HasKey(i => i.idobservacion);
            
        }
    }
}
