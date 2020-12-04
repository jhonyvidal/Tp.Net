using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Logistica
{
    public class ConsecutivoMap : IEntityTypeConfiguration<Consecutivo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Consecutivo> builder)
        {
            builder.ToTable("LOG010004")
               .HasKey(r => r.idConsecutivo);
        }
    }
}
