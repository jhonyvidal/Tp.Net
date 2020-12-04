using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class ZonaMap : IEntityTypeConfiguration<Zona>
    {
        public void Configure(EntityTypeBuilder<Zona> builder)
        {
            builder.ToTable("ADM010001")
             .HasKey(ca => ca.id_zona);
           
        }
    }
}
