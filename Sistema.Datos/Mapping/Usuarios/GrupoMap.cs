using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("TEC010010")
               .HasKey(r => r.id_grupo);
        }
    }
}
