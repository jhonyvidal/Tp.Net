using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class EstadoCivilMap : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.ToTable("REH010007")
             .HasKey(ca => ca.id_estadocivil);
            //builder.Property(ca => ca.desc_cargo)
            //  .HasMaxLength(256); 

        }
    }
}
