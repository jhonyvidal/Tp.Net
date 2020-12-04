using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class ContactosMap : IEntityTypeConfiguration<Contactos>
    {
        public void Configure(EntityTypeBuilder<Contactos> builder)
        {
           builder.ToTable("REH010035")
             .HasKey(contacto => contacto.id_contacto);

        }
    }
}
