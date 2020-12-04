using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Correspondencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Correspondencia
{
    public class RemitenteMap : IEntityTypeConfiguration<Remitente>
    {
        public void Configure(EntityTypeBuilder<Remitente> builder)
        {
            builder.ToTable("CRP010002")
                .HasKey(i => i.id_remitente);

        }
    }
}
