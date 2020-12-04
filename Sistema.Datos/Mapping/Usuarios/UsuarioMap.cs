using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios.Admin
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TEC010001")
               .HasKey(u => u.id_usuario);
            builder.Property(u => u.clave);
            builder.Property(u => u.id_empleado);
            builder.Property(u => u.id_zona);
            builder.Property(u => u.id_zona);
            builder.Property(u => u.id_perfil);
            builder.Property(u => u.estado);

        }
    }
}
