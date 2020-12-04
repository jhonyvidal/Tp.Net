using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class DependenciaMap : IEntityTypeConfiguration<Dependencia>
    {
        public void Configure(EntityTypeBuilder<Dependencia> builder)
        {
            builder.ToTable("REH010002")
             .HasKey(ca => ca.id_dependencia);
            //builder.Property(ca => ca.desc_cargo)
            //  .HasMaxLength(256); 

        }
    }
}
