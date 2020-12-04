using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Correspondencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Correspondencia
{
    public class CorrespondenciaMap : IEntityTypeConfiguration<correspondencia>
    {
        public void Configure(EntityTypeBuilder<correspondencia> builder)
        {
            builder.ToTable("CRP010001")
                .HasKey(i => i.id_correspondencia);

            //builder.HasOne(i => i.correo)
            //.WithMany(p => p.correspondencia)
            //.HasForeignKey(i => i.id_usuario);

        }
    }
}
