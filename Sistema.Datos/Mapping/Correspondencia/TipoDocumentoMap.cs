using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Correspondencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Correspondencia
{
    public class TipoDocumentoMap : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("CRP010003")
                .HasKey(i => i.id_tipodocumento);

        }
    }
}
