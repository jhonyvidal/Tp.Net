using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class NivelAcademicoMap : IEntityTypeConfiguration<NivelAcademico>
    {
        public void Configure(EntityTypeBuilder<NivelAcademico> builder)
        {
            builder.ToTable("REH010008")
             .HasKey(ca => ca.id_nivelacademico);
            //builder.Property(ca => ca.desc_cargo)
            //  .HasMaxLength(256); 

        }
    }
}
