using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Logistica
{
    public class EntregaRemesaMap : IEntityTypeConfiguration<EntregaRemesa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EntregaRemesa> builder)
        {
            builder.ToTable("DIG010001")
               .HasKey(r => r.idEntregaRemesa);
        }
    }
}
